using Gastos.Domain.Common;

namespace Gastos.Application.Competencias;

public sealed record ExcluirCompetenciaCommand(int Id);

public sealed class ExcluirCompetenciaHandler(ICompetenciaRepository competenciaRepository)
{
    public async Task<Result> HandleAsync(ExcluirCompetenciaCommand command, CancellationToken cancellationToken)
    {
        var competencia = await competenciaRepository.ObterPorIdAsync(command.Id, cancellationToken);
        if (competencia is null)
        {
            return Result.Failure(new Error("competencia.nao_encontrada", "A competência informada não foi encontrada."));
        }

        await competenciaRepository.RemoverAsync(competencia, cancellationToken);
        return Result.Success();
    }
}
