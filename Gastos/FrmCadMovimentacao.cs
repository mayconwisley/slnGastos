using Negocio.Cliente.Listar;
using Negocio.Competencia.Listar;
using Negocio.Fixo.Listar;
using Negocio.Movimento.Devedor.Listar;
using Negocio.Movimento.Emprestimo.Listar;
using Negocio.Movimento.Geral;
using Negocio.Movimento.Geral.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.Movimentacao;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmCadMovimentacao : Form
    {
        string strLogin;

        int idCliente, idMovimentacao, idCompetencia, idComeptenciaAnterior;
        decimal valSalEntSaiAnt = 0, valSalPagRecAnt = 0, valSalPendAnte = 0;
        DateTime date;

        private FrmPrincipal frmForm;


        public FrmCadMovimentacao(string login)
        {
            InitializeComponent();
            strLogin = login;
        }

        public FrmCadMovimentacao(FrmPrincipal form, string login)
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
                    LblCompetencia.Text = "Competência: " + date.ToString("MM/yyyy");
                    idComeptenciaAnterior = competenciaIdData.CompetenciaId(idCliente, date.AddMonths(-1));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Competência não cadastrada!! \n\n" + ex.Message);
                LblCompetencia.Text = "Competencia: 00/0000";
            }
        }

        private void InformacaoSaldoAnterior(int idCliente, int idCompetencia)
        {
            SaldoEntSaiClienteComp saldoEntSaiClienteComp = new SaldoEntSaiClienteComp();
            SaldoPagRecClienteComp saldoPagRecClienteComp = new SaldoPagRecClienteComp();
            SaldoPendClienteComp saldoPendClienteComp = new SaldoPendClienteComp();

            valSalEntSaiAnt = saldoEntSaiClienteComp.Saldo(idCliente, idCompetencia);
            valSalPagRecAnt = saldoPagRecClienteComp.Saldo(idCliente, idCompetencia);
            valSalPendAnte = saldoPendClienteComp.Saldo(idCliente, idCompetencia);

            if (valSalEntSaiAnt == 0)
            {
                LblSalES.ForeColor = Color.Black;
            }
            else if (valSalEntSaiAnt < 0)
            {
                LblSalES.ForeColor = Color.Red;
            }
            else
            {
                LblSalES.ForeColor = Color.Green;
            }

            if (valSalPagRecAnt == 0)
            {
                LblSalPR.ForeColor = Color.Black;
            }
            else if (valSalPagRecAnt < 0)
            {
                LblSalPR.ForeColor = Color.Red;
            }
            else
            {
                LblSalPR.ForeColor = Color.Green;
            }

            if (valSalPendAnte == 0)
            {
                LblSalPend.ForeColor = Color.Black;
            }
            else if (valSalPendAnte < 0)
            {
                LblSalPend.ForeColor = Color.Red;
            }
            else
            {
                LblSalPend.ForeColor = Color.Green;
            }

            LblSalES.Text = "Sal. E. S.: " + valSalEntSaiAnt.ToString("#,##0.00");
            LblSalPR.Text = "Sal. P. R.: " + valSalPagRecAnt.ToString("#,##0.00");
            LblSalPend.Text = "Sal. Pend.: " + valSalPendAnte.ToString("#,##0.00");
        }

        private void CadastrarMovimentacao(OpcaoCadastro opcaoCadastro)
        {
            MovimentacaoObj movimentacao = new MovimentacaoObj();
            Negocio.Movimento.Emprestimo.Alterar alteraMovimentoEmprestimo = new Negocio.Movimento.Emprestimo.Alterar();
            Inserir inserir = new Inserir();
            Alterar alterar = new Alterar();
            Excluir excluir = new Excluir();

            try
            {
                movimentacao.Id = idMovimentacao;
                movimentacao.DataMovimento = DateTime.Parse(MktDataMovimento.Text);
                movimentacao.Descricao = TxtDescricao.Text.Trim();
                movimentacao.Valor = decimal.Parse(TxtValor.Text.Trim());
                movimentacao.TipoLancamento = CbxTipo.Text;
                movimentacao.TipoPagoRecebido = CbxTipo0.Text;

                if (CbCheque.Checked)
                {
                    movimentacao.TipoMonetario = "Cheque";
                }
                else
                {
                    movimentacao.TipoMonetario = "Dinheiro";
                }
                movimentacao.Integracao = "Manual";
                movimentacao.Competencia = new Objeto.Competencia.CompetenciaObj();
                movimentacao.Competencia.Id = idCompetencia;
                movimentacao.Usuario = new Objeto.Usuario.UsuarioObj();
                movimentacao.Usuario.Login = strLogin;
                movimentacao.Cliente = new Objeto.Cliente.ClienteObj();
                movimentacao.Cliente.Id = idCliente;
                movimentacao.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

                switch (opcaoCadastro)
                {
                    case OpcaoCadastro.Salvar:
                        inserir.Cadastro(movimentacao);
                        break;
                    case OpcaoCadastro.Alterar:
                        alterar.Cadastro(movimentacao);
                        break;
                    case OpcaoCadastro.Excluir:
                        excluir.Cadastro(movimentacao);
                        break;
                    default:
                        break;
                }

                LimparCampos();
                ListarMovimentacao(idCliente, idCompetencia);
                BtnAlterar.Enabled = false;
                BtnExcluir.Enabled = false;
                BtnSalvar.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparCampos()
        {
            TxtDescricao.Clear();
            TxtValor.Text = "0,00";
            MktDataMovimento.Clear();
        }

        private void Informacoes()
        {
            decimal valEntrda = 0, valSaida = 0, valSaldo = 0, valPago = 0, valRecebido = 0, valSaldo0 = 0;
            decimal valPendenciaEntrada = 0, valPendenciaSaida = 0, valPendenciaSaldo = 0;
            string strTipoLancamento, strTipoPagoRecebido;

            foreach (DataGridViewRow row in DgvListaMovimentacao.Rows)
            {
                strTipoLancamento = row.Cells["TipoLancamento"].Value.ToString();
                strTipoPagoRecebido = row.Cells["TipoPagoRecebido"].Value.ToString();

                if (strTipoLancamento == "Entrada")
                {
                    valEntrda += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                else
                {
                    valSaida += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }

                valSaldo = valEntrda - valSaida;

                if (strTipoPagoRecebido == "Pago")
                {
                    valPago += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                else if (strTipoPagoRecebido == "Recebido")
                {
                    valRecebido += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }

                valSaldo0 = valRecebido - valPago;

                if (strTipoLancamento == "Entrada" && strTipoPagoRecebido == "Pendente")
                {
                    valPendenciaEntrada += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                else if (strTipoLancamento == "Saída" && strTipoPagoRecebido == "Pendente")
                {
                    valPendenciaSaida += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                valPendenciaSaldo = valPendenciaEntrada - valPendenciaSaida;
            }

            valSaldo += valSalEntSaiAnt;
            valSaldo0 += valSalPagRecAnt;
            valPendenciaSaldo += valSalPendAnte;

            #region Mudar cor do saldo

            if (valSaldo == 0)
            {
                LblSaldo.ForeColor = Color.Black;
            }
            else if (valSaldo < 0)
            {
                LblSaldo.ForeColor = Color.Red;
            }
            else
            {
                LblSaldo.ForeColor = Color.Green;
            }

            if (valSaldo0 == 0)
            {
                LblSaldo0.ForeColor = Color.Black;
            }
            else if (valSaldo0 < 0)
            {
                LblSaldo0.ForeColor = Color.Red;
            }
            else
            {
                LblSaldo0.ForeColor = Color.Green;
            }

            if (valPendenciaSaldo == 0)
            {
                LblSalPen.ForeColor = Color.Black;
            }
            else if (valPendenciaSaldo < 0)
            {
                LblSalPen.ForeColor = Color.Red;
            }
            else
            {
                LblSalPen.ForeColor = Color.Green;
            }
            #endregion

            LblValorEntrada.Text = "Valor Entrada: " + valEntrda.ToString("#,##0.00");
            LblValorSaida.Text = "Valor Saída..: " + valSaida.ToString("#,##0.00");
            LblSaldo.Text = "Valor Saldo..: " + valSaldo.ToString("#,##0.00");

            LblValorPago.Text = "Valor Pago....: " + valPago.ToString("#,##0.00");
            LblValorRecebido.Text = "Valor Recebido: " + valRecebido.ToString("#,##0.00");
            LblSaldo0.Text = "Valor Saldo...: " + valSaldo0.ToString("#,##0.00");

            LblValPenEnt.Text = "Valor Pendente Entrada: " + valPendenciaEntrada.ToString("#,##0.00");
            LblValPenSai.Text = "Valor Pendente Saída..: " + valPendenciaSaida.ToString("#,##0.00");
            LblSalPen.Text = "Valor Saldo...........: " + valPendenciaSaldo.ToString("#,##0.00");
        }

        private void ListarMovimentacao(int idCliente, int idCompetencia)
        {
            CadastroMovGeralCliente cadastroMovGeralCliente = new CadastroMovGeralCliente();
            DgvListaMovimentacao.DataSource = cadastroMovGeralCliente.Consulta(idCliente, idCompetencia);
            InformacaoSaldoAnterior(idCliente, idComeptenciaAnterior);
            Informacoes();
            VerificaIntegracao();
        }

        private void VerificaIntegracao()
        {
            int iInteEmprestimo = 0, iInteDevedores = 0, iInteFixos = 0;
            string strIntegrado;
            foreach (DataGridViewRow row in DgvListaMovimentacao.Rows)
            {
                strIntegrado = row.Cells["Integrado"].Value.ToString();

                if (strIntegrado == "Integrado Emprestimos")
                {
                    iInteEmprestimo++;
                }

                if (strIntegrado == "Integrado Devedores")
                {
                    iInteDevedores++;
                }

                if (strIntegrado == "Integrado Fixos")
                {
                    iInteFixos++;
                }
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            CadastrarMovimentacao(OpcaoCadastro.Salvar);
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            CadastrarMovimentacao(OpcaoCadastro.Alterar);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            CadastrarMovimentacao(OpcaoCadastro.Excluir);
        }

        private void DgvListaMovimentacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idMovimentacao = int.Parse(DgvListaMovimentacao.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            TxtDescricao.Text = DgvListaMovimentacao.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
            decimal valor = decimal.Parse(DgvListaMovimentacao.Rows[e.RowIndex].Cells["Valor"].Value.ToString());
            TxtValor.Text = valor.ToString("#,##0.00");
            MktDataMovimento.Text = DgvListaMovimentacao.Rows[e.RowIndex].Cells["DataMovimento"].Value.ToString();
            string tipoLancamento = DgvListaMovimentacao.Rows[e.RowIndex].Cells["TipoLancamento"].Value.ToString();
            if (tipoLancamento == "Entrada")
            {
                CbxTipo.SelectedIndex = 0;
            }
            else
            {
                CbxTipo.SelectedIndex = 1;
            }

            string tipoPagaRecebido = DgvListaMovimentacao.Rows[e.RowIndex].Cells["TipoPagoRecebido"].Value.ToString();
            if (tipoPagaRecebido == "Pago")
            {
                CbxTipo0.SelectedIndex = 1;
            }
            else if (tipoPagaRecebido == "Recebido")
            {
                CbxTipo0.SelectedIndex = 2;
            }
            else
            {
                CbxTipo0.SelectedIndex = 0;
            }

            string tipoMonetario = DgvListaMovimentacao.Rows[e.RowIndex].Cells["TipoMonetario"].Value.ToString();
            if (tipoMonetario == "Cheque")
            {
                CbCheque.Checked = true;
            }
            else
            {
                CbCheque.Checked = false;
            }

            BtnAlterar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
        }

        private void FrmCadMovimentacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmForm.AtualizarFrmPrincipal();
            frmForm.GraficoEntradaSaida();
            frmForm.GraficoPagoRecebido();
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

        private void TxtValor_Enter(object sender, EventArgs e)
        {
            if (TxtValor.Text == "0,00")
            {
                TxtValor.Text = "";
            }
        }

        private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = int.Parse(CbxNome.SelectedValue.ToString());

            ListarCompetencia(idCliente);
            ListarMovimentacao(idCliente, idCompetencia);
        }

        private void FrmCadMovimentacao_Load(object sender, EventArgs e)
        {
            LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
            MktDataMovimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ListarCliente();

            InformacaoSaldoAnterior(idCliente, idComeptenciaAnterior);
            Informacoes();
        }
    }
}
