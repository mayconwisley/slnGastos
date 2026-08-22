using Gastos.Domain.Common;
using Gastos.Domain.Competencias;

namespace Gastos.Application.Competencias;

public sealed record CadastrarCompetenciaCommand(DateOnly MesReferencia, int ClienteId, bool Ativa);

public sealed class CadastrarCompetenciaHandler(ICompetenciaRepository competenciaRepository)
{
    public async Task<Result<int>> HandleAsync(CadastrarCompetenciaCommand command, CancellationToken cancellationToken)
    {
        var competenciaResult = Competencia.Criar(command.MesReferencia, command.ClienteId, command.Ativa);
        if (!competenciaResult.IsSuccess || competenciaResult.Value is null)
        {
            return Result<int>.Failure(competenciaResult.Errors.ToArray());
        }

        await competenciaRepository.AdicionarAsync(competenciaResult.Value, command.Ativa, cancellationToken);
        return Result<int>.Success(competenciaResult.Value.Id);
    }
}
