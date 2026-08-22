namespace Gastos.Application.Devedores;

public interface IDevedorReadRepository
{
    Task<IReadOnlyList<DevedorDto>> ListarPorClienteAsync(
        int clienteId,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<ResumoDevedorDto>> ListarResumoPorClienteAsync(
        int clienteId,
        CancellationToken cancellationToken);
}
