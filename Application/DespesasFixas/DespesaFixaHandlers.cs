using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.DespesasFixas;

namespace Gastos.Application.DespesasFixas;

public sealed record CadastrarDespesaFixaCommand(
    DateOnly DataInicio,
    string Descricao,
    decimal Valor,
    DateOnly? DataFim,
    string Login,
    int ClienteId);

public sealed class CadastrarDespesaFixaHandler(IDespesaFixaRepository repository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(
        CadastrarDespesaFixaCommand command,
        CancellationToken cancellationToken)
    {
        var resultado = DespesaFixa.Criar(
            command.DataInicio,
            command.Descricao,
            command.Valor,
            command.DataFim,
            command.Login,
            command.ClienteId,
            clock.UtcNow);

        if (!resultado.IsSuccess || resultado.Value is null)
        {
            return Result<int>.Failure(resultado.Errors.ToArray());
        }

        await repository.AdicionarAsync(resultado.Value, cancellationToken);
        return Result<int>.Success(resultado.Value.Id);
    }
}

public sealed record AtualizarDespesaFixaCommand(
    int Id,
    DateOnly DataInicio,
    string Descricao,
    decimal Valor,
    DateOnly? DataFim);

public sealed class AtualizarDespesaFixaHandler(IDespesaFixaRepository repository)
{
    public async Task<Result> HandleAsync(
        AtualizarDespesaFixaCommand command,
        CancellationToken cancellationToken)
    {
        var despesa = await repository.ObterPorIdAsync(command.Id, cancellationToken);

        if (despesa is null)
        {
            return Result.Failure(
                new Error("despesa_fixa.nao_encontrada", "A despesa fixa informada não foi encontrada."));
        }

        var resultado = despesa.Alterar(
            command.DataInicio,
            command.Descricao,
            command.Valor,
            command.DataFim);

        if (!resultado.IsSuccess)
        {
            return resultado;
        }

        await repository.AtualizarAsync(despesa, cancellationToken);
        return Result.Success();
    }
}

public sealed record ExcluirDespesaFixaCommand(int Id);

public sealed class ExcluirDespesaFixaHandler(IDespesaFixaRepository repository)
{
    public async Task<Result> HandleAsync(
        ExcluirDespesaFixaCommand command,
        CancellationToken cancellationToken)
    {
        var despesa = await repository.ObterPorIdAsync(command.Id, cancellationToken);

        if (despesa is null)
        {
            return Result.Failure(
                new Error("despesa_fixa.nao_encontrada", "A despesa fixa informada não foi encontrada."));
        }

        await repository.RemoverAsync(despesa, cancellationToken);
        return Result.Success();
    }
}

public sealed record ListarDespesasFixasPorClienteQuery(int ClienteId);

public sealed class ListarDespesasFixasPorClienteHandler(IDespesaFixaReadRepository repository)
{
    public Task<IReadOnlyList<DespesaFixaDto>> HandleAsync(
        ListarDespesasFixasPorClienteQuery query,
        CancellationToken cancellationToken) =>
        repository.ListarPorClienteAsync(query.ClienteId, cancellationToken);
}
