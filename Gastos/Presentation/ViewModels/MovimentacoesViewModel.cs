using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.Movimentacoes;
using Gastos.Domain.Common;
using Gastos.Domain.Movimentacoes;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class MovimentacoesViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarCompetenciasPorClienteHandler listarCompetenciasHandler;
    private readonly CadastrarMovimentacaoHandler cadastrarHandler;
    private readonly AtualizarMovimentacaoHandler atualizarHandler;
    private readonly ExcluirMovimentacaoHandler excluirHandler;
    private readonly ListarMovimentacoesPorCompetenciaHandler listarHandler;
    private readonly ContextoSessao contextoSessao;
    private ClienteDto? clienteSelecionado;
    private CompetenciaDto? competenciaAtiva;
    private MovimentacaoDto? movimentacaoSelecionada;
    private string descricao = string.Empty;
    private string valor = "0,00";
    private string dataMovimento = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private TipoLancamento tipoLancamento;
    private MeioMonetario meioMonetario;
    private SituacaoFinanceira situacao;
    private string status = string.Empty;

    public MovimentacoesViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarCompetenciasPorClienteHandler listarCompetenciasHandler,
        CadastrarMovimentacaoHandler cadastrarHandler,
        AtualizarMovimentacaoHandler atualizarHandler,
        ExcluirMovimentacaoHandler excluirHandler,
        ListarMovimentacoesPorCompetenciaHandler listarHandler,
        ContextoSessao contextoSessao)
    {
        this.listarClientesHandler = listarClientesHandler;
        this.listarCompetenciasHandler = listarCompetenciasHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
        this.contextoSessao = contextoSessao;
        TiposLancamento = Enum.GetValues<TipoLancamento>();
        MeiosMonetarios = Enum.GetValues<MeioMonetario>();
        Situacoes = Enum.GetValues<SituacaoFinanceira>();
        Limpar();
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
        AtualizarCommand = new AsyncRelayCommand(CarregarMovimentacoesAsync);
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ObservableCollection<MovimentacaoDto> Movimentacoes { get; } = [];
    public IReadOnlyList<TipoLancamento> TiposLancamento { get; }
    public IReadOnlyList<MeioMonetario> MeiosMonetarios { get; }
    public IReadOnlyList<SituacaoFinanceira> Situacoes { get; }

    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                Limpar();
                _ = CarregarCompetenciaEMovimentacoesAsync();
            }
        }
    }

    public MovimentacaoDto? MovimentacaoSelecionada
    {
        get => movimentacaoSelecionada;
        set
        {
            if (SetProperty(ref movimentacaoSelecionada, value) && value is not null)
            {
                Descricao = value.Descricao;
                Valor = value.Valor.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
                DataMovimento = value.DataMovimento.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                TipoLancamento = value.TipoLancamento;
                MeioMonetario = value.MeioMonetario;
                Situacao = value.Situacao;
            }
        }
    }

    public string Descricao { get => descricao; set => SetProperty(ref descricao, value); }
    public string Valor { get => valor; set => SetProperty(ref valor, value); }
    public string DataMovimento { get => dataMovimento; set => SetProperty(ref dataMovimento, value); }
    public TipoLancamento TipoLancamento { get => tipoLancamento; set => SetProperty(ref tipoLancamento, value); }
    public MeioMonetario MeioMonetario { get => meioMonetario; set => SetProperty(ref meioMonetario, value); }
    public SituacaoFinanceira Situacao { get => situacao; set => SetProperty(ref situacao, value); }
    public string CompetenciaAtual => competenciaAtiva is null ? "Nenhuma competência ativa" : competenciaAtiva.MesReferencia.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand LimparCommand { get; }
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
            Status = $"Não foi possível carregar os clientes: {exception.Message}";
        }
    }

    private async Task SalvarAsync()
    {
        if (!TryObterDados(out var data, out var valorInformado) || ClienteSelecionado is null || competenciaAtiva is null)
        {
            return;
        }

        Result resultado;
        if (MovimentacaoSelecionada is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(
                new CadastrarMovimentacaoCommand(data, Descricao, valorInformado, TipoLancamento, MeioMonetario, Situacao, OrigemMovimentacao.Manual, contextoSessao.Login, ClienteSelecionado.Id, competenciaAtiva.Id),
                CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(
                new AtualizarMovimentacaoCommand(MovimentacaoSelecionada.Id, data, Descricao, valorInformado, TipoLancamento, MeioMonetario, Situacao),
                CancellationToken.None);
        }

        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarMovimentacoesAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (MovimentacaoSelecionada is null)
        {
            Status = "Selecione uma movimentação para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirMovimentacaoCommand(MovimentacaoSelecionada.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarMovimentacoesAsync();
        }
    }

    private bool TryObterDados(out DateOnly data, out decimal valorInformado)
    {
        data = default;
        valorInformado = 0;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (ClienteSelecionado is null || competenciaAtiva is null)
        {
            Status = "O cliente precisa ter uma competência ativa.";
            return false;
        }

        if (!DateTime.TryParseExact(DataMovimento.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataInformada) ||
            !decimal.TryParse(Valor, NumberStyles.Number, cultura, out valorInformado) ||
            string.IsNullOrWhiteSpace(Descricao))
        {
            Status = "Informe data, descrição e valor válidos.";
            return false;
        }

        data = DateOnly.FromDateTime(dataInformada);
        return true;
    }

    private async Task CarregarCompetenciaEMovimentacoesAsync()
    {
        competenciaAtiva = null;
        OnPropertyChanged(nameof(CompetenciaAtual));
        Movimentacoes.Clear();
        if (ClienteSelecionado is null)
        {
            return;
        }

        try
        {
            var competencias = await listarCompetenciasHandler.HandleAsync(new ListarCompetenciasPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
            competenciaAtiva = competencias.FirstOrDefault(item => item.Ativa);
            OnPropertyChanged(nameof(CompetenciaAtual));
            if (competenciaAtiva is null)
            {
                Status = "O cliente não possui competência ativa.";
                return;
            }

            await CarregarMovimentacoesAsync();
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar as movimentações: {exception.Message}";
        }
    }

    private async Task CarregarMovimentacoesAsync()
    {
        Movimentacoes.Clear();
        if (ClienteSelecionado is null || competenciaAtiva is null)
        {
            return;
        }

        try
        {
            var movimentacoes = await listarHandler.HandleAsync(new ListarMovimentacoesPorCompetenciaQuery(ClienteSelecionado.Id, competenciaAtiva.Id), CancellationToken.None);
            foreach (var movimentacao in movimentacoes)
            {
                Movimentacoes.Add(movimentacao);
            }
            Status = string.Empty;
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar as movimentações: {exception.Message}";
        }
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        MovimentacaoSelecionada = null;
        Descricao = string.Empty;
        Valor = "0,00";
        DataMovimento = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        TipoLancamento = TipoLancamento.Saida;
        MeioMonetario = MeioMonetario.Dinheiro;
        Situacao = SituacaoFinanceira.Pendente;
    }
}
