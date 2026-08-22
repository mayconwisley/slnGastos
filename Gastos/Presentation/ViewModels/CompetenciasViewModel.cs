using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Domain.Common;

namespace Gastos.Presentation.ViewModels;

public sealed class CompetenciasViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarCompetenciaHandler cadastrarHandler;
    private readonly AtualizarCompetenciaHandler atualizarHandler;
    private readonly ExcluirCompetenciaHandler excluirHandler;
    private readonly ListarCompetenciasPorClienteHandler listarHandler;
    private ClienteDto? clienteSelecionado;
    private CompetenciaDto? competenciaSelecionada;
    private string mesReferencia = DateTime.Today.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private bool ativa = true;
    private string status = string.Empty;

    public CompetenciasViewModel(ListarClientesHandler listarClientesHandler, CadastrarCompetenciaHandler cadastrarHandler, AtualizarCompetenciaHandler atualizarHandler, ExcluirCompetenciaHandler excluirHandler, ListarCompetenciasPorClienteHandler listarHandler)
    {
        this.listarClientesHandler = listarClientesHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];
    public ObservableCollection<CompetenciaDto> Competencias { get; } = [];
    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value))
            {
                Limpar();
                _ = CarregarCompetenciasAsync();
            }
        }
    }

    public CompetenciaDto? CompetenciaSelecionada
    {
        get => competenciaSelecionada;
        set
        {
            if (SetProperty(ref competenciaSelecionada, value) && value is not null)
            {
                MesReferencia = value.MesReferencia.ToDateTime(TimeOnly.MinValue).ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                Ativa = value.Ativa;
            }
        }
    }

    public string MesReferencia { get => mesReferencia; set => SetProperty(ref mesReferencia, value); }
    public bool Ativa { get => ativa; set => SetProperty(ref ativa, value); }
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
        if (ClienteSelecionado is null)
        {
            Status = "Selecione um cliente.";
            return;
        }

        if (!DateTime.TryParseExact(MesReferencia.Trim(), "MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var data))
        {
            Status = "Informe a competência no formato MM/aaaa.";
            return;
        }

        Result resultado;
        if (CompetenciaSelecionada is null)
        {
            var cadastro = await cadastrarHandler.HandleAsync(new CadastrarCompetenciaCommand(DateOnly.FromDateTime(data), ClienteSelecionado.Id, Ativa), CancellationToken.None);
            resultado = cadastro.IsSuccess ? Result.Success() : Result.Failure(cadastro.Errors.ToArray());
        }
        else
        {
            resultado = await atualizarHandler.HandleAsync(new AtualizarCompetenciaCommand(CompetenciaSelecionada.Id, DateOnly.FromDateTime(data), Ativa), CancellationToken.None);
        }

        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarCompetenciasAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (CompetenciaSelecionada is null)
        {
            Status = "Selecione uma competência para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirCompetenciaCommand(CompetenciaSelecionada.Id), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarCompetenciasAsync();
        }
    }

    private async Task CarregarCompetenciasAsync()
    {
        Competencias.Clear();
        if (ClienteSelecionado is null)
        {
            return;
        }

        try
        {
            var competencias = await listarHandler.HandleAsync(new ListarCompetenciasPorClienteQuery(ClienteSelecionado.Id), CancellationToken.None);
            foreach (var competencia in competencias)
            {
                Competencias.Add(competencia);
            }
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar as competências: {exception.Message}";
        }
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        CompetenciaSelecionada = null;
        MesReferencia = DateTime.Today.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        Ativa = true;
    }
}
