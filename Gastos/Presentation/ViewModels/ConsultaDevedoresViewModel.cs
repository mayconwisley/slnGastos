using Gastos.Application.Clientes;
using Gastos.Application.Devedores;

namespace Gastos.Presentation.ViewModels;

public sealed class ConsultaDevedoresViewModel : ConsultaPorClienteViewModel<DevedorDto>
{
    private readonly ListarDevedoresPorClienteHandler listarDevedoresHandler;

    public ConsultaDevedoresViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarDevedoresPorClienteHandler listarDevedoresHandler)
        : base(listarClientesHandler)
    {
        this.listarDevedoresHandler = listarDevedoresHandler;
    }

    protected override async Task<IEnumerable<DevedorDto>> ListarItensAsync(int clienteId, CancellationToken cancellationToken)
    {
        return await listarDevedoresHandler.HandleAsync(new ListarDevedoresPorClienteQuery(clienteId), cancellationToken);
    }
}
