using Gastos.Application.Abstractions;
using Gastos.Application.Movimentacoes;
using Gastos.Domain.Movimentacoes;
using Gastos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace TestGastos.Infrastructure;

public sealed class MovimentacaoPersistenceTests
{
    [Test]
    public async Task CadastrarEListar_ComSqlite_DevePreservarTiposDoDominio()
    {
        var caminho = Path.Combine(Path.GetTempPath(), $"gastos-mov-{Guid.NewGuid():N}.db");
        var options = new DbContextOptionsBuilder<GastosDbContext>().UseSqlite($"Data Source={caminho}").Options;
        try
        {
            await using (var context = new GastosDbContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            var factory = new FactoryFake(options);
            var cadastrar = new CadastrarMovimentacaoHandler(new MovimentacaoRepository(factory), new ClockFake());
            var listar = new ListarMovimentacoesPorCompetenciaHandler(new MovimentacaoReadRepository(factory));

            var resultado = await cadastrar.HandleAsync(new CadastrarMovimentacaoCommand(new DateOnly(2026, 8, 1), "Salário", 100m, TipoLancamento.Entrada, MeioMonetario.Dinheiro, SituacaoFinanceira.Recebido, OrigemMovimentacao.Manual, "maycon", 1, 1), CancellationToken.None);
            var itens = await listar.HandleAsync(new ListarMovimentacoesPorCompetenciaQuery(1, 1), CancellationToken.None);

            Assert.That(resultado.IsSuccess, Is.True);
            Assert.That(itens.Single().TipoLancamento, Is.EqualTo(TipoLancamento.Entrada));
            Assert.That(itens.Single().Situacao, Is.EqualTo(SituacaoFinanceira.Recebido));
        }
        finally
        {
            SqliteConnection.ClearAllPools();
            if (File.Exists(caminho)) File.Delete(caminho);
        }
    }

    private sealed class ClockFake : IClock { public DateTime UtcNow => new(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc); }
    private sealed class FactoryFake(DbContextOptions<GastosDbContext> options) : IDbContextFactory<GastosDbContext>
    { public GastosDbContext CreateDbContext() => new(options); public Task<GastosDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) => Task.FromResult(CreateDbContext()); }
}
