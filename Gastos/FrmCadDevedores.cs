using Negocio.Cliente.Listar;
using Negocio.Devedores;
using Negocio.Devedores.Listar;
using Negocio.Movimento.Devedor.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.Devedores;
using Objeto.MovimentoDevedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmCadDevedores : Form
    {
        string strLogin;
        int idCliente, idDevedores, iParcelas = 0;
        public FrmCadDevedores(string login)
        {
            InitializeComponent();
            strLogin = login;
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
            Informacao();
            MktDataInicio.Focus();
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
                devedores.DataInicio = DateTime.Parse(MktDataInicio.Text.Trim());
                devedores.Nome = TxtNome.Text.Trim();
                devedores.Valor = decimal.Parse(TxtValorParcela.Text.Trim());
                int parcelas = int.Parse(TxtParcela.Text.Trim());
                devedores.Parcelas = parcelas;
                if (parcelas > 1)
                {
                    devedores.Parcelado = "Sim";
                }
                else
                {
                    devedores.Parcelado = "Não";
                }

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
                BtnGerar.Enabled = false;
                BtnSalvar.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GerarMovimentacao(int idDevedores)
        {
            MovimentoDevedoresObj movimentoDevedores = new MovimentoDevedoresObj();
            DevedoresIdMovimento devedoresIdMovimento = new DevedoresIdMovimento();
            Negocio.Movimento.Devedor.Inserir inserir = new Negocio.Movimento.Devedor.Inserir();

            try
            {

                if (devedoresIdMovimento.QtdDevedoresMovimento(idDevedores) > 0)
                {
                    MessageBox.Show("Empréstimos já foi gerado!");
                    return;
                }

                movimentoDevedores.DataMovimento = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                movimentoDevedores.Devedores = new DevedoresObj();
                movimentoDevedores.Devedores.Id = idDevedores;
                movimentoDevedores.Valor = decimal.Parse(TxtValorParcela.Text);
                movimentoDevedores.Pago = "Não";
                movimentoDevedores.Usuario = new Objeto.Usuario.UsuarioObj();
                movimentoDevedores.Usuario.Login = strLogin;
                movimentoDevedores.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                DateTime dataParcela = DateTime.Parse(MktDataInicio.Text);

                for (int i = 1; i <= iParcelas; i++)
                {
                    movimentoDevedores.Parcela = i;
                    movimentoDevedores.DataParcela = dataParcela.AddMonths(i - 1);
                    inserir.Cadastro(movimentoDevedores);
                }

                MessageBox.Show("Movimentação Gerada com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void LimparCampo()
        {
            TxtNome.Clear();
            TxtValorParcela.Text = "0,00";
            TxtParcela.Text = "1";
            MktDataInicio.Clear();
        }

        private void DgvListaDevedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DevedoresIdMovimento devedoresIdMovimento = new DevedoresIdMovimento();

            idDevedores = int.Parse(DgvListaDevedores.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            TxtNome.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            iParcelas = int.Parse(DgvListaDevedores.Rows[e.RowIndex].Cells["Parcelas"].Value.ToString());
            TxtParcela.Text = iParcelas.ToString();
            decimal valor = decimal.Parse(DgvListaDevedores.Rows[e.RowIndex].Cells["Valor"].Value.ToString());
            TxtValorParcela.Text = valor.ToString("#,##0.00");

            MktDataInicio.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["DataInicio"].Value.ToString();
            if (DgvListaDevedores.Rows[e.RowIndex].Cells["Ativo"].Value.ToString() == "Sim")
            {
                CbAtivo.Checked = true;
            }
            else
            {
                CbAtivo.Checked = false;
            }

            try
            {
                if (devedoresIdMovimento.QtdDevedoresMovimento(idDevedores) > 0)
                {
                    BtnGerar.Enabled = false;
                }
                else
                {
                    BtnGerar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void BtnGerar_Click(object sender, EventArgs e)
        {
            GerarMovimentacao(idDevedores);
        }

        private void TxtValorParcela_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtValorParcela.Text = validarNumero.Validar(TxtValorParcela.Text);
            TxtValorParcela.Select(TxtValorParcela.Text.Length, 0);
        }

        private void TxtValorParcela_Leave(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtValorParcela.Text = validarNumero.Zero(TxtValorParcela.Text);
            TxtValorParcela.Text = validarNumero.Formatar(TxtValorParcela.Text);
        }

        private void TxtValorParcela_Enter(object sender, EventArgs e)
        {
            if (TxtValorParcela.Text == "0,00")
            {
                TxtValorParcela.Text = "";
            }
        }

        private void TxtParcela_TextChanged(object sender, EventArgs e)
        {
            ValidarNumero validarNumero = new ValidarNumero();
            TxtParcela.Text = validarNumero.ValidarNumeroInteiro(TxtParcela.Text);
            TxtParcela.Select(TxtParcela.Text.Length, 0);
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

        private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = int.Parse(CbxNome.SelectedValue.ToString());
            ListaDevedores(idCliente);
        }

        private void Informacao()
        {
            decimal valTotalAtivo = 0, valTotalNAtivo = 0, valTotalGeral = 0;
            foreach (DataGridViewRow row in DgvListaDevedores.Rows)
            {
                if (row.Cells["Ativo"].Value.ToString() == "Sim")
                {
                    valTotalAtivo += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                else
                {
                    valTotalNAtivo += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                valTotalGeral += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            LblTotalAtivo.Text = "Total Ativo..: " + valTotalAtivo.ToString("#,##0.00");
            LblTotalNAtivo.Text = "Total Ñ Ativo: " + valTotalNAtivo.ToString("#,##0.00");
            LblTotalGeral.Text = "Total Geral..: " + valTotalGeral.ToString("#,##0.00");
        }


        private void FrmCadDevedores_Load(object sender, EventArgs e)
        {
            LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
            ListaCliente();
        }
    }
}
