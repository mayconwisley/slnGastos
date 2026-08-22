using Gastos.Domain.Movimentacoes;

namespace Gastos.Application.Movimentacoes;

public interface IMovimentacaoRepository
{
    Task AdicionarAsync(Movimentacao movimentacao, CancellationToken cancellationToken);

    Task<Movimentacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(Movimentacao movimentacao, CancellationToken cancellationToken);

    Task RemoverAsync(Movimentacao movimentacao, CancellationToken cancellationToken);
}
