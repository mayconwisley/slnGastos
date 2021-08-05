using System;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmPrincipal : Form
    {

        string strLogin;
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        public FrmPrincipal(string login)
        {
            InitializeComponent();
            strLogin = login;
        }

        private void SubMenuCadCliente_Click(object sender, EventArgs e)
        {
            FrmCadCliente frmCadCliente = new FrmCadCliente(strLogin);
            frmCadCliente.ShowDialog();
        }

        private void SubMenuCadCompetencia_Click(object sender, EventArgs e)
        {
            FrmCadCompetencia frmCadCompetencia = new FrmCadCompetencia();
            frmCadCompetencia.ShowDialog();
        }

        private void SubMenuCadUsuario_Click(object sender, EventArgs e)
        {
            FrmCadUsuario frmCadUsuario = new FrmCadUsuario();
            frmCadUsuario.ShowDialog();
        }

        private void SubMenuFixCadastro_Click(object sender, EventArgs e)
        {
            FrmCadFixos frmCadFixos = new FrmCadFixos(strLogin);
            frmCadFixos.ShowDialog();
        }

        private void SubMenuEmpCadastro_Click(object sender, EventArgs e)
        {
            FrmCadEmprestimo frmCadEmprestimo = new FrmCadEmprestimo(strLogin);
            frmCadEmprestimo.ShowDialog();
        }

        private void SubMenuEmpMovimentacao_Click(object sender, EventArgs e)
        {
            FrmCadMovimentoEmprestimo frmCadMovimentoEmprestimo = new FrmCadMovimentoEmprestimo(strLogin);
            frmCadMovimentoEmprestimo.ShowDialog();
        }

        private void SubMenuDevCadastro_Click(object sender, EventArgs e)
        {
            FrmCadDevedores frmCadDevedores = new FrmCadDevedores(strLogin);
            frmCadDevedores.ShowDialog();
        }

        private void SubMenuDevMovimentacao_Click(object sender, EventArgs e)
        {
            FrmCadMovimentoDevedores frmCadMovimentoDevedores = new FrmCadMovimentoDevedores(strLogin);
            frmCadMovimentoDevedores.ShowDialog();
        }

        private void SubMenuMovCadastro_Click(object sender, EventArgs e)
        {
            FrmCadMovimentacao frmCadMovimentacao = new FrmCadMovimentacao(strLogin);
            frmCadMovimentacao.ShowDialog();
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimeAtual_Tick(object sender, EventArgs e)
        {
            TsLblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/mm/yyyy") + " Hora: " + DateTime.Now.ToString("HH:mm");
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
    }
}
