using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Emprestimos;
using Gastos.Domain.Common;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class ParcelasEmprestimoViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarEmprestimosPorClienteHandler listarEmprestimosHandler;
    private readonly CadastrarParcelaEmprestimoHandler cadastrarHandler;
    private readonly AtualizarParcelaEmprestimoHandler atualizarHandler;
    private readonly ExcluirParcelaEmprestimoHandler excluirHandler;
    private readonly ExcluirParcelasEmprestimoHandler excluirTodasHandler;
    private readonly QuitarEmprestimoHandler quitarHandler;
    private readonly ListarParcelasEmprestimoHandler listarParcelasHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private EmprestimoDto? emprestimoSelecionado;
    private ParcelaEmprestimoDto? parcelaSelecionada;
    private string dataParcela = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private string numeroParcela = "1";
    private string valor = "0,00";
    private bool pago;
    private string dataPagamento = string.Empty;
    private string status = string.Empty;

    public ParcelasEmprestimoViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarEmprestimosPorClienteHandler listarEmprestimosHandler,
        CadastrarParcelaEmprestimoHandler cadastrarHandler,
        AtualizarParcelaEmprestimoHandler atualizarHandler,
        ExcluirParcelaEmprestimoHandler excluirHandler,
        ExcluirParcelasEmprestimoHandler excluirTodasHandler,
        QuitarEmprestimoHandler quitarHandler,
        ListarParcelasEmprestimoHandler listarParcelasHandler,
        ContextoSessao contextoSessao)
    {
        this.listarClientesHandler = listarClientesHandler;
        this.listarEmprestimosHandler = listarEmprestimosHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.excluirTodasHandler = excluirTodasHandler;
        this.quitarHandler = quitarHandler;
        this.listarParcelasHandler = listarParcelasHandler;
        this.contextoSessao = contextoSessao;
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        ExcluirTodasCommand = new AsyncRelayCommand(ExcluirTodasAsync);
        QuitarCommand = new AsyncRelayCommand(QuitarAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ObservableCollection<EmprestimoDto> Emprestimos { get; } = [];
    public ObservableCollection<ParcelaEmprestimoDto> Parcelas { get; } = [];
    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                EmprestimoSelecionado = null;
                _ = CarregarEmprestimosAsync();
            }
        }
    }

    public EmprestimoDto? EmprestimoSelecionado
    {
        get => emprestimoSelecionado;
        set
        {
            if (SetProperty(ref emprestimoSelecionado, value))
            {
                Limpar();
                _ = CarregarParcelasAsync();
            }
        }
    }

    public ParcelaEmprestimoDto? ParcelaSelecionada
    {
        get => parcelaSelecionada;
        set
        {
            if (SetProperty(ref parcelaSelecionada, value) && value is not null)
            {
                DataParcela = value.DataParcela.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                NumeroParcela = value.Parcela.ToString(CultureInfo.InvariantCulture);
                Valor = value.Valor.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                Pago = value.Pago;
                DataPagamento = value.DataPagamento?.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR")) ?? string.Empty;
            }
        }
    }

    public string DataParcela { get => dataParcela; set => SetProperty(ref dataParcela, value); }
    public string NumeroParcela { get => numeroParcela; set => SetProperty(ref numeroParcela, value); }
    public string Valor { get => valor; set => SetProperty(ref valor, value); }
    public bool Pago
    {
        get => pago;
        set
        {
            if (SetProperty(ref pago, value) && value && string.IsNullOrWhiteSpace(DataPagamento))
            {
                DataPagamento = DataParcela;
            }
        }
    }

    public string DataPagamento { get => dataPagamento; set => SetProperty(ref dataPagamento, value); }
    public decimal Total => Parcelas.Sum(item => item.Valor);
    public decimal TotalPago => Parcelas.Where(item => item.Pago).Sum(item => item.Valor);
    public decimal TotalAberto => Total - TotalPago;
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand ExcluirTodasCommand { get; }
    public ICommand QuitarCommand { get; }
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
        if (!TryObterDados(out var data, out var numero, out var valorInformado, out var pagamento) || EmprestimoSelecionado is null)
        {
            return;
        }

        Result resultado;
        if (ParcelaSelecionada is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(new CadastrarParcelaEmprestimoCommand(EmprestimoSelecionado.Id, data, numero, valorInformado, contextoSessao.Login), CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(new AtualizarParcelaEmprestimoCommand(ParcelaSelecionada.Id, data, numero, valorInformado, Pago, pagamento), CancellationToken.None);
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

        var resultado = await excluirHandler.HandleAsync(new ExcluirParcelaEmprestimoCommand(ParcelaSelecionada.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarParcelasAsync();
        }
    }

    private async Task ExcluirTodasAsync()
    {
        if (EmprestimoSelecionado is null)
        {
            Status = "Selecione um empréstimo.";
            return;
        }

        var resultado = await excluirTodasHandler.HandleAsync(new ExcluirParcelasEmprestimoCommand(EmprestimoSelecionado.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarParcelasAsync();
        }
    }

    private async Task QuitarAsync()
    {
        if (EmprestimoSelecionado is null || !TryObterDataPagamento(out var dataPagamento))
        {
            return;
        }

        var resultado = await quitarHandler.HandleAsync(new QuitarEmprestimoCommand(EmprestimoSelecionado.Id, dataPagamento), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            await CarregarParcelasAsync();
        }
    }

    private bool TryObterDados(out DateOnly data, out int numero, out decimal valorInformado, out DateOnly? pagamento)
    {
        data = default;
        numero = 0;
        valorInformado = 0;
        pagamento = null;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (EmprestimoSelecionado is null || !DateTime.TryParseExact(DataParcela.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataParcela) ||
            !int.TryParse(NumeroParcela, NumberStyles.Integer, cultura, out numero) ||
            !decimal.TryParse(Valor, NumberStyles.Number, cultura, out valorInformado))
        {
            Status = "Informe empréstimo, vencimento, número e valor válidos.";
            return false;
        }

        var dataPagamento = default(DateOnly);
        if (Pago && !TryObterDataPagamento(out dataPagamento))
        {
            return false;
        }

        data = DateOnly.FromDateTime(dataParcela);
        pagamento = Pago ? dataPagamento : null;
        return true;
    }

    private bool TryObterDataPagamento(out DateOnly data)
    {
        if (!DateTime.TryParseExact(DataPagamento.Trim(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var dataInformada))
        {
            data = default;
            Status = "Informe a data de pagamento no formato dd/MM/aaaa.";
            return false;
        }

        data = DateOnly.FromDateTime(dataInformada);
        return true;
    }

    private async Task CarregarEmprestimosAsync()
    {
        Emprestimos.Clear();
        Parcelas.Clear();
        AtualizarTotais();
        if (ClienteSelecionado is null)
        {
            return;
        }

        var emprestimos = await listarEmprestimosHandler.HandleAsync(new ListarEmprestimosPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
        foreach (var emprestimo in emprestimos)
        {
            Emprestimos.Add(emprestimo);
        }
    }

    private async Task CarregarParcelasAsync()
    {
        Parcelas.Clear();
        if (EmprestimoSelecionado is null)
        {
            AtualizarTotais();
            return;
        }

        var parcelas = await listarParcelasHandler.HandleAsync(new ListarParcelasEmprestimoQuery(EmprestimoSelecionado.Id), CancellationToken.None);
        foreach (var parcela in parcelas)
        {
            Parcelas.Add(parcela);
        }
        AtualizarTotais();
    }

    private void AtualizarTotais()
    {
        OnPropertyChanged(nameof(Total));
        OnPropertyChanged(nameof(TotalPago));
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
        Pago = false;
        DataPagamento = string.Empty;
    }
}
