using Gastos.Application.Clientes;
using Gastos.Application.Devedores;
using Gastos.Domain.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadDevedores : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly string login = string.Empty;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarDevedorHandler cadastrarHandler;
    private readonly AtualizarDevedorHandler atualizarHandler;
    private readonly ExcluirDevedorHandler excluirHandler;
    private readonly GerarParcelasDevedorHandler gerarParcelasHandler;
    private readonly ListarDevedoresPorClienteHandler listarHandler;
    private int clienteId;
    private int devedorId;
    private bool carregandoClientes;

    public FrmCadDevedores()
    {
        InitializeComponent();
    }

    public FrmCadDevedores(
        FrmPrincipal frmPrincipal,
        string login,
        ListarClientesHandler listarClientesHandler,
        CadastrarDevedorHandler cadastrarHandler,
        AtualizarDevedorHandler atualizarHandler,
        ExcluirDevedorHandler excluirHandler,
        GerarParcelasDevedorHandler gerarParcelasHandler,
        ListarDevedoresPorClienteHandler listarHandler)
    {
        InitializeComponent();
        this.frmPrincipal = frmPrincipal;
        this.login = login;
        this.listarClientesHandler = listarClientesHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.gerarParcelasHandler = gerarParcelasHandler;
        this.listarHandler = listarHandler;
    }

    private async Task CarregarClientesAsync()
    {
        carregandoClientes = true;
        try
        {
            CbxNome.DisplayMember = nameof(ClienteDto.Nome);
            CbxNome.ValueMember = nameof(ClienteDto.Id);
            CbxNome.DataSource = await GetListarClientesHandler()
                .HandleAsync(new ListarClientesQuery(), CancellationToken.None);
        }
        finally
        {
            carregandoClientes = false;
        }
    }

    private async Task CarregarDevedoresAsync()
    {
        DgvListaDevedores.DataSource = clienteId <= 0
            ? null
            : await GetListarHandler().HandleAsync(
                new ListarDevedoresPorClienteQuery(clienteId),
                CancellationToken.None);
    }

    private async Task ExecutarAsync(Operacao operacao)
    {
        try
        {
            Result resultado = operacao switch
            {
                Operacao.Cadastrar => await CadastrarAsync(),
                Operacao.Atualizar => await AtualizarAsync(),
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(new ExcluirDevedorCommand(devedorId), CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };

            if (!resultado.IsSuccess)
            {
                ExibirErros(resultado);
                return;
            }

            LimparCampos();
            await CarregarDevedoresAsync();
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
            return Result.Failure(new Error("devedor.entrada.invalida", "Corrija os dados informados."));
        }

        var resultado = await GetCadastrarHandler().HandleAsync(
            new CadastrarDevedorCommand(dados.Nome, dados.Descricao, dados.Valor, dados.Parcelas, dados.DataInicio, dados.Ativo, login, clienteId),
            CancellationToken.None);

        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private async Task<Result> AtualizarAsync()
    {
        if (!TryObterDados(out var dados))
        {
            return Result.Failure(new Error("devedor.entrada.invalida", "Corrija os dados informados."));
        }

        return await GetAtualizarHandler().HandleAsync(
            new AtualizarDevedorCommand(devedorId, dados.Nome, dados.Descricao, dados.Valor, dados.Parcelas, dados.DataInicio, dados.Ativo),
            CancellationToken.None);
    }

    private bool TryObterDados(out DadosDevedor dados)
    {
        dados = default;
        var cultura = CultureInfo.GetCultureInfo("pt-BR");

        if (clienteId <= 0)
        {
            MessageBox.Show("Selecione um cliente.");
            return false;
        }

        if (!DateTime.TryParseExact(MktDataInicio.Text.Trim(), "dd/MM/yyyy", cultura, DateTimeStyles.None, out var dataInicio))
        {
            MessageBox.Show("Informe uma data inicial válida.");
            return false;
        }

        if (!decimal.TryParse(TxtValor.Text, NumberStyles.Number, cultura, out var valor) ||
            !int.TryParse(TxtParcelas.Text, NumberStyles.Integer, cultura, out var parcelas))
        {
            MessageBox.Show("Informe um valor e uma quantidade de parcelas válidos.");
            return false;
        }

        dados = new DadosDevedor(TxtNome.Text.Trim(), TxtDescricao.Text.Trim(), valor, parcelas, DateOnly.FromDateTime(dataInicio), CbAtivo.Checked);
        return true;
    }

    private void LimparCampos()
    {
        devedorId = 0;
        TxtNome.Clear();
        TxtDescricao.Clear();
        TxtValor.Text = "0,00";
        TxtParcelas.Text = "1";
        MktDataInicio.Clear();
        CbAtivo.Checked = true;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnGerar.Enabled = false;
        BtnSalvar.Enabled = true;
        TxtNome.Focus();
    }

    private async Task GerarParcelasAsync()
    {
        if (devedorId <= 0)
        {
            return;
        }

        try
        {
            var resultado = await GetGerarParcelasHandler().HandleAsync(
                new GerarParcelasDevedorCommand(devedorId),
                CancellationToken.None);
            if (!resultado.IsSuccess)
            {
                ExibirErros(resultado);
                return;
            }

            MessageBox.Show("Parcelas geradas com sucesso.");
            LimparCampos();
            await CarregarDevedoresAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível gerar as parcelas: {ex.Message}");
        }
    }

    private static void ExibirErros(Result resultado) =>
        MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));

    private async void FrmCadDevedores_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = $"Data Cadastro: {DateTime.Now:dd/MM/yyyy}";
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
        await CarregarDevedoresAsync();
    }

    private void DgvListaDevedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListaDevedores.Rows[e.RowIndex].DataBoundItem is not DevedorDto devedor)
        {
            return;
        }

        devedorId = devedor.Id;
        TxtNome.Text = devedor.Nome;
        TxtDescricao.Text = devedor.Descricao;
        TxtValor.Text = devedor.Valor.ToString("#,##0.00");
        TxtParcelas.Text = devedor.Parcelas.ToString(CultureInfo.InvariantCulture);
        MktDataInicio.Text = devedor.DataInicio.ToString("dd/MM/yyyy");
        CbAtivo.Checked = devedor.Ativo;
        BtnAlterar.Enabled = !devedor.ParcelasGeradas;
        BtnExcluir.Enabled = !devedor.ParcelasGeradas;
        BtnGerar.Enabled = !devedor.ParcelasGeradas;
        BtnSalvar.Enabled = false;
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);
    private async void BtnGerar_Click(object sender, EventArgs e) => await GerarParcelasAsync();
    private async void FrmCadDevedores_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (frmPrincipal is not null)
        {
            await frmPrincipal.AtualizarDadosAsync();
        }
    }

    private void TxtValor_TextChanged(object sender, EventArgs e) => ValidarValor();
    private void TxtValor_Leave(object sender, EventArgs e) => FormatarValor();
    private void TxtValor_Enter(object sender, EventArgs e) { if (TxtValor.Text == "0,00") TxtValor.Text = string.Empty; }
    private void TxtParcelas_TextChanged(object sender, EventArgs e) => ValidarParcelas();
    private void TxtParcelas_Leave(object sender, EventArgs e) => FormatarParcelas();
    private void TxtParcelas_Enter(object sender, EventArgs e) { if (TxtParcelas.Text == "0") TxtParcelas.Text = "1"; }

    private void ValidarValor()
    {
        var validador = new ValidarNumero();
        TxtValor.Text = validador.Validar(TxtValor.Text);
        TxtValor.Select(TxtValor.Text.Length, 0);
    }

    private void FormatarValor()
    {
        var validador = new ValidarNumero();
        TxtValor.Text = validador.Formatar(validador.Zero(TxtValor.Text));
    }

    private void ValidarParcelas()
    {
        var validador = new ValidarNumero();
        TxtParcelas.Text = validador.ValidarNumeroInteiro(TxtParcelas.Text);
        TxtParcelas.Select(TxtParcelas.Text.Length, 0);
    }

    private void FormatarParcelas()
    {
        var validador = new ValidarNumero();
        TxtParcelas.Text = validador.FormatarInteiro(validador.ZeroInteiro(TxtParcelas.Text));
    }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private CadastrarDevedorHandler GetCadastrarHandler() => cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarDevedorHandler GetAtualizarHandler() => atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirDevedorHandler GetExcluirHandler() => excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private GerarParcelasDevedorHandler GetGerarParcelasHandler() => gerarParcelasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarDevedoresPorClienteHandler GetListarHandler() => listarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private readonly record struct DadosDevedor(string Nome, string Descricao, decimal Valor, int Parcelas, DateOnly DataInicio, bool Ativo);

    private enum Operacao { Cadastrar, Atualizar, Excluir }
}
