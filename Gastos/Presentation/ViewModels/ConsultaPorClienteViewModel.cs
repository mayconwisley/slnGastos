using System.Collections.ObjectModel;
using System.Windows.Input;
using Gastos.Application.Clientes;

namespace Gastos.Presentation.ViewModels;

public abstract class ConsultaPorClienteViewModel<TItem> : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private ClienteDto? clienteSelecionado;
    private string status = string.Empty;

    protected ConsultaPorClienteViewModel(ListarClientesHandler listarClientesHandler)
    {
        this.listarClientesHandler = listarClientesHandler;
        AtualizarCommand = new AsyncRelayCommand(AtualizarItensAsync);
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ObservableCollection<TItem> Itens { get; } = [];

    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                _ = AtualizarItensAsync();
            }
        }
    }

    public string Status
    {
        get => status;
        private set => SetProperty(ref status, value);
    }

    public ICommand AtualizarCommand { get; }

    public async Task AtivarAsync()
    {
        if (Clientes.Count > 0)
        {
            return;
        }

        try
        {
            var clientes = await listarClientesHandler.HandleAsync(new ListarClientesQuery(), CancellationToken.None);
            Clientes.Clear();

            foreach (var cliente in clientes)
            {
                Clientes.Add(cliente);
            }

            ClienteSelecionado = Clientes.FirstOrDefault();
        }
        catch (Exception exception)
        {
            DefinirStatus($"Não foi possível carregar os clientes: {exception.Message}");
        }
    }

    protected abstract Task<IEnumerable<TItem>> ListarItensAsync(int clienteId, CancellationToken cancellationToken);

    protected virtual Task AoCarregarItensAsync() => Task.CompletedTask;

    protected void DefinirStatus(string mensagem)
    {
        Status = mensagem;
    }

    private async Task AtualizarItensAsync()
    {
        Itens.Clear();
        DefinirStatus(string.Empty);

        if (ClienteSelecionado is null)
        {
            await AoCarregarItensAsync();
            return;
        }

        try
        {
            var itens = await ListarItensAsync(ClienteSelecionado.Id, CancellationToken.None);
            foreach (var item in itens)
            {
                Itens.Add(item);
            }

            await AoCarregarItensAsync();
        }
        catch (Exception exception)
        {
            DefinirStatus($"Não foi possível carregar os dados: {exception.Message}");
        }
    }
}
