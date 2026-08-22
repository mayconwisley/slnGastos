using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Gastos.Application.Clientes;
using Gastos.Application.Painel;

namespace Gastos.Presentation.ViewModels;

public sealed class PainelViewModel : ObservableObject, IAtivavel
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ObterResumoPainelHandler obterResumoPainelHandler;
    private ClienteDto? clienteSelecionado;
    private string competencia = DateTime.Today.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
    private string despesasFixas = "R$ 0,00";
    private string emprestimos = "R$ 0,00";
    private string debitosDevedores = "R$ 0,00";
    private string creditosDevedores = "R$ 0,00";
    private string saldo = "R$ 0,00";
    private string status = string.Empty;

    public PainelViewModel(ListarClientesHandler listarClientesHandler, ObterResumoPainelHandler obterResumoPainelHandler)
    {
        this.listarClientesHandler = listarClientesHandler;
        this.obterResumoPainelHandler = obterResumoPainelHandler;
        AtualizarCommand = new AsyncRelayCommand(CarregarResumoAsync);
    }

    public ObservableCollection<ClienteDto> Clientes { get; } = [];

    public ClienteDto? ClienteSelecionado
    {
        get => clienteSelecionado;
        set
        {
            if (SetProperty(ref clienteSelecionado, value) && value is not null)
            {
                _ = CarregarResumoAsync();
            }
        }
    }

    public string Competencia
    {
        get => competencia;
        set => SetProperty(ref competencia, value);
    }

    public string DespesasFixas { get => despesasFixas; private set => SetProperty(ref despesasFixas, value); }
    public string Emprestimos { get => emprestimos; private set => SetProperty(ref emprestimos, value); }
    public string DebitosDevedores { get => debitosDevedores; private set => SetProperty(ref debitosDevedores, value); }
    public string CreditosDevedores { get => creditosDevedores; private set => SetProperty(ref creditosDevedores, value); }
    public string Saldo { get => saldo; private set => SetProperty(ref saldo, value); }
    public string Status { get => status; private set => SetProperty(ref status, value); }
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
            if (ClienteSelecionado is null)
            {
                Status = "Cadastre um cliente para consultar o resumo financeiro.";
            }
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar o painel: {exception.Message}";
        }
    }

    private async Task CarregarResumoAsync()
    {
        if (ClienteSelecionado is null)
        {
            return;
        }

        if (!DateTime.TryParseExact(Competencia.Trim(), "MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var data))
        {
            Status = "Informe a competência no formato MM/aaaa.";
            return;
        }

        try
        {
            var resultado = await obterResumoPainelHandler.HandleAsync(
                new ObterResumoPainelQuery(ClienteSelecionado.Id, DateOnly.FromDateTime(data)),
                CancellationToken.None);
            if (!resultado.IsSuccess || resultado.Value is null)
            {
                Status = string.Join(" ", resultado.Errors.Select(error => error.Description));
                LimparResumo();
                return;
            }

            var resumo = resultado.Value;
            DespesasFixas = FormatarMoeda(resumo.DespesasFixas);
            Emprestimos = FormatarMoeda(resumo.EmprestimosEmAberto);
            DebitosDevedores = FormatarMoeda(resumo.DebitosDevedores);
            CreditosDevedores = FormatarMoeda(resumo.CreditosDevedores);
            Saldo = FormatarMoeda(resumo.Saldo);
            Status = string.Empty;
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível atualizar o painel: {exception.Message}";
        }
    }

    private void LimparResumo()
    {
        DespesasFixas = "R$ 0,00";
        Emprestimos = "R$ 0,00";
        DebitosDevedores = "R$ 0,00";
        CreditosDevedores = "R$ 0,00";
        Saldo = "R$ 0,00";
    }

    private static string FormatarMoeda(decimal valor) => valor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
}
