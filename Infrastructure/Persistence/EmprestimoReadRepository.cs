using Gastos.Application.Emprestimos;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class EmprestimoReadRepository(IDbContextFactory<GastosDbContext> factory) : IEmprestimoReadRepository
{
    public async Task<IReadOnlyList<EmprestimoDto>> ListarPorClienteAsync(int clienteId, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);

        return await context.Emprestimos
            .AsNoTracking()
            .Where(emprestimo => emprestimo.ClienteId == clienteId)
            .OrderByDescending(emprestimo => emprestimo.DataInicio)
            .Select(emprestimo => new EmprestimoDto(
                emprestimo.Id,
                emprestimo.DataInicio,
                emprestimo.Descricao,
                emprestimo.ValorEmprestado,
                emprestimo.ValorParcela,
                emprestimo.Parcelas,
                emprestimo.Ativo,
                emprestimo.Login,
                emprestimo.ClienteId,
                emprestimo.DataCadastroUtc,
                context.ParcelasEmprestimos.Any(parcela => parcela.EmprestimoId == emprestimo.Id),
                context.ParcelasEmprestimos
                    .Where(parcela => parcela.EmprestimoId == emprestimo.Id && parcela.Pago)
                    .Select(parcela => (decimal?)parcela.Valor)
                    .Sum() ?? 0m))
            .ToListAsync(ct);
    }
}
