namespace Gastos.Application.Competencias;

public interface ICompetenciaReadRepository
{
    Task<IReadOnlyList<CompetenciaDto>> ListarPorClienteAsync(
        int clienteId,
        CancellationToken cancellationToken);
}
