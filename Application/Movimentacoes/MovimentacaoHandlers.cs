using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.Movimentacoes;

namespace Gastos.Application.Movimentacoes;

public sealed record CadastrarMovimentacaoCommand(
    DateOnly DataMovimento,
    string Descricao,
    decimal Valor,
    TipoLancamento TipoLancamento,
    MeioMonetario MeioMonetario,
    SituacaoFinanceira Situacao,
    OrigemMovimentacao Origem,
    string Login,
    int ClienteId,
    int CompetenciaId);

public sealed class CadastrarMovimentacaoHandler(IMovimentacaoRepository repository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(
        CadastrarMovimentacaoCommand command,
        CancellationToken cancellationToken)
    {
        var resultado = Movimentacao.Criar(
            command.DataMovimento,
            command.Descricao,
            command.Valor,
            command.TipoLancamento,
            command.MeioMonetario,
            command.Situacao,
            command.Origem,
            command.Login,
            command.ClienteId,
            command.CompetenciaId,
            clock.UtcNow);

        if (!resultado.IsSuccess || resultado.Value is null)
        {
            return Result<int>.Failure(resultado.Errors.ToArray());
        }

        await repository.AdicionarAsync(resultado.Value, cancellationToken);
        return Result<int>.Success(resultado.Value.Id);
    }
}

public sealed record AtualizarMovimentacaoCommand(
    int Id,
    DateOnly DataMovimento,
    string Descricao,
    decimal Valor,
    TipoLancamento TipoLancamento,
    MeioMonetario MeioMonetario,
    SituacaoFinanceira Situacao);

public sealed class AtualizarMovimentacaoHandler(IMovimentacaoRepository repository)
{
    public async Task<Result> HandleAsync(
        AtualizarMovimentacaoCommand command,
        CancellationToken cancellationToken)
    {
        var movimentacao = await repository.ObterPorIdAsync(command.Id, cancellationToken);

        if (movimentacao is null)
        {
            return Result.Failure(
                new Error("movimentacao.nao_encontrada", "A movimentação informada não foi encontrada."));
        }

        var resultado = movimentacao.Alterar(
            command.DataMovimento,
            command.Descricao,
            command.Valor,
            command.TipoLancamento,
            command.MeioMonetario,
            command.Situacao);

        if (!resultado.IsSuccess)
        {
            return resultado;
        }

        await repository.AtualizarAsync(movimentacao, cancellationToken);
        return Result.Success();
    }
}

public sealed record ExcluirMovimentacaoCommand(int Id);

public sealed class ExcluirMovimentacaoHandler(IMovimentacaoRepository repository)
{
    public async Task<Result> HandleAsync(
        ExcluirMovimentacaoCommand command,
        CancellationToken cancellationToken)
    {
        var movimentacao = await repository.ObterPorIdAsync(command.Id, cancellationToken);

        if (movimentacao is null)
        {
            return Result.Failure(
                new Error("movimentacao.nao_encontrada", "A movimentação informada não foi encontrada."));
        }

        await repository.RemoverAsync(movimentacao, cancellationToken);
        return Result.Success();
    }
}

public sealed record ListarMovimentacoesPorCompetenciaQuery(int ClienteId, int CompetenciaId);

public sealed class ListarMovimentacoesPorCompetenciaHandler(IMovimentacaoReadRepository repository)
{
    public Task<IReadOnlyList<MovimentacaoDto>> HandleAsync(
        ListarMovimentacoesPorCompetenciaQuery query,
        CancellationToken cancellationToken) =>
        repository.ListarPorCompetenciaAsync(query.ClienteId, query.CompetenciaId, cancellationToken);
}
