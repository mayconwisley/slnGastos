using Gastos.Application.Clientes;
using Gastos.Domain.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gastos;

public partial class FrmCadCliente : Form
{
    #region Variaveis
    private string strUsuario = string.Empty;
    private int idCliente;
    private FrmPrincipal frmPrincipal;
    private CadastrarClienteHandler cadastrarClienteHandler;
    private AtualizarClienteHandler atualizarClienteHandler;
    private ExcluirClienteHandler excluirClienteHandler;
    private ListarClientesHandler listarClientesHandler;
    #endregion


    public FrmCadCliente()
    {
        InitializeComponent();
    }

    public FrmCadCliente(string usuario)
    {
        InitializeComponent();
        strUsuario = usuario;
    }
    public FrmCadCliente(
        FrmPrincipal frm,
        string usuario,
        CadastrarClienteHandler cadastrarClienteHandler,
        AtualizarClienteHandler atualizarClienteHandler,
        ExcluirClienteHandler excluirClienteHandler,
        ListarClientesHandler listarClientesHandler)
    {
        InitializeComponent();
        strUsuario = usuario;
        frmPrincipal = frm;
        this.cadastrarClienteHandler = cadastrarClienteHandler;
        this.atualizarClienteHandler = atualizarClienteHandler;
        this.excluirClienteHandler = excluirClienteHandler;
        this.listarClientesHandler = listarClientesHandler;
    }


    #region Funções
    private async Task CadastroAsync(OperacaoCliente operacao)
    {
        try
        {
            Result result = operacao switch
            {
                OperacaoCliente.Cadastrar => await CadastrarAsync(),
                OperacaoCliente.Atualizar => await AtualizarAsync(),
                OperacaoCliente.Excluir => await ExcluirAsync(),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };

            if (!result.IsSuccess)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Select(error => error.Description)));
                return;
            }

            LimparCampo();
            await ListarClienteAsync();

            BtnAlterar.Enabled = false;
            BtnExcluir.Enabled = false;
            BtnSalvar.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void LimparCampo()
    {
        idCliente = 0;
        TxtNome.Clear();
        CbAtivo.Checked = true;
    }

    private async Task ListarClienteAsync()
    {
        DgvListarClientes.DataSource = await GetListarClientesHandler()
            .HandleAsync(new ListarClientesQuery(), CancellationToken.None);
    }

    private async Task<Result> CadastrarAsync()
    {
        Result<int> result = await GetCadastrarClienteHandler().HandleAsync(
            new CadastrarClienteCommand(TxtNome.Text, strUsuario, CbAtivo.Checked),
            CancellationToken.None);

        return result.IsSuccess ? Result.Success() : Result.Failure(result.Errors.ToArray());
    }

    private Task<Result> AtualizarAsync() => GetAtualizarClienteHandler().HandleAsync(
        new AtualizarClienteCommand(idCliente, TxtNome.Text, CbAtivo.Checked),
        CancellationToken.None);

    private Task<Result> ExcluirAsync() => GetExcluirClienteHandler().HandleAsync(
        new ExcluirClienteCommand(idCliente),
        CancellationToken.None);

    private CadastrarClienteHandler GetCadastrarClienteHandler() =>
        cadastrarClienteHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarClienteHandler GetAtualizarClienteHandler() =>
        atualizarClienteHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirClienteHandler GetExcluirClienteHandler() =>
        excluirClienteHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarClientesHandler GetListarClientesHandler() =>
        listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    #endregion

    private async void FrmCadCliente_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
        await ListarClienteAsync();
    }

    private async void BtnSalvar_Click(object sender, EventArgs e)
    {
        await CadastroAsync(OperacaoCliente.Cadastrar);
    }

    private async void BtnAlterar_Click(object sender, EventArgs e)
    {
        await CadastroAsync(OperacaoCliente.Atualizar);
    }

    private async void BtnExcluir_Click(object sender, EventArgs e)
    {
        await CadastroAsync(OperacaoCliente.Excluir);
    }

    private void DgvListarClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        idCliente = int.Parse(DgvListarClientes.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        TxtNome.Text = DgvListarClientes.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        CbAtivo.Checked = (bool)DgvListarClientes.Rows[e.RowIndex].Cells["Ativo"].Value;

        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;
    }

    private async void FrmCadCliente_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            if (frmPrincipal is not null)
            {
                await frmPrincipal.ListarClienteAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private enum OperacaoCliente
    {
        Cadastrar,
        Atualizar,
        Excluir
    }
}
