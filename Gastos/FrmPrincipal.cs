using Negocio.Cliente.Listar;
using Negocio.Competencia.Listar;
using Negocio.Emprestimos.Listar;
using Negocio.Fixo.Listar;
using Negocio.Movimento.Devedor.Listar;
using Negocio.Movimento.Geral.Listar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmPrincipal : Form
{

    string strLogin;
    int idCliente, idCompetencia;
    DateTime competencia;
    public FrmPrincipal()
    {
        InitializeComponent();
    }
    public FrmPrincipal(string login)
    {
        InitializeComponent();
        strLogin = login;
    }


    public void ListarCliente()
    {
        IdNomeCliente idNomeCliente = new IdNomeCliente();
        try
        {
            CbxCliente.DataSource = idNomeCliente.Consulta();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    private void CompetenciaAtivaCliente(int idCliente)
    {
        CompetenciaCliente competenciaCliente = new CompetenciaCliente();
        CompetenciaIdCliente competenciaIdCliente = new CompetenciaIdCliente();

        try
        {

            idCompetencia = competenciaIdCliente.CompetenciaId(idCliente);

            competencia = competenciaCliente.CompetenciaAtiva(idCliente);
            MktCompetencia.Text = competencia.ToString("MM/yyyy");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Informacao(int idCliente, int idCompetencia)
    {

        CadastroFixosAtivoCliente cadastroFixosAtivoCliente = new CadastroFixosAtivoCliente();
        CadastroEmprestimoAtivoCliente cadastroEmprestimoAtivoCliente = new CadastroEmprestimoAtivoCliente();
        ConsultaMovDevClienteValorTotal consultaMovDevClienteValorTotal = new ConsultaMovDevClienteValorTotal();
        SaldoPagRecClienteComp saldoPagRecClienteComp = new SaldoPagRecClienteComp();

        try
        {
            LblDespesaFixo.Text = "Despesa Fixas......: " + cadastroFixosAtivoCliente.ValorFixo(idCliente).ToString("#,##0.00");
            LblDespesaEmprestimo.Text = "Despesa Empréstimos: " + cadastroEmprestimoAtivoCliente.ValorEmprestimoAPagar(idCliente, competencia).ToString("#,##0.00");
            LblDebitoDevedores.Text = "Débito Devedores...: " + consultaMovDevClienteValorTotal.ValorDevedorMes(idCliente, competencia).ToString("#,##0.00");
            LblCreditoDevedores.Text = "Crédito Devedores..: " + consultaMovDevClienteValorTotal.ValorDevedorPago(idCliente, competencia).ToString("#,##0.00");

            decimal saldo = saldoPagRecClienteComp.Saldo(idCliente, idCompetencia, competencia);

            if (saldo == 0)
            {
                LblSaldo.ForeColor = Color.Black;
            }
            else if (saldo > 0)
            {
                LblSaldo.ForeColor = Color.Green;
            }
            else
            {
                LblSaldo.ForeColor = Color.Red;
            }

            LblSaldo.Text = "Saldo: " + saldo.ToString("#,##0.00");

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    public void AtualizarFrmPrincipal()
    {
        CompetenciaAtivaCliente(idCliente);
        Informacao(idCliente, idCompetencia);

    }

    private void SubMenuCadCliente_Click(object sender, EventArgs e)
    {
        FrmCadCliente frmCadCliente = new FrmCadCliente(this, strLogin);
        frmCadCliente.ShowDialog();
    }

    private void SubMenuCadCompetencia_Click(object sender, EventArgs e)
    {
        FrmCadCompetencia frmCadCompetencia = new FrmCadCompetencia(this);
        frmCadCompetencia.ShowDialog();
    }

    private void SubMenuCadUsuario_Click(object sender, EventArgs e)
    {
        FrmCadUsuario frmCadUsuario = new FrmCadUsuario();
        frmCadUsuario.ShowDialog();
    }

    private void SubMenuFixCadastro_Click(object sender, EventArgs e)
    {
        FrmCadFixos frmCadFixos = new FrmCadFixos(this, strLogin);
        frmCadFixos.ShowDialog();
    }

    private void SubMenuEmpCadastro_Click(object sender, EventArgs e)
    {
        FrmCadEmprestimo frmCadEmprestimo = new FrmCadEmprestimo(this, strLogin);
        frmCadEmprestimo.ShowDialog();
    }

    private void SubMenuEmpMovimentacao_Click(object sender, EventArgs e)
    {
        FrmCadMovimentoEmprestimo frmCadMovimentoEmprestimo = new FrmCadMovimentoEmprestimo(this, strLogin);
        frmCadMovimentoEmprestimo.ShowDialog();
    }

    private void SubMenuDevCadastro_Click(object sender, EventArgs e)
    {
        FrmCadDevedores frmCadDevedores = new FrmCadDevedores(this, strLogin);
        frmCadDevedores.ShowDialog();
    }

    private void SubMenuDevMovimentacao_Click(object sender, EventArgs e)
    {
        FrmCadMovimentoDevedores frmCadMovimentoDevedores = new FrmCadMovimentoDevedores(this, strLogin);
        frmCadMovimentoDevedores.ShowDialog();
    }

    private void SubMenuMovCadastro_Click(object sender, EventArgs e)
    {
        FrmCadMovimentacao frmCadMovimentacao = new FrmCadMovimentacao(this, strLogin);
        frmCadMovimentacao.ShowDialog();
    }

    private void MenuSair_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void TimeAtual_Tick(object sender, EventArgs e)
    {
        TsLblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + " Hora: " + DateTime.Now.ToString("HH:mm");
        TsLblUsuario.Text = "Usuário: " + strLogin;
    }

    private void SubMenuFixConsulta_Click(object sender, EventArgs e)
    {
        FrmConFixos frmConFixos = new FrmConFixos();
        frmConFixos.ShowDialog();
    }

    private void SubMenuEmpConsulta_Click(object sender, EventArgs e)
    {
        FrmConEmprestimo frmConEmprestimo = new FrmConEmprestimo();
        frmConEmprestimo.ShowDialog();
    }

    private void SubMenuDevConsulta_Click(object sender, EventArgs e)
    {
        FrmConDevedores frmConDevedores = new FrmConDevedores();
        frmConDevedores.ShowDialog();
    }

    private void SubMenuMovConsulta_Click(object sender, EventArgs e)
    {
        FrmConMovimentacao frmConMovimentacao = new FrmConMovimentacao();
        frmConMovimentacao.ShowDialog();
    }

    private void CbxCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        idCliente = int.Parse(CbxCliente.SelectedValue.ToString());
        competencia = DateTime.Parse(MktCompetencia.Text);
        CompetenciaIdData competenciaId = new();

        idCompetencia = competenciaId.CompetenciaId(idCliente, competencia);

        Informacao(idCliente, idCompetencia);
    }

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        MktCompetencia.Text = DateTime.Now.ToString("MM/yyyy");
        ListarCliente();
    }

    private void MktCompetencia_Leave(object sender, EventArgs e)
    {
        CompetenciaIdData competenciaId = new();
        competencia = DateTime.Parse(MktCompetencia.Text);
        idCompetencia = competenciaId.CompetenciaId(idCliente, competencia);

        Informacao(idCliente, idCompetencia);
    }
}
