using Gastos.Application.Painel;
using Gastos.Domain.Clientes;
using Gastos.Domain.Competencias;
using Gastos.Domain.DespesasFixas;
using Gastos.Domain.Movimentacoes;
using Gastos.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestGastos.Infrastructure;

public sealed class ResumoPainelReadRepositoryTests
{
    [Test]
    public async Task ObterAsync_ComDadosDaCompetencia_DeveCalcularResumoFinanceiro()
    {
        var caminho = Path.Combine(Path.GetTempPath(), $"gastos-painel-{Guid.NewGuid():N}.db");
        var options = new DbContextOptionsBuilder<GastosDbContext>().UseSqlite($"Data Source={caminho}").Options;

        try
        {
            await using (var context = new GastosDbContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                var cliente = Cliente.Criar("Cliente teste", "maycon", true, DateTime.UtcNow).Value!;
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();

                var competencia = Competencia.Criar(new DateOnly(2026, 8, 1), cliente.Id, true).Value!;
                var despesa = DespesaFixa.Criar(new DateOnly(2026, 1, 1), "Internet", 50m, null, "maycon", cliente.Id, DateTime.UtcNow).Value!;
                await context.Competencias.AddAsync(competencia);
                await context.DespesasFixas.AddAsync(despesa);
                await context.SaveChangesAsync();
                var recebimento = Movimentacao.Criar(new DateOnly(2026, 8, 2), "Salário", 500m, TipoLancamento.Entrada, MeioMonetario.Dinheiro, SituacaoFinanceira.Recebido, OrigemMovimentacao.Manual, "maycon", cliente.Id, competencia.Id, DateTime.UtcNow).Value!;
                await context.Movimentacoes.AddAsync(recebimento);
                await context.SaveChangesAsync();
            }

            var resumo = await new ResumoPainelReadRepository(new FactoryFake(options))
                .ObterAsync(1, new DateOnly(2026, 8, 1), CancellationToken.None);

            Assert.That(resumo, Is.Not.Null);
            Assert.That(resumo!.DespesasFixas, Is.EqualTo(50m));
            Assert.That(resumo.Saldo, Is.EqualTo(450m));
        }
        finally
        {
            SqliteConnection.ClearAllPools();
            if (File.Exists(caminho)) File.Delete(caminho);
        }
    }

    private sealed class FactoryFake(DbContextOptions<GastosDbContext> options) : IDbContextFactory<GastosDbContext>
    {
        public GastosDbContext CreateDbContext() => new(options);
        public Task<GastosDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) => Task.FromResult(CreateDbContext());
    }
}
