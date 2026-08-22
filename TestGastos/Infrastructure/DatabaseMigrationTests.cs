using Gastos.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestGastos.Infrastructure;

public sealed class DatabaseMigrationTests
{
    [Test]
    public async Task Inicializar_BancoNovo_DeveAplicarTodasAsMigracoes()
    {
        var bancoTemporario = Path.Combine(Path.GetTempPath(), $"gastos-migracao-{Guid.NewGuid():N}.db");

        var options = new DbContextOptionsBuilder<GastosDbContext>()
            .UseSqlite($"Data Source={bancoTemporario};Foreign Keys=True")
            .Options;

        try
        {
            var factory = new FactoryFake(options);
            var initializer = new DatabaseInitializer(factory);

            await initializer.InitializeAsync(CancellationToken.None);
            await initializer.InitializeAsync(CancellationToken.None);

            await using var context = new GastosDbContext(options);
            var pendentes = await context.Database.GetPendingMigrationsAsync();

            Assert.That(pendentes, Is.Empty);
            Assert.That(await context.Usuarios.CountAsync(), Is.EqualTo(0));
            Assert.That(await context.Competencias.CountAsync(), Is.EqualTo(0));
        }
        finally
        {
            SqliteConnection.ClearAllPools();

            if (File.Exists(bancoTemporario))
            {
                File.Delete(bancoTemporario);
            }
        }
    }

    private sealed class FactoryFake(DbContextOptions<GastosDbContext> options) : IDbContextFactory<GastosDbContext>
    {
        public GastosDbContext CreateDbContext() => new(options);

        public Task<GastosDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(CreateDbContext());
    }
}
