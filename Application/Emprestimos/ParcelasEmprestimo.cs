using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.Emprestimos;

namespace Gastos.Application.Emprestimos;

public sealed record ParcelaEmprestimoDto(int Id, int EmprestimosId, DateOnly DataParcela, int Parcela, decimal Valor, bool Pago, DateOnly? DataPagamento, DateTime DataCadastroUtc)
{
    public string PagoDescricao => Pago ? "Sim" : "Não";
    public DateTime? DataCadastro => DataCadastroUtc;
}

public interface IParcelaEmprestimoRepository
{
    Task AdicionarAsync(ParcelaEmprestimo parcela, CancellationToken ct);
    Task<ParcelaEmprestimo?> ObterPorIdAsync(int id, CancellationToken ct);
    Task AtualizarAsync(ParcelaEmprestimo parcela, CancellationToken ct);
    Task RemoverAsync(ParcelaEmprestimo parcela, CancellationToken ct);
    Task RemoverPorEmprestimoAsync(int emprestimoId, CancellationToken ct);
    Task<IReadOnlyList<ParcelaEmprestimoDto>> ListarPorEmprestimoAsync(int emprestimoId, CancellationToken ct);
    Task QuitarTodasAsync(int emprestimoId, DateOnly dataPagamento, CancellationToken ct);
}

public sealed record CadastrarParcelaEmprestimoCommand(int EmprestimoId, DateOnly DataParcela, int Parcela, decimal Valor, string Login);
public sealed class CadastrarParcelaEmprestimoHandler(IParcelaEmprestimoRepository repository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(CadastrarParcelaEmprestimoCommand command, CancellationToken ct)
    {
        var parcela = ParcelaEmprestimo.Criar(command.EmprestimoId, command.DataParcela, command.Parcela, command.Valor, command.Login, clock.UtcNow);
        if (!parcela.IsSuccess || parcela.Value is null) return Result<int>.Failure(parcela.Errors.ToArray());
        await repository.AdicionarAsync(parcela.Value, ct);
        return Result<int>.Success(parcela.Value.Id);
    }
}

public sealed record AtualizarParcelaEmprestimoCommand(int Id, DateOnly DataParcela, int Parcela, decimal Valor, bool Pago, DateOnly? DataPagamento);
public sealed class AtualizarParcelaEmprestimoHandler(IParcelaEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(AtualizarParcelaEmprestimoCommand command, CancellationToken ct)
    {
        var parcela = await repository.ObterPorIdAsync(command.Id, ct);
        if (parcela is null) return Result.Failure(new Error("parcela_emprestimo.nao_encontrada", "A parcela informada não foi encontrada."));
        var resultado = parcela.Alterar(command.DataParcela, command.Parcela, command.Valor, command.Pago, command.DataPagamento);
        if (!resultado.IsSuccess) return resultado;
        await repository.AtualizarAsync(parcela, ct);
        return Result.Success();
    }
}

public sealed record ExcluirParcelaEmprestimoCommand(int Id);
public sealed class ExcluirParcelaEmprestimoHandler(IParcelaEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(ExcluirParcelaEmprestimoCommand command, CancellationToken ct)
    {
        var parcela = await repository.ObterPorIdAsync(command.Id, ct);
        if (parcela is null) return Result.Failure(new Error("parcela_emprestimo.nao_encontrada", "A parcela informada não foi encontrada."));
        await repository.RemoverAsync(parcela, ct);
        return Result.Success();
    }
}

public sealed record QuitarEmprestimoCommand(int EmprestimoId, DateOnly DataPagamento);
public sealed class QuitarEmprestimoHandler(IParcelaEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(QuitarEmprestimoCommand command, CancellationToken ct)
    {
        if (command.EmprestimoId <= 0) return Result.Failure(new Error("emprestimo.referencia.invalida", "O empréstimo é obrigatório."));
        await repository.QuitarTodasAsync(command.EmprestimoId, command.DataPagamento, ct);
        return Result.Success();
    }
}

public sealed record ExcluirParcelasEmprestimoCommand(int EmprestimoId);
public sealed class ExcluirParcelasEmprestimoHandler(IParcelaEmprestimoRepository repository)
{
    public async Task<Result> HandleAsync(ExcluirParcelasEmprestimoCommand command, CancellationToken ct)
    {
        if (command.EmprestimoId <= 0) return Result.Failure(new Error("emprestimo.referencia.invalida", "O empréstimo é obrigatório."));
        await repository.RemoverPorEmprestimoAsync(command.EmprestimoId, ct);
        return Result.Success();
    }
}

public sealed record ListarParcelasEmprestimoQuery(int EmprestimoId);
public sealed class ListarParcelasEmprestimoHandler(IParcelaEmprestimoRepository repository)
{
    public Task<IReadOnlyList<ParcelaEmprestimoDto>> HandleAsync(ListarParcelasEmprestimoQuery query, CancellationToken ct) =>
        repository.ListarPorEmprestimoAsync(query.EmprestimoId, ct);
}
