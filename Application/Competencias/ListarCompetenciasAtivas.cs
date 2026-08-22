namespace Gastos.Application.Competencias;

public sealed record ListarCompetenciasAtivasQuery;

public sealed class ListarCompetenciasAtivasHandler(ICompetenciaReadRepository competenciaReadRepository)
{
    public Task<IReadOnlyList<CompetenciaAtivaDto>> HandleAsync(
        ListarCompetenciasAtivasQuery query,
        CancellationToken cancellationToken) =>
        competenciaReadRepository.ListarAtivasAsync(cancellationToken);
}
