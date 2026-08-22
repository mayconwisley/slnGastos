using Gastos.Application.Competencias;
using Gastos.Domain.Competencias;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class CompetenciaRepository(IDbContextFactory<GastosDbContext> contextFactory) : ICompetenciaRepository
{
    public async Task AdicionarAsync(Competencia competencia, bool desativarDemaisCompetencias, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await using var transacao = await context.Database.BeginTransactionAsync(cancellationToken);

        if (desativarDemaisCompetencias)
        {
            await DesativarAtivasAsync(context, competencia.ClienteId, competencia.Id, cancellationToken);
        }

        await context.Competencias.AddAsync(competencia, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await transacao.CommitAsync(cancellationToken);
    }

    public async Task<Competencia?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Competencias.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task AtualizarAsync(Competencia competencia, bool desativarDemaisCompetencias, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await using var transacao = await context.Database.BeginTransactionAsync(cancellationToken);

        if (desativarDemaisCompetencias)
        {
            await DesativarAtivasAsync(context, competencia.ClienteId, competencia.Id, cancellationToken);
        }

        context.Competencias.Update(competencia);
        await context.SaveChangesAsync(cancellationToken);
        await transacao.CommitAsync(cancellationToken);
    }

    public async Task RemoverAsync(Competencia competencia, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Competencias.Remove(competencia);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static Task<int> DesativarAtivasAsync(
        GastosDbContext context,
        int clienteId,
        int competenciaId,
        CancellationToken cancellationToken) =>
        context.Competencias
            .Where(item => item.ClienteId == clienteId && item.Id != competenciaId && item.Ativa)
            .ExecuteUpdateAsync(setters => setters.SetProperty(item => item.Ativa, false), cancellationToken);
}
