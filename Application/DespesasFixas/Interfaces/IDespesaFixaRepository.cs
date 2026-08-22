using Gastos.Domain.DespesasFixas;

namespace Gastos.Application.DespesasFixas;

public interface IDespesaFixaRepository
{
    Task AdicionarAsync(DespesaFixa despesa, CancellationToken cancellationToken);

    Task<DespesaFixa?> ObterPorIdAsync(int id, CancellationToken cancellationToken);

    Task AtualizarAsync(DespesaFixa despesa, CancellationToken cancellationToken);

    Task RemoverAsync(DespesaFixa despesa, CancellationToken cancellationToken);
}
