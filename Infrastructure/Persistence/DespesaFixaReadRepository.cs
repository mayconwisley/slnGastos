using Gastos.Application.DespesasFixas;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class DespesaFixaReadRepository(IDbContextFactory<GastosDbContext> factory) : IDespesaFixaReadRepository
{
    public async Task<IReadOnlyList<DespesaFixaDto>> ListarPorClienteAsync(
        int clienteId,
        CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);

        return await context.DespesasFixas
            .AsNoTracking()
            .Where(item => item.ClienteId == clienteId)
            .OrderByDescending(item => item.DataInicio)
            .ThenBy(item => item.Descricao)
            .Select(item => new DespesaFixaDto(
                item.Id,
                item.DataInicio,
                item.Descricao,
                item.Valor,
                item.DataFim,
                item.DataFim == null,
                item.Login,
                item.ClienteId,
                item.DataCadastroUtc))
            .ToListAsync(cancellationToken);
    }
}
