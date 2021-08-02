using Negocio.Cliente;
using Negocio.Cliente.Listar;
using Negocio.Utilitario;
using Objeto.Cliente;
using Objeto.Usuario;
using System;
using System.Windows.Forms;


namespace Gastos
{
    public partial class FrmCadCliente : Form
    {
        #region Variaveis
        string strUsuario = string.Empty;
        int idCliente = 0;



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

        #region Funções
        private void Cadastro(OpcaoCadastro opcaoCadastro)
        {
            ClienteObj cliente = new ClienteObj();
            Inserir inserir = new Inserir();
            Alterar alterar = new Alterar();
            Excluir excluir = new Excluir();


            try
            {
                cliente.Id = idCliente;
                cliente.Nome = TxtNome.Text.Trim();
                if (CbAtivo.Checked)
                {
                    cliente.Ativo = "Sim";
                }
                else
                {
                    cliente.Ativo = "Não";
                }
                cliente.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                cliente.Usuario = new UsuarioObj();
                cliente.Usuario.Login = strUsuario;

                switch (opcaoCadastro)
                {
                    case OpcaoCadastro.Salvar:
                        inserir.Cadastro(cliente);
                        break;
                    case OpcaoCadastro.Alterar:
                        alterar.Cadastro(cliente);
                        break;
                    case OpcaoCadastro.Excluir:
                        excluir.Cadastro(cliente);
                        break;
                    default:
                        break;
                }

                LimparCampo();
                ListarCliente();

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
        private void ListarCliente()
        {
            CadastroCliente cadastroCliente = new CadastroCliente();

            DgvListarClientes.DataSource = cadastroCliente.Consulta();
        }
        #endregion

        private void FrmCadCliente_Load(object sender, EventArgs e)
        {
            LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
            ListarCliente();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Cadastro(OpcaoCadastro.Salvar);
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            Cadastro(OpcaoCadastro.Alterar);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            Cadastro(OpcaoCadastro.Excluir);
        }

        private void DgvListarClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idCliente = int.Parse(DgvListarClientes.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            TxtNome.Text = DgvListarClientes.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            strUsuario = DgvListarClientes.Rows[e.RowIndex].Cells["Login"].Value.ToString();

            if (DgvListarClientes.Rows[e.RowIndex].Cells["Ativo"].Value.ToString() == "Sim")
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
    }
}
