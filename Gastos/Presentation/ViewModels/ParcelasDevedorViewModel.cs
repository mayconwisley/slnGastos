using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Devedores;
using Gastos.Domain.Common;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class ParcelasDevedorViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarDevedoresPorClienteHandler listarDevedoresHandler;
    private readonly CadastrarParcelaDevedorHandler cadastrarHandler;
    private readonly AtualizarParcelaDevedorHandler atualizarHandler;
    private readonly ExcluirParcelaDevedorHandler excluirHandler;
    private readonly ExcluirParcelasDevedorHandler excluirTodasHandler;
    private readonly ListarParcelasDevedorHandler listarParcelasHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private DevedorDto? devedorSelecionado;
    private ParcelaDevedorDto? parcelaSelecionada;
    private string dataParcela = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private string numeroParcela = "1";
    private string valor = "0,00";
    private bool recebido;
    private string dataRecebido = string.Empty;
    private string status = string.Empty;

    public ParcelasDevedorViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarDevedoresPorClienteHandler listarDevedoresHandler,
        CadastrarParcelaDevedorHandler cadastrarHandler,
        AtualizarParcelaDevedorHandler atualizarHandler,
        ExcluirParcelaDevedorHandler excluirHandler,
        ExcluirParcelasDevedorHandler excluirTodasHandler,
        ListarParcelasDevedorHandler listarParcelasHandler,
        ContextoSessao contextoSessao)
    {
        this.listarClientesHandler = listarClientesHandler;
        this.listarDevedoresHandler = listarDevedoresHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.excluirTodasHandler = excluirTodasHandler;
        this.listarParcelasHandler = listarParcelasHandler;
        this.contextoSessao = contextoSessao;
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        ExcluirTodasCommand = new AsyncRelayCommand(ExcluirTodasAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ObservableCollection<DevedorDto> Devedores { get; } = [];
    public ObservableCollection<ParcelaDevedorDto> Parcelas { get; } = [];
    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                DevedorSelecionado = null;
                _ = CarregarDevedoresAsync();
            }
        }
    }

    public DevedorDto? DevedorSelecionado
    {
        get => devedorSelecionado;
        set
        {
            if (SetProperty(ref devedorSelecionado, value))
            {
                Limpar();
                _ = CarregarParcelasAsync();
            }
        }
    }

    public ParcelaDevedorDto? ParcelaSelecionada
    {
        get => parcelaSelecionada;
        set
        {
            if (SetProperty(ref parcelaSelecionada, value) && value is not null)
            {
                DataParcela = value.DataParcela.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                NumeroParcela = value.Parcela.ToString(CultureInfo.InvariantCulture);
                Valor = value.Valor.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                Recebido = value.Recebido;
                DataRecebido = value.DataRecebido?.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR")) ?? string.Empty;
            }
        }
    }

    public string DataParcela { get => dataParcela; set => SetProperty(ref dataParcela, value); }
    public string NumeroParcela { get => numeroParcela; set => SetProperty(ref numeroParcela, value); }
    public string Valor { get => valor; set => SetProperty(ref valor, value); }
    public bool Recebido
    {
        get => recebido;
        set
        {
            if (SetProperty(ref recebido, value) && value && string.IsNullOrWhiteSpace(DataRecebido))
            {
                DataRecebido = DataParcela;
            }
        }
    }

    public string DataRecebido { get => dataRecebido; set => SetProperty(ref dataRecebido, value); }
    public decimal Total => Parcelas.Sum(item => item.Valor);
    public decimal TotalRecebido => Parcelas.Where(item => item.Recebido).Sum(item => item.Valor);
    public decimal TotalAberto => Total - TotalRecebido;
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand ExcluirTodasCommand { get; }
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
        if (!TryObterDados(out var data, out var numero, out var valorInformado, out var dataRecebimento) || DevedorSelecionado is null)
        {
            return;
        }

        Result resultado;
        if (ParcelaSelecionada is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(new CadastrarParcelaDevedorCommand(DevedorSelecionado.Id, data, numero, valorInformado, contextoSessao.Login), CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(new AtualizarParcelaDevedorCommand(ParcelaSelecionada.Id, data, numero, valorInformado, Recebido, dataRecebimento), CancellationToken.None);
        }

        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarParcelasAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (ParcelaSelecionada is null)
        {
            Status = "Selecione uma parcela para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirParcelaDevedorCommand(ParcelaSelecionada.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarParcelasAsync();
        }
    }

    private async Task ExcluirTodasAsync()
    {
        if (DevedorSelecionado is null)
        {
            Status = "Selecione um devedor.";
            return;
        }

        var resultado = await excluirTodasHandler.HandleAsync(new ExcluirParcelasDevedorCommand(DevedorSelecionado.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarParcelasAsync();
        }
    }

    private bool TryObterDados(out DateOnly data, out int numero, out decimal valorInformado, out DateOnly? dataRecebimento)
    {
        data = default;
        numero = 0;
        valorInformado = 0;
        dataRecebimento = null;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (DevedorSelecionado is null || !DateTime.TryParseExact(DataParcela.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataParcela) ||
            !int.TryParse(NumeroParcela, NumberStyles.Integer, cultura, out numero) ||
            !decimal.TryParse(Valor, NumberStyles.Number, cultura, out valorInformado))
        {
            Status = "Informe devedor, vencimento, número e valor válidos.";
            return false;
        }

        var dataInformada = default(DateOnly);
        if (Recebido && !TryObterDataRecebido(out dataInformada))
        {
            return false;
        }

        data = DateOnly.FromDateTime(dataParcela);
        dataRecebimento = Recebido ? dataInformada : null;
        return true;
    }

    private bool TryObterDataRecebido(out DateOnly data)
    {
        if (!DateTime.TryParseExact(DataRecebido.Trim(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var dataInformada))
        {
            data = default;
            Status = "Informe a data de recebimento no formato dd/MM/aaaa.";
            return false;
        }

        data = DateOnly.FromDateTime(dataInformada);
        return true;
    }

    private async Task CarregarDevedoresAsync()
    {
        Devedores.Clear();
        Parcelas.Clear();
        AtualizarTotais();
        if (ClienteSelecionado is null)
        {
            return;
        }

        var devedores = await listarDevedoresHandler.HandleAsync(new ListarDevedoresPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
        foreach (var devedor in devedores)
        {
            Devedores.Add(devedor);
        }
    }

    private async Task CarregarParcelasAsync()
    {
        Parcelas.Clear();
        if (DevedorSelecionado is null)
        {
            AtualizarTotais();
            return;
        }

        var parcelas = await listarParcelasHandler.HandleAsync(new ListarParcelasDevedorQuery(DevedorSelecionado.Id), CancellationToken.None);
        foreach (var parcela in parcelas)
        {
            Parcelas.Add(parcela);
        }
        AtualizarTotais();
    }

    private void AtualizarTotais()
    {
        OnPropertyChanged(nameof(Total));
        OnPropertyChanged(nameof(TotalRecebido));
        OnPropertyChanged(nameof(TotalAberto));
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        ParcelaSelecionada = null;
        DataParcela = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        NumeroParcela = "1";
        Valor = "0,00";
        Recebido = false;
        DataRecebido = string.Empty;
    }
}
