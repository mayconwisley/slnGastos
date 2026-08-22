using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.Devedores;

namespace Gastos.Application.Devedores;

public sealed record CadastrarDevedorCommand(string Nome, string Descricao, decimal Valor, int Parcelas, DateOnly DataInicio, bool Ativo, string Login, int ClienteId);

public sealed class CadastrarDevedorHandler(IDevedorRepository repository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(CadastrarDevedorCommand command, CancellationToken ct)
    {
        var resultado = Devedor.Criar(command.Nome, command.Descricao, command.Valor, command.Parcelas, command.DataInicio, command.Ativo, command.Login, command.ClienteId, clock.UtcNow);
        if (!resultado.IsSuccess || resultado.Value is null)
        {
            return Result<int>.Failure(resultado.Errors.ToArray());
        }

        await repository.AdicionarAsync(resultado.Value, ct);
        return Result<int>.Success(resultado.Value.Id);
    }
}

public sealed record AtualizarDevedorCommand(int Id, string Nome, string Descricao, decimal Valor, int Parcelas, DateOnly DataInicio, bool Ativo);

public sealed class AtualizarDevedorHandler(IDevedorRepository repository)
{
    public async Task<Result> HandleAsync(AtualizarDevedorCommand command, CancellationToken ct)
    {
        var devedor = await repository.ObterPorIdAsync(command.Id, ct);
        if (devedor is null)
        {
            return Result.Failure(new Error("devedor.nao_encontrado", "O devedor informado não foi encontrado."));
        }

        if (await repository.PossuiParcelasAsync(command.Id, ct))
        {
            return Result.Failure(new Error("devedor.possui_parcelas", "Não é possível alterar o devedor após gerar parcelas."));
        }

        var resultado = devedor.Alterar(command.Nome, command.Descricao, command.Valor, command.Parcelas, command.DataInicio, command.Ativo);
        if (!resultado.IsSuccess)
        {
            return resultado;
        }

        await repository.AtualizarAsync(devedor, ct);
        return Result.Success();
    }
}

public sealed record ExcluirDevedorCommand(int Id);

public sealed class ExcluirDevedorHandler(IDevedorRepository repository)
{
    public async Task<Result> HandleAsync(ExcluirDevedorCommand command, CancellationToken ct)
    {
        var devedor = await repository.ObterPorIdAsync(command.Id, ct);
        if (devedor is null)
        {
            return Result.Failure(new Error("devedor.nao_encontrado", "O devedor informado não foi encontrado."));
        }

        if (await repository.PossuiParcelasAsync(command.Id, ct))
        {
            return Result.Failure(new Error("devedor.possui_parcelas", "Não é possível excluir o devedor após gerar parcelas."));
        }

        await repository.RemoverAsync(devedor, ct);
        return Result.Success();
    }
}

public sealed record GerarParcelasDevedorCommand(int DevedorId);

public sealed class GerarParcelasDevedorHandler(IDevedorRepository repository)
{
    public async Task<Result> HandleAsync(GerarParcelasDevedorCommand command, CancellationToken ct)
    {
        var devedor = await repository.ObterPorIdAsync(command.DevedorId, ct);
        if (devedor is null)
        {
            return Result.Failure(new Error("devedor.nao_encontrado", "O devedor informado não foi encontrado."));
        }

        if (await repository.PossuiParcelasAsync(command.DevedorId, ct))
        {
            return Result.Failure(new Error("devedor.parcelas_ja_geradas", "As parcelas desse devedor já foram geradas."));
        }

        await repository.GerarParcelasAsync(devedor, ct);
        return Result.Success();
    }
}

public sealed record ListarDevedoresPorClienteQuery(int ClienteId);

public sealed class ListarDevedoresPorClienteHandler(IDevedorReadRepository repository)
{
    public Task<IReadOnlyList<DevedorDto>> HandleAsync(ListarDevedoresPorClienteQuery query, CancellationToken ct) =>
        repository.ListarPorClienteAsync(query.ClienteId, ct);
}

public sealed record ListarResumoDevedoresPorClienteQuery(int ClienteId);

public sealed class ListarResumoDevedoresPorClienteHandler(IDevedorReadRepository repository)
{
    public Task<IReadOnlyList<ResumoDevedorDto>> HandleAsync(ListarResumoDevedoresPorClienteQuery query, CancellationToken ct) =>
        repository.ListarResumoPorClienteAsync(query.ClienteId, ct);
}
