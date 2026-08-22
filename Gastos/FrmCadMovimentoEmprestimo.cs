using Gastos.Application.Clientes;
using Gastos.Application.Emprestimos;
using Gastos.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadMovimentoEmprestimo : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly string login = string.Empty;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarEmprestimosPorClienteHandler listarEmprestimosHandler;
    private readonly CadastrarParcelaEmprestimoHandler cadastrarHandler;
    private readonly AtualizarParcelaEmprestimoHandler atualizarHandler;
    private readonly ExcluirParcelaEmprestimoHandler excluirHandler;
    private readonly ExcluirParcelasEmprestimoHandler excluirTodasHandler;
    private readonly QuitarEmprestimoHandler quitarHandler;
    private readonly ListarParcelasEmprestimoHandler listarParcelasHandler;
    private int clienteId;
    private int emprestimoId;
    private int parcelaId;
    private bool carregandoClientes;
    private bool carregandoEmprestimos;

    public FrmCadMovimentoEmprestimo()
    {
        InitializeComponent();
    }

    public FrmCadMovimentoEmprestimo(
        FrmPrincipal frmPrincipal,
        string login,
        ListarClientesHandler listarClientesHandler,
        ListarEmprestimosPorClienteHandler listarEmprestimosHandler,
        CadastrarParcelaEmprestimoHandler cadastrarHandler,
        AtualizarParcelaEmprestimoHandler atualizarHandler,
        ExcluirParcelaEmprestimoHandler excluirHandler,
        ExcluirParcelasEmprestimoHandler excluirTodasHandler,
        QuitarEmprestimoHandler quitarHandler,
        ListarParcelasEmprestimoHandler listarParcelasHandler)
    {
        InitializeComponent();
        this.frmPrincipal = frmPrincipal;
        this.login = login;
        this.listarClientesHandler = listarClientesHandler;
        this.listarEmprestimosHandler = listarEmprestimosHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.excluirTodasHandler = excluirTodasHandler;
        this.quitarHandler = quitarHandler;
        this.listarParcelasHandler = listarParcelasHandler;
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

    private async Task CarregarEmprestimosAsync()
    {
        carregandoEmprestimos = true;
        try
        {
            CbxDescricao.DisplayMember = nameof(EmprestimoDto.Descricao);
            CbxDescricao.ValueMember = nameof(EmprestimoDto.Id);
            CbxDescricao.DataSource = await GetListarEmprestimosHandler().HandleAsync(
                new ListarEmprestimosPorClienteQuery(clienteId),
                CancellationToken.None);
        }
        finally { carregandoEmprestimos = false; }
    }

    private async Task CarregarParcelasAsync()
    {
        var parcelas = emprestimoId <= 0
            ? []
            : await GetListarParcelasHandler().HandleAsync(new ListarParcelasEmprestimoQuery(emprestimoId), CancellationToken.None);
        DgvListarMovimentoEmp.DataSource = parcelas;
        AtualizarTotais(parcelas);
    }

    private async Task ExecutarAsync(Operacao operacao)
    {
        try
        {
            Result resultado = operacao switch
            {
                Operacao.Cadastrar => await CadastrarAsync(),
                Operacao.Atualizar => await AtualizarAsync(),
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(new ExcluirParcelaEmprestimoCommand(parcelaId), CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };
            if (!resultado.IsSuccess) { ExibirErros(resultado); return; }
            LimparCampos();
            await CarregarParcelasAsync();
        }
        catch (Exception ex) { MessageBox.Show($"Não foi possível concluir a operação: {ex.Message}"); }
    }

    private async Task<Result> CadastrarAsync()
    {
        if (!TryObterDados(out var dados)) return FalhaEntrada();
        var resultado = await GetCadastrarHandler().HandleAsync(
            new CadastrarParcelaEmprestimoCommand(emprestimoId, dados.DataParcela, dados.Numero, dados.Valor, login),
            CancellationToken.None);
        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private async Task<Result> AtualizarAsync()
    {
        if (!TryObterDados(out var dados)) return FalhaEntrada();
        return await GetAtualizarHandler().HandleAsync(
            new AtualizarParcelaEmprestimoCommand(parcelaId, dados.DataParcela, dados.Numero, dados.Valor, dados.Pago, dados.DataPagamento),
            CancellationToken.None);
    }

    private bool TryObterDados(out DadosParcela dados)
    {
        dados = default;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (emprestimoId <= 0 ||
            !DateTime.TryParseExact(MktDataParcela.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataParcela) ||
            !int.TryParse(TxtParcela.Text, NumberStyles.Integer, cultura, out var numero) ||
            !decimal.TryParse(TxtValor.Text, NumberStyles.Number, cultura, out var valor))
        {
            MessageBox.Show("Informe empréstimo, vencimento, número e valor válidos.");
            return false;
        }

        var pago = CbxPago.Text == "Sim";
        DateOnly? dataPagamento = null;
        if (pago)
        {
            if (!DateTime.TryParseExact(MktDataPagamento.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var data))
            {
                MessageBox.Show("Informe a data de pagamento.");
                return false;
            }
            dataPagamento = DateOnly.FromDateTime(data);
        }

        dados = new DadosParcela(DateOnly.FromDateTime(dataParcela), numero, valor, pago, dataPagamento);
        return true;
    }

    private async Task QuitarAsync()
    {
        if (emprestimoId <= 0) return;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (!DateTime.TryParseExact(MktDataPagamento.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataPagamento))
        {
            MessageBox.Show("Informe a data de pagamento para quitar o empréstimo.");
            return;
        }

        var resultado = await GetQuitarHandler().HandleAsync(new QuitarEmprestimoCommand(emprestimoId, DateOnly.FromDateTime(dataPagamento)), CancellationToken.None);
        if (!resultado.IsSuccess) { ExibirErros(resultado); return; }
        LimparCampos();
        await CarregarParcelasAsync();
    }

    private async Task ExcluirTodasAsync()
    {
        if (emprestimoId <= 0 || MessageBox.Show("Deseja excluir todos os lançamentos?", "Aviso", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        var resultado = await GetExcluirTodasHandler().HandleAsync(new ExcluirParcelasEmprestimoCommand(emprestimoId), CancellationToken.None);
        if (!resultado.IsSuccess) { ExibirErros(resultado); return; }
        LimparCampos();
        await CarregarParcelasAsync();
    }

    private void LimparCampos()
    {
        parcelaId = 0;
        TxtParcela.Text = "1";
        TxtValor.Text = "0,00";
        MktDataPagamento.Clear();
        MktDataParcela.Clear();
        CbxPago.SelectedIndex = 1;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnSalvar.Enabled = true;
    }

    private void AtualizarTotais(IReadOnlyList<ParcelaEmprestimoDto> parcelas)
    {
        var pago = parcelas.Where(item => item.Pago).Sum(item => item.Valor);
        var geral = parcelas.Sum(item => item.Valor);
        LblValorTotal.Text = $"Valor Total..: {geral:#,##0.00}";
        LblValorPago.Text = $"Valor Pago...: {pago:#,##0.00}";
        LblValorPagar.Text = $"Valor a Pagar: {(geral - pago):#,##0.00}";
    }

    private static Result FalhaEntrada() => Result.Failure(new Error("parcela_emprestimo.entrada.invalida", "Corrija os dados informados."));
    private static void ExibirErros(Result resultado) => MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));

    private async void FrmCadMovimentoEmprestimo_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = $"Data Cadastro: {DateTime.Now:dd/MM/yyyy}";
        CbxPago.SelectedIndex = 1;
        MktDataPagamento.Text = DateTime.Now.ToString("dd/MM/yyyy");
        try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int id) return;
        clienteId = id;
        try { await CarregarEmprestimosAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxDescrocao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoEmprestimos || CbxDescricao.SelectedValue is not int id) return;
        emprestimoId = id;
        LimparCampos();
        await CarregarParcelasAsync();
    }

    private void DgvListarMovimentoEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListarMovimentoEmp.Rows[e.RowIndex].DataBoundItem is not ParcelaEmprestimoDto parcela) return;
        parcelaId = parcela.Id;
        MktDataParcela.Text = parcela.DataParcela.ToString("dd/MM/yyyy");
        TxtParcela.Text = parcela.Parcela.ToString(CultureInfo.InvariantCulture);
        TxtValor.Text = parcela.Valor.ToString("#,##0.00");
        CbxPago.SelectedIndex = parcela.Pago ? 0 : 1;
        MktDataPagamento.Text = parcela.DataPagamento?.ToString("dd/MM/yyyy") ?? string.Empty;
        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);
    private async void BtnQuitar_Click(object sender, EventArgs e) => await QuitarAsync();
    private async void CmsExcluirTudo_Click(object sender, EventArgs e) => await ExcluirTodasAsync();
    private async void FrmCadMovimentoEmprestimo_FormClosing(object sender, FormClosingEventArgs e) { if (frmPrincipal is not null) await frmPrincipal.AtualizarDadosAsync(); }

    private void CbxPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CbxPago.Text == "Sim" && string.IsNullOrWhiteSpace(MktDataPagamento.Text.Trim())) MktDataPagamento.Text = MktDataParcela.Text;
        if (CbxPago.Text == "Não") MktDataPagamento.Clear();
    }

    private void TxtParcela_TextChanged(object sender, EventArgs e) { var v = new ValidarNumero(); TxtParcela.Text = v.ValidarNumeroInteiro(TxtParcela.Text); TxtParcela.Select(TxtParcela.Text.Length, 0); }
    private void TxtParcela_Leave(object sender, EventArgs e) { var v = new ValidarNumero(); TxtParcela.Text = v.FormatarInteiro(v.ZeroInteiro(TxtParcela.Text)); }
    private void TxtParcela_Enter(object sender, EventArgs e) { if (TxtParcela.Text == "0") TxtParcela.Text = "1"; }
    private void TxtValor_TextChanged(object sender, EventArgs e) { var v = new ValidarNumero(); TxtValor.Text = v.Validar(TxtValor.Text); TxtValor.Select(TxtValor.Text.Length, 0); }
    private void TxtValor_Leave(object sender, EventArgs e) { var v = new ValidarNumero(); TxtValor.Text = v.Formatar(v.Zero(TxtValor.Text)); }
    private void TxtValor_Enter(object sender, EventArgs e) { if (TxtValor.Text == "0,00") TxtValor.Text = string.Empty; }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarEmprestimosPorClienteHandler GetListarEmprestimosHandler() => listarEmprestimosHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private CadastrarParcelaEmprestimoHandler GetCadastrarHandler() => cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarParcelaEmprestimoHandler GetAtualizarHandler() => atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelaEmprestimoHandler GetExcluirHandler() => excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelasEmprestimoHandler GetExcluirTodasHandler() => excluirTodasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private QuitarEmprestimoHandler GetQuitarHandler() => quitarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarParcelasEmprestimoHandler GetListarParcelasHandler() => listarParcelasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private readonly record struct DadosParcela(DateOnly DataParcela, int Numero, decimal Valor, bool Pago, DateOnly? DataPagamento);
    private enum Operacao { Cadastrar, Atualizar, Excluir }
}
