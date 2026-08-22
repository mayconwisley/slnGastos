using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.Movimentacoes;
using Gastos.Domain.Common;
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

public partial class FrmCadMovimentacao : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly string login = string.Empty;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarCompetenciasPorClienteHandler listarCompetenciasHandler;
    private readonly CadastrarMovimentacaoHandler cadastrarHandler;
    private readonly AtualizarMovimentacaoHandler atualizarHandler;
    private readonly ExcluirMovimentacaoHandler excluirHandler;
    private readonly ListarMovimentacoesPorCompetenciaHandler listarHandler;
    private int clienteId;
    private int movimentacaoId;
    private int competenciaId;
    private bool carregandoClientes;
    private IReadOnlyList<CompetenciaDto> competencias = [];
    private IReadOnlyList<MovimentacaoDto> movimentacoes = [];

    public FrmCadMovimentacao()
    {
        InitializeComponent();
    }

    public FrmCadMovimentacao(
        FrmPrincipal frmPrincipal,
        string login,
        ListarClientesHandler listarClientesHandler,
        ListarCompetenciasPorClienteHandler listarCompetenciasHandler,
        CadastrarMovimentacaoHandler cadastrarHandler,
        AtualizarMovimentacaoHandler atualizarHandler,
        ExcluirMovimentacaoHandler excluirHandler,
        ListarMovimentacoesPorCompetenciaHandler listarHandler)
    {
        InitializeComponent();
        this.frmPrincipal = frmPrincipal;
        this.login = login;
        this.listarClientesHandler = listarClientesHandler;
        this.listarCompetenciasHandler = listarCompetenciasHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
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
        finally
        {
            carregandoClientes = false;
        }
    }

    private async Task CarregarCompetenciaEMovimentacoesAsync()
    {
        competencias = await GetListarCompetenciasHandler().HandleAsync(
            new ListarCompetenciasPorClienteQuery(clienteId),
            CancellationToken.None);

        var competenciaAtiva = competencias.FirstOrDefault(item => item.Ativa);
        if (competenciaAtiva is null)
        {
            competenciaId = 0;
            movimentacoes = [];
            DgvListaMovimentacao.DataSource = null;
            LblCompetencia.Text = "Competência: não cadastrada";
            AtualizarResumo([], []);
            return;
        }

        competenciaId = competenciaAtiva.Id;
        LblCompetencia.Text = $"Competência: {competenciaAtiva.MesReferencia:MM/yyyy}";
        movimentacoes = await GetListarHandler().HandleAsync(
            new ListarMovimentacoesPorCompetenciaQuery(clienteId, competenciaId),
            CancellationToken.None);
        DgvListaMovimentacao.DataSource = movimentacoes;

        var anteriores = await ListarMovimentacoesAnterioresAsync(competenciaAtiva.MesReferencia);
        AtualizarResumo(movimentacoes, anteriores);
    }

    private async Task<IReadOnlyList<MovimentacaoDto>> ListarMovimentacoesAnterioresAsync(DateOnly mesAtual)
    {
        var consultas = competencias
            .Where(item => item.MesReferencia < mesAtual)
            .Select(item => GetListarHandler().HandleAsync(
                new ListarMovimentacoesPorCompetenciaQuery(clienteId, item.Id),
                CancellationToken.None));
        var resultados = await Task.WhenAll(consultas);
        return resultados.SelectMany(item => item).ToArray();
    }

    private async Task ExecutarAsync(Operacao operacao)
    {
        try
        {
            Result resultado = operacao switch
            {
                Operacao.Cadastrar => await CadastrarAsync(),
                Operacao.Atualizar => await AtualizarAsync(),
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(new ExcluirMovimentacaoCommand(movimentacaoId), CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };

            if (!resultado.IsSuccess)
            {
                ExibirErros(resultado);
                return;
            }

            LimparCampos();
            await CarregarCompetenciaEMovimentacoesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível concluir a operação: {ex.Message}");
        }
    }

    private async Task<Result> CadastrarAsync()
    {
        if (!TryObterDados(out var dados))
        {
            return Result.Failure(new Error("movimentacao.entrada.invalida", "Corrija os dados informados."));
        }

        var resultado = await GetCadastrarHandler().HandleAsync(
            new CadastrarMovimentacaoCommand(
                dados.Data,
                dados.Descricao,
                dados.Valor,
                dados.TipoLancamento,
                dados.MeioMonetario,
                dados.Situacao,
                OrigemMovimentacao.Manual,
                login,
                clienteId,
                competenciaId),
            CancellationToken.None);

        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private async Task<Result> AtualizarAsync()
    {
        if (!TryObterDados(out var dados))
        {
            return Result.Failure(new Error("movimentacao.entrada.invalida", "Corrija os dados informados."));
        }

        return await GetAtualizarHandler().HandleAsync(
            new AtualizarMovimentacaoCommand(
                movimentacaoId,
                dados.Data,
                dados.Descricao,
                dados.Valor,
                dados.TipoLancamento,
                dados.MeioMonetario,
                dados.Situacao),
            CancellationToken.None);
    }

    private bool TryObterDados(out DadosMovimentacao dados)
    {
        dados = default;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (clienteId <= 0 || competenciaId <= 0)
        {
            MessageBox.Show("O cliente precisa ter uma competência ativa.");
            return false;
        }

        if (!DateTime.TryParseExact(MktDataMovimento.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var data) ||
            !decimal.TryParse(TxtValor.Text, NumberStyles.Number, cultura, out var valor))
        {
            MessageBox.Show("Informe uma data e um valor válidos.");
            return false;
        }

        if (!TryObterTipoLancamento(CbxTipo.Text, out var tipo) || !TryObterSituacao(CbxTipo0.Text, out var situacao))
        {
            MessageBox.Show("Selecione o tipo de lançamento e a situação.");
            return false;
        }

        dados = new DadosMovimentacao(
            DateOnly.FromDateTime(data),
            TxtDescricao.Text.Trim(),
            valor,
            tipo,
            CbCheque.Checked ? MeioMonetario.Cheque : MeioMonetario.Dinheiro,
            situacao);
        return true;
    }

    private static bool TryObterTipoLancamento(string texto, out TipoLancamentoDominio tipo)
    {
        tipo = texto == "Entrada" ? TipoLancamentoDominio.Entrada : TipoLancamentoDominio.Saida;
        return texto is "Entrada" or "Saída";
    }

    private static bool TryObterSituacao(string texto, out SituacaoFinanceira situacao)
    {
        situacao = texto switch
        {
            "Pago" => SituacaoFinanceira.Pago,
            "Recebido" => SituacaoFinanceira.Recebido,
            _ => SituacaoFinanceira.Pendente
        };
        return texto is "Pendente" or "Pago" or "Recebido";
    }

    private void LimparCampos()
    {
        movimentacaoId = 0;
        TxtDescricao.Clear();
        TxtValor.Text = "0,00";
        MktDataMovimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
        CbxTipo.SelectedIndex = -1;
        CbxTipo0.SelectedIndex = -1;
        CbCheque.Checked = false;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnSalvar.Enabled = true;
        TxtDescricao.Focus();
    }

    private void AtualizarResumo(IReadOnlyList<MovimentacaoDto> atuais, IReadOnlyList<MovimentacaoDto> anteriores)
    {
        var atual = ResumoFinanceiro.Calcular(atuais);
        var anterior = ResumoFinanceiro.Calcular(anteriores);

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
        label.ForeColor = valor switch
        {
            > 0 => Color.Green,
            < 0 => Color.Red,
            _ => Color.Black
        };
        label.Text = $"{titulo}: {valor:#,##0.00}";
    }

    private static void ExibirErros(Result resultado) =>
        MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));

    private async void FrmCadMovimentacao_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = $"Data Cadastro: {DateTime.Now:dd/MM/yyyy}";
        MktDataMovimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
        try
        {
            await CarregarClientesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int id)
        {
            return;
        }

        clienteId = id;
        LimparCampos();
        try
        {
            await CarregarCompetenciaEMovimentacoesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DgvListaMovimentacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListaMovimentacao.Rows[e.RowIndex].DataBoundItem is not MovimentacaoDto movimentacao)
        {
            return;
        }

        if (movimentacao.Origem != OrigemMovimentacao.Manual)
        {
            MessageBox.Show("Movimentações integradas não podem ser alteradas por este cadastro.");
            return;
        }

        movimentacaoId = movimentacao.Id;
        TxtDescricao.Text = movimentacao.Descricao;
        TxtValor.Text = movimentacao.Valor.ToString("#,##0.00");
        MktDataMovimento.Text = movimentacao.DataMovimento.ToString("dd/MM/yyyy");
        CbxTipo.SelectedIndex = movimentacao.TipoLancamento == TipoLancamentoDominio.Entrada ? 0 : 1;
        CbxTipo0.SelectedIndex = movimentacao.Situacao switch { SituacaoFinanceira.Pago => 1, SituacaoFinanceira.Recebido => 2, _ => 0 };
        CbCheque.Checked = movimentacao.MeioMonetario == MeioMonetario.Cheque;
        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);
    private async void FrmCadMovimentacao_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (frmPrincipal is not null)
        {
            await frmPrincipal.AtualizarDadosAsync();
        }
    }

    private void TxtValor_TextChanged(object sender, EventArgs e)
    {
        var validador = new ValidarNumero();
        TxtValor.Text = validador.Validar(TxtValor.Text);
        TxtValor.Select(TxtValor.Text.Length, 0);
    }

    private void TxtValor_Leave(object sender, EventArgs e)
    {
        var validador = new ValidarNumero();
        TxtValor.Text = validador.Formatar(validador.Zero(TxtValor.Text));
    }

    private void TxtValor_Enter(object sender, EventArgs e)
    {
        if (TxtValor.Text == "0,00")
        {
            TxtValor.Text = string.Empty;
        }
    }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarCompetenciasPorClienteHandler GetListarCompetenciasHandler() => listarCompetenciasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private CadastrarMovimentacaoHandler GetCadastrarHandler() => cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarMovimentacaoHandler GetAtualizarHandler() => atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirMovimentacaoHandler GetExcluirHandler() => excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarMovimentacoesPorCompetenciaHandler GetListarHandler() => listarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private readonly record struct DadosMovimentacao(DateOnly Data, string Descricao, decimal Valor, TipoLancamentoDominio TipoLancamento, MeioMonetario MeioMonetario, SituacaoFinanceira Situacao);
    private readonly record struct ResumoFinanceiro(decimal Entradas, decimal Saidas, decimal Pagos, decimal Recebidos, decimal PendentesEntrada, decimal PendentesSaida)
    {
        public decimal SaldoLancamentos => Entradas - Saidas;
        public decimal SaldoLiquidado => Recebidos - Pagos;
        public decimal SaldoPendente => PendentesEntrada - PendentesSaida;

        public static ResumoFinanceiro Calcular(IEnumerable<MovimentacaoDto> itens) => new(
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Entrada).Sum(item => item.Valor),
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Saida).Sum(item => item.Valor),
            itens.Where(item => item.Situacao == SituacaoFinanceira.Pago).Sum(item => item.Valor),
            itens.Where(item => item.Situacao == SituacaoFinanceira.Recebido).Sum(item => item.Valor),
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Entrada && item.Situacao == SituacaoFinanceira.Pendente).Sum(item => item.Valor),
            itens.Where(item => item.TipoLancamento == TipoLancamentoDominio.Saida && item.Situacao == SituacaoFinanceira.Pendente).Sum(item => item.Valor));
    }

    private enum Operacao { Cadastrar, Atualizar, Excluir }
}
