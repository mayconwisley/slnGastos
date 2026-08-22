namespace Gastos.Application.Clientes;

public interface IClienteReadRepository
{
    Task<IReadOnlyList<ClienteDto>> ListarAsync(CancellationToken cancellationToken);
}
