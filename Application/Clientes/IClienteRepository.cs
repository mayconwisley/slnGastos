using Gastos.Domain.Clientes;

namespace Gastos.Application.Clientes;

public interface IClienteRepository
{
    Task AdicionarAsync(Cliente cliente, CancellationToken cancellationToken);

    Task<Cliente?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(Cliente cliente, CancellationToken cancellationToken);

    Task RemoverAsync(Cliente cliente, CancellationToken cancellationToken);
}
