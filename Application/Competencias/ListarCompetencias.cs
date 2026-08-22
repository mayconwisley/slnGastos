namespace Gastos.Application.Competencias;

public sealed record ListarCompetenciasPorClienteQuery(int ClienteId);

public sealed class ListarCompetenciasPorClienteHandler(ICompetenciaReadRepository competenciaReadRepository)
{
    public Task<IReadOnlyList<CompetenciaDto>> HandleAsync(
        ListarCompetenciasPorClienteQuery query,
        CancellationToken cancellationToken) =>
        competenciaReadRepository.ListarPorClienteAsync(query.ClienteId, cancellationToken);
}
