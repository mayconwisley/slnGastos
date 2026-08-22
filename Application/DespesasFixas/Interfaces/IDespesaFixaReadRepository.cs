namespace Gastos.Application.DespesasFixas;

public interface IDespesaFixaReadRepository
{
    Task<IReadOnlyList<DespesaFixaDto>> ListarPorClienteAsync(
        int clienteId,
        CancellationToken cancellationToken);
}
