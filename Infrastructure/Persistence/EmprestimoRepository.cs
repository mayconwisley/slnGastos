using Gastos.Application.Emprestimos;
using Gastos.Domain.Emprestimos;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class EmprestimoRepository(IDbContextFactory<GastosDbContext> factory) : IEmprestimoRepository
{
    public async Task AdicionarAsync(Emprestimo emprestimo, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        await context.Emprestimos.AddAsync(emprestimo, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Emprestimo?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.Emprestimos.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task AtualizarAsync(Emprestimo emprestimo, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Emprestimos.Update(emprestimo);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoverAsync(Emprestimo emprestimo, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Emprestimos.Remove(emprestimo);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> PossuiParcelasAsync(int emprestimoId, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.ParcelasEmprestimos
            .AnyAsync(item => item.EmprestimoId == emprestimoId, cancellationToken);
    }

    public async Task GerarParcelasAsync(Emprestimo emprestimo, CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var parcelasExistentes = await context.ParcelasEmprestimos
            .AnyAsync(item => item.EmprestimoId == emprestimo.Id, cancellationToken);

        if (parcelasExistentes)
        {
            throw new InvalidOperationException("As parcelas desse empréstimo já foram geradas.");
        }

        var parcelas = Enumerable.Range(1, emprestimo.Parcelas)
            .Select(numeroParcela => new ParcelaEmprestimo(
                emprestimo.Id,
                emprestimo.DataInicio.AddMonths(numeroParcela - 1),
                numeroParcela,
                emprestimo.ValorParcela,
                emprestimo.Login,
                emprestimo.DataCadastroUtc));

        await context.ParcelasEmprestimos.AddRangeAsync(parcelas, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
