using Gastos.Domain.Emprestimos;

namespace Gastos.Application.Emprestimos;

public interface IEmprestimoRepository
{
    Task AdicionarAsync(Emprestimo emprestimo, CancellationToken cancellationToken);

    Task<Emprestimo?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(Emprestimo emprestimo, CancellationToken cancellationToken);

    Task RemoverAsync(Emprestimo emprestimo, CancellationToken cancellationToken);

    Task<bool> PossuiParcelasAsync(int emprestimoId, CancellationToken cancellationToken);

    Task GerarParcelasAsync(Emprestimo emprestimo, CancellationToken cancellationToken);
}
