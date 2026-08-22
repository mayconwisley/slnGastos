using Gastos.Application.Usuarios;
using Gastos.Domain.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadUsuario : Form
{
    private readonly CadastrarUsuarioHandler cadastrarHandler;
    private readonly AtualizarUsuarioHandler atualizarHandler;
    private readonly ExcluirUsuarioHandler excluirHandler;
    private readonly ListarUsuariosHandler listarHandler;
    private string loginSelecionado = string.Empty;

    public FrmCadUsuario()
    {
        InitializeComponent();
    }

    public FrmCadUsuario(CadastrarUsuarioHandler cadastrarHandler, AtualizarUsuarioHandler atualizarHandler, ExcluirUsuarioHandler excluirHandler, ListarUsuariosHandler listarHandler)
    {
        InitializeComponent();
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
    }

    private async Task CarregarUsuariosAsync()
    {
        dgvListaUsuario.DataSource = await GetListarHandler().HandleAsync(CancellationToken.None);
    }

    private async Task ExecutarAsync(Operacao operacao)
    {
        if (!ValidarSenha(operacao)) return;

        try
        {
            Result resultado = operacao switch
            {
                Operacao.Cadastrar => await GetCadastrarHandler().HandleAsync(
                    new CadastrarUsuarioCommand(TxtLogin.Text.Trim(), TxtNome.Text.Trim(), TxtSenha.Text, TxtLembSenha.Text.Trim(), CbAtivo.Checked),
                    CancellationToken.None),
                Operacao.Atualizar => await GetAtualizarHandler().HandleAsync(
                    new AtualizarUsuarioCommand(loginSelecionado, TxtNome.Text.Trim(), string.IsNullOrWhiteSpace(TxtSenha.Text) ? null : TxtSenha.Text, TxtLembSenha.Text.Trim(), CbAtivo.Checked),
                    CancellationToken.None),
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(new ExcluirUsuarioCommand(loginSelecionado), CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };

            if (!resultado.IsSuccess)
            {
                MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description)));
                return;
            }

            LimparCampos();
            await CarregarUsuariosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível concluir a operação: {ex.Message}");
        }
    }

    private bool ValidarSenha(Operacao operacao)
    {
        if (operacao == Operacao.Excluir) return !string.IsNullOrWhiteSpace(loginSelecionado);
        if (string.IsNullOrWhiteSpace(TxtNome.Text) || string.IsNullOrWhiteSpace(TxtLogin.Text))
        {
            MessageBox.Show("Informe nome e login.");
            return false;
        }

        if (operacao == Operacao.Cadastrar && string.IsNullOrWhiteSpace(TxtSenha.Text))
        {
            MessageBox.Show("Informe uma senha.");
            return false;
        }

        if (!string.IsNullOrWhiteSpace(TxtSenha.Text) && TxtSenha.Text != TxtConfSenha.Text)
        {
            MessageBox.Show("Senha não confere, ajuste e tente novamente.");
            return false;
        }

        return true;
    }

    private void LimparCampos()
    {
        loginSelecionado = string.Empty;
        TxtConfSenha.Clear();
        TxtLembSenha.Clear();
        TxtLogin.Clear();
        TxtNome.Clear();
        TxtSenha.Clear();
        CbAtivo.Checked = true;
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnSalvar.Enabled = true;
        TxtLogin.Enabled = true;
    }

    private void CbMostrarSenha_CheckedChanged(object sender, EventArgs e)
    {
        TxtSenha.UseSystemPasswordChar = !CbMostrarSenha.Checked;
        TxtConfSenha.UseSystemPasswordChar = !CbMostrarSenha.Checked;
    }

    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);

    private void dgvListaUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvListaUsuario.Rows[e.RowIndex].DataBoundItem is not UsuarioDto usuario) return;
        loginSelecionado = usuario.Login;
        TxtNome.Text = usuario.Nome;
        TxtLogin.Text = usuario.Login;
        TxtLembSenha.Text = usuario.Lembrete;
        TxtSenha.Clear();
        TxtConfSenha.Clear();
        CbAtivo.Checked = usuario.EstaAtivo;
        TxtLogin.Enabled = false;
        BtnSalvar.Enabled = false;
        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
    }

    private async void FrmCadUsuario_Load(object sender, EventArgs e)
    {
        LblDataAtual.Text = $"Data Cadastro: {DateTime.Now:dd/MM/yyyy}";
        try { await CarregarUsuariosAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private CadastrarUsuarioHandler GetCadastrarHandler() => cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarUsuarioHandler GetAtualizarHandler() => atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirUsuarioHandler GetExcluirHandler() => excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarUsuariosHandler GetListarHandler() => listarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private enum Operacao { Cadastrar, Atualizar, Excluir }
}
