using Gastos.Application.Clientes;
using Gastos.Application.DespesasFixas;

namespace Gastos.Presentation.ViewModels;

public sealed class ConsultaDespesasFixasViewModel : ConsultaPorClienteViewModel<DespesaFixaDto>
{
    private readonly ListarDespesasFixasPorClienteHandler listarDespesasHandler;

    public ConsultaDespesasFixasViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarDespesasFixasPorClienteHandler listarDespesasHandler)
        : base(listarClientesHandler)
    {
        this.listarDespesasHandler = listarDespesasHandler;
    }

    public decimal TotalAtivo => Itens.Where(item => item.Ativa).Sum(item => item.Valor);
    public decimal TotalInativo => Itens.Where(item => !item.Ativa).Sum(item => item.Valor);
    public decimal TotalGeral => Itens.Sum(item => item.Valor);

    protected override async Task<IEnumerable<DespesaFixaDto>> ListarItensAsync(int clienteId, CancellationToken cancellationToken)
    {
        return await listarDespesasHandler.HandleAsync(new ListarDespesasFixasPorClienteQuery(clienteId), cancellationToken);
    }

    protected override Task AoCarregarItensAsync()
    {
        OnPropertyChanged(nameof(TotalAtivo));
        OnPropertyChanged(nameof(TotalInativo));
        OnPropertyChanged(nameof(TotalGeral));
        return Task.CompletedTask;
    }
}
