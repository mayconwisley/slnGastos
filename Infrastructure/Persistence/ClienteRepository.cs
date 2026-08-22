using Gastos.Application.Clientes;
using Gastos.Domain.Clientes;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class ClienteRepository(IDbContextFactory<GastosDbContext> contextFactory) : IClienteRepository
{
    public async Task AdicionarAsync(Cliente cliente, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Clientes.AddAsync(cliente, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Cliente?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Clientes.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task AtualizarAsync(Cliente cliente, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Clientes.Update(cliente);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoverAsync(Cliente cliente, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Clientes.Remove(cliente);
        await context.SaveChangesAsync(cancellationToken);
    }
}
