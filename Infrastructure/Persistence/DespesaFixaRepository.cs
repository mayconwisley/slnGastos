using Gastos.Application.DespesasFixas;
using Gastos.Domain.DespesasFixas;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class DespesaFixaRepository(IDbContextFactory<GastosDbContext> factory) : IDespesaFixaRepository
{
    public async Task AdicionarAsync(DespesaFixa despesa, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        await context.DespesasFixas.AddAsync(despesa, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<DespesaFixa?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.DespesasFixas.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task AtualizarAsync(DespesaFixa despesa, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.DespesasFixas.Update(despesa);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoverAsync(DespesaFixa despesa, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.DespesasFixas.Remove(despesa);
        await context.SaveChangesAsync(cancellationToken);
    }
}
