using Gastos.Application.Devedores;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class DevedorReadRepository(IDbContextFactory<GastosDbContext> factory) : IDevedorReadRepository
{
    public async Task<IReadOnlyList<DevedorDto>> ListarPorClienteAsync(int clienteId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);

        return await context.Devedores
            .AsNoTracking()
            .Where(devedor => devedor.ClienteId == clienteId)
            .OrderBy(devedor => devedor.Nome)
            .Select(devedor => new DevedorDto(
                devedor.Id,
                devedor.Nome,
                devedor.Descricao,
                devedor.Valor,
                devedor.Parcelas,
                devedor.DataInicio,
                devedor.Ativo,
                devedor.Login,
                devedor.ClienteId,
                devedor.DataCadastroUtc,
                context.ParcelasDevedores.Any(parcela => parcela.DevedorId == devedor.Id)))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<ResumoDevedorDto>> ListarResumoPorClienteAsync(int clienteId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);

        return await (
            from parcela in context.ParcelasDevedores.AsNoTracking()
            join devedor in context.Devedores.AsNoTracking() on parcela.DevedorId equals devedor.Id
            where devedor.ClienteId == clienteId
            group parcela by new { parcela.DevedorId, devedor.Nome, parcela.Recebido } into grupo
            orderby grupo.Key.Nome
            select new ResumoDevedorDto(grupo.Key.DevedorId, grupo.Key.Nome, grupo.Sum(item => item.Valor), grupo.Key.Recebido))
            .ToListAsync(ct);
    }
}
