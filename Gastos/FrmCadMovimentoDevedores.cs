using Gastos.Application.Clientes;
using Gastos.Application.Devedores;
using Gastos.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadMovimentoDevedores : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly string login = string.Empty;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarDevedoresPorClienteHandler listarDevedoresHandler;
    private readonly CadastrarParcelaDevedorHandler cadastrarHandler;
    private readonly AtualizarParcelaDevedorHandler atualizarHandler;
    private readonly ExcluirParcelaDevedorHandler excluirHandler;
    private readonly ExcluirParcelasDevedorHandler excluirTodasHandler;
    private readonly ListarParcelasDevedorHandler listarParcelasHandler;
    private int clienteId;
    private int devedorId;
    private int parcelaId;
    private bool carregandoClientes;
    private bool carregandoDevedores;

    public FrmCadMovimentoDevedores()
    {
        InitializeComponent();
    }

    public FrmCadMovimentoDevedores(
        FrmPrincipal frmPrincipal,
        string login,
        ListarClientesHandler listarClientesHandler,
        ListarDevedoresPorClienteHandler listarDevedoresHandler,
        CadastrarParcelaDevedorHandler cadastrarHandler,
        AtualizarParcelaDevedorHandler atualizarHandler,
        ExcluirParcelaDevedorHandler excluirHandler,
        ExcluirParcelasDevedorHandler excluirTodasHandler,
        ListarParcelasDevedorHandler listarParcelasHandler)
    {
        InitializeComponent();
        this.frmPrincipal = frmPrincipal;
        this.login = login;
        this.listarClientesHandler = listarClientesHandler;
        this.listarDevedoresHandler = listarDevedoresHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.excluirTodasHandler = excluirTodasHandler;
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

    private async Task CarregarDevedoresAsync()
    {
        carregandoDevedores = true;
        try
        {
            CbxDescricao.DisplayMember = nameof(DevedorDto.Descricao);
            CbxDescricao.ValueMember = nameof(DevedorDto.Id);
            CbxDescricao.DataSource = await GetListarDevedoresHandler().HandleAsync(new ListarDevedoresPorClienteQuery(clienteId), CancellationToken.None);
        }
        finally { carregandoDevedores = false; }
    }

    private async Task CarregarParcelasAsync()
    {
        IReadOnlyList<ParcelaDevedorDto> parcelas = devedorId <= 0
            ? []
            : await GetListarParcelasHandler().HandleAsync(new ListarParcelasDevedorQuery(devedorId), CancellationToken.None);
        DgvListarMovimentoDev.DataSource = parcelas;
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
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(new ExcluirParcelaDevedorCommand(parcelaId), CancellationToken.None),
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
        var resultado = await GetCadastrarHandler().HandleAsync(new CadastrarParcelaDevedorCommand(devedorId, dados.DataParcela, dados.Numero, dados.Valor, login), CancellationToken.None);
        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private async Task<Result> AtualizarAsync()
    {
        if (!TryObterDados(out var dados)) return FalhaEntrada();
        return await GetAtualizarHandler().HandleAsync(new AtualizarParcelaDevedorCommand(parcelaId, dados.DataParcela, dados.Numero, dados.Valor, dados.Recebido, dados.DataRecebido), CancellationToken.None);
    }

    private bool TryObterDados(out DadosParcela dados)
    {
        dados = default;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        if (devedorId <= 0 ||
            !DateTime.TryParseExact(MktDataParcela.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataParcela) ||
            !int.TryParse(TxtParcela.Text, NumberStyles.Integer, cultura, out var numero) ||
            !decimal.TryParse(TxtValor.Text, NumberStyles.Number, cultura, out var valor))
        {
            MessageBox.Show("Informe devedor, vencimento, número e valor válidos.");
            return false;
        }

        var recebido = CbxRecebido.Text == "Sim";
        DateOnly? dataRecebido = null;
        if (recebido)
        {
            if (!DateTime.TryParseExact(MktDataRecebido.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var data))
            {
                MessageBox.Show("Informe a data de recebimento.");
                return false;
            }
            dataRecebido = DateOnly.FromDateTime(data);
        }

        dados = new DadosParcela(DateOnly.FromDateTime(dataParcela), numero, valor, recebido, dataRecebido);
        return true;
    }

    private async Task ExcluirTodasAsync()
    {
        if (devedorId <= 0 || MessageBox.Show("Deseja excluir todos os lançamentos?", "Aviso", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        var resultado = await GetExcluirTodasHandler().HandleAsync(new ExcluirParcelasDevedorCommand(devedorId), CancellationToken.None);
        if (!resultado.IsSuccess) { ExibirErros(resultado); return; }
        LimparCampos();
        await CarregarParcelasAsync();
    }

    private void LimparCampos()
    {
        parcelaId = 0;
        TxtParcela.Text = "1";
        TxtValor.Text = "0,00";
        MktDataRecebido.Clear();
        MktDataParcela.Clear();
        CbxRecebido.SelectedIndex = 1;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnSalvar.Enabled = true;
    }

    private void AtualizarTotais(IReadOnlyList<ParcelaDevedorDto> parcelas)
    {
        var recebido = parcelas.Where(item => item.Recebido).Sum(item => item.Valor);
        var geral = parcelas.Sum(item => item.Valor);
        LblValorTotal.Text = $"Valor Total......: {geral:#,##0.00}";
        LblValorPago.Text = $"Valor Recebido...: {recebido:#,##0.00}";
        LblValorPagar.Text = $"Valor a Receber..: {(geral - recebido):#,##0.00}";
    }

    private static Result FalhaEntrada() => Result.Failure(new Error("parcela_devedor.entrada.invalida", "Corrija os dados informados."));
    private static void ExibirErros(Result resultado) => MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));

    private async void FrmCadMovimentoDevedores_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = $"Data Cadastro: {DateTime.Now:dd/MM/yyyy}";
        CbxRecebido.SelectedIndex = 1;
        try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int id) return;
        clienteId = id;
        try { await CarregarDevedoresAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxDescricao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoDevedores || CbxDescricao.SelectedValue is not int id) return;
        devedorId = id;
        LimparCampos();
        await CarregarParcelasAsync();
    }

    private void DgvListarMovimentoDev_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListarMovimentoDev.Rows[e.RowIndex].DataBoundItem is not ParcelaDevedorDto parcela) return;
        parcelaId = parcela.Id;
        MktDataParcela.Text = parcela.DataParcela.ToString("dd/MM/yyyy");
        TxtParcela.Text = parcela.Parcela.ToString(CultureInfo.InvariantCulture);
        TxtValor.Text = parcela.Valor.ToString("#,##0.00");
        CbxRecebido.SelectedIndex = parcela.Recebido ? 0 : 1;
        MktDataRecebido.Text = parcela.DataRecebido?.ToString("dd/MM/yyyy") ?? string.Empty;
        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);
    private async void CmsExcluirTudo_Click(object sender, EventArgs e) => await ExcluirTodasAsync();
    private async void FrmCadMovimentoDevedores_FormClosing(object sender, FormClosingEventArgs e) { if (frmPrincipal is not null) await frmPrincipal.AtualizarDadosAsync(); }

    private void CbxPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        var recebido = CbxRecebido.Text == "Sim";
        MktDataRecebido.Enabled = recebido;
        if (recebido && string.IsNullOrWhiteSpace(MktDataRecebido.Text.Trim())) MktDataRecebido.Text = MktDataParcela.Text;
        if (!recebido) MktDataRecebido.Clear();
    }

    private void TxtParcela_TextChanged(object sender, EventArgs e) { var v = new ValidarNumero(); TxtParcela.Text = v.ValidarNumeroInteiro(TxtParcela.Text); TxtParcela.Select(TxtParcela.Text.Length, 0); }
    private void TxtParcela_Leave(object sender, EventArgs e) { var v = new ValidarNumero(); TxtParcela.Text = v.FormatarInteiro(v.ZeroInteiro(TxtParcela.Text)); }
    private void TxtParcela_Enter(object sender, EventArgs e) { if (TxtParcela.Text == "0") TxtParcela.Text = "1"; }
    private void TxtValor_TextChanged(object sender, EventArgs e) { var v = new ValidarNumero(); TxtValor.Text = v.Validar(TxtValor.Text); TxtValor.Select(TxtValor.Text.Length, 0); }
    private void TxtValor_Leave(object sender, EventArgs e) { var v = new ValidarNumero(); TxtValor.Text = v.Formatar(v.Zero(TxtValor.Text)); }
    private void TxtValor_Enter(object sender, EventArgs e) { if (TxtValor.Text == "0,00") TxtValor.Text = string.Empty; }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarDevedoresPorClienteHandler GetListarDevedoresHandler() => listarDevedoresHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private CadastrarParcelaDevedorHandler GetCadastrarHandler() => cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarParcelaDevedorHandler GetAtualizarHandler() => atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelaDevedorHandler GetExcluirHandler() => excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelasDevedorHandler GetExcluirTodasHandler() => excluirTodasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarParcelasDevedorHandler GetListarParcelasHandler() => listarParcelasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private readonly record struct DadosParcela(DateOnly DataParcela, int Numero, decimal Valor, bool Recebido, DateOnly? DataRecebido);
    private enum Operacao { Cadastrar, Atualizar, Excluir }
}
