using Gastos.Application.Usuarios;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmTelaLogin : Form
{
    private readonly QuantidadeUsuariosHandler quantidadeUsuariosHandler;
    private readonly AutenticarUsuarioHandler autenticarUsuarioHandler;
    private readonly ObterLembreteSenhaHandler obterLembreteSenhaHandler;
    private readonly CadastrarUsuarioHandler cadastrarUsuarioHandler;
    private readonly AtualizarUsuarioHandler atualizarUsuarioHandler;
    private readonly ExcluirUsuarioHandler excluirUsuarioHandler;
    private readonly ListarUsuariosHandler listarUsuariosHandler;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Login { get; private set; } = string.Empty;

    public FrmTelaLogin()
    {
        InitializeComponent();
    }

    public FrmTelaLogin(
        QuantidadeUsuariosHandler quantidadeUsuariosHandler,
        AutenticarUsuarioHandler autenticarUsuarioHandler,
        ObterLembreteSenhaHandler obterLembreteSenhaHandler,
        CadastrarUsuarioHandler cadastrarUsuarioHandler,
        AtualizarUsuarioHandler atualizarUsuarioHandler,
        ExcluirUsuarioHandler excluirUsuarioHandler,
        ListarUsuariosHandler listarUsuariosHandler)
    {
        InitializeComponent();
        this.quantidadeUsuariosHandler = quantidadeUsuariosHandler;
        this.autenticarUsuarioHandler = autenticarUsuarioHandler;
        this.obterLembreteSenhaHandler = obterLembreteSenhaHandler;
        this.cadastrarUsuarioHandler = cadastrarUsuarioHandler;
        this.atualizarUsuarioHandler = atualizarUsuarioHandler;
        this.excluirUsuarioHandler = excluirUsuarioHandler;
        this.listarUsuariosHandler = listarUsuariosHandler;
    }

    private async Task LembrarSenhaAsync()
    {
        if (string.IsNullOrWhiteSpace(TxtLogin.Text))
        {
            MessageBox.Show("Digite um usuário para pesquisar o lembrete de senha.");
            return;
        }

        try
        {
            var resultado = await GetObterLembreteSenhaHandler().HandleAsync(new ObterLembreteSenhaQuery(TxtLogin.Text.Trim()), CancellationToken.None);
            MessageBox.Show(resultado.IsSuccess
                ? $"Seu lembrete de senha é: {resultado.Value}"
                : string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async Task AcessarAsync()
    {
        try
        {
            var login = TxtLogin.Text.Trim();
            var resultado = await GetAutenticarUsuarioHandler().HandleAsync(new AutenticarUsuarioCommand(login, TxtSenha.Text), CancellationToken.None);
            if (!resultado.IsSuccess)
            {
                MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));
                return;
            }

            Login = login;
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void FrmTelaLogin_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            ProcessTabKey(true);
            e.Handled = true;
        }
    }

    private async void TxtSenha_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) await AcessarAsync();
    }

    private async void FrmTelaLogin_Load(object sender, EventArgs e)
    {
        try
        {
            if (await GetQuantidadeUsuariosHandler().HandleAsync(CancellationToken.None) == 0)
            {
                using var cadastro = new FrmCadUsuario(
                    GetCadastrarUsuarioHandler(),
                    GetAtualizarUsuarioHandler(),
                    GetExcluirUsuarioHandler(),
                    GetListarUsuariosHandler());
                cadastro.MinimizeBox = false;
                cadastro.TopMost = true;
                cadastro.ShowDialog();
            }

            TxtLogin.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void LkLblLembreSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => await LembrarSenhaAsync();
    private async void BtnAcessar_Click(object sender, EventArgs e) => await AcessarAsync();
    private void BtnCancelar_Click(object sender, EventArgs e) => System.Windows.Forms.Application.Exit();

    private QuantidadeUsuariosHandler GetQuantidadeUsuariosHandler() => quantidadeUsuariosHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AutenticarUsuarioHandler GetAutenticarUsuarioHandler() => autenticarUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ObterLembreteSenhaHandler GetObterLembreteSenhaHandler() => obterLembreteSenhaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private CadastrarUsuarioHandler GetCadastrarUsuarioHandler() => cadastrarUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarUsuarioHandler GetAtualizarUsuarioHandler() => atualizarUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirUsuarioHandler GetExcluirUsuarioHandler() => excluirUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarUsuariosHandler GetListarUsuariosHandler() => listarUsuariosHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
}
