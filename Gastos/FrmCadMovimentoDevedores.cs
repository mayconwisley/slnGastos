using Negocio.Cliente.Listar;
using Negocio.Devedores.Listar;
using Negocio.Movimento.Devedor;
using Negocio.Movimento.Devedor.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.MovimentoDevedores;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadMovimentoDevedores : Form
{
    string strLogin;
    int idCliente, idDevedor, idMovimentoDev;

    private FrmPrincipal frmForm;

    public FrmCadMovimentoDevedores(string login)
    {
        InitializeComponent();
        strLogin = login;
    }

    public FrmCadMovimentoDevedores(FrmPrincipal form, string login)
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

    private void ListarDevedores(int idCliente)
    {
        CbxDescricao.Text = "";
        IdDescricaoDevedor idDescricaoDevedor = new IdDescricaoDevedor();
        CbxDescricao.DataSource = idDescricaoDevedor.Consulta(idCliente);
    }

    private void ListarMovimento(int idDevedor)
    {
        CadastroMovDevCliente cadastroMovDevCliente = new CadastroMovDevCliente();
        DgvListarMovimentoDev.DataSource = cadastroMovDevCliente.Consulta(idDevedor);
        Informacoes();
    }

    private void CadastroDevedores(OpcaoCadastro opcaoCadastro)
    {
        MovimentoDevedoresObj movimentoDevedores = new MovimentoDevedoresObj();
        Inserir inserir = new Inserir();
        Alterar alterar = new Alterar();
        Excluir excluir = new Excluir();

        try
        {
            movimentoDevedores.Id = idMovimentoDev;
            movimentoDevedores.Devedores = new Objeto.Devedores.DevedoresObj();
            movimentoDevedores.Devedores.Id = idDevedor;
            movimentoDevedores.Valor = decimal.Parse(TxtValor.Text);
            movimentoDevedores.Recebido = CbxRecebido.Text;
            movimentoDevedores.Usuario = new Objeto.Usuario.UsuarioObj();
            movimentoDevedores.Usuario.Login = strLogin;
            movimentoDevedores.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            movimentoDevedores.Descricao = TxtDescricao.Text.Trim();
            DateTime dataParcela = DateTime.Parse(MktDataParcela.Text);
            movimentoDevedores.Parcela = int.Parse(TxtParcela.Text);
            movimentoDevedores.DataParcela = dataParcela;

            DateTime dataRecebido;
            bool sucesso = DateTime.TryParse(MktDataRecebido.Text, out dataRecebido);

            if (sucesso)
            {
                movimentoDevedores.DataRecebido = dataRecebido;
            }


            switch (opcaoCadastro)
            {
                case OpcaoCadastro.Salvar:
                    inserir.Cadastro(movimentoDevedores);
                    break;
                case OpcaoCadastro.Alterar:
                    alterar.Cadastro(movimentoDevedores);
                    break;
                case OpcaoCadastro.Excluir:
                    excluir.Cadastro(movimentoDevedores);
                    break;
                default:
                    break;
            }
            ListarMovimento(idDevedor);
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

    private void Informacoes()
    {
        decimal valGeral = 0, valPago = 0, valPagar = 0;

        foreach (DataGridViewRow row in DgvListarMovimentoDev.Rows)
        {
            if (row.Cells["Recebido"].Value.ToString() == "Sim")
            {
                valPago += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            else
            {
                valPagar += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            valGeral += decimal.Parse(row.Cells["Valor"].Value.ToString());
        }

        LblValorTotal.Text = "Valor Total......: " + valGeral.ToString("#,##0.00");
        LblValorPago.Text = "Valor Recebido...: " + valPago.ToString("#,##0.00");
        LblValorPagar.Text = "Valor a Receber..: " + valPagar.ToString("#,##0.00");

    }

    private void ExcluirTudoDevedor(int idDevedor)
    {
        ExcluirTudoClienteDevedor excluirTudoClienteDevedor = new ExcluirTudoClienteDevedor();
        try
        {
            if (MessageBox.Show("Deseja excluir todos os lançamentos?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                excluirTudoClienteDevedor.Cadastro(idDevedor);
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
        MktDataRecebido.Clear();
        MktDataParcela.Clear();

    }

    private void DgvListarMovimentoDev_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        idMovimentoDev = int.Parse(DgvListarMovimentoDev.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        MktDataParcela.Text = DgvListarMovimentoDev.Rows[e.RowIndex].Cells["DataParcela"].Value.ToString();
        TxtParcela.Text = DgvListarMovimentoDev.Rows[e.RowIndex].Cells["Parcela"].Value.ToString();
        decimal valor = decimal.Parse(DgvListarMovimentoDev.Rows[e.RowIndex].Cells["Valor"].Value.ToString());
        TxtValor.Text = valor.ToString("#,##0.00");
        if (DgvListarMovimentoDev.Rows[e.RowIndex].Cells["Recebido"].Value.ToString() == "Sim")
        {
            CbxRecebido.SelectedIndex = 0;
        }
        else
        {
            CbxRecebido.SelectedIndex = 1;
        }

        MktDataRecebido.Text = DgvListarMovimentoDev.Rows[e.RowIndex].Cells["DataRecebido"].Value.ToString();
        if (MktDataRecebido.Text == "01/01/0001")
        {
            MktDataRecebido.Clear();
        }
        TxtDescricao.Text = DgvListarMovimentoDev.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();

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

    private void CbxPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CbxRecebido.SelectedIndex == 0)
        {
            MktDataRecebido.Enabled = true;
            MktDataRecebido.Text = MktDataParcela.Text;
            MktDataRecebido.Focus();
        }
        else
        {
            MktDataRecebido.Enabled = false;
            MktDataRecebido.Clear();
        }
    }

    private void CbxDescricao_SelectedIndexChanged(object sender, EventArgs e)
    {
        idDevedor = int.Parse(CbxDescricao.SelectedValue.ToString());
        ListarMovimento(idDevedor);
    }

    private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        idCliente = int.Parse(CbxNome.SelectedValue.ToString());
        ListarDevedores(idCliente);
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

    private void FrmCadMovimentoDevedores_FormClosing(object sender, FormClosingEventArgs e)
    {
        frmForm.AtualizarFrmPrincipal();
    }

    private void CmsExcluirTudo_Click(object sender, EventArgs e)
    {
        ExcluirTudoDevedor(idDevedor);
        ListarDevedores(idCliente);
        LimparCampos();
        BtnAlterar.Enabled = false;
        BtnExcluir.Enabled = false;
        BtnSalvar.Enabled = true;
    }

    private void FrmCadMovimentoDevedores_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = "Data Cadastro:" + DateTime.Now.ToString("dd/MM/yyyy");
        ListarCliente();
        CbxRecebido.SelectedIndex = 1;
    }
}
