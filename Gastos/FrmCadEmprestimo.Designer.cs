
namespace Gastos
{
    partial class FrmCadEmprestimo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblDataCadastro = new System.Windows.Forms.Label();
            this.CbxNome = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CbAtivo = new System.Windows.Forms.CheckBox();
            this.TxtParcela = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtValorParcela = new System.Windows.Forms.TextBox();
            this.TxtValorEmprestado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MktDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DgvListaEmprestimos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorEmprestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblTotalGeral = new System.Windows.Forms.Label();
            this.LblTotalNAtivo = new System.Windows.Forms.Label();
            this.LblTotalAtivo = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BtnGerar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaEmprestimos)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblDataCadastro);
            this.groupBox1.Controls.Add(this.CbxNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // LblDataCadastro
            // 
            this.LblDataCadastro.AutoSize = true;
            this.LblDataCadastro.Location = new System.Drawing.Point(3, 66);
            this.LblDataCadastro.Name = "LblDataCadastro";
            this.LblDataCadastro.Size = new System.Drawing.Size(139, 13);
            this.LblDataCadastro.TabIndex = 2;
            this.LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // CbxNome
            // 
            this.CbxNome.DisplayMember = "Nome";
            this.CbxNome.FormattingEnabled = true;
            this.CbxNome.Location = new System.Drawing.Point(6, 32);
            this.CbxNome.Name = "CbxNome";
            this.CbxNome.Size = new System.Drawing.Size(316, 21);
            this.CbxNome.TabIndex = 0;
            this.CbxNome.ValueMember = "Id";
            this.CbxNome.SelectedIndexChanged += new System.EventHandler(this.CbxNome_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CbAtivo);
            this.groupBox2.Controls.Add(this.TxtParcela);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtValorParcela);
            this.groupBox2.Controls.Add(this.TxtValorEmprestado);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtDescricao);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.MktDataInicio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 154);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastro Empréstimo";
            // 
            // CbAtivo
            // 
            this.CbAtivo.AutoSize = true;
            this.CbAtivo.Checked = true;
            this.CbAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbAtivo.Location = new System.Drawing.Point(272, 122);
            this.CbAtivo.Name = "CbAtivo";
            this.CbAtivo.Size = new System.Drawing.Size(50, 17);
            this.CbAtivo.TabIndex = 5;
            this.CbAtivo.Text = "Ativo";
            this.CbAtivo.UseVisualStyleBackColor = true;
            // 
            // TxtParcela
            // 
            this.TxtParcela.Location = new System.Drawing.Point(180, 120);
            this.TxtParcela.Name = "TxtParcela";
            this.TxtParcela.Size = new System.Drawing.Size(66, 20);
            this.TxtParcela.TabIndex = 4;
            this.TxtParcela.Text = "1";
            this.TxtParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtParcela.TextChanged += new System.EventHandler(this.TxtParcela_TextChanged);
            this.TxtParcela.Leave += new System.EventHandler(this.TxtParcela_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Parcelas";
            // 
            // TxtValorParcela
            // 
            this.TxtValorParcela.Location = new System.Drawing.Point(93, 120);
            this.TxtValorParcela.Name = "TxtValorParcela";
            this.TxtValorParcela.Size = new System.Drawing.Size(81, 20);
            this.TxtValorParcela.TabIndex = 3;
            this.TxtValorParcela.Text = "0,00";
            this.TxtValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValorParcela.TextChanged += new System.EventHandler(this.TxtValorParcela_TextChanged);
            this.TxtValorParcela.Enter += new System.EventHandler(this.TxtValorParcela_Enter);
            this.TxtValorParcela.Leave += new System.EventHandler(this.TxtValorParcela_Leave);
            // 
            // TxtValorEmprestado
            // 
            this.TxtValorEmprestado.Location = new System.Drawing.Point(6, 120);
            this.TxtValorEmprestado.Name = "TxtValorEmprestado";
            this.TxtValorEmprestado.Size = new System.Drawing.Size(81, 20);
            this.TxtValorEmprestado.TabIndex = 2;
            this.TxtValorEmprestado.Text = "0,00";
            this.TxtValorEmprestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValorEmprestado.TextChanged += new System.EventHandler(this.TxtValorEmprestado_TextChanged);
            this.TxtValorEmprestado.Enter += new System.EventHandler(this.TxtValorEmprestado_Enter);
            this.TxtValorEmprestado.Leave += new System.EventHandler(this.TxtValorEmprestado_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor Parcela";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor Emprest.";
            // 
            // TxtDescricao
            // 
            this.TxtDescricao.Location = new System.Drawing.Point(6, 71);
            this.TxtDescricao.MaxLength = 200;
            this.TxtDescricao.Name = "TxtDescricao";
            this.TxtDescricao.Size = new System.Drawing.Size(316, 20);
            this.TxtDescricao.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Descrição";
            // 
            // MktDataInicio
            // 
            this.MktDataInicio.Location = new System.Drawing.Point(6, 32);
            this.MktDataInicio.Mask = "00/00/0000";
            this.MktDataInicio.Name = "MktDataInicio";
            this.MktDataInicio.Size = new System.Drawing.Size(81, 20);
            this.MktDataInicio.TabIndex = 0;
            this.MktDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data Inicio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DgvListaEmprestimos);
            this.groupBox3.Location = new System.Drawing.Point(12, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 210);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Empréstimos cadastrados";
            // 
            // DgvListaEmprestimos
            // 
            this.DgvListaEmprestimos.AllowUserToAddRows = false;
            this.DgvListaEmprestimos.AllowUserToDeleteRows = false;
            this.DgvListaEmprestimos.AllowUserToOrderColumns = true;
            this.DgvListaEmprestimos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvListaEmprestimos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvListaEmprestimos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvListaEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaEmprestimos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DataInicio,
            this.Descricao,
            this.ValorEmprestado,
            this.ValorParcela,
            this.Parcelas,
            this.ValorAPagar,
            this.Ativo,
            this.Login,
            this.ClienteId,
            this.DataCadastro});
            this.DgvListaEmprestimos.Location = new System.Drawing.Point(6, 19);
            this.DgvListaEmprestimos.MultiSelect = false;
            this.DgvListaEmprestimos.Name = "DgvListaEmprestimos";
            this.DgvListaEmprestimos.ReadOnly = true;
            this.DgvListaEmprestimos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaEmprestimos.Size = new System.Drawing.Size(562, 185);
            this.DgvListaEmprestimos.TabIndex = 0;
            this.DgvListaEmprestimos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaEmprestimos_CellDoubleClick);
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
            // DataInicio
            // 
            this.DataInicio.DataPropertyName = "DataInicio";
            this.DataInicio.HeaderText = "Data Inicio";
            this.DataInicio.Name = "DataInicio";
            this.DataInicio.ReadOnly = true;
            this.DataInicio.Width = 77;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 80;
            // 
            // ValorEmprestado
            // 
            this.ValorEmprestado.DataPropertyName = "ValorEmprestado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.ValorEmprestado.DefaultCellStyle = dataGridViewCellStyle1;
            this.ValorEmprestado.HeaderText = "Valor Emprestado";
            this.ValorEmprestado.Name = "ValorEmprestado";
            this.ValorEmprestado.ReadOnly = true;
            this.ValorEmprestado.Width = 105;
            // 
            // ValorParcela
            // 
            this.ValorParcela.DataPropertyName = "ValorParcela";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.ValorParcela.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValorParcela.HeaderText = "Valor Parcela";
            this.ValorParcela.Name = "ValorParcela";
            this.ValorParcela.ReadOnly = true;
            this.ValorParcela.Width = 87;
            // 
            // Parcelas
            // 
            this.Parcelas.DataPropertyName = "Parcelas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Parcelas.DefaultCellStyle = dataGridViewCellStyle3;
            this.Parcelas.HeaderText = "Parcelas";
            this.Parcelas.Name = "Parcelas";
            this.Parcelas.ReadOnly = true;
            this.Parcelas.Width = 73;
            // 
            // ValorAPagar
            // 
            this.ValorAPagar.DataPropertyName = "ValorAPagar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.ValorAPagar.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorAPagar.HeaderText = "Valor a Pagar";
            this.ValorAPagar.Name = "ValorAPagar";
            this.ValorAPagar.ReadOnly = true;
            this.ValorAPagar.Width = 88;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 56;
            // 
            // Login
            // 
            this.Login.DataPropertyName = "Login";
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Visible = false;
            this.Login.Width = 58;
            // 
            // ClienteId
            // 
            this.ClienteId.DataPropertyName = "ClienteId";
            this.ClienteId.HeaderText = "ClienteId";
            this.ClienteId.Name = "ClienteId";
            this.ClienteId.ReadOnly = true;
            this.ClienteId.Visible = false;
            this.ClienteId.Width = 73;
            // 
            // DataCadastro
            // 
            this.DataCadastro.DataPropertyName = "DataCadastro";
            this.DataCadastro.HeaderText = "Data Cadastro";
            this.DataCadastro.Name = "DataCadastro";
            this.DataCadastro.ReadOnly = true;
            this.DataCadastro.Width = 92;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnExcluir);
            this.groupBox4.Controls.Add(this.BtnAlterar);
            this.groupBox4.Controls.Add(this.BtnSalvar);
            this.groupBox4.Location = new System.Drawing.Point(499, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(88, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.Location = new System.Drawing.Point(6, 69);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 2;
            this.BtnExcluir.Text = "&Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Enabled = false;
            this.BtnAlterar.Location = new System.Drawing.Point(6, 40);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(75, 23);
            this.BtnAlterar.TabIndex = 1;
            this.BtnAlterar.Text = "&Alterar";
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Location = new System.Drawing.Point(6, 11);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(75, 23);
            this.BtnSalvar.TabIndex = 0;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LblTotalGeral);
            this.groupBox5.Controls.Add(this.LblTotalNAtivo);
            this.groupBox5.Controls.Add(this.LblTotalAtivo);
            this.groupBox5.Location = new System.Drawing.Point(346, 162);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informações sobre a parcela";
            // 
            // LblTotalGeral
            // 
            this.LblTotalGeral.AutoSize = true;
            this.LblTotalGeral.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalGeral.Location = new System.Drawing.Point(6, 61);
            this.LblTotalGeral.Name = "LblTotalGeral";
            this.LblTotalGeral.Size = new System.Drawing.Size(140, 14);
            this.LblTotalGeral.TabIndex = 2;
            this.LblTotalGeral.Text = "Total Geral..: 0,00";
            // 
            // LblTotalNAtivo
            // 
            this.LblTotalNAtivo.AutoSize = true;
            this.LblTotalNAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalNAtivo.Location = new System.Drawing.Point(6, 43);
            this.LblTotalNAtivo.Name = "LblTotalNAtivo";
            this.LblTotalNAtivo.Size = new System.Drawing.Size(140, 14);
            this.LblTotalNAtivo.TabIndex = 1;
            this.LblTotalNAtivo.Text = "Total Ñ Ativo: 0,00";
            // 
            // LblTotalAtivo
            // 
            this.LblTotalAtivo.AutoSize = true;
            this.LblTotalAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalAtivo.Location = new System.Drawing.Point(6, 24);
            this.LblTotalAtivo.Name = "LblTotalAtivo";
            this.LblTotalAtivo.Size = new System.Drawing.Size(140, 14);
            this.LblTotalAtivo.TabIndex = 0;
            this.LblTotalAtivo.Text = "Total Ativo..: 0,00";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BtnGerar);
            this.groupBox6.Location = new System.Drawing.Point(492, 116);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(95, 44);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Movimentação";
            // 
            // BtnGerar
            // 
            this.BtnGerar.Enabled = false;
            this.BtnGerar.Location = new System.Drawing.Point(10, 15);
            this.BtnGerar.Name = "BtnGerar";
            this.BtnGerar.Size = new System.Drawing.Size(75, 23);
            this.BtnGerar.TabIndex = 0;
            this.BtnGerar.Text = "&Gerar";
            this.BtnGerar.UseVisualStyleBackColor = true;
            this.BtnGerar.Click += new System.EventHandler(this.BtnGerar_Click);
            // 
            // FrmCadEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 489);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadEmprestimo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Empréstimo";
            this.Load += new System.EventHandler(this.FrmCadEmprestimo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaEmprestimos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox MktDataInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtValorEmprestado;
        private System.Windows.Forms.TextBox TxtParcela;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CbAtivo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DgvListaEmprestimos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblTotalGeral;
        private System.Windows.Forms.Label LblTotalNAtivo;
        private System.Windows.Forms.Label LblTotalAtivo;
        private System.Windows.Forms.TextBox TxtValorParcela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorEmprestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtnGerar;
    }
}