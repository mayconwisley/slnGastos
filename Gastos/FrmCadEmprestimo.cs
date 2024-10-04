using Negocio.Cliente.Listar;
using Negocio.Competencia.Listar;
using Negocio.Emprestimos;
using Negocio.Emprestimos.Listar;
using Negocio.Movimento.Emprestimo.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.Competencia;
using Objeto.Emprestimos;
using Objeto.MovimentoEmprestimos;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadEmprestimo : Form
{
    string strLogin;
    int idCliente, idEmprestimo, iParcelas = 0, idCompetencia = 0;
    DateTime date;

    FrmPrincipal frmForm;

    public FrmCadEmprestimo(string login)
    {
        InitializeComponent();
        strLogin = login;
    }

    public FrmCadEmprestimo(FrmPrincipal form, string login)
    {
        InitializeComponent();
        strLogin = login;
        frmForm = form;
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
                this.Text = "Cadastro Empréstimo | Competência: " + date.ToString("MM/yyyy");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Competência não cadastrada!! \n\n" + ex.Message);

        }
    }

    private void ListaCliente()
    {
        IdNomeCliente idNomeCliente = new IdNomeCliente();
        CbxNome.DataSource = idNomeCliente.Consulta();
    }

    private void ListaEmprestimos(int idCliente)
    {
        CadastroEmprestimosCliente cadastroEmprestimosCliente = new CadastroEmprestimosCliente();
        DgvListaEmprestimos.DataSource = cadastroEmprestimosCliente.Consulta(idCliente);
        Informacao();
        MktDataInicio.Focus();
    }

    private void CadastroEmprestimos(OpcaoCadastro opcaoCadastro)
    {
        EmprestimoObj emprestimo = new EmprestimoObj();
        Inserir inserir = new Inserir();
        Alterar alterar = new Alterar();
        Excluir excluir = new Excluir();

        try
        {
            emprestimo.Id = idEmprestimo;
            emprestimo.DataInicio = DateTime.Parse(MktDataInicio.Text.Trim());
            emprestimo.Descricao = TxtDescricao.Text.Trim();
            emprestimo.ValorEmprestado = decimal.Parse(TxtValorEmprestado.Text);
            emprestimo.ValorParcela = decimal.Parse(TxtValorParcela.Text);
            emprestimo.Parcelas = int.Parse(TxtParcela.Text);
            if (CbAtivo.Checked)
            {
                emprestimo.Ativo = "Sim";
            }
            else
            {
                emprestimo.Ativo = "Não";
            }

            emprestimo.Usuario = new Objeto.Usuario.UsuarioObj();
            emprestimo.Usuario.Login = strLogin;
            emprestimo.Cliente = new Objeto.Cliente.ClienteObj();
            emprestimo.Cliente.Id = idCliente;
            emprestimo.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

            switch (opcaoCadastro)
            {
                case OpcaoCadastro.Salvar:
                    inserir.Cadastro(emprestimo);
                    break;
                case OpcaoCadastro.Alterar:
                    alterar.Cadastro(emprestimo);
                    break;
                case OpcaoCadastro.Excluir:
                    excluir.Cadastro(emprestimo);
                    break;
                default:
                    break;
            }

            ListaEmprestimos(idCliente);
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

    private void GerarMovimentacao(int idEmprestimo)
    {
        MovimentoEmprestimoObj movimentoEmprestimo = new MovimentoEmprestimoObj();
        EmprestimoIdMovimento emprestimoIdMovimento = new EmprestimoIdMovimento();
        Negocio.Movimento.Emprestimo.Inserir inserir = new Negocio.Movimento.Emprestimo.Inserir();

        try
        {

            if (emprestimoIdMovimento.QtdEmprestimoMovimento(idEmprestimo) > 0)
            {
                MessageBox.Show("Empréstimos já foi gerado!");
                return;
            }

            movimentoEmprestimo.Emprestimo = new EmprestimoObj();
            movimentoEmprestimo.Emprestimo.Id = idEmprestimo;
            movimentoEmprestimo.Valor = decimal.Parse(TxtValorParcela.Text);
            movimentoEmprestimo.Pago = "Não";
            movimentoEmprestimo.Usuario = new Objeto.Usuario.UsuarioObj();
            movimentoEmprestimo.Usuario.Login = strLogin;
            movimentoEmprestimo.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            

            DateTime dataParcela = DateTime.Parse(MktDataInicio.Text);

            for (int i = 1; i <= iParcelas; i++)
            {
                movimentoEmprestimo.Parcela = i;
                movimentoEmprestimo.DataParcela = dataParcela.AddMonths(i - 1);
                inserir.Cadastro(movimentoEmprestimo);
            }

            MessageBox.Show("Movimentação Gerada com Sucesso!");

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

    private void LimparCampo()
    {
        TxtDescricao.Clear();
        TxtValorParcela.Text = "0,00";
        TxtParcela.Text = "1";
        TxtValorEmprestado.Text = "0,00";
        MktDataInicio.Clear();
    }

    private void Informacao()
    {
        decimal valTotalAtivo = 0, valTotalNAtivo = 0, valTotalGeral = 0;
        foreach (DataGridViewRow row in DgvListaEmprestimos.Rows)
        {
            if (row.Cells["Ativo"].Value.ToString() == "Sim")
            {
                valTotalAtivo += decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
            }
            else
            {
                valTotalNAtivo += decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
            }
            valTotalGeral += decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
        }

        LblTotalAtivo.Text = "Total Ativo..: " + valTotalAtivo.ToString("#,##0.00");
        LblTotalNAtivo.Text = "Total Ñ Ativo: " + valTotalNAtivo.ToString("#,##0.00");
        LblTotalGeral.Text = "Total Geral..: " + valTotalGeral.ToString("#,##0.00");
    }

    private void FrmCadEmprestimo_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
        ListaCliente();
    }

    private void DgvListaEmprestimos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        EmprestimoIdMovimento emprestimoIdMovimento = new EmprestimoIdMovimento();

        idEmprestimo = int.Parse(DgvListaEmprestimos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        TxtDescricao.Text = DgvListaEmprestimos.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
        iParcelas = int.Parse(DgvListaEmprestimos.Rows[e.RowIndex].Cells["Parcelas"].Value.ToString());
        TxtParcela.Text = iParcelas.ToString();
        decimal valorEmprestado = decimal.Parse(DgvListaEmprestimos.Rows[e.RowIndex].Cells["ValorEmprestado"].Value.ToString());
        TxtValorEmprestado.Text = valorEmprestado.ToString("#,##0.00");
        decimal valorParcela = decimal.Parse(DgvListaEmprestimos.Rows[e.RowIndex].Cells["ValorParcela"].Value.ToString());
        TxtValorParcela.Text = valorParcela.ToString("#,##0.00");
        
        MktDataInicio.Text = DgvListaEmprestimos.Rows[e.RowIndex].Cells["DataInicio"].Value.ToString();
        if (DgvListaEmprestimos.Rows[e.RowIndex].Cells["Ativo"].Value.ToString() == "Sim")
        {
            CbAtivo.Checked = true;
        }
        else
        {
            CbAtivo.Checked = false;
        }
        try
        {
            if (emprestimoIdMovimento.QtdEmprestimoMovimento(idEmprestimo) > 0)
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
        CadastroEmprestimos(OpcaoCadastro.Salvar);
    }

    private void BtnAlterar_Click(object sender, EventArgs e)
    {
        CadastroEmprestimos(OpcaoCadastro.Alterar);
    }

    private void BtnExcluir_Click(object sender, EventArgs e)
    {
        CadastroEmprestimos(OpcaoCadastro.Excluir);
    }

    private void TxtValorEmprestado_TextChanged(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new ValidarNumero();
        TxtValorEmprestado.Text = validarNumero.Validar(TxtValorEmprestado.Text);
        TxtValorEmprestado.Select(TxtValorEmprestado.Text.Length, 0);
    }

    private void TxtValorEmprestado_Leave(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new ValidarNumero();
        TxtValorEmprestado.Text = validarNumero.Zero(TxtValorEmprestado.Text);
        TxtValorEmprestado.Text = validarNumero.Formatar(TxtValorEmprestado.Text);
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

    private void TxtValorEmprestado_Enter(object sender, EventArgs e)
    {
        if (TxtValorEmprestado.Text == "0,00")
        {
            TxtValorEmprestado.Text = "";
        }
    }

    private void TxtValorParcela_Enter(object sender, EventArgs e)
    {
        if (TxtValorParcela.Text == "0,00")
        {

            TxtValorParcela.Text = "";
        }
    }

    private void TxtValorParcela_TextChanged(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new ValidarNumero();
        TxtValorParcela.Text = validarNumero.Validar(TxtValorParcela.Text);
        TxtValorParcela.Select(TxtValorParcela.Text.Length, 0);
    }

    private void BtnGerar_Click(object sender, EventArgs e)
    {
        GerarMovimentacao(idEmprestimo);
    }

    private void FrmCadEmprestimo_FormClosing(object sender, FormClosingEventArgs e)
    {
        frmForm.AtualizarFrmPrincipal();
    }

    private void TxtValorParcela_Leave(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new ValidarNumero();
        TxtValorParcela.Text = validarNumero.Zero(TxtValorParcela.Text);
        TxtValorParcela.Text = validarNumero.Formatar(TxtValorParcela.Text);
    }

    private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        idCliente = int.Parse(CbxNome.SelectedValue.ToString());
        ListaEmprestimos(idCliente);
        ListarCompetencia(idCliente);
    }
}
