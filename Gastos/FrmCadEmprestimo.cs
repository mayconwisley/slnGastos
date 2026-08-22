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

public partial class FrmCadEmprestimo : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly string login = string.Empty;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarEmprestimoHandler cadastrarHandler;
    private readonly AtualizarEmprestimoHandler atualizarHandler;
    private readonly ExcluirEmprestimoHandler excluirHandler;
    private readonly GerarParcelasEmprestimoHandler gerarParcelasHandler;
    private readonly ListarEmprestimosPorClienteHandler listarHandler;
    private int clienteId;
    private int emprestimoId;
    private bool carregandoClientes;

    public FrmCadEmprestimo()
    {
        InitializeComponent();
    }

    public FrmCadEmprestimo(
        FrmPrincipal frmPrincipal,
        string login,
        ListarClientesHandler listarClientesHandler,
        CadastrarEmprestimoHandler cadastrarHandler,
        AtualizarEmprestimoHandler atualizarHandler,
        ExcluirEmprestimoHandler excluirHandler,
        GerarParcelasEmprestimoHandler gerarParcelasHandler,
        ListarEmprestimosPorClienteHandler listarHandler)
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

    private async Task CarregarEmprestimosAsync()
    {
        DgvListaEmprestimos.DataSource = clienteId <= 0
            ? null
            : await GetListarHandler().HandleAsync(
                new ListarEmprestimosPorClienteQuery(clienteId),
                CancellationToken.None);

        AtualizarTotais();
    }

    private async Task ExecutarAsync(Operacao operacao)
    {
        try
        {
            Result resultado = operacao switch
            {
                Operacao.Cadastrar => await CadastrarAsync(),
                Operacao.Atualizar => await AtualizarAsync(),
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(
                    new ExcluirEmprestimoCommand(emprestimoId),
                    CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };

            ExibirErros(resultado);
            if (!resultado.IsSuccess)
            {
                return;
            }

            LimparCampos();
            await CarregarEmprestimosAsync();
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
            return Result.Failure(new Error("emprestimo.entrada.invalida", "Corrija os dados informados."));
        }

        var resultado = await GetCadastrarHandler().HandleAsync(
            new CadastrarEmprestimoCommand(
                dados.DataInicio,
                dados.Descricao,
                dados.ValorEmprestado,
                dados.ValorParcela,
                dados.Parcelas,
                dados.Ativo,
                login,
                clienteId),
            CancellationToken.None);

        return resultado.IsSuccess
            ? Result.Success()
            : Result.Failure(resultado.Errors.ToArray());
    }

    private async Task<Result> AtualizarAsync()
    {
        if (!TryObterDados(out var dados))
        {
            return Result.Failure(new Error("emprestimo.entrada.invalida", "Corrija os dados informados."));
        }

        return await GetAtualizarHandler().HandleAsync(
            new AtualizarEmprestimoCommand(
                emprestimoId,
                dados.DataInicio,
                dados.Descricao,
                dados.ValorEmprestado,
                dados.ValorParcela,
                dados.Parcelas,
                dados.Ativo),
            CancellationToken.None);
    }

    private bool TryObterDados(out DadosEmprestimo dados)
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

        if (!decimal.TryParse(TxtValorEmprestado.Text, NumberStyles.Number, cultura, out var valorEmprestado) ||
            !decimal.TryParse(TxtValorParcela.Text, NumberStyles.Number, cultura, out var valorParcela) ||
            !int.TryParse(TxtParcela.Text, NumberStyles.Integer, cultura, out var parcelas))
        {
            MessageBox.Show("Informe valores e quantidade de parcelas válidos.");
            return false;
        }

        dados = new DadosEmprestimo(
            DateOnly.FromDateTime(dataInicio),
            TxtDescricao.Text.Trim(),
            valorEmprestado,
            valorParcela,
            parcelas,
            CbAtivo.Checked);
        return true;
    }

    private void LimparCampos()
    {
        emprestimoId = 0;
        TxtDescricao.Clear();
        TxtValorParcela.Text = "0,00";
        TxtParcela.Text = "1";
        TxtValorEmprestado.Text = "0,00";
        MktDataInicio.Clear();
        CbAtivo.Checked = true;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnGerar.Enabled = false;
        BtnSalvar.Enabled = true;
        MktDataInicio.Focus();
    }

    private void AtualizarTotais()
    {
        var emprestimos = DgvListaEmprestimos.DataSource as IReadOnlyList<EmprestimoDto> ?? [];
        var ativos = emprestimos.Where(item => item.Ativo).Sum(item => item.ValorParcela);
        var inativos = emprestimos.Where(item => !item.Ativo).Sum(item => item.ValorParcela);
        LblTotalAtivo.Text = $"Total Ativo..: {ativos:#,##0.00}";
        LblTotalNAtivo.Text = $"Total Ñ Ativo: {inativos:#,##0.00}";
        LblTotalGeral.Text = $"Total Geral..: {(ativos + inativos):#,##0.00}";
    }

    private async Task GerarParcelasAsync()
    {
        if (emprestimoId <= 0)
        {
            return;
        }

        try
        {
            var resultado = await GetGerarParcelasHandler().HandleAsync(
                new GerarParcelasEmprestimoCommand(emprestimoId),
                CancellationToken.None);
            ExibirErros(resultado);
            if (!resultado.IsSuccess)
            {
                return;
            }

            MessageBox.Show("Parcelas geradas com sucesso.");
            LimparCampos();
            await CarregarEmprestimosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível gerar as parcelas: {ex.Message}");
        }
    }

    private static void ExibirErros(Result resultado)
    {
        if (!resultado.IsSuccess)
        {
            MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));
        }
    }

    private async void FrmCadEmprestimo_Load(object sender, EventArgs e)
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
        await CarregarEmprestimosAsync();
    }

    private void DgvListaEmprestimos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListaEmprestimos.Rows[e.RowIndex].DataBoundItem is not EmprestimoDto emprestimo)
        {
            return;
        }

        emprestimoId = emprestimo.Id;
        TxtDescricao.Text = emprestimo.Descricao;
        TxtParcela.Text = emprestimo.Parcelas.ToString(CultureInfo.InvariantCulture);
        TxtValorEmprestado.Text = emprestimo.ValorEmprestado.ToString("#,##0.00");
        TxtValorParcela.Text = emprestimo.ValorParcela.ToString("#,##0.00");
        MktDataInicio.Text = emprestimo.DataInicio.ToString("dd/MM/yyyy");
        CbAtivo.Checked = emprestimo.Ativo;
        BtnGerar.Enabled = !emprestimo.ParcelasGeradas;
        BtnAlterar.Enabled = !emprestimo.ParcelasGeradas;
        BtnExcluir.Enabled = !emprestimo.ParcelasGeradas;
        BtnSalvar.Enabled = false;
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);
    private async void BtnGerar_Click(object sender, EventArgs e) => await GerarParcelasAsync();
    private async void FrmCadEmprestimo_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (frmPrincipal is not null)
        {
            await frmPrincipal.AtualizarDadosAsync();
        }
    }

    private void TxtValorEmprestado_TextChanged(object sender, EventArgs e) => ValidarValor(TxtValorEmprestado);
    private void TxtValorParcela_TextChanged(object sender, EventArgs e) => ValidarValor(TxtValorParcela);
    private void TxtValorEmprestado_Leave(object sender, EventArgs e) => FormatarValor(TxtValorEmprestado);
    private void TxtValorParcela_Leave(object sender, EventArgs e) => FormatarValor(TxtValorParcela);
    private void TxtValorEmprestado_Enter(object sender, EventArgs e) => LimparZero(TxtValorEmprestado);
    private void TxtValorParcela_Enter(object sender, EventArgs e) => LimparZero(TxtValorParcela);

    private void TxtParcela_TextChanged(object sender, EventArgs e)
    {
        var validador = new ValidarNumero();
        TxtParcela.Text = validador.ValidarNumeroInteiro(TxtParcela.Text);
        TxtParcela.Select(TxtParcela.Text.Length, 0);
    }

    private void TxtParcela_Leave(object sender, EventArgs e)
    {
        var validador = new ValidarNumero();
        TxtParcela.Text = validador.FormatarInteiro(validador.ZeroInteiro(TxtParcela.Text));
    }

    private static void ValidarValor(TextBox campo)
    {
        var validador = new ValidarNumero();
        campo.Text = validador.Validar(campo.Text);
        campo.Select(campo.Text.Length, 0);
    }

    private static void FormatarValor(TextBox campo)
    {
        var validador = new ValidarNumero();
        campo.Text = validador.Formatar(validador.Zero(campo.Text));
    }

    private static void LimparZero(TextBox campo)
    {
        if (campo.Text == "0,00")
        {
            campo.Text = string.Empty;
        }
    }

    private ListarClientesHandler GetListarClientesHandler() =>
        listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarEmprestimoHandler GetCadastrarHandler() =>
        cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarEmprestimoHandler GetAtualizarHandler() =>
        atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirEmprestimoHandler GetExcluirHandler() =>
        excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private GerarParcelasEmprestimoHandler GetGerarParcelasHandler() =>
        gerarParcelasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarEmprestimosPorClienteHandler GetListarHandler() =>
        listarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private readonly record struct DadosEmprestimo(
        DateOnly DataInicio,
        string Descricao,
        decimal ValorEmprestado,
        decimal ValorParcela,
        int Parcelas,
        bool Ativo);

    private enum Operacao
    {
        Cadastrar,
        Atualizar,
        Excluir
    }
}
