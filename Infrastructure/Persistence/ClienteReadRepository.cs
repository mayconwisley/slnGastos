using Gastos.Application.Clientes;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class ClienteReadRepository(IDbContextFactory<GastosDbContext> contextFactory) : IClienteReadRepository
{
    public async Task<IReadOnlyList<ClienteDto>> ListarAsync(CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        return await context.Clientes
            .AsNoTracking()
            .OrderBy(item => item.Nome)
            .Select(item => new ClienteDto(item.Id, item.Nome, item.Login, item.Ativo, item.DataCadastroUtc))
            .ToListAsync(cancellationToken);
    }
}
