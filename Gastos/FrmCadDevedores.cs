using Negocio.Cliente.Listar;
using Negocio.Devedores;
using Negocio.Devedores.Listar;
using Negocio.Movimento.Devedor.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.Devedores;
using Objeto.MovimentoDevedores;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadDevedores : Form
{
    string strLogin;
    int idCliente, idDevedores, iParcelas = 0;
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
            devedores.Descricao = TxtDescricao.Text.Trim();
            devedores.Valor = decimal.Parse(TxtValor.Text.Trim());
            devedores.Parcelas = int.Parse(TxtParcelas.Text.Trim());
            devedores.DataInicio = DateTime.Parse(MktDataInicio.Text);
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

    private void GerarMovimentacao(int idDevedor)
    {
        MovimentoDevedoresObj movimentoDevedores = new();
        DevedoresIdMovimento devedoresIdMovimento = new();

        Negocio.Movimento.Devedor.Inserir inserir = new();

        try
        {

            if (devedoresIdMovimento.QtdDevedoresMovimento(idDevedor) > 0)
            {
                MessageBox.Show("Devedor já foi gerado!");
                return;
            }

            movimentoDevedores.Devedores = new();
            movimentoDevedores.Devedores.Id = idDevedor;
            movimentoDevedores.Valor = decimal.Parse(TxtValor.Text);
            movimentoDevedores.Recebido = "Não";
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

            MessageBox.Show("Devedores Gerado com Sucesso!");

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

    private void DgvListaDevedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        DevedoresIdMovimento devedoresIdMovimento = new DevedoresIdMovimento();

        idDevedores = int.Parse(DgvListaDevedores.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        iParcelas = int.Parse(DgvListaDevedores.Rows[e.RowIndex].Cells["Parcelas"].Value.ToString());
        TxtNome.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        TxtDescricao.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
        TxtValor.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["Valor"].Value.ToString();
        TxtParcelas.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["Parcelas"].Value.ToString();
        MktDataInicio.Text = DgvListaDevedores.Rows[e.RowIndex].Cells["DataInicio"].Value.ToString();


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
        BtnGerar.Enabled = true;
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
        MktDataInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
    }

    private void FrmCadDevedores_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
        ListaCliente();
    }

    private void TxtValor_TextChanged(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new();
        TxtValor.Text = validarNumero.Validar(TxtValor.Text);
        TxtValor.Select(TxtValor.Text.Length, 0);
    }

    private void TxtValor_Leave(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new();
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

    private void TxtParcelas_TextChanged(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new();
        TxtParcelas.Text = validarNumero.ValidarNumeroInteiro(TxtParcelas.Text);
        TxtParcelas.Select(TxtParcelas.Text.Length, 0);
    }

    private void TxtParcelas_Leave(object sender, EventArgs e)
    {
        ValidarNumero validarNumero = new();
        TxtParcelas.Text = validarNumero.ZeroInteiro(TxtParcelas.Text);
        TxtParcelas.Text = validarNumero.FormatarInteiro(TxtParcelas.Text);
    }

    private void TxtParcelas_Enter(object sender, EventArgs e)
    {
        if (TxtParcelas.Text == "0")
        {
            TxtParcelas.Text = "1";
        }
    }

    private void BtnGerar_Click(object sender, EventArgs e)
    {
        GerarMovimentacao(idDevedores);
    }
}
