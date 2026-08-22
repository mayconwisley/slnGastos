using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Domain.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadCompetencia : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarCompetenciaHandler cadastrarCompetenciaHandler;
    private readonly AtualizarCompetenciaHandler atualizarCompetenciaHandler;
    private readonly ExcluirCompetenciaHandler excluirCompetenciaHandler;
    private readonly ListarCompetenciasPorClienteHandler listarCompetenciasHandler;
    private int idCliente;
    private int idCompetencia;
    private bool carregandoClientes;

    public FrmCadCompetencia()
    {
        InitializeComponent();
    }

    public FrmCadCompetencia(
        FrmPrincipal frmPrincipal,
        ListarClientesHandler listarClientesHandler,
        CadastrarCompetenciaHandler cadastrarCompetenciaHandler,
        AtualizarCompetenciaHandler atualizarCompetenciaHandler,
        ExcluirCompetenciaHandler excluirCompetenciaHandler,
        ListarCompetenciasPorClienteHandler listarCompetenciasHandler)
    {
        InitializeComponent();
        this.frmPrincipal = frmPrincipal;
        this.listarClientesHandler = listarClientesHandler;
        this.cadastrarCompetenciaHandler = cadastrarCompetenciaHandler;
        this.atualizarCompetenciaHandler = atualizarCompetenciaHandler;
        this.excluirCompetenciaHandler = excluirCompetenciaHandler;
        this.listarCompetenciasHandler = listarCompetenciasHandler;
    }

    private async Task ListarClientesAsync()
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

    private async Task ListarCompetenciasAsync()
    {
        if (idCliente <= 0)
        {
            DgvListaCompetencia.DataSource = null;
            return;
        }

        DgvListaCompetencia.DataSource = await GetListarCompetenciasHandler()
            .HandleAsync(new ListarCompetenciasPorClienteQuery(idCliente), CancellationToken.None);
    }

    private async Task ExecutarCadastroAsync(OperacaoCompetencia operacao)
    {
        if (!DateTime.TryParseExact(
                MktCompetencia.Text.Trim(),
                "MM/yyyy",
                CultureInfo.GetCultureInfo("pt-BR"),
                DateTimeStyles.None,
                out var dataReferencia))
        {
            MessageBox.Show("Informe uma competência válida no formato MM/aaaa.");
            return;
        }

        var mesReferencia = DateOnly.FromDateTime(dataReferencia);

        try
        {
            var resultado = operacao switch
            {
                OperacaoCompetencia.Cadastrar => await CadastrarAsync(mesReferencia),
                OperacaoCompetencia.Atualizar => await AtualizarAsync(mesReferencia),
                OperacaoCompetencia.Excluir => await ExcluirAsync(),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };

            if (!resultado.IsSuccess)
            {
                MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));
                return;
            }

            LimparFormulario();
            await ListarCompetenciasAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível concluir a operação: {ex.Message}");
        }
    }

    private async Task<Result> CadastrarAsync(DateOnly mesReferencia)
    {
        var resultado = await GetCadastrarCompetenciaHandler().HandleAsync(
            new CadastrarCompetenciaCommand(mesReferencia, idCliente, CbAtivo.Checked),
            CancellationToken.None);

        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private Task<Result> AtualizarAsync(DateOnly mesReferencia) =>
        GetAtualizarCompetenciaHandler().HandleAsync(
            new AtualizarCompetenciaCommand(idCompetencia, mesReferencia, CbAtivo.Checked),
            CancellationToken.None);

    private Task<Result> ExcluirAsync() =>
        GetExcluirCompetenciaHandler().HandleAsync(
            new ExcluirCompetenciaCommand(idCompetencia),
            CancellationToken.None);

    private void LimparFormulario()
    {
        idCompetencia = 0;
        MktCompetencia.Clear();
        CbAtivo.Checked = false;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnSalvar.Enabled = true;
        MktCompetencia.Focus();
    }

    private async void FrmCadCompetencia_Load(object sender, EventArgs e)
    {
        try
        {
            await ListarClientesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar os clientes: {ex.Message}");
        }
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int clienteId)
        {
            return;
        }

        idCliente = clienteId;
        LimparFormulario();

        try
        {
            await ListarCompetenciasAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar as competências: {ex.Message}");
        }
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) =>
        await ExecutarCadastroAsync(OperacaoCompetencia.Cadastrar);

    private async void BtnAlterar_Click(object sender, EventArgs e) =>
        await ExecutarCadastroAsync(OperacaoCompetencia.Atualizar);

    private async void BtnExcluir_Click(object sender, EventArgs e) =>
        await ExecutarCadastroAsync(OperacaoCompetencia.Excluir);

    private async void FrmCadCompetencia_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (frmPrincipal is not null)
        {
            await frmPrincipal.AtualizarDadosAsync();
        }
    }

    private void DgvListaCompetencia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListaCompetencia.Rows[e.RowIndex].DataBoundItem is not CompetenciaDto competencia)
        {
            return;
        }

        idCompetencia = competencia.Id;
        MktCompetencia.Text = competencia.MesReferencia.ToString("MM/yyyy");
        CbAtivo.Checked = competencia.Ativa;
        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;
    }

    private ListarClientesHandler GetListarClientesHandler() =>
        listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarCompetenciaHandler GetCadastrarCompetenciaHandler() =>
        cadastrarCompetenciaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarCompetenciaHandler GetAtualizarCompetenciaHandler() =>
        atualizarCompetenciaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirCompetenciaHandler GetExcluirCompetenciaHandler() =>
        excluirCompetenciaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarCompetenciasPorClienteHandler GetListarCompetenciasHandler() =>
        listarCompetenciasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private enum OperacaoCompetencia
    {
        Cadastrar,
        Atualizar,
        Excluir
    }
}
