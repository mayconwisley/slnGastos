using Negocio.Cliente.Listar;
using Negocio.Competencia;
using Negocio.Competencia.Listar;
using Negocio.Utilitario;
using Objeto.Cliente;
using Objeto.Competencia;
using System;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmCadCompetencia : Form
    {
        int idCliente, idCompetencia;
        FrmPrincipal frmForm;

        public FrmCadCompetencia()
        {
            InitializeComponent();
        }

        public FrmCadCompetencia(FrmPrincipal form)
        {
            InitializeComponent();
            frmForm = form; 
        }

        private void ListarCliente()
        {
            IdNomeCliente idNomeCliente = new IdNomeCliente();
            CbxNome.DataSource = idNomeCliente.Consulta();
        }

        private void Cadastro(OpcaoCadastro opcaoCadastro)
        {

            CompetenciaObj competencia = new CompetenciaObj();
            Inserir inserir = new Inserir();
            Alterar alterar = new Alterar();
            Excluir excluir = new Excluir();
            AlterarCompetenciaAtivoNao alterarCompetenciaAtivoNao = new AlterarCompetenciaAtivoNao();

            try
            {
                competencia.Id = idCompetencia;
                competencia.Data = DateTime.Parse(MktCompetencia.Text.Trim());
                competencia.Cliente = new ClienteObj();
                competencia.Cliente.Id = idCliente;

                if (CbAtivo.Checked)
                {
                    competencia.Ativo = "Sim";
                }
                else
                {
                    competencia.Ativo = "Não";
                }

                switch (opcaoCadastro)
                {
                    case OpcaoCadastro.Salvar:
                        if (CbAtivo.Checked)
                        {
                            alterarCompetenciaAtivoNao.Cadastro(idCliente);
                        }
                        inserir.Cadastro(competencia);
                        break;
                    case OpcaoCadastro.Alterar:
                        if (CbAtivo.Checked)
                        {
                            alterarCompetenciaAtivoNao.Cadastro(idCliente);
                        }
                        alterar.Cadastro(competencia);
                        break;
                    case OpcaoCadastro.Excluir:
                        excluir.Cadastro(competencia);
                        break;
                    default:
                        break;
                }

                BtnAlterar.Enabled = false;
                BtnExcluir.Enabled = false;
                BtnSalvar.Enabled = true;
                ListarCompetencia(idCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListarCompetencia(int idCliente)
        {
            CadastroCompetencia cadastroCompetencia = new CadastroCompetencia();
            DgvListaCompetencia.DataSource = cadastroCompetencia.Consulta(idCliente);
            MktCompetencia.Clear();
            MktCompetencia.Focus();
        }

        private void FrmCadCompetencia_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }

        private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = int.Parse(CbxNome.SelectedValue.ToString());
            ListarCompetencia(idCliente);
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

        private void FrmCadCompetencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmForm.AtualizarFrmPrincipal();
        }

        private void DgvListaCompetencia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idCompetencia = int.Parse(DgvListaCompetencia.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            DateTime compe = DateTime.Parse(DgvListaCompetencia.Rows[e.RowIndex].Cells["Data"].Value.ToString());
            MktCompetencia.Text = compe.ToString("MM/yyyy");

            if (DgvListaCompetencia.Rows[e.RowIndex].Cells["Ativo"].Value.ToString() == "Sim")
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
