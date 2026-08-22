using Gastos.Domain.Devedores;

namespace Gastos.Application.Devedores;

public interface IDevedorRepository
{
    Task AdicionarAsync(Devedor devedor, CancellationToken cancellationToken);

    Task<Devedor?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(Devedor devedor, CancellationToken cancellationToken);

    Task RemoverAsync(Devedor devedor, CancellationToken cancellationToken);

    Task<bool> PossuiParcelasAsync(int devedorId, CancellationToken cancellationToken);

    Task GerarParcelasAsync(Devedor devedor, CancellationToken cancellationToken);
}
