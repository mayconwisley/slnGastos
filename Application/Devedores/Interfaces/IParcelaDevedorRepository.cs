using Gastos.Domain.Devedores;

namespace Gastos.Application.Devedores;

public interface IParcelaDevedorRepository
{
    Task AdicionarAsync(ParcelaDevedor parcela, CancellationToken cancellationToken);

    Task<ParcelaDevedor?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(ParcelaDevedor parcela, CancellationToken cancellationToken);

    Task RemoverAsync(ParcelaDevedor parcela, CancellationToken cancellationToken);

    Task RemoverPorDevedorAsync(int devedorId, CancellationToken cancellationToken);

    Task<IReadOnlyList<ParcelaDevedorDto>> ListarPorDevedorAsync(
        int devedorId,
        CancellationToken cancellationToken);
}
