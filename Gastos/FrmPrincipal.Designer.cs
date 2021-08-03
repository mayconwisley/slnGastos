
namespace Gastos
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuCadCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuCadSeparador1 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuCadCompetencia = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuCadSeparador2 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuCadUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuCadSeparador3 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuCadRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFixo = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuFixCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuFixConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuFixSeparador1 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuFixRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEmprestimo = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuEmpCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuEmpMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuEmpConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuEmpRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDevedores = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuDevCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuDevMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuDevConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuDevRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuMovCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuMovConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SubMenuMovRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsLblDataHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsLblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeAtual = new System.Windows.Forms.Timer(this.components);
            this.MenuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastro,
            this.MenuFixo,
            this.MenuEmprestimo,
            this.MenuDevedores,
            this.MenuMovimentacao,
            this.MenuSair});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(1213, 24);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuCadastro
            // 
            this.MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuCadCliente,
            this.SubMenuCadSeparador1,
            this.SubMenuCadCompetencia,
            this.SubMenuCadSeparador2,
            this.SubMenuCadUsuario,
            this.SubMenuCadSeparador3,
            this.SubMenuCadRelatorio});
            this.MenuCadastro.Name = "MenuCadastro";
            this.MenuCadastro.Size = new System.Drawing.Size(66, 20);
            this.MenuCadastro.Text = "Cadastro";
            // 
            // SubMenuCadCliente
            // 
            this.SubMenuCadCliente.Name = "SubMenuCadCliente";
            this.SubMenuCadCliente.Size = new System.Drawing.Size(145, 22);
            this.SubMenuCadCliente.Text = "Cliente";
            this.SubMenuCadCliente.Click += new System.EventHandler(this.SubMenuCadCliente_Click);
            // 
            // SubMenuCadSeparador1
            // 
            this.SubMenuCadSeparador1.Name = "SubMenuCadSeparador1";
            this.SubMenuCadSeparador1.Size = new System.Drawing.Size(142, 6);
            // 
            // SubMenuCadCompetencia
            // 
            this.SubMenuCadCompetencia.Name = "SubMenuCadCompetencia";
            this.SubMenuCadCompetencia.Size = new System.Drawing.Size(145, 22);
            this.SubMenuCadCompetencia.Text = "Competência";
            this.SubMenuCadCompetencia.Click += new System.EventHandler(this.SubMenuCadCompetencia_Click);
            // 
            // SubMenuCadSeparador2
            // 
            this.SubMenuCadSeparador2.Name = "SubMenuCadSeparador2";
            this.SubMenuCadSeparador2.Size = new System.Drawing.Size(142, 6);
            // 
            // SubMenuCadUsuario
            // 
            this.SubMenuCadUsuario.Name = "SubMenuCadUsuario";
            this.SubMenuCadUsuario.Size = new System.Drawing.Size(145, 22);
            this.SubMenuCadUsuario.Text = "Usuário";
            this.SubMenuCadUsuario.Click += new System.EventHandler(this.SubMenuCadUsuario_Click);
            // 
            // SubMenuCadSeparador3
            // 
            this.SubMenuCadSeparador3.Name = "SubMenuCadSeparador3";
            this.SubMenuCadSeparador3.Size = new System.Drawing.Size(142, 6);
            // 
            // SubMenuCadRelatorio
            // 
            this.SubMenuCadRelatorio.Name = "SubMenuCadRelatorio";
            this.SubMenuCadRelatorio.Size = new System.Drawing.Size(145, 22);
            this.SubMenuCadRelatorio.Text = "Relatório";
            // 
            // MenuFixo
            // 
            this.MenuFixo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuFixCadastro,
            this.SubMenuFixConsulta,
            this.SubMenuFixSeparador1,
            this.SubMenuFixRelatorio});
            this.MenuFixo.Name = "MenuFixo";
            this.MenuFixo.Size = new System.Drawing.Size(41, 20);
            this.MenuFixo.Text = "Fixo";
            // 
            // SubMenuFixCadastro
            // 
            this.SubMenuFixCadastro.Name = "SubMenuFixCadastro";
            this.SubMenuFixCadastro.Size = new System.Drawing.Size(121, 22);
            this.SubMenuFixCadastro.Text = "Cadastro";
            this.SubMenuFixCadastro.Click += new System.EventHandler(this.SubMenuFixCadastro_Click);
            // 
            // SubMenuFixConsulta
            // 
            this.SubMenuFixConsulta.Name = "SubMenuFixConsulta";
            this.SubMenuFixConsulta.Size = new System.Drawing.Size(121, 22);
            this.SubMenuFixConsulta.Text = "Consulta";
            this.SubMenuFixConsulta.Click += new System.EventHandler(this.SubMenuFixConsulta_Click);
            // 
            // SubMenuFixSeparador1
            // 
            this.SubMenuFixSeparador1.Name = "SubMenuFixSeparador1";
            this.SubMenuFixSeparador1.Size = new System.Drawing.Size(118, 6);
            // 
            // SubMenuFixRelatorio
            // 
            this.SubMenuFixRelatorio.Name = "SubMenuFixRelatorio";
            this.SubMenuFixRelatorio.Size = new System.Drawing.Size(121, 22);
            this.SubMenuFixRelatorio.Text = "Relatório";
            // 
            // MenuEmprestimo
            // 
            this.MenuEmprestimo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuEmpCadastro,
            this.SubMenuEmpMovimentacao,
            this.SubMenuEmpConsulta,
            this.toolStripSeparator5,
            this.SubMenuEmpRelatorio});
            this.MenuEmprestimo.Name = "MenuEmprestimo";
            this.MenuEmprestimo.Size = new System.Drawing.Size(88, 20);
            this.MenuEmprestimo.Text = "Empréstimos";
            // 
            // SubMenuEmpCadastro
            // 
            this.SubMenuEmpCadastro.Name = "SubMenuEmpCadastro";
            this.SubMenuEmpCadastro.Size = new System.Drawing.Size(154, 22);
            this.SubMenuEmpCadastro.Text = "Cadastro";
            this.SubMenuEmpCadastro.Click += new System.EventHandler(this.SubMenuEmpCadastro_Click);
            // 
            // SubMenuEmpMovimentacao
            // 
            this.SubMenuEmpMovimentacao.Name = "SubMenuEmpMovimentacao";
            this.SubMenuEmpMovimentacao.Size = new System.Drawing.Size(154, 22);
            this.SubMenuEmpMovimentacao.Text = "Movimentação";
            this.SubMenuEmpMovimentacao.Click += new System.EventHandler(this.SubMenuEmpMovimentacao_Click);
            // 
            // SubMenuEmpConsulta
            // 
            this.SubMenuEmpConsulta.Name = "SubMenuEmpConsulta";
            this.SubMenuEmpConsulta.Size = new System.Drawing.Size(154, 22);
            this.SubMenuEmpConsulta.Text = "Consulta";
            this.SubMenuEmpConsulta.Click += new System.EventHandler(this.SubMenuEmpConsulta_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(151, 6);
            // 
            // SubMenuEmpRelatorio
            // 
            this.SubMenuEmpRelatorio.Name = "SubMenuEmpRelatorio";
            this.SubMenuEmpRelatorio.Size = new System.Drawing.Size(154, 22);
            this.SubMenuEmpRelatorio.Text = "Relatório";
            // 
            // MenuDevedores
            // 
            this.MenuDevedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuDevCadastro,
            this.SubMenuDevMovimentacao,
            this.SubMenuDevConsulta,
            this.toolStripSeparator6,
            this.SubMenuDevRelatorio});
            this.MenuDevedores.Name = "MenuDevedores";
            this.MenuDevedores.Size = new System.Drawing.Size(74, 20);
            this.MenuDevedores.Text = "Devedores";
            // 
            // SubMenuDevCadastro
            // 
            this.SubMenuDevCadastro.Name = "SubMenuDevCadastro";
            this.SubMenuDevCadastro.Size = new System.Drawing.Size(154, 22);
            this.SubMenuDevCadastro.Text = "Cadastro";
            this.SubMenuDevCadastro.Click += new System.EventHandler(this.SubMenuDevCadastro_Click);
            // 
            // SubMenuDevMovimentacao
            // 
            this.SubMenuDevMovimentacao.Name = "SubMenuDevMovimentacao";
            this.SubMenuDevMovimentacao.Size = new System.Drawing.Size(154, 22);
            this.SubMenuDevMovimentacao.Text = "Movimentação";
            this.SubMenuDevMovimentacao.Click += new System.EventHandler(this.SubMenuDevMovimentacao_Click);
            // 
            // SubMenuDevConsulta
            // 
            this.SubMenuDevConsulta.Name = "SubMenuDevConsulta";
            this.SubMenuDevConsulta.Size = new System.Drawing.Size(154, 22);
            this.SubMenuDevConsulta.Text = "Consulta";
            this.SubMenuDevConsulta.Click += new System.EventHandler(this.SubMenuDevConsulta_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(151, 6);
            // 
            // SubMenuDevRelatorio
            // 
            this.SubMenuDevRelatorio.Name = "SubMenuDevRelatorio";
            this.SubMenuDevRelatorio.Size = new System.Drawing.Size(154, 22);
            this.SubMenuDevRelatorio.Text = "Relatório";
            // 
            // MenuMovimentacao
            // 
            this.MenuMovimentacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuMovCadastro,
            this.SubMenuMovConsulta,
            this.toolStripSeparator7,
            this.SubMenuMovRelatorio});
            this.MenuMovimentacao.Name = "MenuMovimentacao";
            this.MenuMovimentacao.Size = new System.Drawing.Size(99, 20);
            this.MenuMovimentacao.Text = "Movimentação";
            // 
            // SubMenuMovCadastro
            // 
            this.SubMenuMovCadastro.Name = "SubMenuMovCadastro";
            this.SubMenuMovCadastro.Size = new System.Drawing.Size(180, 22);
            this.SubMenuMovCadastro.Text = "Cadastro";
            this.SubMenuMovCadastro.Click += new System.EventHandler(this.SubMenuMovCadastro_Click);
            // 
            // SubMenuMovConsulta
            // 
            this.SubMenuMovConsulta.Name = "SubMenuMovConsulta";
            this.SubMenuMovConsulta.Size = new System.Drawing.Size(180, 22);
            this.SubMenuMovConsulta.Text = "Consulta";
            this.SubMenuMovConsulta.Click += new System.EventHandler(this.SubMenuMovConsulta_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // SubMenuMovRelatorio
            // 
            this.SubMenuMovRelatorio.Name = "SubMenuMovRelatorio";
            this.SubMenuMovRelatorio.Size = new System.Drawing.Size(180, 22);
            this.SubMenuMovRelatorio.Text = "Relatório";
            // 
            // MenuSair
            // 
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(38, 20);
            this.MenuSair.Text = "Sair";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TsLblDataHora,
            this.TsLblUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 690);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1213, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(334, 17);
            this.toolStripStatusLabel1.Text = "Controle de Gastro - V. 1.0 - Desenvolvido por: Maycon Wisley";
            // 
            // TsLblDataHora
            // 
            this.TsLblDataHora.Name = "TsLblDataHora";
            this.TsLblDataHora.Size = new System.Drawing.Size(63, 17);
            this.TsLblDataHora.Text = "Data Hora:";
            // 
            // TsLblUsuario
            // 
            this.TsLblUsuario.Name = "TsLblUsuario";
            this.TsLblUsuario.Size = new System.Drawing.Size(50, 17);
            this.TsLblUsuario.Text = "Usuário:";
            // 
            // TimeAtual
            // 
            this.TimeAtual.Enabled = true;
            this.TimeAtual.Interval = 1000;
            this.TimeAtual.Tick += new System.EventHandler(this.TimeAtual_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 712);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuPrincipal);
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos";
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastro;
        private System.Windows.Forms.ToolStripMenuItem SubMenuCadCliente;
        private System.Windows.Forms.ToolStripSeparator SubMenuCadSeparador1;
        private System.Windows.Forms.ToolStripMenuItem SubMenuCadCompetencia;
        private System.Windows.Forms.ToolStripSeparator SubMenuCadSeparador2;
        private System.Windows.Forms.ToolStripMenuItem SubMenuCadUsuario;
        private System.Windows.Forms.ToolStripSeparator SubMenuCadSeparador3;
        private System.Windows.Forms.ToolStripMenuItem SubMenuCadRelatorio;
        private System.Windows.Forms.ToolStripMenuItem MenuFixo;
        private System.Windows.Forms.ToolStripMenuItem SubMenuFixCadastro;
        private System.Windows.Forms.ToolStripMenuItem SubMenuFixConsulta;
        private System.Windows.Forms.ToolStripSeparator SubMenuFixSeparador1;
        private System.Windows.Forms.ToolStripMenuItem SubMenuFixRelatorio;
        private System.Windows.Forms.ToolStripMenuItem MenuEmprestimo;
        private System.Windows.Forms.ToolStripMenuItem SubMenuEmpCadastro;
        private System.Windows.Forms.ToolStripMenuItem SubMenuEmpMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem SubMenuEmpConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem SubMenuEmpRelatorio;
        private System.Windows.Forms.ToolStripMenuItem MenuDevedores;
        private System.Windows.Forms.ToolStripMenuItem SubMenuDevCadastro;
        private System.Windows.Forms.ToolStripMenuItem SubMenuDevMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem SubMenuDevConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem SubMenuDevRelatorio;
        private System.Windows.Forms.ToolStripMenuItem MenuMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem SubMenuMovCadastro;
        private System.Windows.Forms.ToolStripMenuItem SubMenuMovConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem SubMenuMovRelatorio;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TsLblDataHora;
        private System.Windows.Forms.Timer TimeAtual;
        private System.Windows.Forms.ToolStripStatusLabel TsLblUsuario;
    }
}

