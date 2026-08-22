using Gastos.Domain.Emprestimos;

namespace Gastos.Application.Emprestimos;

public interface IParcelaEmprestimoRepository
{
    Task AdicionarAsync(ParcelaEmprestimo parcela, CancellationToken cancellationToken);

    Task<ParcelaEmprestimo?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(ParcelaEmprestimo parcela, CancellationToken cancellationToken);

    Task RemoverAsync(ParcelaEmprestimo parcela, CancellationToken cancellationToken);

    Task RemoverPorEmprestimoAsync(int emprestimoId, CancellationToken cancellationToken);

    Task<IReadOnlyList<ParcelaEmprestimoDto>> ListarPorEmprestimoAsync(
        int emprestimoId,
        CancellationToken cancellationToken);

    Task QuitarTodasAsync(int emprestimoId, DateOnly dataPagamento, CancellationToken cancellationToken);
}
