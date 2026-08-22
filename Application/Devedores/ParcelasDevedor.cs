using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.Devedores;

namespace Gastos.Application.Devedores;

public sealed record ParcelaDevedorDto(int Id, int DevedoresId, DateOnly DataParcela, int Parcela, decimal Valor, bool Recebido, DateOnly? DataRecebido, DateTime DataCadastroUtc, string Descricao)
{
    public string RecebidoDescricao => Recebido ? "Sim" : "Não";
    public DateTime DataCadastro => DataCadastroUtc;
}

public sealed record CadastrarParcelaDevedorCommand(int DevedorId, DateOnly DataParcela, int Parcela, decimal Valor, string Login);
public sealed class CadastrarParcelaDevedorHandler(IParcelaDevedorRepository repository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(CadastrarParcelaDevedorCommand command, CancellationToken ct)
    {
        var parcela = ParcelaDevedor.Criar(command.DevedorId, command.DataParcela, command.Parcela, command.Valor, command.Login, clock.UtcNow);
        if (!parcela.IsSuccess || parcela.Value is null) return Result<int>.Failure(parcela.Errors.ToArray());
        await repository.AdicionarAsync(parcela.Value, ct);
        return Result<int>.Success(parcela.Value.Id);
    }
}

public sealed record AtualizarParcelaDevedorCommand(int Id, DateOnly DataParcela, int Parcela, decimal Valor, bool Recebido, DateOnly? DataRecebido);
public sealed class AtualizarParcelaDevedorHandler(IParcelaDevedorRepository repository)
{
    public async Task<Result> HandleAsync(AtualizarParcelaDevedorCommand command, CancellationToken ct)
    {
        var parcela = await repository.ObterPorIdAsync(command.Id, ct);
        if (parcela is null) return Result.Failure(new Error("parcela_devedor.nao_encontrada", "A parcela informada não foi encontrada."));
        var resultado = parcela.Alterar(command.DataParcela, command.Parcela, command.Valor, command.Recebido, command.DataRecebido);
        if (!resultado.IsSuccess) return resultado;
        await repository.AtualizarAsync(parcela, ct);
        return Result.Success();
    }
}

public sealed record ExcluirParcelaDevedorCommand(int Id);
public sealed class ExcluirParcelaDevedorHandler(IParcelaDevedorRepository repository)
{
    public async Task<Result> HandleAsync(ExcluirParcelaDevedorCommand command, CancellationToken ct)
    {
        var parcela = await repository.ObterPorIdAsync(command.Id, ct);
        if (parcela is null) return Result.Failure(new Error("parcela_devedor.nao_encontrada", "A parcela informada não foi encontrada."));
        await repository.RemoverAsync(parcela, ct);
        return Result.Success();
    }
}

public sealed record ExcluirParcelasDevedorCommand(int DevedorId);
public sealed class ExcluirParcelasDevedorHandler(IParcelaDevedorRepository repository)
{
    public async Task<Result> HandleAsync(ExcluirParcelasDevedorCommand command, CancellationToken ct)
    {
        if (command.DevedorId <= 0) return Result.Failure(new Error("devedor.referencia.invalida", "O devedor é obrigatório."));
        await repository.RemoverPorDevedorAsync(command.DevedorId, ct);
        return Result.Success();
    }
}

public sealed record ListarParcelasDevedorQuery(int DevedorId);
public sealed class ListarParcelasDevedorHandler(IParcelaDevedorRepository repository)
{
    public Task<IReadOnlyList<ParcelaDevedorDto>> HandleAsync(ListarParcelasDevedorQuery query, CancellationToken ct) =>
        repository.ListarPorDevedorAsync(query.DevedorId, ct);
}
