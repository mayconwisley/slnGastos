using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Devedores;
using Gastos.Domain.Common;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class DevedoresViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarDevedorHandler cadastrarHandler;
    private readonly AtualizarDevedorHandler atualizarHandler;
    private readonly ExcluirDevedorHandler excluirHandler;
    private readonly GerarParcelasDevedorHandler gerarParcelasHandler;
    private readonly ListarDevedoresPorClienteHandler listarHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private DevedorDto? devedorSelecionado;
    private string nome = string.Empty;
    private string descricao = string.Empty;
    private string valor = "0,00";
    private string parcelas = "1";
    private string dataInicio = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private bool ativo = true;
    private string status = string.Empty;

    public DevedoresViewModel(
        ListarClientesHandler listarClientesHandler,
        CadastrarDevedorHandler cadastrarHandler,
        AtualizarDevedorHandler atualizarHandler,
        ExcluirDevedorHandler excluirHandler,
        GerarParcelasDevedorHandler gerarParcelasHandler,
        ListarDevedoresPorClienteHandler listarHandler,
        ContextoSessao contextoSessao)
    {
        this.listarClientesHandler = listarClientesHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.gerarParcelasHandler = gerarParcelasHandler;
        this.listarHandler = listarHandler;
        this.contextoSessao = contextoSessao;
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        GerarParcelasCommand = new AsyncRelayCommand(GerarParcelasAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ObservableCollection<DevedorDto> Devedores { get; } = [];
    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                Limpar();
                _ = CarregarDevedoresAsync();
            }
        }
    }

    public DevedorDto? DevedorSelecionado
    {
        get => devedorSelecionado;
        set
        {
            if (SetProperty(ref devedorSelecionado, value) && value is not null)
            {
                Nome = value.Nome;
                Descricao = value.Descricao;
                Valor = value.Valor.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                Parcelas = value.Parcelas.ToString(CultureInfo.InvariantCulture);
                DataInicio = value.DataInicio.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                Ativo = value.Ativo;
            }
        }
    }

    public string Nome { get => nome; set => SetProperty(ref nome, value); }
    public string Descricao { get => descricao; set => SetProperty(ref descricao, value); }
    public string Valor { get => valor; set => SetProperty(ref valor, value); }
    public string Parcelas { get => parcelas; set => SetProperty(ref parcelas, value); }
    public string DataInicio { get => dataInicio; set => SetProperty(ref dataInicio, value); }
    public bool Ativo { get => ativo; set => SetProperty(ref ativo, value); }
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand GerarParcelasCommand { get; }
    public ICommand LimparCommand { get; }

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
            Status = $"Não foi possível carregar os clientes: {exception.Message}";
        }
    }

    private async Task SalvarAsync()
    {
        if (!TryObterDados(out var valorInformado, out var quantidade, out var inicio) || ClienteSelecionado is null)
        {
            return;
        }

        Result resultado;
        if (DevedorSelecionado is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(new CadastrarDevedorCommand(Nome, Descricao, valorInformado, quantidade, inicio, Ativo, contextoSessao.Login, ClienteSelecionado.Id), CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(new AtualizarDevedorCommand(DevedorSelecionado.Id, Nome, Descricao, valorInformado, quantidade, inicio, Ativo), CancellationToken.None);
        }

        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarDevedoresAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (DevedorSelecionado is null)
        {
            Status = "Selecione um devedor para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirDevedorCommand(DevedorSelecionado.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarDevedoresAsync();
        }
    }

    private async Task GerarParcelasAsync()
    {
        if (DevedorSelecionado is null)
        {
            Status = "Selecione um devedor para gerar as parcelas.";
            return;
        }

        var resultado = await gerarParcelasHandler.HandleAsync(new GerarParcelasDevedorCommand(DevedorSelecionado.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            await CarregarDevedoresAsync();
        }
    }

    private bool TryObterDados(out decimal valorInformado, out int quantidade, out DateOnly inicio)
    {
        valorInformado = 0;
        quantidade = 0;
        inicio = default;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (ClienteSelecionado is null || string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Descricao) ||
            !decimal.TryParse(Valor, NumberStyles.Number, cultura, out valorInformado) ||
            !int.TryParse(Parcelas, NumberStyles.Integer, cultura, out quantidade) ||
            !DateTime.TryParseExact(DataInicio.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var data))
        {
            Status = "Informe cliente, nome, descrição, data, valor e parcelas válidos.";
            return false;
        }

        inicio = DateOnly.FromDateTime(data);
        return true;
    }

    private async Task CarregarDevedoresAsync()
    {
        Devedores.Clear();
        if (ClienteSelecionado is null)
        {
            return;
        }

        try
        {
            var devedores = await listarHandler.HandleAsync(new ListarDevedoresPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
            foreach (var devedor in devedores)
            {
                Devedores.Add(devedor);
            }
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar os devedores: {exception.Message}";
        }
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        DevedorSelecionado = null;
        Nome = string.Empty;
        Descricao = string.Empty;
        Valor = "0,00";
        Parcelas = "1";
        DataInicio = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        Ativo = true;
    }
}
