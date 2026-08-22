using Gastos.Domain.DespesasFixas;
namespace Gastos.Application.DespesasFixas;
public interface IDespesaFixaRepository { Task AdicionarAsync(DespesaFixa despesa, CancellationToken ct); Task<DespesaFixa?> ObterPorIdAsync(int id, CancellationToken ct); Task AtualizarAsync(DespesaFixa despesa, CancellationToken ct); Task RemoverAsync(DespesaFixa despesa, CancellationToken ct); }
