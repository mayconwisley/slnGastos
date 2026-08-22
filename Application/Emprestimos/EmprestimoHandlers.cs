using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.Emprestimos;

namespace Gastos.Application.Emprestimos;

public sealed record CadastrarEmprestimoCommand(
    DateOnly DataInicio,
    string Descricao,
    decimal ValorEmprestado,
    decimal ValorParcela,
    int Parcelas,
    bool Ativo,
    string Login,
    int ClienteId);

public sealed class CadastrarEmprestimoHandler(IEmprestimoRepository repository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(
        CadastrarEmprestimoCommand command,
        CancellationToken cancellationToken)
    {
        var resultado = Emprestimo.Criar(
            command.DataInicio,
            command.Descricao,
            command.ValorEmprestado,
            command.ValorParcela,
            command.Parcelas,
            command.Ativo,
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

public sealed record AtualizarEmprestimoCommand(
    int Id,
    DateOnly DataInicio,
    string Descricao,
    decimal ValorEmprestado,
    decimal ValorParcela,
    int Parcelas,
    bool Ativo);

public sealed class AtualizarEmprestimoHandler(IEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(
        AtualizarEmprestimoCommand command,
        CancellationToken cancellationToken)
    {
        var emprestimo = await repository.ObterPorIdAsync(command.Id, cancellationToken);

        if (emprestimo is null)
        {
            return EmprestimoNaoEncontrado();
        }

        if (await repository.PossuiParcelasAsync(command.Id, cancellationToken))
        {
            return EmprestimoComParcelas();
        }

        var resultado = emprestimo.Alterar(
            command.DataInicio,
            command.Descricao,
            command.ValorEmprestado,
            command.ValorParcela,
            command.Parcelas,
            command.Ativo);

        if (!resultado.IsSuccess)
        {
            return resultado;
        }

        await repository.AtualizarAsync(emprestimo, cancellationToken);
        return Result.Success();
    }

    private static Result EmprestimoNaoEncontrado() => Result.Failure(
        new Error("emprestimo.nao_encontrado", "O empréstimo informado não foi encontrado."));

    private static Result EmprestimoComParcelas() => Result.Failure(
        new Error("emprestimo.possui_parcelas", "Não é possível alterar o empréstimo após gerar parcelas."));
}

public sealed record ExcluirEmprestimoCommand(int Id);

public sealed class ExcluirEmprestimoHandler(IEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(
        ExcluirEmprestimoCommand command,
        CancellationToken cancellationToken)
    {
        var emprestimo = await repository.ObterPorIdAsync(command.Id, cancellationToken);

        if (emprestimo is null)
        {
            return Result.Failure(
                new Error("emprestimo.nao_encontrado", "O empréstimo informado não foi encontrado."));
        }

        if (await repository.PossuiParcelasAsync(command.Id, cancellationToken))
        {
            return Result.Failure(
                new Error("emprestimo.possui_parcelas", "Não é possível excluir o empréstimo após gerar parcelas."));
        }

        await repository.RemoverAsync(emprestimo, cancellationToken);
        return Result.Success();
    }
}

public sealed record GerarParcelasEmprestimoCommand(int EmprestimoId);

public sealed class GerarParcelasEmprestimoHandler(IEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(
        GerarParcelasEmprestimoCommand command,
        CancellationToken cancellationToken)
    {
        var emprestimo = await repository.ObterPorIdAsync(command.EmprestimoId, cancellationToken);

        if (emprestimo is null)
        {
            return Result.Failure(
                new Error("emprestimo.nao_encontrado", "O empréstimo informado não foi encontrado."));
        }

        if (await repository.PossuiParcelasAsync(command.EmprestimoId, cancellationToken))
        {
            return Result.Failure(
                new Error("emprestimo.parcelas_ja_geradas", "As parcelas desse empréstimo já foram geradas."));
        }

        await repository.GerarParcelasAsync(emprestimo, cancellationToken);
        return Result.Success();
    }
}

public sealed record ListarEmprestimosPorClienteQuery(int ClienteId);

public sealed class ListarEmprestimosPorClienteHandler(IEmprestimoReadRepository repository)
{
    public Task<IReadOnlyList<EmprestimoDto>> HandleAsync(
        ListarEmprestimosPorClienteQuery query,
        CancellationToken cancellationToken) =>
        repository.ListarPorClienteAsync(query.ClienteId, cancellationToken);
}
