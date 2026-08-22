using Gastos.Application.Devedores;
using Gastos.Domain.Devedores;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class DevedorRepository(IDbContextFactory<GastosDbContext> factory) : IDevedorRepository
{
    public async Task AdicionarAsync(Devedor devedor, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await context.Devedores.AddAsync(devedor, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<Devedor?> ObterPorIdAsync(int id, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.Devedores.SingleOrDefaultAsync(devedor => devedor.Id == id, ct);
    }

    public async Task AtualizarAsync(Devedor devedor, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.Devedores.Update(devedor);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoverAsync(Devedor devedor, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.Devedores.Remove(devedor);
        await context.SaveChangesAsync(ct);
    }

    public async Task<bool> PossuiParcelasAsync(int devedorId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.ParcelasDevedores.AnyAsync(parcela => parcela.DevedorId == devedorId, ct);
    }

    public async Task GerarParcelasAsync(Devedor devedor, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await using var transacao = await context.Database.BeginTransactionAsync(ct);

        if (await context.ParcelasDevedores.AnyAsync(parcela => parcela.DevedorId == devedor.Id, ct))
        {
            throw new InvalidOperationException("As parcelas desse devedor já foram geradas.");
        }

        var parcelas = Enumerable.Range(1, devedor.Parcelas)
            .Select(numero => new ParcelaDevedor(
                devedor.Id,
                devedor.DataInicio.AddMonths(numero - 1),
                numero,
                devedor.Valor,
                devedor.Login,
                devedor.DataCadastroUtc));

        await context.ParcelasDevedores.AddRangeAsync(parcelas, ct);
        await context.SaveChangesAsync(ct);
        await transacao.CommitAsync(ct);
    }
}
