using Gastos.Domain.Emprestimos;

namespace Gastos.Application.Emprestimos;

public sealed record EmprestimoDto(
    int Id,
    DateOnly DataInicio,
    string Descricao,
    decimal ValorEmprestado,
    decimal ValorParcela,
    int Parcelas,
    bool Ativo,
    string Login,
    int ClienteId,
    DateTime DataCadastroUtc,
    bool ParcelasGeradas,
    decimal ValorPago)
{
    public decimal ValorAPagar => (ValorParcela * Parcelas) - ValorPago;

    public DateTime DataCadastro => DataCadastroUtc;
}
public interface IEmprestimoRepository { Task AdicionarAsync(Emprestimo emprestimo, CancellationToken ct); Task<Emprestimo?> ObterPorIdAsync(int id, CancellationToken ct); Task AtualizarAsync(Emprestimo emprestimo, CancellationToken ct); Task RemoverAsync(Emprestimo emprestimo, CancellationToken ct); Task<bool> PossuiParcelasAsync(int emprestimoId, CancellationToken ct); Task GerarParcelasAsync(Emprestimo emprestimo, CancellationToken ct); }
public interface IEmprestimoReadRepository { Task<IReadOnlyList<EmprestimoDto>> ListarPorClienteAsync(int clienteId, CancellationToken ct); }
