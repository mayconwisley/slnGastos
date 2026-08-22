using Gastos.Application.Movimentacoes;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class MovimentacaoReadRepository(IDbContextFactory<GastosDbContext> factory) : IMovimentacaoReadRepository
{
    public async Task<IReadOnlyList<MovimentacaoDto>> ListarPorCompetenciaAsync(
        int clienteId,
        int competenciaId,
        CancellationToken cancellationToken)
    {
        await using var context = await factory.CreateDbContextAsync(cancellationToken);

        return await context.Movimentacoes
            .AsNoTracking()
            .Where(item => item.ClienteId == clienteId && item.CompetenciaId == competenciaId)
            .OrderByDescending(item => item.DataMovimento)
            .ThenBy(item => item.Descricao)
            .Select(item => new MovimentacaoDto(
                item.Id,
                item.DataMovimento,
                item.Descricao,
                item.Valor,
                item.TipoLancamento,
                item.MeioMonetario,
                item.Situacao,
                item.Origem,
                item.Login,
                item.ClienteId,
                item.CompetenciaId,
                item.DataCadastroUtc))
            .ToListAsync(cancellationToken);
    }
}
