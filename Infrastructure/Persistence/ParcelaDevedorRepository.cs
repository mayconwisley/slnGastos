using Gastos.Application.Devedores;
using Gastos.Domain.Devedores;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class ParcelaDevedorRepository(IDbContextFactory<GastosDbContext> factory) : IParcelaDevedorRepository
{
    public async Task AdicionarAsync(ParcelaDevedor parcela, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await context.ParcelasDevedores.AddAsync(parcela, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<ParcelaDevedor?> ObterPorIdAsync(int id, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.ParcelasDevedores.SingleOrDefaultAsync(item => item.Id == id, ct);
    }

    public async Task AtualizarAsync(ParcelaDevedor parcela, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.ParcelasDevedores.Update(parcela);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoverAsync(ParcelaDevedor parcela, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.ParcelasDevedores.Remove(parcela);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoverPorDevedorAsync(int devedorId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await context.ParcelasDevedores.Where(item => item.DevedorId == devedorId).ExecuteDeleteAsync(ct);
    }

    public async Task<IReadOnlyList<ParcelaDevedorDto>> ListarPorDevedorAsync(int devedorId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await (
            from parcela in context.ParcelasDevedores.AsNoTracking()
            join devedor in context.Devedores.AsNoTracking() on parcela.DevedorId equals devedor.Id
            where parcela.DevedorId == devedorId
            orderby parcela.Parcela
            select new ParcelaDevedorDto(parcela.Id, parcela.DevedorId, parcela.DataParcela, parcela.Parcela, parcela.Valor, parcela.Recebido, parcela.DataRecebido, parcela.DataCadastroUtc, devedor.Descricao))
            .ToListAsync(ct);
    }
}
