using Gastos.Application.Abstractions;
using Gastos.Application.Devedores;
using Gastos.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestGastos.Infrastructure;

public sealed class DevedorPersistenceTests
{
    [Test]
    public async Task GerarParcelasAsync_ComSqlite_DevePersistirParcelasUmaUnicaVez()
    {
        var caminho = Path.Combine(Path.GetTempPath(), $"gastos-devedor-{Guid.NewGuid():N}.db");
        var options = new DbContextOptionsBuilder<GastosDbContext>().UseSqlite($"Data Source={caminho}").Options;

        try
        {
            await using (var context = new GastosDbContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            var factory = new FactoryFake(options);
            var repository = new DevedorRepository(factory);
            var cadastrar = new CadastrarDevedorHandler(repository, new ClockFake());
            var gerar = new GerarParcelasDevedorHandler(repository);

            var cadastro = await cadastrar.HandleAsync(
                new CadastrarDevedorCommand("João", "Acordo", 150m, 3, new DateOnly(2026, 8, 1), true, "maycon", 1),
                CancellationToken.None);
            var geracao = await gerar.HandleAsync(new GerarParcelasDevedorCommand(cadastro.Value), CancellationToken.None);
            var segundaGeracao = await gerar.HandleAsync(new GerarParcelasDevedorCommand(cadastro.Value), CancellationToken.None);

            await using var verificacao = new GastosDbContext(options);
            Assert.That(cadastro.IsSuccess, Is.True);
            Assert.That(geracao.IsSuccess, Is.True);
            Assert.That(segundaGeracao.IsSuccess, Is.False);
            Assert.That(await verificacao.ParcelasDevedores.CountAsync(), Is.EqualTo(3));
        }
        finally
        {
            SqliteConnection.ClearAllPools();
            if (File.Exists(caminho)) File.Delete(caminho);
        }
    }

    private sealed class ClockFake : IClock
    {
        public DateTime UtcNow => new(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc);
    }

    private sealed class FactoryFake(DbContextOptions<GastosDbContext> options) : IDbContextFactory<GastosDbContext>
    {
        public GastosDbContext CreateDbContext() => new(options);

        public Task<GastosDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(CreateDbContext());
    }
}
