
namespace Gastos
{
    partial class FrmCadMovimentoDevedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            groupBox5 = new System.Windows.Forms.GroupBox();
            LblValorPagar = new System.Windows.Forms.Label();
            LblValorPago = new System.Windows.Forms.Label();
            LblValorTotal = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            DgvListarMovimentoDev = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DevedoresId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Recebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox3 = new System.Windows.Forms.GroupBox();
            BtnExcluir = new System.Windows.Forms.Button();
            CmsBtnExcluir = new System.Windows.Forms.ContextMenuStrip(components);
            CmsExcluirTudo = new System.Windows.Forms.ToolStripMenuItem();
            BtnAlterar = new System.Windows.Forms.Button();
            BtnSalvar = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            LblDataCadastro = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            MktDataRecebido = new System.Windows.Forms.MaskedTextBox();
            label7 = new System.Windows.Forms.Label();
            CbxRecebido = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            TxtValor = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            TxtParcela = new System.Windows.Forms.TextBox();
            MktDataParcela = new System.Windows.Forms.MaskedTextBox();
            label2 = new System.Windows.Forms.Label();
            groupBox6 = new System.Windows.Forms.GroupBox();
            CbxNome = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            CbxDescricao = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListarMovimentoDev).BeginInit();
            groupBox3.SuspendLayout();
            CmsBtnExcluir.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(LblValorPagar);
            groupBox5.Controls.Add(LblValorPago);
            groupBox5.Controls.Add(LblValorTotal);
            groupBox5.Location = new System.Drawing.Point(14, 586);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Size = new System.Drawing.Size(631, 103);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Informações";
            // 
            // LblValorPagar
            // 
            LblValorPagar.AutoSize = true;
            LblValorPagar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblValorPagar.Location = new System.Drawing.Point(7, 69);
            LblValorPagar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblValorPagar.Name = "LblValorPagar";
            LblValorPagar.Size = new System.Drawing.Size(168, 14);
            LblValorPagar.TabIndex = 2;
            LblValorPagar.Text = "Valor a Receber..: 0,00";
            // 
            // LblValorPago
            // 
            LblValorPago.AutoSize = true;
            LblValorPago.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblValorPago.Location = new System.Drawing.Point(7, 44);
            LblValorPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblValorPago.Name = "LblValorPago";
            LblValorPago.Size = new System.Drawing.Size(168, 14);
            LblValorPago.TabIndex = 1;
            LblValorPago.Text = "Valor Recebido...: 0,00";
            // 
            // LblValorTotal
            // 
            LblValorTotal.AutoSize = true;
            LblValorTotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblValorTotal.Location = new System.Drawing.Point(7, 18);
            LblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblValorTotal.Name = "LblValorTotal";
            LblValorTotal.Size = new System.Drawing.Size(168, 14);
            LblValorTotal.TabIndex = 0;
            LblValorTotal.Text = "Valor Total......: 0,00";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(DgvListarMovimentoDev);
            groupBox4.Location = new System.Drawing.Point(14, 280);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Size = new System.Drawing.Size(631, 300);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Movimentacões cadastradas";
            // 
            // DgvListarMovimentoDev
            // 
            DgvListarMovimentoDev.AllowUserToAddRows = false;
            DgvListarMovimentoDev.AllowUserToDeleteRows = false;
            DgvListarMovimentoDev.AllowUserToOrderColumns = true;
            DgvListarMovimentoDev.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DgvListarMovimentoDev.BackgroundColor = System.Drawing.SystemColors.Control;
            DgvListarMovimentoDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvListarMovimentoDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListarMovimentoDev.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, DevedoresId, DataParcela, Descricao, Parcela, Valor, Recebido, DataRecebido, DataCadastro });
            DgvListarMovimentoDev.Location = new System.Drawing.Point(7, 22);
            DgvListarMovimentoDev.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvListarMovimentoDev.MultiSelect = false;
            DgvListarMovimentoDev.Name = "DgvListarMovimentoDev";
            DgvListarMovimentoDev.ReadOnly = true;
            DgvListarMovimentoDev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvListarMovimentoDev.Size = new System.Drawing.Size(614, 267);
            DgvListarMovimentoDev.TabIndex = 0;
            DgvListarMovimentoDev.CellDoubleClick += DgvListarMovimentoDev_CellDoubleClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 41;
            // 
            // DevedoresId
            // 
            DevedoresId.DataPropertyName = "DevedoresId";
            DevedoresId.HeaderText = "DevedoresId";
            DevedoresId.Name = "DevedoresId";
            DevedoresId.ReadOnly = true;
            DevedoresId.Visible = false;
            DevedoresId.Width = 93;
            // 
            // DataParcela
            // 
            DataParcela.DataPropertyName = "DataParcela";
            DataParcela.HeaderText = "Data Parcela";
            DataParcela.Name = "DataParcela";
            DataParcela.ReadOnly = true;
            DataParcela.Width = 97;
            // 
            // Descricao
            // 
            Descricao.DataPropertyName = "Descricao";
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 83;
            // 
            // Parcela
            // 
            Parcela.DataPropertyName = "Parcela";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            Parcela.DefaultCellStyle = dataGridViewCellStyle5;
            Parcela.HeaderText = "Parcela";
            Parcela.Name = "Parcela";
            Parcela.ReadOnly = true;
            Parcela.Width = 70;
            // 
            // Valor
            // 
            Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            Valor.DefaultCellStyle = dataGridViewCellStyle6;
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            Valor.Width = 58;
            // 
            // Recebido
            // 
            Recebido.DataPropertyName = "Recebido";
            Recebido.HeaderText = "Recebido";
            Recebido.Name = "Recebido";
            Recebido.ReadOnly = true;
            Recebido.Width = 81;
            // 
            // DataRecebido
            // 
            DataRecebido.DataPropertyName = "DataRecebido";
            DataRecebido.HeaderText = "Data Recebido";
            DataRecebido.Name = "DataRecebido";
            DataRecebido.ReadOnly = true;
            DataRecebido.Width = 108;
            // 
            // DataCadastro
            // 
            DataCadastro.DataPropertyName = "DataCadastro";
            DataCadastro.HeaderText = "Data Cadastro";
            DataCadastro.Name = "DataCadastro";
            DataCadastro.ReadOnly = true;
            DataCadastro.Width = 106;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnExcluir);
            groupBox3.Controls.Add(BtnAlterar);
            groupBox3.Controls.Add(BtnSalvar);
            groupBox3.Location = new System.Drawing.Point(542, 14);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(103, 115);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            // 
            // BtnExcluir
            // 
            BtnExcluir.ContextMenuStrip = CmsBtnExcluir;
            BtnExcluir.Enabled = false;
            BtnExcluir.Location = new System.Drawing.Point(7, 81);
            BtnExcluir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new System.Drawing.Size(88, 27);
            BtnExcluir.TabIndex = 2;
            BtnExcluir.Text = "&Excluir";
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // CmsBtnExcluir
            // 
            CmsBtnExcluir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { CmsExcluirTudo });
            CmsBtnExcluir.Name = "CmsBtnExcluir";
            CmsBtnExcluir.Size = new System.Drawing.Size(229, 26);
            // 
            // CmsExcluirTudo
            // 
            CmsExcluirTudo.Name = "CmsExcluirTudo";
            CmsExcluirTudo.Size = new System.Drawing.Size(228, 22);
            CmsExcluirTudo.Text = "Excluir Todos os Movimentos";
            CmsExcluirTudo.Click += CmsExcluirTudo_Click;
            // 
            // BtnAlterar
            // 
            BtnAlterar.Enabled = false;
            BtnAlterar.Location = new System.Drawing.Point(7, 47);
            BtnAlterar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnAlterar.Name = "BtnAlterar";
            BtnAlterar.Size = new System.Drawing.Size(88, 27);
            BtnAlterar.TabIndex = 1;
            BtnAlterar.Text = "&Alterar";
            BtnAlterar.UseVisualStyleBackColor = true;
            BtnAlterar.Click += BtnAlterar_Click;
            // 
            // BtnSalvar
            // 
            BtnSalvar.Location = new System.Drawing.Point(7, 14);
            BtnSalvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new System.Drawing.Size(88, 27);
            BtnSalvar.TabIndex = 0;
            BtnSalvar.Text = "&Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblDataCadastro);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(MktDataRecebido);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(CbxRecebido);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(TxtValor);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(TxtParcela);
            groupBox2.Controls.Add(MktDataParcela);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new System.Drawing.Point(14, 177);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(481, 97);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cadastro Movimentação";
            // 
            // LblDataCadastro
            // 
            LblDataCadastro.AutoSize = true;
            LblDataCadastro.Location = new System.Drawing.Point(6, 68);
            LblDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDataCadastro.Name = "LblDataCadastro";
            LblDataCadastro.Size = new System.Drawing.Size(145, 15);
            LblDataCadastro.TabIndex = 3;
            LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(358, 23);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(104, 15);
            label11.TabIndex = 9;
            label11.Text = "Data Recebimento";
            // 
            // MktDataRecebido
            // 
            MktDataRecebido.Enabled = false;
            MktDataRecebido.Location = new System.Drawing.Point(355, 42);
            MktDataRecebido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MktDataRecebido.Mask = "00/00/0000";
            MktDataRecebido.Name = "MktDataRecebido";
            MktDataRecebido.Size = new System.Drawing.Size(116, 23);
            MktDataRecebido.TabIndex = 4;
            MktDataRecebido.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(267, 24);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(56, 15);
            label7.TabIndex = 7;
            label7.Text = "Recebido";
            // 
            // CbxRecebido
            // 
            CbxRecebido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            CbxRecebido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CbxRecebido.FormattingEnabled = true;
            CbxRecebido.Items.AddRange(new object[] { "Sim", "Não" });
            CbxRecebido.Location = new System.Drawing.Point(264, 42);
            CbxRecebido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbxRecebido.Name = "CbxRecebido";
            CbxRecebido.Size = new System.Drawing.Size(83, 23);
            CbxRecebido.TabIndex = 3;
            CbxRecebido.SelectedIndexChanged += CbxPago_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(188, 25);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(33, 15);
            label6.TabIndex = 5;
            label6.Text = "Valor";
            // 
            // TxtValor
            // 
            TxtValor.Location = new System.Drawing.Point(184, 42);
            TxtValor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtValor.Name = "TxtValor";
            TxtValor.Size = new System.Drawing.Size(72, 23);
            TxtValor.TabIndex = 2;
            TxtValor.Text = "0,00";
            TxtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            TxtValor.TextChanged += TxtValor_TextChanged;
            TxtValor.Enter += TxtValor_Enter;
            TxtValor.Leave += TxtValor_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(104, 23);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(45, 15);
            label5.TabIndex = 3;
            label5.Text = "Parcela";
            // 
            // TxtParcela
            // 
            TxtParcela.Location = new System.Drawing.Point(100, 42);
            TxtParcela.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtParcela.Name = "TxtParcela";
            TxtParcela.Size = new System.Drawing.Size(76, 23);
            TxtParcela.TabIndex = 1;
            TxtParcela.Text = "1";
            TxtParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TxtParcela.TextChanged += TxtParcela_TextChanged;
            TxtParcela.Enter += TxtParcela_Enter;
            TxtParcela.Leave += TxtParcela_Leave;
            // 
            // MktDataParcela
            // 
            MktDataParcela.Location = new System.Drawing.Point(7, 42);
            MktDataParcela.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MktDataParcela.Mask = "00/00/0000";
            MktDataParcela.Name = "MktDataParcela";
            MktDataParcela.Size = new System.Drawing.Size(86, 23);
            MktDataParcela.TabIndex = 0;
            MktDataParcela.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 23);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 15);
            label2.TabIndex = 0;
            label2.Text = "Data Parcela";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(CbxNome);
            groupBox6.Controls.Add(label12);
            groupBox6.Location = new System.Drawing.Point(14, 14);
            groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox6.Size = new System.Drawing.Size(481, 74);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Cliente";
            // 
            // CbxNome
            // 
            CbxNome.DisplayMember = "Nome";
            CbxNome.FormattingEnabled = true;
            CbxNome.Location = new System.Drawing.Point(9, 37);
            CbxNome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbxNome.Name = "CbxNome";
            CbxNome.Size = new System.Drawing.Size(462, 23);
            CbxNome.TabIndex = 0;
            CbxNome.ValueMember = "Id";
            CbxNome.SelectedIndexChanged += CbxNome_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(9, 18);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(40, 15);
            label12.TabIndex = 0;
            label12.Text = "Nome";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CbxDescricao);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(14, 95);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(481, 75);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Devedor";
            // 
            // CbxDescricao
            // 
            CbxDescricao.DisplayMember = "Nome";
            CbxDescricao.FormattingEnabled = true;
            CbxDescricao.Location = new System.Drawing.Point(9, 39);
            CbxDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbxDescricao.Name = "CbxDescricao";
            CbxDescricao.Size = new System.Drawing.Size(462, 23);
            CbxDescricao.TabIndex = 0;
            CbxDescricao.ValueMember = "Id";
            CbxDescricao.SelectedIndexChanged += CbxDescricao_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 18);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // FrmCadMovimentoDevedores
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(657, 702);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox6);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCadMovimentoDevedores";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cadastro Movimento Devedores";
            FormClosing += FrmCadMovimentoDevedores_FormClosing;
            Load += FrmCadMovimentoDevedores_Load;
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvListarMovimentoDev).EndInit();
            groupBox3.ResumeLayout(false);
            CmsBtnExcluir.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblValorPagar;
        private System.Windows.Forms.Label LblValorPago;
        private System.Windows.Forms.Label LblValorTotal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DgvListarMovimentoDev;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox MktDataRecebido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbxRecebido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtParcela;
        private System.Windows.Forms.MaskedTextBox MktDataParcela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CbxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevedoresId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRecebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.ContextMenuStrip CmsBtnExcluir;
        private System.Windows.Forms.ToolStripMenuItem CmsExcluirTudo;
    }
}