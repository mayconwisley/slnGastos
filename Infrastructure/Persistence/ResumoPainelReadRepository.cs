using Gastos.Application.Painel;
using Gastos.Domain.Movimentacoes;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class ResumoPainelReadRepository(IDbContextFactory<GastosDbContext> factory) : IResumoPainelReadRepository
{
    public async Task<ResumoPainelDto?> ObterAsync(int clienteId, DateOnly mesReferencia, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        var competencia = await context.Competencias
            .AsNoTracking()
            .SingleOrDefaultAsync(item => item.ClienteId == clienteId && item.MesReferencia == mesReferencia, ct);
        if (competencia is null)
        {
            return null;
        }

        var inicioMes = new DateOnly(mesReferencia.Year, mesReferencia.Month, 1);
        var fimMes = inicioMes.AddMonths(1);
        var despesasFixas = await context.DespesasFixas
            .AsNoTracking()
            .Where(item => item.ClienteId == clienteId && item.DataInicio < fimMes && (item.DataFim == null || item.DataFim >= inicioMes))
            .SumAsync(item => (decimal?)item.Valor, ct) ?? 0m;

        var emprestimosEmAberto = await (
            from parcela in context.ParcelasEmprestimos.AsNoTracking()
            join emprestimo in context.Emprestimos.AsNoTracking() on parcela.EmprestimoId equals emprestimo.Id
            where emprestimo.ClienteId == clienteId && emprestimo.Ativo && !parcela.Pago && parcela.DataParcela >= inicioMes && parcela.DataParcela < fimMes
            select parcela.Valor).SumAsync(item => (decimal?)item, ct) ?? 0m;

        var debitosDevedores = await (
            from parcela in context.ParcelasDevedores.AsNoTracking()
            join devedor in context.Devedores.AsNoTracking() on parcela.DevedorId equals devedor.Id
            where devedor.ClienteId == clienteId && devedor.Ativo && !parcela.Recebido && parcela.DataParcela >= inicioMes && parcela.DataParcela < fimMes
            select parcela.Valor).SumAsync(item => (decimal?)item, ct) ?? 0m;

        var creditosDevedores = await (
            from parcela in context.ParcelasDevedores.AsNoTracking()
            join devedor in context.Devedores.AsNoTracking() on parcela.DevedorId equals devedor.Id
            where devedor.ClienteId == clienteId && devedor.Ativo && parcela.Recebido && parcela.DataParcela >= inicioMes && parcela.DataParcela < fimMes
            select parcela.Valor).SumAsync(item => (decimal?)item, ct) ?? 0m;

        var movimentosAteCompetencia =
            from movimentacao in context.Movimentacoes.AsNoTracking()
            join competenciaMovimento in context.Competencias.AsNoTracking() on movimentacao.CompetenciaId equals competenciaMovimento.Id
            where movimentacao.ClienteId == clienteId && competenciaMovimento.MesReferencia <= mesReferencia
            select movimentacao;

        var recebidos = await movimentosAteCompetencia
            .Where(item => item.Situacao == SituacaoFinanceira.Recebido)
            .SumAsync(item => (decimal?)item.Valor, ct) ?? 0m;
        var pagos = await movimentosAteCompetencia
            .Where(item => item.Situacao == SituacaoFinanceira.Pago)
            .SumAsync(item => (decimal?)item.Valor, ct) ?? 0m;

        return new ResumoPainelDto(
            competencia.Id,
            competencia.MesReferencia,
            despesasFixas,
            emprestimosEmAberto,
            debitosDevedores,
            creditosDevedores,
            recebidos - pagos - emprestimosEmAberto - despesasFixas - debitosDevedores);
    }
}
