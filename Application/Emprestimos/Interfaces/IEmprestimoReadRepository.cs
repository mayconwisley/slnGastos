namespace Gastos.Application.Emprestimos;

public interface IEmprestimoReadRepository
{
    Task<IReadOnlyList<EmprestimoDto>> ListarPorClienteAsync(
        int clienteId,
        CancellationToken cancellationToken);
}
