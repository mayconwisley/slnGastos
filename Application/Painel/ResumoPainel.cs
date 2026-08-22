using Gastos.Domain.Common;

namespace Gastos.Application.Painel;

public sealed record ResumoPainelDto(
    int CompetenciaId,
    DateOnly MesReferencia,
    decimal DespesasFixas,
    decimal EmprestimosEmAberto,
    decimal DebitosDevedores,
    decimal CreditosDevedores,
    decimal Saldo);

public interface IResumoPainelReadRepository
{
    Task<ResumoPainelDto?> ObterAsync(int clienteId, DateOnly mesReferencia, CancellationToken ct);
}

public sealed record ObterResumoPainelQuery(int ClienteId, DateOnly MesReferencia);

public sealed class ObterResumoPainelHandler(IResumoPainelReadRepository repository)
{
    public async Task<Result<ResumoPainelDto>> HandleAsync(ObterResumoPainelQuery query, CancellationToken ct)
    {
        if (query.ClienteId <= 0)
        {
            return Result<ResumoPainelDto>.Failure(new Error("painel.cliente.invalido", "O cliente é obrigatório."));
        }

        var resumo = await repository.ObterAsync(query.ClienteId, query.MesReferencia, ct);
        return resumo is null
            ? Result<ResumoPainelDto>.Failure(new Error("painel.competencia.nao_encontrada", "Não há competência cadastrada para o mês informado."))
            : Result<ResumoPainelDto>.Success(resumo);
    }
}
