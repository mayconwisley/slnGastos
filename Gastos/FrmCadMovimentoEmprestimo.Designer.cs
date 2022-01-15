
namespace Gastos
{
    partial class FrmCadMovimentoEmprestimo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblValorPagar = new System.Windows.Forms.Label();
            this.LblValorPago = new System.Windows.Forms.Label();
            this.LblValorTotal = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DgvListarMovimentoEmp = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmprestimosId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.CmsBtnExcluir = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmsExcluirTudo = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblDataCadastro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MktDataPagamento = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbxPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtParcela = new System.Windows.Forms.TextBox();
            this.MktDataParcela = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbxDescricao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CbxNome = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.BtnQuitar = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarMovimentoEmp)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.CmsBtnExcluir.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LblValorPagar);
            this.groupBox5.Controls.Add(this.LblValorPago);
            this.groupBox5.Controls.Add(this.LblValorTotal);
            this.groupBox5.Location = new System.Drawing.Point(10, 503);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(541, 89);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informações";
            // 
            // LblValorPagar
            // 
            this.LblValorPagar.AutoSize = true;
            this.LblValorPagar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorPagar.Location = new System.Drawing.Point(6, 60);
            this.LblValorPagar.Name = "LblValorPagar";
            this.LblValorPagar.Size = new System.Drawing.Size(140, 14);
            this.LblValorPagar.TabIndex = 2;
            this.LblValorPagar.Text = "Valor a pagar: 0,00";
            // 
            // LblValorPago
            // 
            this.LblValorPago.AutoSize = true;
            this.LblValorPago.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorPago.Location = new System.Drawing.Point(6, 38);
            this.LblValorPago.Name = "LblValorPago";
            this.LblValorPago.Size = new System.Drawing.Size(140, 14);
            this.LblValorPago.TabIndex = 1;
            this.LblValorPago.Text = "Valor Pago...: 0,00";
            // 
            // LblValorTotal
            // 
            this.LblValorTotal.AutoSize = true;
            this.LblValorTotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorTotal.Location = new System.Drawing.Point(6, 16);
            this.LblValorTotal.Name = "LblValorTotal";
            this.LblValorTotal.Size = new System.Drawing.Size(140, 14);
            this.LblValorTotal.TabIndex = 0;
            this.LblValorTotal.Text = "Valor Total..: 0,00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DgvListarMovimentoEmp);
            this.groupBox4.Location = new System.Drawing.Point(10, 241);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(541, 256);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Movimentacões cadastradas";
            // 
            // DgvListarMovimentoEmp
            // 
            this.DgvListarMovimentoEmp.AllowUserToAddRows = false;
            this.DgvListarMovimentoEmp.AllowUserToDeleteRows = false;
            this.DgvListarMovimentoEmp.AllowUserToOrderColumns = true;
            this.DgvListarMovimentoEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvListarMovimentoEmp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvListarMovimentoEmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvListarMovimentoEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListarMovimentoEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.EmprestimosId,
            this.DataParcela,
            this.Parcela,
            this.Valor,
            this.Pago,
            this.Integrado,
            this.DataPagamento,
            this.DataCadastro});
            this.DgvListarMovimentoEmp.Location = new System.Drawing.Point(6, 19);
            this.DgvListarMovimentoEmp.MultiSelect = false;
            this.DgvListarMovimentoEmp.Name = "DgvListarMovimentoEmp";
            this.DgvListarMovimentoEmp.ReadOnly = true;
            this.DgvListarMovimentoEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListarMovimentoEmp.Size = new System.Drawing.Size(526, 231);
            this.DgvListarMovimentoEmp.TabIndex = 0;
            this.DgvListarMovimentoEmp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListarMovimentoEmp_CellDoubleClick);
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
            // EmprestimosId
            // 
            this.EmprestimosId.DataPropertyName = "EmprestimosId";
            this.EmprestimosId.HeaderText = "EmprestimosId";
            this.EmprestimosId.Name = "EmprestimosId";
            this.EmprestimosId.ReadOnly = true;
            this.EmprestimosId.Visible = false;
            // 
            // DataParcela
            // 
            this.DataParcela.DataPropertyName = "DataParcela";
            this.DataParcela.HeaderText = "Data Parcela";
            this.DataParcela.Name = "DataParcela";
            this.DataParcela.ReadOnly = true;
            this.DataParcela.Width = 87;
            // 
            // Parcela
            // 
            this.Parcela.DataPropertyName = "Parcela";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.Parcela.DefaultCellStyle = dataGridViewCellStyle5;
            this.Parcela.HeaderText = "Parcela";
            this.Parcela.Name = "Parcela";
            this.Parcela.ReadOnly = true;
            this.Parcela.Width = 68;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle6;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 56;
            // 
            // Pago
            // 
            this.Pago.DataPropertyName = "Pago";
            this.Pago.HeaderText = "Pago";
            this.Pago.Name = "Pago";
            this.Pago.ReadOnly = true;
            this.Pago.Width = 57;
            // 
            // Integrado
            // 
            this.Integrado.DataPropertyName = "Integrado";
            this.Integrado.HeaderText = "Integrado";
            this.Integrado.Name = "Integrado";
            this.Integrado.ReadOnly = true;
            this.Integrado.Width = 77;
            // 
            // DataPagamento
            // 
            this.DataPagamento.DataPropertyName = "DataPagamento";
            this.DataPagamento.HeaderText = "Data Pagamento";
            this.DataPagamento.Name = "DataPagamento";
            this.DataPagamento.ReadOnly = true;
            this.DataPagamento.Width = 103;
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
            this.groupBox3.Location = new System.Drawing.Point(463, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 100);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.ContextMenuStrip = this.CmsBtnExcluir;
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.Location = new System.Drawing.Point(6, 70);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 0;
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
            this.BtnAlterar.TabIndex = 0;
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
            this.groupBox2.Controls.Add(this.LblDataCadastro);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.MktDataPagamento);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CbxPago);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtValor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtParcela);
            this.groupBox2.Controls.Add(this.MktDataParcela);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(10, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastro Movimentação";
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
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Data Pagamento";
            // 
            // MktDataPagamento
            // 
            this.MktDataPagamento.Location = new System.Drawing.Point(304, 36);
            this.MktDataPagamento.Mask = "00/00/0000";
            this.MktDataPagamento.Name = "MktDataPagamento";
            this.MktDataPagamento.Size = new System.Drawing.Size(100, 20);
            this.MktDataPagamento.TabIndex = 8;
            this.MktDataPagamento.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Pago";
            // 
            // CbxPago
            // 
            this.CbxPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbxPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbxPago.FormattingEnabled = true;
            this.CbxPago.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.CbxPago.Location = new System.Drawing.Point(226, 36);
            this.CbxPago.Name = "CbxPago";
            this.CbxPago.Size = new System.Drawing.Size(72, 21);
            this.CbxPago.TabIndex = 6;
            this.CbxPago.SelectedIndexChanged += new System.EventHandler(this.CbxPago_SelectedIndexChanged);
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
            this.TxtValor.TabIndex = 4;
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
            this.TxtParcela.TabIndex = 2;
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
            this.MktDataParcela.TabIndex = 1;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbxDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 65);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empréstimo";
            // 
            // CbxDescricao
            // 
            this.CbxDescricao.DisplayMember = "Nome";
            this.CbxDescricao.FormattingEnabled = true;
            this.CbxDescricao.Location = new System.Drawing.Point(8, 34);
            this.CbxDescricao.Name = "CbxDescricao";
            this.CbxDescricao.Size = new System.Drawing.Size(327, 21);
            this.CbxDescricao.TabIndex = 1;
            this.CbxDescricao.ValueMember = "Id";
            this.CbxDescricao.SelectedIndexChanged += new System.EventHandler(this.CbxDescrocao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CbxNome);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(10, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(343, 64);
            this.groupBox6.TabIndex = 5;
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
            this.CbxNome.TabIndex = 1;
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.BtnQuitar);
            this.groupBox7.Location = new System.Drawing.Point(463, 116);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(88, 52);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Location = new System.Drawing.Point(7, 15);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(75, 23);
            this.BtnQuitar.TabIndex = 0;
            this.BtnQuitar.Text = "Quitar";
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // FrmCadMovimentoEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 605);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadMovimentoEmprestimo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Movimentação Empréstimo";
            this.Load += new System.EventHandler(this.FrmCadMovimentoEmprestimo_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarMovimentoEmp)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.CmsBtnExcluir.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblValorPagar;
        private System.Windows.Forms.Label LblValorPago;
        private System.Windows.Forms.Label LblValorTotal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DgvListarMovimentoEmp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbxPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtParcela;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.ComboBox CbxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MktDataParcela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox MktDataPagamento;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip CmsBtnExcluir;
        private System.Windows.Forms.ToolStripMenuItem CmsExcluirTudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmprestimosId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button BtnQuitar;
    }
}