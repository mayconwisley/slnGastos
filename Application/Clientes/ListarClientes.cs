namespace Gastos.Application.Clientes;

public sealed record ListarClientesQuery;

public sealed class ListarClientesHandler(IClienteReadRepository clienteReadRepository)
{
    public Task<IReadOnlyList<ClienteDto>> HandleAsync(ListarClientesQuery _, CancellationToken cancellationToken) =>
        clienteReadRepository.ListarAsync(cancellationToken);
}
