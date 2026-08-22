using System.Collections.ObjectModel;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Domain.Common;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class ClientesViewModel : ObservableObject, IAtivavel
{
    private readonly CadastrarClienteHandler cadastrarHandler;
    private readonly AtualizarClienteHandler atualizarHandler;
    private readonly ExcluirClienteHandler excluirHandler;
    private readonly ListarClientesHandler listarHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private string nome = string.Empty;
    private bool ativo = true;
    private string status = string.Empty;

    public ClientesViewModel(CadastrarClienteHandler cadastrarHandler, AtualizarClienteHandler atualizarHandler, ExcluirClienteHandler excluirHandler, ListarClientesHandler listarHandler, ContextoSessao contextoSessao)
    {
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
        this.contextoSessao = contextoSessao;
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value) && value is not null)
            {
                Nome = value.Nome;
                Ativo = value.Ativo;
            }
        }
    }

    public string Nome { get => nome; set => SetProperty(ref nome, value); }
    public bool Ativo { get => ativo; set => SetProperty(ref ativo, value); }
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand LimparCommand { get; }

    public Task AtivarAsync() => CarregarAsync();

    private async Task SalvarAsync()
    {
        Result resultado = ClienteSelecionado is null
            ? await CriarAsync()
            : await atualizarHandler.HandleAsync(new AtualizarClienteCommand(ClienteSelecionado.Id, Nome, Ativo), CancellationToken.None);

        if (!ExibirResultado(resultado))
        {
            return;
        }

        Limpar();
        await CarregarAsync();
    }

    private async Task<Result> CriarAsync()
    {
        var resultado = await cadastrarHandler.HandleAsync(new CadastrarClienteCommand(Nome, contextoSessao.Login, Ativo), CancellationToken.None);
        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private async Task ExcluirAsync()
    {
        if (ClienteSelecionado is null)
        {
            Status = "Selecione um cliente para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirClienteCommand(ClienteSelecionado.Id), CancellationToken.None);
        if (!ExibirResultado(resultado))
        {
            return;
        }

        Limpar();
        await CarregarAsync();
    }

    private async Task CarregarAsync()
    {
        try
        {
            var clientes = await listarHandler.HandleAsync(new ListarClientesQuery(), CancellationToken.None);
            Clientes.Clear();
            foreach (var cliente in clientes)
            {
                Clientes.Add(cliente);
            }
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar os clientes: {exception.Message}";
        }
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess
            ? "Operação concluída com sucesso."
            : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        ClienteSelecionado = null;
        Nome = string.Empty;
        Ativo = true;
    }
}
