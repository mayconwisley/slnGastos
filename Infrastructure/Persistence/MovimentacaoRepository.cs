using Gastos.Application.Movimentacoes;
using Gastos.Domain.Movimentacoes;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class MovimentacaoRepository(IDbContextFactory<GastosDbContext> factory) : IMovimentacaoRepository
{
    public async Task AdicionarAsync(Movimentacao movimentacao, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        await context.Movimentacoes.AddAsync(movimentacao, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Movimentacao?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.Movimentacoes.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task AtualizarAsync(Movimentacao movimentacao, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Movimentacoes.Update(movimentacao);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoverAsync(Movimentacao movimentacao, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Movimentacoes.Remove(movimentacao);
        await context.SaveChangesAsync(cancellationToken);
    }
}
