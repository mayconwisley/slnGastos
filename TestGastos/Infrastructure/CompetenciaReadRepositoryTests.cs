using Gastos.Domain.Clientes;
using Gastos.Domain.Competencias;
using Gastos.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestGastos.Infrastructure;

public sealed class CompetenciaReadRepositoryTests
{
    [Test]
    public async Task ListarAtivasAsync_ComCompetenciasAtivas_DeveRetornarClienteEMesReferencia()
    {
        var caminho = Path.Combine(Path.GetTempPath(), $"gastos-competencias-{Guid.NewGuid():N}.db");
        var options = new DbContextOptionsBuilder<GastosDbContext>().UseSqlite($"Data Source={caminho}").Options;

        try
        {
            await using (var context = new GastosDbContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                var cliente = Cliente.Criar("Ana Souza", "ana", true, DateTime.UtcNow).Value!;
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();

                var ativa = Competencia.Criar(new DateOnly(2026, 8, 1), cliente.Id, true).Value!;
                var inativa = Competencia.Criar(new DateOnly(2026, 7, 1), cliente.Id, false).Value!;
                await context.Competencias.AddRangeAsync(ativa, inativa);
                await context.SaveChangesAsync();
            }

            var competencias = await new CompetenciaReadRepository(new FactoryFake(options))
                .ListarAtivasAsync(CancellationToken.None);

            Assert.That(competencias, Has.Count.EqualTo(1));
            Assert.That(competencias[0].ClienteNome, Is.EqualTo("Ana Souza"));
            Assert.That(competencias[0].MesReferencia, Is.EqualTo(new DateOnly(2026, 8, 1)));
        }
        finally
        {
            SqliteConnection.ClearAllPools();

            if (File.Exists(caminho))
            {
                File.Delete(caminho);
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
