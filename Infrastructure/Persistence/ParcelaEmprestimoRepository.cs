using Gastos.Application.Emprestimos;
using Gastos.Domain.Emprestimos;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class ParcelaEmprestimoRepository(IDbContextFactory<GastosDbContext> factory) : IParcelaEmprestimoRepository
{
    public async Task AdicionarAsync(ParcelaEmprestimo parcela, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await context.ParcelasEmprestimos.AddAsync(parcela, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<ParcelaEmprestimo?> ObterPorIdAsync(int id, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.ParcelasEmprestimos.SingleOrDefaultAsync(item => item.Id == id, ct);
    }

    public async Task AtualizarAsync(ParcelaEmprestimo parcela, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.ParcelasEmprestimos.Update(parcela);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoverAsync(ParcelaEmprestimo parcela, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.ParcelasEmprestimos.Remove(parcela);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoverPorEmprestimoAsync(int emprestimoId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await context.ParcelasEmprestimos.Where(item => item.EmprestimoId == emprestimoId).ExecuteDeleteAsync(ct);
    }

    public async Task<IReadOnlyList<ParcelaEmprestimoDto>> ListarPorEmprestimoAsync(int emprestimoId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.ParcelasEmprestimos
            .AsNoTracking()
            .Where(item => item.EmprestimoId == emprestimoId)
            .OrderBy(item => item.Parcela)
            .Select(item => new ParcelaEmprestimoDto(item.Id, item.EmprestimoId, item.DataParcela, item.Parcela, item.Valor, item.Pago, item.DataPagamento, item.DataCadastroUtc))
            .ToListAsync(ct);
    }

    public async Task QuitarTodasAsync(int emprestimoId, DateOnly dataPagamento, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await using var transacao = await context.Database.BeginTransactionAsync(ct);
        var parcelas = await context.ParcelasEmprestimos.Where(item => item.EmprestimoId == emprestimoId && !item.Pago).ToListAsync(ct);
        foreach (var parcela in parcelas)
        {
            parcela.Quitar(dataPagamento);
        }

        var emprestimo = await context.Emprestimos.SingleOrDefaultAsync(item => item.Id == emprestimoId, ct);
        if (emprestimo is not null && parcelas.Count > 0)
        {
            emprestimo.Desativar();
            await context.SaveChangesAsync(ct);
        }

        await transacao.CommitAsync(ct);
    }
}
