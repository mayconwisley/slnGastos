using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.Movimentacoes;
using Gastos.Domain.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipoLancamentoDominio = Gastos.Domain.Movimentacoes.TipoLancamento;

namespace Gastos;

public partial class FrmConMovimentacao : Form
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarCompetenciasPorClienteHandler listarCompetenciasHandler;
    private readonly ListarMovimentacoesPorCompetenciaHandler listarMovimentacoesHandler;
    private int clienteId;
    private bool carregandoClientes;

    public FrmConMovimentacao()
    {
        InitializeComponent();
    }

    public FrmConMovimentacao(ListarClientesHandler listarClientesHandler, ListarCompetenciasPorClienteHandler listarCompetenciasHandler, ListarMovimentacoesPorCompetenciaHandler listarMovimentacoesHandler)
    {
        InitializeComponent();
        this.listarClientesHandler = listarClientesHandler;
        this.listarCompetenciasHandler = listarCompetenciasHandler;
        this.listarMovimentacoesHandler = listarMovimentacoesHandler;
    }

    private async Task CarregarClientesAsync()
    {
        carregandoClientes = true;
        try
        {
            CbxNome.DisplayMember = nameof(ClienteDto.Nome);
            CbxNome.ValueMember = nameof(ClienteDto.Id);
            CbxNome.DataSource = await GetListarClientesHandler().HandleAsync(new ListarClientesQuery(), CancellationToken.None);
        }
        finally { carregandoClientes = false; }
    }

    private async Task CarregarMovimentacoesAsync()
    {
        if (clienteId <= 0 || !DateTime.TryParseExact(MktCompetencia.Text.Trim(), "MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var data)) return;
        var mes = DateOnly.FromDateTime(data);
        var competencias = await GetListarCompetenciasHandler().HandleAsync(new ListarCompetenciasPorClienteQuery(clienteId), CancellationToken.None);
        var competenciaAtual = competencias.SingleOrDefault(item => item.MesReferencia == mes);
        if (competenciaAtual is null)
        {
            DgvListaMovimentacao.DataSource = null;
            AtualizarResumo([], []);
            return;
        }

        var atuais = await GetListarMovimentacoesHandler().HandleAsync(new ListarMovimentacoesPorCompetenciaQuery(clienteId, competenciaAtual.Id), CancellationToken.None);
        var consultasAnteriores = competencias
            .Where(item => item.MesReferencia < mes)
            .Select(item => GetListarMovimentacoesHandler().HandleAsync(new ListarMovimentacoesPorCompetenciaQuery(clienteId, item.Id), CancellationToken.None));
        var anteriores = (await Task.WhenAll(consultasAnteriores)).SelectMany(item => item).ToArray();
        DgvListaMovimentacao.DataSource = atuais;
        AtualizarResumo(atuais, anteriores);
    }

    private void AtualizarResumo(IReadOnlyList<MovimentacaoDto> atuais, IReadOnlyList<MovimentacaoDto> anteriores)
    {
        var atual = Resumo.Calcular(atuais);
        var anterior = Resumo.Calcular(anteriores);
        AtualizarSaldo(LblSalES, "Sal. E. S.", anterior.SaldoLancamentos);
        AtualizarSaldo(LblSalPR, "Sal. P. R.", anterior.SaldoLiquidado);
        AtualizarSaldo(LblSalPend, "Sal. Pend.", anterior.SaldoPendente);
        AtualizarSaldo(LblSaldo, "Valor Saldo..", atual.SaldoLancamentos + anterior.SaldoLancamentos);
        AtualizarSaldo(LblSaldo0, "Valor Saldo...", atual.SaldoLiquidado + anterior.SaldoLiquidado);
        AtualizarSaldo(LblSalPen, "Valor Saldo...........", atual.SaldoPendente + anterior.SaldoPendente);
        LblValorEntrada.Text = $"Valor Entrada: {atual.Entradas:#,##0.00}";
        LblValorSaida.Text = $"Valor Saída..: {atual.Saidas:#,##0.00}";
        LblValorPago.Text = $"Valor Pago....: {atual.Pagos:#,##0.00}";
        LblValorRecebido.Text = $"Valor Recebido: {atual.Recebidos:#,##0.00}";
        LblValPenEnt.Text = $"Valor Pendente Entrada: {atual.PendentesEntrada:#,##0.00}";
        LblValPenSai.Text = $"Valor Pendente Saída..: {atual.PendentesSaida:#,##0.00}";
    }

    private static void AtualizarSaldo(Label label, string titulo, decimal valor)
    {
        label.ForeColor = valor switch { > 0 => Color.Green, < 0 => Color.Red, _ => Color.Black };
        label.Text = $"{titulo}: {valor:#,##0.00}";
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int id) return;
        clienteId = id;
        try { await CarregarMovimentacoesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void MktCompetencia_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) await AtualizarConsultaAsync();
    }

    private async void MktCompetencia_Leave(object sender, EventArgs e) => await AtualizarConsultaAsync();
    private async Task AtualizarConsultaAsync()
    {
        try { await CarregarMovimentacoesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void FrmConMovimentacao_Load(object sender, EventArgs e)
    {
        MktCompetencia.Text = DateTime.Now.ToString("MM/yyyy");
        try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarCompetenciasPorClienteHandler GetListarCompetenciasHandler() => listarCompetenciasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarMovimentacoesPorCompetenciaHandler GetListarMovimentacoesHandler() => listarMovimentacoesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private readonly record struct Resumo(decimal Entradas, decimal Saidas, decimal Pagos, decimal Recebidos, decimal PendentesEntrada, decimal PendentesSaida)
    {
        public decimal SaldoLancamentos => Entradas - Saidas;
        public decimal SaldoLiquidado => Recebidos - Pagos;
        public decimal SaldoPendente => PendentesEntrada - PendentesSaida;

        public static Resumo Calcular(IEnumerable<MovimentacaoDto> itens) => new(
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Entrada).Sum(item => item.Valor),
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Saida).Sum(item => item.Valor),
            itens.Where(item => item.Situacao == SituacaoFinanceira.Pago).Sum(item => item.Valor),
            itens.Where(item => item.Situacao == SituacaoFinanceira.Recebido).Sum(item => item.Valor),
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Entrada && item.Situacao == SituacaoFinanceira.Pendente).Sum(item => item.Valor),
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Saida && item.Situacao == SituacaoFinanceira.Pendente).Sum(item => item.Valor));
    }
}
