using AcessarSistema.Login;
using Negocio.Usuario.Listar;
using Objeto.Usuario;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmTelaLogin : Form
{
    public string Login { get; set; }

    public FrmTelaLogin()
    {
        InitializeComponent();
    }

    private void LembrarSenha(string login)
    {
        UsuarioObj usuario = new UsuarioObj();
        LembreSenha lembrarSenha = new LembreSenha();
        try
        {
            usuario.Login = login;

            if (TxtLogin.Text == "")
            {
                MessageBox.Show("Digite um usuário para pesquisar o lembrete de Senha!");
                return;
            }

            string strLembrarSenha = lembrarSenha.LembreteSenha(usuario);

            MessageBox.Show("Seu lembrete de Senha é: " + strLembrarSenha);

        }
        catch (Exception ex)
        {
            MessageBox.Show("Usuário não cadastro no sistema!\n\n" + ex.Message);
        }
    }


    private void BtnAcessar_Click(object sender, EventArgs e)
    {
        UsuarioObj usuario = new UsuarioObj();


        try
        {
            usuario.Login = TxtLogin.Text.Trim();
            usuario.Senha = TxtSenha.Text.Trim();
            Login = TxtLogin.Text.Trim();

            if (Logar.Acessar(usuario))
            {

                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Usuário e/ou Senha estão incorretos!!!");
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show("Usuário não cadastro no sistema!\n\n" + ex.Message);
        }

    }

    private void FrmTelaLogin_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            this.ProcessTabKey(true);
            e.Handled = true;
        }
    }

    private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BtnAcessar_Click(e, e);
        }
    }

    private void FrmTelaLogin_Load(object sender, EventArgs e)
    {
        QuantidadeUsuario quantidadeUsuario = new QuantidadeUsuario();

        try
        {
            int qtdUsuario = quantidadeUsuario.QtdUsuario();
            if (qtdUsuario <= 0)
            {
                FrmCadUsuario frmCadUsuario = new FrmCadUsuario();
                frmCadUsuario.MinimizeBox = false;
                frmCadUsuario.TopMost = true;
                frmCadUsuario.ShowDialog();
            }

            if (TxtLogin.Text == "")
            {
                TxtLogin.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private void LkLblLembreSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        LembrarSenha(TxtLogin.Text.Trim());
    }

    private void BtnCancelar_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
