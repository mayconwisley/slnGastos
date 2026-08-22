using Gastos.Application.Clientes;
using Gastos.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestGastos.Infrastructure;

public sealed class ClientePersistenceTests
{
    [Test]
    public async Task CadastrarEListar_ComBancoLocal_DevePersistirCliente()
    {
        string databasePath = Path.Combine(Path.GetTempPath(), $"gastos-{Guid.NewGuid():N}.db");
        var options = new DbContextOptionsBuilder<GastosDbContext>()
            .UseSqlite($"Data Source={databasePath};Foreign Keys=True")
            .Options;

        try
        {
            await using (var context = new GastosDbContext(options))
            {
                await context.Database.ExecuteSqlRawAsync(
                    "CREATE TABLE Cliente (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nome TEXT NOT NULL, Login TEXT NOT NULL, Data TEXT NOT NULL);");
                var factory = new TestDbContextFactory(options);
                var initializer = new DatabaseInitializer(factory);
                await initializer.InitializeAsync(CancellationToken.None);

                var repository = new ClienteRepository(factory);
                var handler = new CadastrarClienteHandler(repository, new FixedClock());
                var listarHandler = new ListarClientesHandler(new ClienteReadRepository(factory));

                var cadastro = await handler.HandleAsync(
                    new CadastrarClienteCommand("Ana Souza", "ana", true),
                    CancellationToken.None);
                var clientes = await listarHandler.HandleAsync(new ListarClientesQuery(), CancellationToken.None);

                Assert.That(cadastro.IsSuccess, Is.True);
                Assert.That(cadastro.Value, Is.GreaterThan(0));
                Assert.That(clientes, Has.Count.EqualTo(1));
                Assert.That(clientes[0].Nome, Is.EqualTo("Ana Souza"));
            }
        }
        finally
        {
            SqliteConnection.ClearAllPools();

            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }
        }
    }

    private sealed class FixedClock : Gastos.Application.Abstractions.IClock
    {
        public DateTime UtcNow => new(2026, 8, 21, 12, 0, 0, DateTimeKind.Utc);
    }

    private sealed class TestDbContextFactory(DbContextOptions<GastosDbContext> options) : IDbContextFactory<GastosDbContext>
    {
        public GastosDbContext CreateDbContext() => new(options);

        public Task<GastosDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(CreateDbContext());
    }
}
