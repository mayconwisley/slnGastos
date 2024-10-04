using Criptografia;
using Negocio.Usuario;
using Negocio.Usuario.Listar;
using Negocio.Utilitario;
using Objeto.Usuario;
using System;
using System.Windows.Forms;


namespace Gastos;

public partial class FrmCadUsuario : Form
{
    public FrmCadUsuario()
    {
        InitializeComponent();
    }

    #region Objetos

    #endregion

    #region Variaveis
    string strSenhaCrip, strChave, strSenhaDescrip;
    #endregion

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        Cadastro(OpcaoCadastro.Salvar);
    }

    #region Funções
    /*Cadastrar, Alterar e Excluir um usuário*/
    private void Cadastro(OpcaoCadastro opcaoCadastro)
    {
        UsuarioObj usuario = new UsuarioObj();
        Inserir inserir = new Inserir();
        Alterar alterar = new Alterar();
        Excluir excluir = new Excluir();

        try
        {
            strChave = Chave.Gerar();
            strSenhaCrip = Criptografar.CriptografarSenha(strChave, TxtSenha.Text.Trim());

            usuario.Login = TxtLogin.Text.Trim();
            usuario.Nome = TxtNome.Text.Trim();
            usuario.Chave = strChave;
            usuario.Senha = strSenhaCrip;
            usuario.Lembrete = TxtLembSenha.Text.Trim();
            usuario.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

            if (CbAtivo.Checked)
            {
                usuario.Ativo = "Sim";
            }
            else
            {
                usuario.Ativo = "Não";
            }

            if (TxtSenha.Text == TxtConfSenha.Text)
            {
                switch (opcaoCadastro)
                {
                    case OpcaoCadastro.Salvar:
                        if (VerificarCampos() == false)
                        {
                            inserir.Cadastro(usuario);
                        }
                        break;
                    case OpcaoCadastro.Alterar:
                        if (VerificarCampos() == false)
                        {
                            alterar.Cadastro(usuario);
                        }
                        break;
                    case OpcaoCadastro.Excluir:
                        excluir.Cadastro(usuario);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Senha não confere, ajuste e tente novamente!");
                return;
            }

            ListarUsuario();
            LimparCampos();

            BtnAlterar.Enabled = false;
            BtnExcluir.Enabled = false;
            BtnSalvar.Enabled = true;
            TxtLogin.Enabled = true;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private bool VerificarCampos()
    {
        if (TxtNome.Text == "" || TxtLogin.Text == "" || TxtSenha.Text == "")
        {
            MessageBox.Show("Campos: Nome, Login ou Senha estão em branco");
            return true;
        }
        else
        {
            return false;
        }

    }
    /*Listar os cadastro do usuário*/
    private void ListarUsuario()
    {
        CadastroUsuario cadastroUsuario = new CadastroUsuario();
        try
        {
            dgvListaUsuario.DataSource = cadastroUsuario.Consulta();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


    }
    /*Limpar campos após uma ação de Cadastrar, alterar ou excluir*/
    private void LimparCampos()
    {
        TxtConfSenha.Clear();
        TxtLembSenha.Clear();
        TxtLogin.Clear();
        TxtNome.Clear();
        TxtSenha.Clear();
    }
    #endregion


    private void CbMostrarSenha_CheckedChanged(object sender, EventArgs e)
    {
        if (CbMostrarSenha.Checked)
        {
            TxtSenha.UseSystemPasswordChar = false;
            TxtConfSenha.UseSystemPasswordChar = false;
        }
        else
        {
            TxtSenha.UseSystemPasswordChar = true;
            TxtConfSenha.UseSystemPasswordChar = true;
        }
    }

    private void BtnAlterar_Click(object sender, EventArgs e)
    {
        Cadastro(OpcaoCadastro.Alterar);
    }

    private void BtnExcluir_Click(object sender, EventArgs e)
    {
        Cadastro(OpcaoCadastro.Excluir);
    }

    private void dgvListaUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        TxtNome.Text = dgvListaUsuario.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        TxtLogin.Text = dgvListaUsuario.Rows[e.RowIndex].Cells["Login"].Value.ToString();

        strChave = dgvListaUsuario.Rows[e.RowIndex].Cells["Chaves"].Value.ToString();
        strSenhaCrip = dgvListaUsuario.Rows[e.RowIndex].Cells["Senha"].Value.ToString();

        strSenhaDescrip = Descriptografar.DescriptografarSenha(strChave, strSenhaCrip);

        TxtSenha.Text = strSenhaDescrip;
        TxtConfSenha.Text = strSenhaDescrip;

        TxtLembSenha.Text = dgvListaUsuario.Rows[e.RowIndex].Cells["Lembrete"].Value.ToString();


        if (dgvListaUsuario.Rows[e.RowIndex].Cells["Ativo"].Value.ToString() == "Sim")
        {
            CbAtivo.Checked = true;
        }
        else
        {
            CbAtivo.Checked = false;
        }

        TxtLogin.Enabled = false;
        BtnSalvar.Enabled = false;
        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
    }

    private void FrmCadUsuario_Load(object sender, EventArgs e)
    {
        LblDataAtual.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
        ListarUsuario();
    }
}
