using Gastos.Application.Abstractions;
using Gastos.Application.Movimentacoes;
using Gastos.Domain.Movimentacoes;

namespace TestGastos.Application;

public sealed class CadastrarMovimentacaoHandlerTests
{
    [Test]
    public async Task HandleAsync_ComSituacaoInvalida_NaoDevePersistir()
    {
        var repository = new MovimentacaoRepositoryFake();
        var handler = new CadastrarMovimentacaoHandler(repository, new ClockFake());

        var resultado = await handler.HandleAsync(
            new CadastrarMovimentacaoCommand(new DateOnly(2026, 8, 1), "Conta", 100m, TipoLancamento.Saida, MeioMonetario.Dinheiro, SituacaoFinanceira.Recebido, OrigemMovimentacao.Manual, "maycon", 1, 1),
            CancellationToken.None);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(repository.FoiChamado, Is.False);
    }

    private sealed class ClockFake : IClock { public DateTime UtcNow => new(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc); }
    private sealed class MovimentacaoRepositoryFake : IMovimentacaoRepository
    {
        public bool FoiChamado { get; private set; }
        public Task AdicionarAsync(Movimentacao movimentacao, CancellationToken ct) { FoiChamado = true; return Task.CompletedTask; }
        public Task<Movimentacao?> ObterPorIdAsync(int id, CancellationToken ct) => Task.FromResult<Movimentacao?>(null);
        public Task AtualizarAsync(Movimentacao movimentacao, CancellationToken ct) => Task.CompletedTask;
        public Task RemoverAsync(Movimentacao movimentacao, CancellationToken ct) => Task.CompletedTask;
    }
}
