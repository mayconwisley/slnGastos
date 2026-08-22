namespace Gastos.Application.Movimentacoes;

public interface IMovimentacaoReadRepository
{
    Task<IReadOnlyList<MovimentacaoDto>> ListarPorCompetenciaAsync(
        int clienteId,
        int competenciaId,
        CancellationToken cancellationToken);
}
