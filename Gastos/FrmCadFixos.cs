using Negocio.Cliente.Listar;
using Negocio.Fixo;
using Negocio.Fixo.Listar;
using Negocio.Utilitario;
using Negocio.Validador;
using Objeto.Fixos;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadFixos : Form
{
    string strLogin;
    int idCliente, idFixos;

    FrmPrincipal frmForm;
    public FrmCadFixos(string login)
    {
        InitializeComponent();
        strLogin = login;
    }

    public FrmCadFixos(FrmPrincipal form, string login)
    {
        InitializeComponent();
        strLogin = login;
        frmForm = form;
    }

    private void CadastroFixos(OpcaoCadastro opcaoCadastro)
    {
        FixoObj fixo = new FixoObj();
        Inserir inserir = new Inserir();
        Alterar alterar = new Alterar();
        Excluir excluir = new Excluir();

        DateTime dataFim = new DateTime();
        try
        {
            fixo.Id = idFixos;
            fixo.DataInicio = DateTime.Parse(MktDataInicio.Text.Trim());
            fixo.Descricao = TxtDescricao.Text.Trim();
            fixo.Valor = decimal.Parse(TxtValor.Text.Trim());
            bool sucesso = DateTime.TryParse(MktDataFim.Text.Trim(), out dataFim);
            if (sucesso)
            {
                fixo.DataFim = dataFim;
            }


            if (MktDataInicio.MaskCompleted && !MktDataFim.MaskCompleted)
            {
                fixo.Ativo = "Sim";
            }

            if (MktDataFim.MaskCompleted)
            {
                fixo.Ativo = "Não";
            }


            fixo.DataCadastro = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            fixo.Usuario = new Objeto.Usuario.UsuarioObj();
            fixo.Usuario.Login = strLogin;
            fixo.Cliente = new Objeto.Cliente.ClienteObj();
            fixo.Cliente.Id = idCliente;


            switch (opcaoCadastro)
            {
                case OpcaoCadastro.Salvar:
                    inserir.Cadastro(fixo);
                    break;
                case OpcaoCadastro.Alterar:
                    alterar.Cadastro(fixo);
                    break;
                case OpcaoCadastro.Excluir:
                    excluir.Cadastro(fixo);
                    break;
                default:
                    break;
            }
            ListaFixo(idCliente);
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

    private void ListarCliente()
    {
        IdNomeCliente idNomeCliente = new IdNomeCliente();
        CbxCliente.DataSource = idNomeCliente.Consulta();
    }

    private void LimparCampos()
    {
        TxtDescricao.Clear();
        MktDataFim.Clear();
        MktDataInicio.Clear();
        TxtValor.Text = "0,00";

    }

    private void ListaFixo(int idCliente)
    {
        CadastroFixosCliente cadastroFixosCliente = new CadastroFixosCliente();
        DgvListarFixos.DataSource = cadastroFixosCliente.Consulta(idCliente);
        Informacoes();
        MktDataInicio.Focus();

    }

    private void Informacoes()
    {
        decimal valTotalAtivo = 0, valTotalNAtivo = 0, valTotalGeral = 0;

        foreach (DataGridViewRow row in DgvListarFixos.Rows)
        {
            if (row.Cells["Ativo"].Value.ToString() == "Sim")
            {
                valTotalAtivo = valTotalAtivo + decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            else
            {
                valTotalNAtivo = valTotalNAtivo + decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            valTotalGeral = valTotalGeral + decimal.Parse(row.Cells["Valor"].Value.ToString());
        }

        LblTotalAtivo.Text = "Total Ativo...: " + valTotalAtivo.ToString("#,##0.00");
        LblTotalNAtivo.Text = "Total Ñ Ativo.: " + valTotalNAtivo.ToString("#,##0.00");
        LblTotalGeral.Text = "Total Geral...: " + valTotalGeral.ToString("#,##0.00");
    }

    private void FrmCadFixos_Load(object sender, EventArgs e)
    {
        LblDataCadastro.Text = "Data Cadastro: " + DateTime.Now.ToString("dd/MM/yyyy");
        ListarCliente();
    }

    private void CbxCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        idCliente = int.Parse(CbxCliente.SelectedValue.ToString());
        ListaFixo(idCliente);
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        CadastroFixos(OpcaoCadastro.Salvar);
    }

    private void BtnAlterar_Click(object sender, EventArgs e)
    {
        CadastroFixos(OpcaoCadastro.Alterar);
    }

    private void BtnExcluir_Click(object sender, EventArgs e)
    {
        CadastroFixos(OpcaoCadastro.Excluir);
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

    private void FrmCadFixos_FormClosing(object sender, FormClosingEventArgs e)
    {
        frmForm.AtualizarFrmPrincipal();
    }

    private void DgvListarFixos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        idFixos = int.Parse(DgvListarFixos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        TxtDescricao.Text = DgvListarFixos.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();

        decimal valor = decimal.Parse(DgvListarFixos.Rows[e.RowIndex].Cells["Valor"].Value.ToString());
        TxtValor.Text = valor.ToString("#,##0.00");
        MktDataInicio.Text = DgvListarFixos.Rows[e.RowIndex].Cells["DataInicio"].Value.ToString();
        MktDataFim.Text = DgvListarFixos.Rows[e.RowIndex].Cells["DataFim"].Value.ToString();

        if (!MktDataFim.MaskCompleted)
        {
            MktDataFim.Clear();
        }

        BtnAlterar.Enabled = true;
        BtnExcluir.Enabled = true;
        BtnSalvar.Enabled = false;

    }
}
