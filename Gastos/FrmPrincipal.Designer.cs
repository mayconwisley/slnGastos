
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CbxCliente = new System.Windows.Forms.ComboBox();
            this.MktCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlFixos = new System.Windows.Forms.Panel();
            this.LblDespesaFixo = new System.Windows.Forms.Label();
            this.PnlDevedores = new System.Windows.Forms.Panel();
            this.LblCreditoDevedores = new System.Windows.Forms.Label();
            this.PnlEmprestimos = new System.Windows.Forms.Panel();
            this.LblDespesaEmprestimo = new System.Windows.Forms.Label();
            this.PnlGraficoMovimentacao = new System.Windows.Forms.Panel();
            this.GraEntradaSaida = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.PnlSaldoMes = new System.Windows.Forms.Panel();
            this.LblSaldo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GraRecebidoPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.MenuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PnlFixos.SuspendLayout();
            this.PnlDevedores.SuspendLayout();
            this.PnlEmprestimos.SuspendLayout();
            this.PnlGraficoMovimentacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraEntradaSaida)).BeginInit();
            this.PnlSaldoMes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraRecebidoPago)).BeginInit();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CbxCliente);
            this.panel1.Controls.Add(this.MktCompetencia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 52);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // CbxCliente
            // 
            this.CbxCliente.DisplayMember = "Nome";
            this.CbxCliente.FormattingEnabled = true;
            this.CbxCliente.Location = new System.Drawing.Point(81, 22);
            this.CbxCliente.Name = "CbxCliente";
            this.CbxCliente.Size = new System.Drawing.Size(223, 21);
            this.CbxCliente.TabIndex = 2;
            this.CbxCliente.ValueMember = "Id";
            this.CbxCliente.SelectedIndexChanged += new System.EventHandler(this.CbxCliente_SelectedIndexChanged);
            // 
            // MktCompetencia
            // 
            this.MktCompetencia.Location = new System.Drawing.Point(9, 22);
            this.MktCompetencia.Mask = "00/0000";
            this.MktCompetencia.Name = "MktCompetencia";
            this.MktCompetencia.Size = new System.Drawing.Size(66, 20);
            this.MktCompetencia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Competência";
            // 
            // PnlFixos
            // 
            this.PnlFixos.Controls.Add(this.LblDespesaFixo);
            this.PnlFixos.Location = new System.Drawing.Point(12, 98);
            this.PnlFixos.Name = "PnlFixos";
            this.PnlFixos.Size = new System.Drawing.Size(508, 32);
            this.PnlFixos.TabIndex = 3;
            // 
            // LblDespesaFixo
            // 
            this.LblDespesaFixo.AutoSize = true;
            this.LblDespesaFixo.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDespesaFixo.Location = new System.Drawing.Point(4, 4);
            this.LblDespesaFixo.Name = "LblDespesaFixo";
            this.LblDespesaFixo.Size = new System.Drawing.Size(337, 25);
            this.LblDespesaFixo.TabIndex = 0;
            this.LblDespesaFixo.Text = "Despesa Fixas......: 0,00";
            // 
            // PnlDevedores
            // 
            this.PnlDevedores.Controls.Add(this.LblCreditoDevedores);
            this.PnlDevedores.Location = new System.Drawing.Point(12, 174);
            this.PnlDevedores.Name = "PnlDevedores";
            this.PnlDevedores.Size = new System.Drawing.Size(508, 32);
            this.PnlDevedores.TabIndex = 3;
            // 
            // LblCreditoDevedores
            // 
            this.LblCreditoDevedores.AutoSize = true;
            this.LblCreditoDevedores.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCreditoDevedores.Location = new System.Drawing.Point(3, 5);
            this.LblCreditoDevedores.Name = "LblCreditoDevedores";
            this.LblCreditoDevedores.Size = new System.Drawing.Size(337, 25);
            this.LblCreditoDevedores.TabIndex = 0;
            this.LblCreditoDevedores.Text = "Crédito Devedores..: 0,00";
            // 
            // PnlEmprestimos
            // 
            this.PnlEmprestimos.Controls.Add(this.LblDespesaEmprestimo);
            this.PnlEmprestimos.Location = new System.Drawing.Point(12, 136);
            this.PnlEmprestimos.Name = "PnlEmprestimos";
            this.PnlEmprestimos.Size = new System.Drawing.Size(508, 32);
            this.PnlEmprestimos.TabIndex = 3;
            // 
            // LblDespesaEmprestimo
            // 
            this.LblDespesaEmprestimo.AutoSize = true;
            this.LblDespesaEmprestimo.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDespesaEmprestimo.Location = new System.Drawing.Point(4, 4);
            this.LblDespesaEmprestimo.Name = "LblDespesaEmprestimo";
            this.LblDespesaEmprestimo.Size = new System.Drawing.Size(337, 25);
            this.LblDespesaEmprestimo.TabIndex = 0;
            this.LblDespesaEmprestimo.Text = "Despesa Emprestimos: 0,00";
            // 
            // PnlGraficoMovimentacao
            // 
            this.PnlGraficoMovimentacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlGraficoMovimentacao.Controls.Add(this.GraEntradaSaida);
            this.PnlGraficoMovimentacao.Controls.Add(this.label6);
            this.PnlGraficoMovimentacao.Location = new System.Drawing.Point(526, 368);
            this.PnlGraficoMovimentacao.Name = "PnlGraficoMovimentacao";
            this.PnlGraficoMovimentacao.Size = new System.Drawing.Size(675, 319);
            this.PnlGraficoMovimentacao.TabIndex = 4;
            // 
            // GraEntradaSaida
            // 
            this.GraEntradaSaida.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.AxisX.LabelStyle.Format = "00/0000";
            chartArea3.AxisY.LabelStyle.Format = "#,##0.00";
            chartArea3.Name = "ChartArea1";
            this.GraEntradaSaida.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.GraEntradaSaida.Legends.Add(legend3);
            this.GraEntradaSaida.Location = new System.Drawing.Point(3, 27);
            this.GraEntradaSaida.Name = "GraEntradaSaida";
            this.GraEntradaSaida.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series5.ChartArea = "ChartArea1";
            series5.IsValueShownAsLabel = true;
            series5.LabelFormat = "#,##0.00";
            series5.Legend = "Legend1";
            series5.Name = "Entradas";
            series6.ChartArea = "ChartArea1";
            series6.IsValueShownAsLabel = true;
            series6.LabelFormat = "#,##0.00";
            series6.Legend = "Legend1";
            series6.Name = "Saidas";
            this.GraEntradaSaida.Series.Add(series5);
            this.GraEntradaSaida.Series.Add(series6);
            this.GraEntradaSaida.Size = new System.Drawing.Size(669, 289);
            this.GraEntradaSaida.TabIndex = 1;
            this.GraEntradaSaida.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title3.Name = "Teste";
            title3.Text = "Movimentações";
            this.GraEntradaSaida.Titles.Add(title3);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(354, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Gráfico dos ultimos 5 meses das movimentações";
            // 
            // PnlSaldoMes
            // 
            this.PnlSaldoMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PnlSaldoMes.Controls.Add(this.LblSaldo);
            this.PnlSaldoMes.Location = new System.Drawing.Point(12, 542);
            this.PnlSaldoMes.Name = "PnlSaldoMes";
            this.PnlSaldoMes.Size = new System.Drawing.Size(508, 145);
            this.PnlSaldoMes.TabIndex = 5;
            // 
            // LblSaldo
            // 
            this.LblSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblSaldo.AutoSize = true;
            this.LblSaldo.Font = new System.Drawing.Font("Courier New", 26F, System.Drawing.FontStyle.Bold);
            this.LblSaldo.Location = new System.Drawing.Point(3, 52);
            this.LblSaldo.Name = "LblSaldo";
            this.LblSaldo.Size = new System.Drawing.Size(248, 40);
            this.LblSaldo.TabIndex = 0;
            this.LblSaldo.Text = "Saldo: 0,00";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.GraRecebidoPago);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(526, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 295);
            this.panel2.TabIndex = 4;
            // 
            // GraRecebidoPago
            // 
            this.GraRecebidoPago.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.AxisX.LabelStyle.Format = "00/0000";
            chartArea4.AxisX2.LabelStyle.Format = "#,##0.00";
            chartArea4.AxisY.LabelStyle.Format = "#,##0.00";
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.BorderColor = System.Drawing.Color.Empty;
            chartArea4.Name = "ChartArea1";
            chartArea4.ShadowColor = System.Drawing.Color.Gray;
            this.GraRecebidoPago.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.GraRecebidoPago.Legends.Add(legend4);
            this.GraRecebidoPago.Location = new System.Drawing.Point(3, 27);
            this.GraRecebidoPago.Name = "GraRecebidoPago";
            this.GraRecebidoPago.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series7.ChartArea = "ChartArea1";
            series7.IsValueShownAsLabel = true;
            series7.LabelFormat = "#,##0.00";
            series7.Legend = "Legend1";
            series7.Name = "Recebido";
            series8.ChartArea = "ChartArea1";
            series8.IsValueShownAsLabel = true;
            series8.LabelFormat = "#,##0.00";
            series8.Legend = "Legend1";
            series8.Name = "Pagos";
            this.GraRecebidoPago.Series.Add(series7);
            this.GraRecebidoPago.Series.Add(series8);
            this.GraRecebidoPago.Size = new System.Drawing.Size(669, 265);
            this.GraRecebidoPago.TabIndex = 1;
            this.GraRecebidoPago.Text = "chart1";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title4.Name = "Teste";
            title4.Text = "Movimentações";
            this.GraRecebidoPago.Titles.Add(title4);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(354, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Gráfico dos ultimos 5 meses das movimentações";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 712);
            this.Controls.Add(this.PnlSaldoMes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnlGraficoMovimentacao);
            this.Controls.Add(this.PnlDevedores);
            this.Controls.Add(this.PnlEmprestimos);
            this.Controls.Add(this.PnlFixos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnlFixos.ResumeLayout(false);
            this.PnlFixos.PerformLayout();
            this.PnlDevedores.ResumeLayout(false);
            this.PnlDevedores.PerformLayout();
            this.PnlEmprestimos.ResumeLayout(false);
            this.PnlEmprestimos.PerformLayout();
            this.PnlGraficoMovimentacao.ResumeLayout(false);
            this.PnlGraficoMovimentacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraEntradaSaida)).EndInit();
            this.PnlSaldoMes.ResumeLayout(false);
            this.PnlSaldoMes.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraRecebidoPago)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MktCompetencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbxCliente;
        private System.Windows.Forms.Panel PnlFixos;
        private System.Windows.Forms.Label LblDespesaFixo;
        private System.Windows.Forms.Panel PnlDevedores;
        private System.Windows.Forms.Label LblCreditoDevedores;
        private System.Windows.Forms.Panel PnlEmprestimos;
        private System.Windows.Forms.Label LblDespesaEmprestimo;
        private System.Windows.Forms.Panel PnlGraficoMovimentacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraEntradaSaida;
        private System.Windows.Forms.Panel PnlSaldoMes;
        private System.Windows.Forms.Label LblSaldo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraRecebidoPago;
        private System.Windows.Forms.Label label8;
    }
}

