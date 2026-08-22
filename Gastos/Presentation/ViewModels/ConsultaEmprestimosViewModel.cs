using Gastos.Application.Clientes;
using Gastos.Application.Emprestimos;

namespace Gastos.Presentation.ViewModels;

public sealed class ConsultaEmprestimosViewModel : ConsultaPorClienteViewModel<EmprestimoDto>
{
    private readonly ListarEmprestimosPorClienteHandler listarEmprestimosHandler;

    public ConsultaEmprestimosViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarEmprestimosPorClienteHandler listarEmprestimosHandler)
        : base(listarClientesHandler)
    {
        this.listarEmprestimosHandler = listarEmprestimosHandler;
    }

    protected override async Task<IEnumerable<EmprestimoDto>> ListarItensAsync(int clienteId, CancellationToken cancellationToken)
    {
        return await listarEmprestimosHandler.HandleAsync(new ListarEmprestimosPorClienteQuery(clienteId), cancellationToken);
    }
}
