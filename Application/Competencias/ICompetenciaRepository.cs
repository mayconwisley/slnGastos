using Gastos.Domain.Competencias;

namespace Gastos.Application.Competencias;

public interface ICompetenciaRepository
{
    Task AdicionarAsync(Competencia competencia, bool desativarDemaisCompetencias, CancellationToken cancellationToken);

    Task<Competencia?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(Competencia competencia, bool desativarDemaisCompetencias, CancellationToken cancellationToken);

    Task RemoverAsync(Competencia competencia, CancellationToken cancellationToken);
}
