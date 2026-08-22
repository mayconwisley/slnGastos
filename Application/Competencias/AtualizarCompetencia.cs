using Gastos.Domain.Common;

namespace Gastos.Application.Competencias;

public sealed record AtualizarCompetenciaCommand(int Id, DateOnly MesReferencia, bool Ativa);

public sealed class AtualizarCompetenciaHandler(ICompetenciaRepository competenciaRepository)
{
    public async Task<Result> HandleAsync(AtualizarCompetenciaCommand command, CancellationToken cancellationToken)
    {
        var competencia = await competenciaRepository.ObterPorIdAsync(command.Id, cancellationToken);
        if (competencia is null)
        {
            return Result.Failure(new Error("competencia.nao_encontrada", "A competência informada não foi encontrada."));
        }

        var alteracao = competencia.Alterar(command.MesReferencia, command.Ativa);
        if (!alteracao.IsSuccess)
        {
            return alteracao;
        }

        await competenciaRepository.AtualizarAsync(competencia, command.Ativa, cancellationToken);
        return Result.Success();
    }
}
