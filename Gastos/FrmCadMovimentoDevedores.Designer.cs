
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblValorPagar = new System.Windows.Forms.Label();
            this.LblValorPago = new System.Windows.Forms.Label();
            this.LblValorTotal = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DgvListarMovimentoDev = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevedoresId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.CmsBtnExcluir = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmsExcluirTudo = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.LblDataCadastro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MktDataRecebido = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbxRecebido = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtParcela = new System.Windows.Forms.TextBox();
            this.MktDataParcela = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CbxNome = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbxDescricao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarMovimentoDev)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.CmsBtnExcluir.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LblValorPagar);
            this.groupBox5.Controls.Add(this.LblValorPago);
            this.groupBox5.Controls.Add(this.LblValorTotal);
            this.groupBox5.Location = new System.Drawing.Point(12, 570);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(541, 89);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informações";
            // 
            // LblValorPagar
            // 
            this.LblValorPagar.AutoSize = true;
            this.LblValorPagar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorPagar.Location = new System.Drawing.Point(6, 60);
            this.LblValorPagar.Name = "LblValorPagar";
            this.LblValorPagar.Size = new System.Drawing.Size(168, 14);
            this.LblValorPagar.TabIndex = 2;
            this.LblValorPagar.Text = "Valor a Receber..: 0,00";
            // 
            // LblValorPago
            // 
            this.LblValorPago.AutoSize = true;
            this.LblValorPago.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorPago.Location = new System.Drawing.Point(6, 38);
            this.LblValorPago.Name = "LblValorPago";
            this.LblValorPago.Size = new System.Drawing.Size(168, 14);
            this.LblValorPago.TabIndex = 1;
            this.LblValorPago.Text = "Valor Recebido...: 0,00";
            // 
            // LblValorTotal
            // 
            this.LblValorTotal.AutoSize = true;
            this.LblValorTotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorTotal.Location = new System.Drawing.Point(6, 16);
            this.LblValorTotal.Name = "LblValorTotal";
            this.LblValorTotal.Size = new System.Drawing.Size(168, 14);
            this.LblValorTotal.TabIndex = 0;
            this.LblValorTotal.Text = "Valor Total......: 0,00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DgvListarMovimentoDev);
            this.groupBox4.Location = new System.Drawing.Point(12, 308);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(541, 256);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Movimentacões cadastradas";
            // 
            // DgvListarMovimentoDev
            // 
            this.DgvListarMovimentoDev.AllowUserToAddRows = false;
            this.DgvListarMovimentoDev.AllowUserToDeleteRows = false;
            this.DgvListarMovimentoDev.AllowUserToOrderColumns = true;
            this.DgvListarMovimentoDev.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvListarMovimentoDev.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvListarMovimentoDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvListarMovimentoDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListarMovimentoDev.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DevedoresId,
            this.DataParcela,
            this.Descricao,
            this.Parcela,
            this.Valor,
            this.Recebido,
            this.DataRecebido,
            this.DataCadastro});
            this.DgvListarMovimentoDev.Location = new System.Drawing.Point(6, 19);
            this.DgvListarMovimentoDev.MultiSelect = false;
            this.DgvListarMovimentoDev.Name = "DgvListarMovimentoDev";
            this.DgvListarMovimentoDev.ReadOnly = true;
            this.DgvListarMovimentoDev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListarMovimentoDev.Size = new System.Drawing.Size(526, 231);
            this.DgvListarMovimentoDev.TabIndex = 0;
            this.DgvListarMovimentoDev.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListarMovimentoDev_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 41;
            // 
            // DevedoresId
            // 
            this.DevedoresId.DataPropertyName = "DevedoresId";
            this.DevedoresId.HeaderText = "DevedoresId";
            this.DevedoresId.Name = "DevedoresId";
            this.DevedoresId.ReadOnly = true;
            this.DevedoresId.Visible = false;
            this.DevedoresId.Width = 93;
            // 
            // DataParcela
            // 
            this.DataParcela.DataPropertyName = "DataParcela";
            this.DataParcela.HeaderText = "Data Parcela";
            this.DataParcela.Name = "DataParcela";
            this.DataParcela.ReadOnly = true;
            this.DataParcela.Width = 87;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 80;
            // 
            // Parcela
            // 
            this.Parcela.DataPropertyName = "Parcela";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.Parcela.DefaultCellStyle = dataGridViewCellStyle1;
            this.Parcela.HeaderText = "Parcela";
            this.Parcela.Name = "Parcela";
            this.Parcela.ReadOnly = true;
            this.Parcela.Width = 68;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 56;
            // 
            // Recebido
            // 
            this.Recebido.DataPropertyName = "Recebido";
            this.Recebido.HeaderText = "Recebido";
            this.Recebido.Name = "Recebido";
            this.Recebido.ReadOnly = true;
            this.Recebido.Width = 78;
            // 
            // DataRecebido
            // 
            this.DataRecebido.DataPropertyName = "DataRecebido";
            this.DataRecebido.HeaderText = "Data Recebido";
            this.DataRecebido.Name = "DataRecebido";
            this.DataRecebido.ReadOnly = true;
            this.DataRecebido.Width = 96;
            // 
            // DataCadastro
            // 
            this.DataCadastro.DataPropertyName = "DataCadastro";
            this.DataCadastro.HeaderText = "Data Cadastro";
            this.DataCadastro.Name = "DataCadastro";
            this.DataCadastro.ReadOnly = true;
            this.DataCadastro.Width = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnExcluir);
            this.groupBox3.Controls.Add(this.BtnAlterar);
            this.groupBox3.Controls.Add(this.BtnSalvar);
            this.groupBox3.Location = new System.Drawing.Point(465, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.ContextMenuStrip = this.CmsBtnExcluir;
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.Location = new System.Drawing.Point(6, 70);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 2;
            this.BtnExcluir.Text = "&Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // CmsBtnExcluir
            // 
            this.CmsBtnExcluir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsExcluirTudo});
            this.CmsBtnExcluir.Name = "CmsBtnExcluir";
            this.CmsBtnExcluir.Size = new System.Drawing.Size(229, 26);
            // 
            // CmsExcluirTudo
            // 
            this.CmsExcluirTudo.Name = "CmsExcluirTudo";
            this.CmsExcluirTudo.Size = new System.Drawing.Size(228, 22);
            this.CmsExcluirTudo.Text = "Excluir Todos os Movimentos";
            this.CmsExcluirTudo.Click += new System.EventHandler(this.CmsExcluirTudo_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Enabled = false;
            this.BtnAlterar.Location = new System.Drawing.Point(6, 41);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(75, 23);
            this.BtnAlterar.TabIndex = 1;
            this.BtnAlterar.Text = "&Alterar";
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Location = new System.Drawing.Point(6, 12);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(75, 23);
            this.BtnSalvar.TabIndex = 0;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtDescricao);
            this.groupBox2.Controls.Add(this.LblDataCadastro);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.MktDataRecebido);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CbxRecebido);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtValor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtParcela);
            this.groupBox2.Controls.Add(this.MktDataParcela);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastro Movimentação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descricão";
            // 
            // TxtDescricao
            // 
            this.TxtDescricao.Location = new System.Drawing.Point(6, 104);
            this.TxtDescricao.Name = "TxtDescricao";
            this.TxtDescricao.Size = new System.Drawing.Size(397, 20);
            this.TxtDescricao.TabIndex = 5;
            // 
            // LblDataCadastro
            // 
            this.LblDataCadastro.AutoSize = true;
            this.LblDataCadastro.Location = new System.Drawing.Point(5, 59);
            this.LblDataCadastro.Name = "LblDataCadastro";
            this.LblDataCadastro.Size = new System.Drawing.Size(139, 13);
            this.LblDataCadastro.TabIndex = 3;
            this.LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(307, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Data Recebimento";
            // 
            // MktDataRecebido
            // 
            this.MktDataRecebido.Enabled = false;
            this.MktDataRecebido.Location = new System.Drawing.Point(304, 36);
            this.MktDataRecebido.Mask = "00/00/0000";
            this.MktDataRecebido.Name = "MktDataRecebido";
            this.MktDataRecebido.Size = new System.Drawing.Size(100, 20);
            this.MktDataRecebido.TabIndex = 4;
            this.MktDataRecebido.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Recebido";
            // 
            // CbxRecebido
            // 
            this.CbxRecebido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbxRecebido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbxRecebido.FormattingEnabled = true;
            this.CbxRecebido.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.CbxRecebido.Location = new System.Drawing.Point(226, 36);
            this.CbxRecebido.Name = "CbxRecebido";
            this.CbxRecebido.Size = new System.Drawing.Size(72, 21);
            this.CbxRecebido.TabIndex = 3;
            this.CbxRecebido.SelectedIndexChanged += new System.EventHandler(this.CbxPago_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor";
            // 
            // TxtValor
            // 
            this.TxtValor.Location = new System.Drawing.Point(158, 36);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(62, 20);
            this.TxtValor.TabIndex = 2;
            this.TxtValor.Text = "0,00";
            this.TxtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValor.TextChanged += new System.EventHandler(this.TxtValor_TextChanged);
            this.TxtValor.Enter += new System.EventHandler(this.TxtValor_Enter);
            this.TxtValor.Leave += new System.EventHandler(this.TxtValor_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Parcela";
            // 
            // TxtParcela
            // 
            this.TxtParcela.Location = new System.Drawing.Point(86, 36);
            this.TxtParcela.Name = "TxtParcela";
            this.TxtParcela.Size = new System.Drawing.Size(66, 20);
            this.TxtParcela.TabIndex = 1;
            this.TxtParcela.Text = "1";
            this.TxtParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtParcela.TextChanged += new System.EventHandler(this.TxtParcela_TextChanged);
            this.TxtParcela.Enter += new System.EventHandler(this.TxtParcela_Enter);
            this.TxtParcela.Leave += new System.EventHandler(this.TxtParcela_Leave);
            // 
            // MktDataParcela
            // 
            this.MktDataParcela.Location = new System.Drawing.Point(6, 36);
            this.MktDataParcela.Mask = "00/00/0000";
            this.MktDataParcela.Name = "MktDataParcela";
            this.MktDataParcela.Size = new System.Drawing.Size(74, 20);
            this.MktDataParcela.TabIndex = 0;
            this.MktDataParcela.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Parcela";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CbxNome);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(343, 64);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cliente";
            // 
            // CbxNome
            // 
            this.CbxNome.DisplayMember = "Nome";
            this.CbxNome.FormattingEnabled = true;
            this.CbxNome.Location = new System.Drawing.Point(8, 32);
            this.CbxNome.Name = "CbxNome";
            this.CbxNome.Size = new System.Drawing.Size(327, 21);
            this.CbxNome.TabIndex = 0;
            this.CbxNome.ValueMember = "Id";
            this.CbxNome.SelectedIndexChanged += new System.EventHandler(this.CbxNome_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Nome";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbxDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devedor";
            // 
            // CbxDescricao
            // 
            this.CbxDescricao.DisplayMember = "Nome";
            this.CbxDescricao.FormattingEnabled = true;
            this.CbxDescricao.Location = new System.Drawing.Point(8, 34);
            this.CbxDescricao.Name = "CbxDescricao";
            this.CbxDescricao.Size = new System.Drawing.Size(327, 21);
            this.CbxDescricao.TabIndex = 0;
            this.CbxDescricao.ValueMember = "Id";
            this.CbxDescricao.SelectedIndexChanged += new System.EventHandler(this.CbxDescricao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // FrmCadMovimentoDevedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 668);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadMovimentoDevedores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Movimento Devedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadMovimentoDevedores_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadMovimentoDevedores_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarMovimentoDev)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.CmsBtnExcluir.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDescricao;
    }
}