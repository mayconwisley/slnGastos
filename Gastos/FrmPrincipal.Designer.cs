
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            MenuPrincipal = new System.Windows.Forms.MenuStrip();
            MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuCadCliente = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuCadSeparador1 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuCadCompetencia = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuCadSeparador2 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuCadUsuario = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuCadSeparador3 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuCadRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            MenuFixo = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuFixCadastro = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuFixConsulta = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuFixSeparador1 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuFixRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            MenuEmprestimo = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuEmpCadastro = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuEmpMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuEmpConsulta = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuEmpRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            MenuDevedores = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuDevCadastro = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuDevMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuDevConsulta = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuDevRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            MenuMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuMovCadastro = new System.Windows.Forms.ToolStripMenuItem();
            SubMenuMovConsulta = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            SubMenuMovRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            TsLblDataHora = new System.Windows.Forms.ToolStripStatusLabel();
            TsLblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            TimeAtual = new System.Windows.Forms.Timer(components);
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            CbxCliente = new System.Windows.Forms.ComboBox();
            MktCompetencia = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            PnlFixos = new System.Windows.Forms.Panel();
            LblDespesaFixo = new System.Windows.Forms.Label();
            PnlDevedores = new System.Windows.Forms.Panel();
            LblCreditoDevedores = new System.Windows.Forms.Label();
            PnlEmprestimos = new System.Windows.Forms.Panel();
            LblDespesaEmprestimo = new System.Windows.Forms.Label();
            PnlSaldoMes = new System.Windows.Forms.Panel();
            LblSaldo = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            LblDebitoDevedores = new System.Windows.Forms.Label();
            MenuPrincipal.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            PnlFixos.SuspendLayout();
            PnlDevedores.SuspendLayout();
            PnlEmprestimos.SuspendLayout();
            PnlSaldoMes.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPrincipal
            // 
            MenuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuCadastro, MenuFixo, MenuEmprestimo, MenuDevedores, MenuMovimentacao, MenuSair });
            MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            MenuPrincipal.Name = "MenuPrincipal";
            MenuPrincipal.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            MenuPrincipal.Size = new System.Drawing.Size(903, 24);
            MenuPrincipal.TabIndex = 0;
            MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuCadastro
            // 
            MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SubMenuCadCliente, SubMenuCadSeparador1, SubMenuCadCompetencia, SubMenuCadSeparador2, SubMenuCadUsuario, SubMenuCadSeparador3, SubMenuCadRelatorio });
            MenuCadastro.Name = "MenuCadastro";
            MenuCadastro.Size = new System.Drawing.Size(66, 20);
            MenuCadastro.Text = "Cadastro";
            // 
            // SubMenuCadCliente
            // 
            SubMenuCadCliente.Name = "SubMenuCadCliente";
            SubMenuCadCliente.Size = new System.Drawing.Size(145, 22);
            SubMenuCadCliente.Text = "Cliente";
            SubMenuCadCliente.Click += SubMenuCadCliente_Click;
            // 
            // SubMenuCadSeparador1
            // 
            SubMenuCadSeparador1.Name = "SubMenuCadSeparador1";
            SubMenuCadSeparador1.Size = new System.Drawing.Size(142, 6);
            // 
            // SubMenuCadCompetencia
            // 
            SubMenuCadCompetencia.Name = "SubMenuCadCompetencia";
            SubMenuCadCompetencia.Size = new System.Drawing.Size(145, 22);
            SubMenuCadCompetencia.Text = "Competência";
            SubMenuCadCompetencia.Click += SubMenuCadCompetencia_Click;
            // 
            // SubMenuCadSeparador2
            // 
            SubMenuCadSeparador2.Name = "SubMenuCadSeparador2";
            SubMenuCadSeparador2.Size = new System.Drawing.Size(142, 6);
            // 
            // SubMenuCadUsuario
            // 
            SubMenuCadUsuario.Name = "SubMenuCadUsuario";
            SubMenuCadUsuario.Size = new System.Drawing.Size(145, 22);
            SubMenuCadUsuario.Text = "Usuário";
            SubMenuCadUsuario.Click += SubMenuCadUsuario_Click;
            // 
            // SubMenuCadSeparador3
            // 
            SubMenuCadSeparador3.Name = "SubMenuCadSeparador3";
            SubMenuCadSeparador3.Size = new System.Drawing.Size(142, 6);
            SubMenuCadSeparador3.Visible = false;
            // 
            // SubMenuCadRelatorio
            // 
            SubMenuCadRelatorio.Name = "SubMenuCadRelatorio";
            SubMenuCadRelatorio.Size = new System.Drawing.Size(145, 22);
            SubMenuCadRelatorio.Text = "Relatório";
            SubMenuCadRelatorio.Visible = false;
            // 
            // MenuFixo
            // 
            MenuFixo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SubMenuFixCadastro, SubMenuFixConsulta, SubMenuFixSeparador1, SubMenuFixRelatorio });
            MenuFixo.Name = "MenuFixo";
            MenuFixo.Size = new System.Drawing.Size(41, 20);
            MenuFixo.Text = "Fixo";
            // 
            // SubMenuFixCadastro
            // 
            SubMenuFixCadastro.Name = "SubMenuFixCadastro";
            SubMenuFixCadastro.Size = new System.Drawing.Size(121, 22);
            SubMenuFixCadastro.Text = "Cadastro";
            SubMenuFixCadastro.Click += SubMenuFixCadastro_Click;
            // 
            // SubMenuFixConsulta
            // 
            SubMenuFixConsulta.Name = "SubMenuFixConsulta";
            SubMenuFixConsulta.Size = new System.Drawing.Size(121, 22);
            SubMenuFixConsulta.Text = "Consulta";
            SubMenuFixConsulta.Click += SubMenuFixConsulta_Click;
            // 
            // SubMenuFixSeparador1
            // 
            SubMenuFixSeparador1.Name = "SubMenuFixSeparador1";
            SubMenuFixSeparador1.Size = new System.Drawing.Size(118, 6);
            SubMenuFixSeparador1.Visible = false;
            // 
            // SubMenuFixRelatorio
            // 
            SubMenuFixRelatorio.Name = "SubMenuFixRelatorio";
            SubMenuFixRelatorio.Size = new System.Drawing.Size(121, 22);
            SubMenuFixRelatorio.Text = "Relatório";
            SubMenuFixRelatorio.Visible = false;
            // 
            // MenuEmprestimo
            // 
            MenuEmprestimo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SubMenuEmpCadastro, SubMenuEmpMovimentacao, SubMenuEmpConsulta, toolStripSeparator5, SubMenuEmpRelatorio });
            MenuEmprestimo.Name = "MenuEmprestimo";
            MenuEmprestimo.Size = new System.Drawing.Size(88, 20);
            MenuEmprestimo.Text = "Empréstimos";
            // 
            // SubMenuEmpCadastro
            // 
            SubMenuEmpCadastro.Name = "SubMenuEmpCadastro";
            SubMenuEmpCadastro.Size = new System.Drawing.Size(154, 22);
            SubMenuEmpCadastro.Text = "Cadastro";
            SubMenuEmpCadastro.Click += SubMenuEmpCadastro_Click;
            // 
            // SubMenuEmpMovimentacao
            // 
            SubMenuEmpMovimentacao.Name = "SubMenuEmpMovimentacao";
            SubMenuEmpMovimentacao.Size = new System.Drawing.Size(154, 22);
            SubMenuEmpMovimentacao.Text = "Movimentação";
            SubMenuEmpMovimentacao.Click += SubMenuEmpMovimentacao_Click;
            // 
            // SubMenuEmpConsulta
            // 
            SubMenuEmpConsulta.Name = "SubMenuEmpConsulta";
            SubMenuEmpConsulta.Size = new System.Drawing.Size(154, 22);
            SubMenuEmpConsulta.Text = "Consulta";
            SubMenuEmpConsulta.Click += SubMenuEmpConsulta_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(151, 6);
            toolStripSeparator5.Visible = false;
            // 
            // SubMenuEmpRelatorio
            // 
            SubMenuEmpRelatorio.Name = "SubMenuEmpRelatorio";
            SubMenuEmpRelatorio.Size = new System.Drawing.Size(154, 22);
            SubMenuEmpRelatorio.Text = "Relatório";
            SubMenuEmpRelatorio.Visible = false;
            // 
            // MenuDevedores
            // 
            MenuDevedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SubMenuDevCadastro, SubMenuDevMovimentacao, SubMenuDevConsulta, toolStripSeparator6, SubMenuDevRelatorio });
            MenuDevedores.Name = "MenuDevedores";
            MenuDevedores.Size = new System.Drawing.Size(74, 20);
            MenuDevedores.Text = "Devedores";
            // 
            // SubMenuDevCadastro
            // 
            SubMenuDevCadastro.Name = "SubMenuDevCadastro";
            SubMenuDevCadastro.Size = new System.Drawing.Size(154, 22);
            SubMenuDevCadastro.Text = "Cadastro";
            SubMenuDevCadastro.Click += SubMenuDevCadastro_Click;
            // 
            // SubMenuDevMovimentacao
            // 
            SubMenuDevMovimentacao.Name = "SubMenuDevMovimentacao";
            SubMenuDevMovimentacao.Size = new System.Drawing.Size(154, 22);
            SubMenuDevMovimentacao.Text = "Movimentação";
            SubMenuDevMovimentacao.Click += SubMenuDevMovimentacao_Click;
            // 
            // SubMenuDevConsulta
            // 
            SubMenuDevConsulta.Name = "SubMenuDevConsulta";
            SubMenuDevConsulta.Size = new System.Drawing.Size(154, 22);
            SubMenuDevConsulta.Text = "Consulta";
            SubMenuDevConsulta.Click += SubMenuDevConsulta_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(151, 6);
            toolStripSeparator6.Visible = false;
            // 
            // SubMenuDevRelatorio
            // 
            SubMenuDevRelatorio.Name = "SubMenuDevRelatorio";
            SubMenuDevRelatorio.Size = new System.Drawing.Size(154, 22);
            SubMenuDevRelatorio.Text = "Relatório";
            SubMenuDevRelatorio.Visible = false;
            // 
            // MenuMovimentacao
            // 
            MenuMovimentacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SubMenuMovCadastro, SubMenuMovConsulta, toolStripSeparator7, SubMenuMovRelatorio });
            MenuMovimentacao.Name = "MenuMovimentacao";
            MenuMovimentacao.Size = new System.Drawing.Size(99, 20);
            MenuMovimentacao.Text = "Movimentação";
            // 
            // SubMenuMovCadastro
            // 
            SubMenuMovCadastro.Name = "SubMenuMovCadastro";
            SubMenuMovCadastro.Size = new System.Drawing.Size(121, 22);
            SubMenuMovCadastro.Text = "Cadastro";
            SubMenuMovCadastro.Click += SubMenuMovCadastro_Click;
            // 
            // SubMenuMovConsulta
            // 
            SubMenuMovConsulta.Name = "SubMenuMovConsulta";
            SubMenuMovConsulta.Size = new System.Drawing.Size(121, 22);
            SubMenuMovConsulta.Text = "Consulta";
            SubMenuMovConsulta.Click += SubMenuMovConsulta_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(118, 6);
            toolStripSeparator7.Visible = false;
            // 
            // SubMenuMovRelatorio
            // 
            SubMenuMovRelatorio.Name = "SubMenuMovRelatorio";
            SubMenuMovRelatorio.Size = new System.Drawing.Size(121, 22);
            SubMenuMovRelatorio.Text = "Relatório";
            SubMenuMovRelatorio.Visible = false;
            // 
            // MenuSair
            // 
            MenuSair.Name = "MenuSair";
            MenuSair.Size = new System.Drawing.Size(38, 20);
            MenuSair.Text = "Sair";
            MenuSair.Click += MenuSair_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, TsLblDataHora, TsLblUsuario });
            statusStrip1.Location = new System.Drawing.Point(0, 569);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(903, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(334, 17);
            toolStripStatusLabel1.Text = "Controle de Gastro - V. 1.0 - Desenvolvido por: Maycon Wisley";
            // 
            // TsLblDataHora
            // 
            TsLblDataHora.Name = "TsLblDataHora";
            TsLblDataHora.Size = new System.Drawing.Size(63, 17);
            TsLblDataHora.Text = "Data Hora:";
            // 
            // TsLblUsuario
            // 
            TsLblUsuario.Name = "TsLblUsuario";
            TsLblUsuario.Size = new System.Drawing.Size(50, 17);
            TsLblUsuario.Text = "Usuário:";
            // 
            // TimeAtual
            // 
            TimeAtual.Enabled = true;
            TimeAtual.Interval = 1000;
            TimeAtual.Tick += TimeAtual_Tick;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CbxCliente);
            panel1.Controls.Add(MktCompetencia);
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(14, 31);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(370, 60);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(91, 7);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Cliente";
            // 
            // CbxCliente
            // 
            CbxCliente.DisplayMember = "Nome";
            CbxCliente.FormattingEnabled = true;
            CbxCliente.Location = new System.Drawing.Point(94, 25);
            CbxCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbxCliente.Name = "CbxCliente";
            CbxCliente.Size = new System.Drawing.Size(259, 23);
            CbxCliente.TabIndex = 2;
            CbxCliente.ValueMember = "Id";
            CbxCliente.SelectedIndexChanged += CbxCliente_SelectedIndexChanged;
            // 
            // MktCompetencia
            // 
            MktCompetencia.Location = new System.Drawing.Point(10, 25);
            MktCompetencia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MktCompetencia.Mask = "00/0000";
            MktCompetencia.Name = "MktCompetencia";
            MktCompetencia.Size = new System.Drawing.Size(76, 23);
            MktCompetencia.TabIndex = 1;
            MktCompetencia.Leave += MktCompetencia_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 7);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Competência";
            // 
            // PnlFixos
            // 
            PnlFixos.Controls.Add(LblDespesaFixo);
            PnlFixos.Location = new System.Drawing.Point(14, 113);
            PnlFixos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PnlFixos.Name = "PnlFixos";
            PnlFixos.Size = new System.Drawing.Size(593, 37);
            PnlFixos.TabIndex = 3;
            // 
            // LblDespesaFixo
            // 
            LblDespesaFixo.AutoSize = true;
            LblDespesaFixo.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            LblDespesaFixo.Location = new System.Drawing.Point(5, 5);
            LblDespesaFixo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDespesaFixo.Name = "LblDespesaFixo";
            LblDespesaFixo.Size = new System.Drawing.Size(337, 25);
            LblDespesaFixo.TabIndex = 0;
            LblDespesaFixo.Text = "Despesa Fixas......: 0,00";
            // 
            // PnlDevedores
            // 
            PnlDevedores.Controls.Add(LblCreditoDevedores);
            PnlDevedores.Location = new System.Drawing.Point(14, 243);
            PnlDevedores.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PnlDevedores.Name = "PnlDevedores";
            PnlDevedores.Size = new System.Drawing.Size(593, 37);
            PnlDevedores.TabIndex = 3;
            // 
            // LblCreditoDevedores
            // 
            LblCreditoDevedores.AutoSize = true;
            LblCreditoDevedores.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            LblCreditoDevedores.Location = new System.Drawing.Point(4, 6);
            LblCreditoDevedores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblCreditoDevedores.Name = "LblCreditoDevedores";
            LblCreditoDevedores.Size = new System.Drawing.Size(337, 25);
            LblCreditoDevedores.TabIndex = 0;
            LblCreditoDevedores.Text = "Crédito Devedores..: 0,00";
            // 
            // PnlEmprestimos
            // 
            PnlEmprestimos.Controls.Add(LblDespesaEmprestimo);
            PnlEmprestimos.Location = new System.Drawing.Point(14, 157);
            PnlEmprestimos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PnlEmprestimos.Name = "PnlEmprestimos";
            PnlEmprestimos.Size = new System.Drawing.Size(593, 37);
            PnlEmprestimos.TabIndex = 3;
            // 
            // LblDespesaEmprestimo
            // 
            LblDespesaEmprestimo.AutoSize = true;
            LblDespesaEmprestimo.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            LblDespesaEmprestimo.Location = new System.Drawing.Point(5, 5);
            LblDespesaEmprestimo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDespesaEmprestimo.Name = "LblDespesaEmprestimo";
            LblDespesaEmprestimo.Size = new System.Drawing.Size(337, 25);
            LblDespesaEmprestimo.TabIndex = 0;
            LblDespesaEmprestimo.Text = "Despesa Empréstimos: 0,00";
            // 
            // PnlSaldoMes
            // 
            PnlSaldoMes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            PnlSaldoMes.Controls.Add(LblSaldo);
            PnlSaldoMes.Location = new System.Drawing.Point(13, 399);
            PnlSaldoMes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PnlSaldoMes.Name = "PnlSaldoMes";
            PnlSaldoMes.Size = new System.Drawing.Size(593, 167);
            PnlSaldoMes.TabIndex = 5;
            // 
            // LblSaldo
            // 
            LblSaldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            LblSaldo.AutoSize = true;
            LblSaldo.Font = new System.Drawing.Font("Courier New", 26F, System.Drawing.FontStyle.Bold);
            LblSaldo.Location = new System.Drawing.Point(4, 60);
            LblSaldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblSaldo.Name = "LblSaldo";
            LblSaldo.Size = new System.Drawing.Size(248, 40);
            LblSaldo.TabIndex = 0;
            LblSaldo.Text = "Saldo: 0,00";
            // 
            // panel3
            // 
            panel3.Controls.Add(LblDebitoDevedores);
            panel3.Location = new System.Drawing.Point(14, 200);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(593, 37);
            panel3.TabIndex = 3;
            // 
            // LblDebitoDevedores
            // 
            LblDebitoDevedores.AutoSize = true;
            LblDebitoDevedores.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            LblDebitoDevedores.Location = new System.Drawing.Point(4, 6);
            LblDebitoDevedores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDebitoDevedores.Name = "LblDebitoDevedores";
            LblDebitoDevedores.Size = new System.Drawing.Size(337, 25);
            LblDebitoDevedores.TabIndex = 0;
            LblDebitoDevedores.Text = "Débito Devedores...: 0,00";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(903, 591);
            Controls.Add(PnlSaldoMes);
            Controls.Add(panel3);
            Controls.Add(PnlDevedores);
            Controls.Add(PnlEmprestimos);
            Controls.Add(PnlFixos);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(MenuPrincipal);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuPrincipal;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FrmPrincipal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gastos - Versão de Teste - Sujeito a bugs";
            Load += FrmPrincipal_Load;
            MenuPrincipal.ResumeLayout(false);
            MenuPrincipal.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PnlFixos.ResumeLayout(false);
            PnlFixos.PerformLayout();
            PnlDevedores.ResumeLayout(false);
            PnlDevedores.PerformLayout();
            PnlEmprestimos.ResumeLayout(false);
            PnlEmprestimos.PerformLayout();
            PnlSaldoMes.ResumeLayout(false);
            PnlSaldoMes.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart GraEntradaSaida;
        private System.Windows.Forms.Panel PnlSaldoMes;
        private System.Windows.Forms.Label LblSaldo;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraRecebidoPago;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblDebitoDevedores;
    }
}

