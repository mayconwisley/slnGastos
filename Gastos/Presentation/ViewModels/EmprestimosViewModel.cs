using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Emprestimos;
using Gastos.Domain.Common;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class EmprestimosViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarEmprestimoHandler cadastrarHandler;
    private readonly AtualizarEmprestimoHandler atualizarHandler;
    private readonly ExcluirEmprestimoHandler excluirHandler;
    private readonly GerarParcelasEmprestimoHandler gerarParcelasHandler;
    private readonly ListarEmprestimosPorClienteHandler listarHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private EmprestimoDto? emprestimoSelecionado;
    private string descricao = string.Empty;
    private string dataInicio = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private string valorEmprestado = "0,00";
    private string valorParcela = "0,00";
    private string parcelas = "1";
    private bool ativo = true;
    private string status = string.Empty;

    public EmprestimosViewModel(
        ListarClientesHandler listarClientesHandler,
        CadastrarEmprestimoHandler cadastrarHandler,
        AtualizarEmprestimoHandler atualizarHandler,
        ExcluirEmprestimoHandler excluirHandler,
        GerarParcelasEmprestimoHandler gerarParcelasHandler,
        ListarEmprestimosPorClienteHandler listarHandler,
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
    public ObservableCollection<EmprestimoDto> Emprestimos { get; } = [];
    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                Limpar();
                _ = CarregarEmprestimosAsync();
            }
        }
    }

    public EmprestimoDto? EmprestimoSelecionado
    {
        get => emprestimoSelecionado;
        set
        {
            if (SetProperty(ref emprestimoSelecionado, value) && value is not null)
            {
                Descricao = value.Descricao;
                DataInicio = value.DataInicio.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                ValorEmprestado = value.ValorEmprestado.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                ValorParcela = value.ValorParcela.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                Parcelas = value.Parcelas.ToString(CultureInfo.InvariantCulture);
                Ativo = value.Ativo;
            }
        }
    }

    public string Descricao { get => descricao; set => SetProperty(ref descricao, value); }
    public string DataInicio { get => dataInicio; set => SetProperty(ref dataInicio, value); }
    public string ValorEmprestado { get => valorEmprestado; set => SetProperty(ref valorEmprestado, value); }
    public string ValorParcela { get => valorParcela; set => SetProperty(ref valorParcela, value); }
    public string Parcelas { get => parcelas; set => SetProperty(ref parcelas, value); }
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
        if (!TryObterDados(out var inicio, out var emprestado, out var parcela, out var quantidade) || ClienteSelecionado is null)
        {
            return;
        }

        Result resultado;
        if (EmprestimoSelecionado is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(new CadastrarEmprestimoCommand(inicio, Descricao, emprestado, parcela, quantidade, Ativo, contextoSessao.Login, ClienteSelecionado.Id), CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(new AtualizarEmprestimoCommand(EmprestimoSelecionado.Id, inicio, Descricao, emprestado, parcela, quantidade, Ativo), CancellationToken.None);
        }

        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarEmprestimosAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (EmprestimoSelecionado is null)
        {
            Status = "Selecione um empréstimo para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirEmprestimoCommand(EmprestimoSelecionado.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarEmprestimosAsync();
        }
    }

    private async Task GerarParcelasAsync()
    {
        if (EmprestimoSelecionado is null)
        {
            Status = "Selecione um empréstimo para gerar as parcelas.";
            return;
        }

        var resultado = await gerarParcelasHandler.HandleAsync(new GerarParcelasEmprestimoCommand(EmprestimoSelecionado.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            await CarregarEmprestimosAsync();
        }
    }

    private bool TryObterDados(out DateOnly inicio, out decimal emprestado, out decimal parcela, out int quantidade)
    {
        inicio = default;
        emprestado = 0;
        parcela = 0;
        quantidade = 0;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (ClienteSelecionado is null || string.IsNullOrWhiteSpace(Descricao) ||
            !DateTime.TryParseExact(DataInicio.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var data) ||
            !decimal.TryParse(ValorEmprestado, NumberStyles.Number, cultura, out emprestado) ||
            !decimal.TryParse(ValorParcela, NumberStyles.Number, cultura, out parcela) ||
            !int.TryParse(Parcelas, NumberStyles.Integer, cultura, out quantidade))
        {
            Status = "Informe cliente, descrição, data, valores e quantidade de parcelas válidos.";
            return false;
        }

        inicio = DateOnly.FromDateTime(data);
        return true;
    }

    private async Task CarregarEmprestimosAsync()
    {
        Emprestimos.Clear();
        if (ClienteSelecionado is null)
        {
            return;
        }

        try
        {
            var emprestimos = await listarHandler.HandleAsync(new ListarEmprestimosPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
            foreach (var emprestimo in emprestimos)
            {
                Emprestimos.Add(emprestimo);
            }
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar os empréstimos: {exception.Message}";
        }
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        EmprestimoSelecionado = null;
        Descricao = string.Empty;
        DataInicio = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        ValorEmprestado = "0,00";
        ValorParcela = "0,00";
        Parcelas = "1";
        Ativo = true;
    }
}
