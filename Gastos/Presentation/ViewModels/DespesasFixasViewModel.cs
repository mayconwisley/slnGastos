using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.DespesasFixas;
using Gastos.Domain.Common;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class DespesasFixasViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarDespesaFixaHandler cadastrarHandler;
    private readonly AtualizarDespesaFixaHandler atualizarHandler;
    private readonly ExcluirDespesaFixaHandler excluirHandler;
    private readonly ListarDespesasFixasPorClienteHandler listarHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private DespesaFixaDto? despesaSelecionada;
    private string descricao = string.Empty;
    private string valor = "0,00";
    private string dataInicio = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private string dataFim = string.Empty;
    private string status = string.Empty;

    public DespesasFixasViewModel(
        ListarClientesHandler listarClientesHandler,
        CadastrarDespesaFixaHandler cadastrarHandler,
        AtualizarDespesaFixaHandler atualizarHandler,
        ExcluirDespesaFixaHandler excluirHandler,
        ListarDespesasFixasPorClienteHandler listarHandler,
        ContextoSessao contextoSessao)
    {
        this.listarClientesHandler = listarClientesHandler;
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
    public ObservableCollection<DespesaFixaDto> Despesas { get; } = [];

    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                Limpar();
                _ = CarregarDespesasAsync();
            }
        }
    }

    public DespesaFixaDto? DespesaSelecionada
    {
        get => despesaSelecionada;
        set
        {
            if (SetProperty(ref despesaSelecionada, value) && value is not null)
            {
                Descricao = value.Descricao;
                Valor = value.Valor.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                DataInicio = value.DataInicio.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                DataFim = value.DataFim?.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR")) ?? string.Empty;
            }
        }
    }

    public string Descricao { get => descricao; set => SetProperty(ref descricao, value); }
    public string Valor { get => valor; set => SetProperty(ref valor, value); }
    public string DataInicio { get => dataInicio; set => SetProperty(ref dataInicio, value); }
    public string DataFim { get => dataFim; set => SetProperty(ref dataFim, value); }
    public decimal TotalAtivo => Despesas.Where(item => item.Ativa).Sum(item => item.Valor);
    public decimal TotalInativo => Despesas.Where(item => !item.Ativa).Sum(item => item.Valor);
    public decimal TotalGeral => Despesas.Sum(item => item.Valor);
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
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
        if (!TryObterDados(out var inicio, out var fim, out var valorInformado) || ClienteSelecionado is null)
        {
            return;
        }

        Result resultado;
        if (DespesaSelecionada is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(
                new CadastrarDespesaFixaCommand(inicio, Descricao, valorInformado, fim, contextoSessao.Login, ClienteSelecionado.Id),
                CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(
                new AtualizarDespesaFixaCommand(DespesaSelecionada.Id, inicio, Descricao, valorInformado, fim),
                CancellationToken.None);
        }

        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarDespesasAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (DespesaSelecionada is null)
        {
            Status = "Selecione uma despesa fixa para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirDespesaFixaCommand(DespesaSelecionada.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarDespesasAsync();
        }
    }

    private bool TryObterDados(out DateOnly inicio, out DateOnly? fim, out decimal valorInformado)
    {
        inicio = default;
        fim = null;
        valorInformado = 0;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (ClienteSelecionado is null)
        {
            Status = "Selecione um cliente.";
            return false;
        }

        if (!DateTime.TryParseExact(DataInicio.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataInicial))
        {
            Status = "Informe uma data inicial válida no formato dd/MM/aaaa.";
            return false;
        }

        if (!decimal.TryParse(Valor, NumberStyles.Number, cultura, out valorInformado))
        {
            Status = "Informe um valor válido.";
            return false;
        }

        if (!string.IsNullOrWhiteSpace(DataFim))
        {
            if (!DateTime.TryParseExact(DataFim.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataFinal))
            {
                Status = "Informe uma data final válida no formato dd/MM/aaaa.";
                return false;
            }

            fim = DateOnly.FromDateTime(dataFinal);
        }

        inicio = DateOnly.FromDateTime(dataInicial);
        return true;
    }

    private async Task CarregarDespesasAsync()
    {
        Despesas.Clear();
        if (ClienteSelecionado is null)
        {
            AtualizarTotais();
            return;
        }

        try
        {
            var despesas = await listarHandler.HandleAsync(new ListarDespesasFixasPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
            foreach (var despesa in despesas)
            {
                Despesas.Add(despesa);
            }
            AtualizarTotais();
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar as despesas: {exception.Message}";
        }
    }

    private void AtualizarTotais()
    {
        OnPropertyChanged(nameof(TotalAtivo));
        OnPropertyChanged(nameof(TotalInativo));
        OnPropertyChanged(nameof(TotalGeral));
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        DespesaSelecionada = null;
        Descricao = string.Empty;
        Valor = "0,00";
        DataInicio = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        DataFim = string.Empty;
    }
}
