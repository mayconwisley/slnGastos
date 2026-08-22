using Gastos.Application.Competencias;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class CompetenciaReadRepository(IDbContextFactory<GastosDbContext> contextFactory) : ICompetenciaReadRepository
{
    public async Task<IReadOnlyList<CompetenciaAtivaDto>> ListarAtivasAsync(CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        return await (
            from competencia in context.Competencias.AsNoTracking()
            join cliente in context.Clientes.AsNoTracking() on competencia.ClienteId equals cliente.Id
            where competencia.Ativa
            orderby cliente.Nome
            select new CompetenciaAtivaDto(
                competencia.Id,
                competencia.MesReferencia,
                competencia.ClienteId,
                cliente.Nome))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<CompetenciaDto>> ListarPorClienteAsync(int clienteId, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        return await context.Competencias
            .AsNoTracking()
            .Where(item => item.ClienteId == clienteId)
            .OrderByDescending(item => item.MesReferencia)
            .Select(item => new CompetenciaDto(item.Id, item.MesReferencia, item.ClienteId, item.Ativa))
            .ToListAsync(cancellationToken);
    }
}
