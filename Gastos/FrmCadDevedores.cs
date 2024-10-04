using Negocio.Cliente.Listar;
using Negocio.Devedores;
using Negocio.Devedores.Listar;
using Negocio.Movimento.Devedor.Listar;
using Negocio.Utilitario;
using Objeto.Devedores;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadDevedores : Form
{
    string strLogin;
    int idCliente, idDevedores;
    FrmPrincipal frmForm;
    public FrmCadDevedores(string login)
    {
        InitializeComponent();
        strLogin = login;
    }

    public FrmCadDevedores(FrmPrincipal form, string login)
    {
        InitializeComponent();
        strLogin = login;
        frmForm = form;
    }
    private void ListaCliente()
    {
        IdNomeCliente idNomeCliente = new IdNomeCliente();
        CbxNome.DataSource = idNomeCliente.Consulta();
    }

    private void ListaDevedores(int idCliente)
    {
        CadastroDevedoresCliente cadastroDevedoresCliente = new CadastroDevedoresCliente();
        DgvListaDevedores.DataSource = cadastroDevedoresCliente.Consulta(idCliente);
    }

    private void CadastroDevedores(OpcaoCadastro opcaoCadastro)
    {
        DevedoresObj devedores = new DevedoresObj();
        Inserir inserir = new Inserir();
        Alterar alterar = new Alterar();
        Excluir excluir = new Excluir();

        try
        {
            devedores.Id = idDevedores;
            devedores.Nome = TxtNome.Text.Trim();

            if (CbAtivo.Checked)
            {
                devedores.Ativo = "Sim";
            }
            else
            {
                devedores.Ativo = "Não";
            }

            devedores.Usuario = new Objeto.Usuario.UsuarioObj();
            devedores.Usuario.Login = strLogin;
            devedores.Cliente = new Objeto.Cliente.ClienteObj();
            devedores.Cliente.Id = idCliente;
            devedores.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

            switch (opcaoCadastro)
            {
                case OpcaoCadastro.Salvar:
                    inserir.Cadastro(devedores);
                    break;
                case OpcaoCadastro.Alterar:
                    alterar.Cadastro(devedores);
                    break;
                case OpcaoCadastro.Excluir:
                    excluir.Cadastro(devedores);
                    break;
                default:
                    break;
            }

            ListaDevedores(idCliente);
            LimparCampo();
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
        TxtNome.Clear();
    }

    private void DgvListaDevedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        DevedoresIdMovimento devedoresIdMovimento = new DevedoresIdMovimento();

        idDevedores = int.Parse(DgvListaDevedores.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        TxtNome.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        if (DgvListaDevedores.Rows[e.RowIndex].Cells["Ativo"].Value.ToString() == "Sim")
        {
            CbAtivo.Checked = true;
        }
        else
        {
            CbAtivo.Checked = false;
        }

        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        CadastroDevedores(OpcaoCadastro.Salvar);
    }

    private void BtnAlterar_Click(object sender, EventArgs e)
    {
        CadastroDevedores(OpcaoCadastro.Alterar);
    }

    private void BtnExcluir_Click(object sender, EventArgs e)
    {
        CadastroDevedores(OpcaoCadastro.Excluir);
    }
    private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        idCliente = int.Parse(CbxNome.SelectedValue.ToString());
        ListaDevedores(idCliente);
    }

    private void FrmCadDevedores_FormClosing(object sender, FormClosingEventArgs e)
    {
        frmForm.AtualizarFrmPrincipal();
    }

    private void FrmCadDevedores_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
        ListaCliente();
    }
}
