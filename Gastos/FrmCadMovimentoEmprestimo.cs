using Negocio.Cliente.Listar;
using Negocio.Competencia.Listar;
using Negocio.Emprestimos.Listar;
using Negocio.Movimento.Emprestimo;
using Negocio.Movimento.Emprestimo.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.Competencia;
using Objeto.Emprestimos;
using Objeto.MovimentoEmprestimos;
using System;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmCadMovimentoEmprestimo : Form
    {
        string strLogin;
        int idCliente, idEmprestimo, idMovimentoEmp, idCompetencia;
        DateTime date;


        private FrmPrincipal frmForm;

        public FrmCadMovimentoEmprestimo(string login)
        {
            InitializeComponent();
            strLogin = login;
        }

        private void ListarCompetencia(int idCliente)
        {
            CompetenciaCliente competenciaCliente = new CompetenciaCliente();
            CompetenciaIdCliente competenciaIdCliente = new CompetenciaIdCliente();
            CompetenciaIdData competenciaIdData = new CompetenciaIdData();

            try
            {
                idCompetencia = competenciaIdCliente.CompetenciaId(idCliente);
                bool sucesso = DateTime.TryParse(competenciaCliente.CompetenciaAtiva(idCliente).ToString(), out date);

                if (sucesso)
                {
                    this.Text = "Cadastro Movimentação Empréstimo | Competência: " + date.ToString("MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Competência não cadastrada!! \n\n" + ex.Message);

            }
        }

        public FrmCadMovimentoEmprestimo(FrmPrincipal form, string login)
        {
            InitializeComponent();
            frmForm = form;
            strLogin = login;
        }

        private void ListarCliente()
        {
            IdNomeCliente idNomeCliente = new IdNomeCliente();
            CbxNome.DataSource = idNomeCliente.Consulta();
        }

        private void ListarEmprestimo(int idCliente)
        {
            CbxDescricao.Text = "";
            IdDescricaoEmprestimo idDescricaoEmprestimo = new IdDescricaoEmprestimo();
            CbxDescricao.DataSource = idDescricaoEmprestimo.Consulta(idCliente);
        }

        private void ListarMovimento(int idEmprestimo)
        {
            CadastroMovEmprCliente cadastroMovEmprCliente = new CadastroMovEmprCliente();
            DgvListarMovimentoEmp.DataSource = cadastroMovEmprCliente.Consulta(idEmprestimo);
            Informacoes();
        }

        private void CadastroMovimento(OpcaoCadastro opcaoCadastro)
        {
            MovimentoEmprestimoObj movimentoEmprestimo = new MovimentoEmprestimoObj();
            Negocio.Emprestimos.Alterar alterarEmprestimo = new Negocio.Emprestimos.Alterar();

            Inserir inserir = new Inserir();
            Alterar alterar = new Alterar();
            Excluir excluir = new Excluir();


            try
            {
                movimentoEmprestimo.Id = idMovimentoEmp;
                movimentoEmprestimo.Emprestimo = new EmprestimoObj();
                movimentoEmprestimo.Emprestimo.Id = idEmprestimo;
                movimentoEmprestimo.Valor = decimal.Parse(TxtValor.Text);
                movimentoEmprestimo.Pago = CbxPago.Text;
                movimentoEmprestimo.Usuario = new Objeto.Usuario.UsuarioObj();
                movimentoEmprestimo.Usuario.Login = strLogin;
                movimentoEmprestimo.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                movimentoEmprestimo.Competencia = new CompetenciaObj();
                movimentoEmprestimo.Competencia.Id = idCompetencia;
                DateTime dataParcela;
                bool sucessoDtParcela = DateTime.TryParse(MktDataParcela.Text, out dataParcela);

                movimentoEmprestimo.Parcela = int.Parse(TxtParcela.Text);
                movimentoEmprestimo.DataParcela = dataParcela;
                DateTime dataPagamento;
                bool sucesso = DateTime.TryParse(MktDataPagamento.Text, out dataPagamento);

                if (sucesso)
                {
                    movimentoEmprestimo.DataPagameno = dataPagamento;
                }

                switch (opcaoCadastro)
                {
                    case OpcaoCadastro.Salvar:
                        inserir.Cadastro(movimentoEmprestimo);
                        break;
                    case OpcaoCadastro.Alterar:
                        alterar.Cadastro(movimentoEmprestimo);
                        break;
                    case OpcaoCadastro.Excluir:
                        excluir.Cadastro(movimentoEmprestimo);
                        break;
                    case OpcaoCadastro.Quitar:
                        movimentoEmprestimo.Pago = "Sim";

                        alterar.Quitar(movimentoEmprestimo);
                        alterarEmprestimo.Ativo(idEmprestimo);
                        break;

                    default:
                        break;
                }
                ListarMovimento(idEmprestimo);
                LimparCampos();

                BtnAlterar.Enabled = false;
                BtnExcluir.Enabled = false;
                BtnSalvar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExcluirTudoEmprestimo(int idEmprestimo)
        {
            ExcluirTudoClienteEmprestimo excluirTudoClienteEmprestimo = new ExcluirTudoClienteEmprestimo();
            try
            {
                if (MessageBox.Show("Deseja excluir todos os lançamentos?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    excluirTudoClienteEmprestimo.Cadastro(idEmprestimo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparCampos()
        {
            TxtParcela.Text = "1";
            TxtValor.Text = "0,00";
            MktDataPagamento.Clear();
            MktDataParcela.Clear();

        }

        private void Informacoes()
        {
            decimal valGeral = 0, valPago = 0, valPagar = 0;

            foreach (DataGridViewRow row in DgvListarMovimentoEmp.Rows)
            {
                if (row.Cells["Pago"].Value.ToString() == "Sim")
                {
                    valPago += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                else
                {
                    valPagar += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                valGeral += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            LblValorTotal.Text = "Valor Total..: " + valGeral.ToString("#,##0.00");
            LblValorPago.Text = "Valor Pago...: " + valPago.ToString("#,##0.00");
            LblValorPagar.Text = "Valor a Pagar: " + valPagar.ToString("#,##0.00");

        }

        private void FrmCadMovimentoEmprestimo_Load(object sender, EventArgs e)
        {
            LblDataCadastro.Text = "Data Cadastro:" + DateTime.Now.ToString("dd/MM/yyyy");
            ListarCliente();
            CbxPago.SelectedIndex = 1;
            MktDataPagamento.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void DgvListarMovimentoEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idMovimentoEmp = int.Parse(DgvListarMovimentoEmp.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            MktDataParcela.Text = DgvListarMovimentoEmp.Rows[e.RowIndex].Cells["DataParcela"].Value.ToString();
            TxtParcela.Text = DgvListarMovimentoEmp.Rows[e.RowIndex].Cells["Parcela"].Value.ToString();
            decimal valor = decimal.Parse(DgvListarMovimentoEmp.Rows[e.RowIndex].Cells["Valor"].Value.ToString());
            TxtValor.Text = valor.ToString("#,##0.00");
            if (DgvListarMovimentoEmp.Rows[e.RowIndex].Cells["Pago"].Value.ToString() == "Sim")
            {
                CbxPago.SelectedIndex = 0;
            }
            else
            {
                CbxPago.SelectedIndex = 1;
            }

            MktDataPagamento.Text = DgvListarMovimentoEmp.Rows[e.RowIndex].Cells["DataPagamento"].Value.ToString();
            if (MktDataPagamento.Text == "01/01/0001")
            {
                MktDataPagamento.Clear();
            }

            BtnAlterar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;


        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            CadastroMovimento(OpcaoCadastro.Salvar);
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            CadastroMovimento(OpcaoCadastro.Alterar);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            CadastroMovimento(OpcaoCadastro.Excluir);
        }

        private void CbxPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxPago.SelectedIndex == 0)
            {

                MktDataPagamento.Text = MktDataParcela.Text;
                MktDataPagamento.Focus();
            }
            else
            {

                MktDataPagamento.Clear();
            }
        }

        private void TxtParcela_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtParcela.Text = validarNumero.ValidarNumeroInteiro(TxtParcela.Text);
            TxtParcela.Select(TxtParcela.Text.Length, 0);
        }

        private void TxtValor_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtValor.Text = validarNumero.Validar(TxtValor.Text);
            TxtValor.Select(TxtValor.Text.Length, 0);
        }

        private void TxtValor_Leave(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtValor.Text = validarNumero.Zero(TxtValor.Text);
            TxtValor.Text = validarNumero.Formatar(TxtValor.Text);
        }

        private void TxtParcela_Leave(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtParcela.Text = validarNumero.ZeroInteiro(TxtParcela.Text);
            TxtParcela.Text = validarNumero.FormatarInteiro(TxtParcela.Text);
        }

        private void TxtParcela_Enter(object sender, EventArgs e)
        {
            if (TxtParcela.Text == "0")
            {
                TxtParcela.Text = "1";
            }
        }

        private void TxtValor_Enter(object sender, EventArgs e)
        {
            if (TxtValor.Text == "0,00")
            {
                TxtValor.Text = "";
            }
        }

        private void CmsExcluirTudo_Click(object sender, EventArgs e)
        {
            ExcluirTudoEmprestimo(idEmprestimo);
            ListarEmprestimo(idCliente);
            LimparCampos();
            BtnAlterar.Enabled = false;
            BtnExcluir.Enabled = false;
            BtnSalvar.Enabled = true;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            CadastroMovimento(OpcaoCadastro.Quitar);
        }

        private void FrmCadMovimentoEmprestimo_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmForm.AtualizarFrmPrincipal();
            frmForm.GraficoEntradaSaida();
            frmForm.GraficoPagoRecebido();
        }

        private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = int.Parse(CbxNome.SelectedValue.ToString());
            ListarEmprestimo(idCliente);
            ListarCompetencia(idCliente);
        }

        private void CbxDescrocao_SelectedIndexChanged(object sender, EventArgs e)
        {
            idEmprestimo = int.Parse(CbxDescricao.SelectedValue.ToString());
            ListarMovimento(idEmprestimo);
        }
    }
}
