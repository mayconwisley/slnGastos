
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            LblDataCadastro = new System.Windows.Forms.Label();
            CbxNome = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            CbAtivo = new System.Windows.Forms.CheckBox();
            TxtParcela = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            TxtValorParcela = new System.Windows.Forms.TextBox();
            TxtValorEmprestado = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            TxtDescricao = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            MktDataInicio = new System.Windows.Forms.MaskedTextBox();
            label3 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            DgvListaEmprestimos = new System.Windows.Forms.DataGridView();
            groupBox4 = new System.Windows.Forms.GroupBox();
            BtnExcluir = new System.Windows.Forms.Button();
            BtnAlterar = new System.Windows.Forms.Button();
            BtnSalvar = new System.Windows.Forms.Button();
            groupBox5 = new System.Windows.Forms.GroupBox();
            LblTotalGeral = new System.Windows.Forms.Label();
            LblTotalNAtivo = new System.Windows.Forms.Label();
            LblTotalAtivo = new System.Windows.Forms.Label();
            groupBox6 = new System.Windows.Forms.GroupBox();
            BtnGerar = new System.Windows.Forms.Button();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ValorEmprestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ValorParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ValorAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ClienteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaEmprestimos).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblDataCadastro);
            groupBox1.Controls.Add(CbxNome);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(14, 12);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(383, 106);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cliente";
            // 
            // LblDataCadastro
            // 
            LblDataCadastro.AutoSize = true;
            LblDataCadastro.Location = new System.Drawing.Point(4, 76);
            LblDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDataCadastro.Name = "LblDataCadastro";
            LblDataCadastro.Size = new System.Drawing.Size(145, 15);
            LblDataCadastro.TabIndex = 2;
            LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // CbxNome
            // 
            CbxNome.DisplayMember = "Nome";
            CbxNome.FormattingEnabled = true;
            CbxNome.Location = new System.Drawing.Point(7, 37);
            CbxNome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbxNome.Name = "CbxNome";
            CbxNome.Size = new System.Drawing.Size(368, 23);
            CbxNome.TabIndex = 0;
            CbxNome.ValueMember = "Id";
            CbxNome.SelectedIndexChanged += CbxNome_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 18);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(CbAtivo);
            groupBox2.Controls.Add(TxtParcela);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(TxtValorParcela);
            groupBox2.Controls.Add(TxtValorEmprestado);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(TxtDescricao);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(MktDataInicio);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new System.Drawing.Point(14, 125);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(383, 178);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cadastro Empréstimo";
            // 
            // CbAtivo
            // 
            CbAtivo.AutoSize = true;
            CbAtivo.Checked = true;
            CbAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            CbAtivo.Location = new System.Drawing.Point(10, 117);
            CbAtivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbAtivo.Name = "CbAtivo";
            CbAtivo.Size = new System.Drawing.Size(54, 19);
            CbAtivo.TabIndex = 6;
            CbAtivo.Text = "Ativo";
            CbAtivo.UseVisualStyleBackColor = true;
            // 
            // TxtParcela
            // 
            TxtParcela.Location = new System.Drawing.Point(201, 87);
            TxtParcela.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtParcela.Name = "TxtParcela";
            TxtParcela.Size = new System.Drawing.Size(59, 23);
            TxtParcela.TabIndex = 4;
            TxtParcela.Text = "1";
            TxtParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TxtParcela.TextChanged += TxtParcela_TextChanged;
            TxtParcela.Leave += TxtParcela_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(204, 68);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 15);
            label6.TabIndex = 4;
            label6.Text = "Parcelas";
            // 
            // TxtValorParcela
            // 
            TxtValorParcela.Location = new System.Drawing.Point(108, 87);
            TxtValorParcela.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtValorParcela.Name = "TxtValorParcela";
            TxtValorParcela.Size = new System.Drawing.Size(84, 23);
            TxtValorParcela.TabIndex = 3;
            TxtValorParcela.Text = "0,00";
            TxtValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            TxtValorParcela.TextChanged += TxtValorParcela_TextChanged;
            TxtValorParcela.Enter += TxtValorParcela_Enter;
            TxtValorParcela.Leave += TxtValorParcela_Leave;
            // 
            // TxtValorEmprestado
            // 
            TxtValorEmprestado.Location = new System.Drawing.Point(7, 87);
            TxtValorEmprestado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtValorEmprestado.Name = "TxtValorEmprestado";
            TxtValorEmprestado.Size = new System.Drawing.Size(94, 23);
            TxtValorEmprestado.TabIndex = 2;
            TxtValorEmprestado.Text = "0,00";
            TxtValorEmprestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            TxtValorEmprestado.TextChanged += TxtValorEmprestado_TextChanged;
            TxtValorEmprestado.Enter += TxtValorEmprestado_Enter;
            TxtValorEmprestado.Leave += TxtValorEmprestado_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(112, 68);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 15);
            label2.TabIndex = 4;
            label2.Text = "Valor Parcela";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 68);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(82, 15);
            label5.TabIndex = 4;
            label5.Text = "Valor Emprest.";
            // 
            // TxtDescricao
            // 
            TxtDescricao.Location = new System.Drawing.Point(108, 37);
            TxtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtDescricao.MaxLength = 200;
            TxtDescricao.Name = "TxtDescricao";
            TxtDescricao.Size = new System.Drawing.Size(266, 23);
            TxtDescricao.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(112, 18);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 15);
            label4.TabIndex = 2;
            label4.Text = "Descrição";
            // 
            // MktDataInicio
            // 
            MktDataInicio.Location = new System.Drawing.Point(7, 37);
            MktDataInicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MktDataInicio.Mask = "00/00/0000";
            MktDataInicio.Name = "MktDataInicio";
            MktDataInicio.Size = new System.Drawing.Size(94, 23);
            MktDataInicio.TabIndex = 0;
            MktDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 18);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 15);
            label3.TabIndex = 0;
            label3.Text = "Data Inicio";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DgvListaEmprestimos);
            groupBox3.Location = new System.Drawing.Point(14, 309);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(671, 242);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Empréstimos cadastrados";
            // 
            // DgvListaEmprestimos
            // 
            DgvListaEmprestimos.AllowUserToAddRows = false;
            DgvListaEmprestimos.AllowUserToDeleteRows = false;
            DgvListaEmprestimos.AllowUserToOrderColumns = true;
            DgvListaEmprestimos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DgvListaEmprestimos.BackgroundColor = System.Drawing.SystemColors.Control;
            DgvListaEmprestimos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvListaEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaEmprestimos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, DataInicio, Descricao, ValorEmprestado, ValorParcela, Parcelas, ValorAPagar, Ativo, Login, ClienteId, DataCadastro });
            DgvListaEmprestimos.Location = new System.Drawing.Point(7, 22);
            DgvListaEmprestimos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvListaEmprestimos.MultiSelect = false;
            DgvListaEmprestimos.Name = "DgvListaEmprestimos";
            DgvListaEmprestimos.ReadOnly = true;
            DgvListaEmprestimos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvListaEmprestimos.Size = new System.Drawing.Size(656, 213);
            DgvListaEmprestimos.TabIndex = 0;
            DgvListaEmprestimos.CellDoubleClick += DgvListaEmprestimos_CellDoubleClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnExcluir);
            groupBox4.Controls.Add(BtnAlterar);
            groupBox4.Controls.Add(BtnSalvar);
            groupBox4.Location = new System.Drawing.Point(582, 12);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Size = new System.Drawing.Size(103, 115);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Enabled = false;
            BtnExcluir.Location = new System.Drawing.Point(7, 80);
            BtnExcluir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new System.Drawing.Size(88, 27);
            BtnExcluir.TabIndex = 2;
            BtnExcluir.Text = "&Excluir";
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // BtnAlterar
            // 
            BtnAlterar.Enabled = false;
            BtnAlterar.Location = new System.Drawing.Point(7, 46);
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
            BtnSalvar.Location = new System.Drawing.Point(7, 13);
            BtnSalvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new System.Drawing.Size(88, 27);
            BtnSalvar.TabIndex = 0;
            BtnSalvar.Text = "&Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(LblTotalGeral);
            groupBox5.Controls.Add(LblTotalNAtivo);
            groupBox5.Controls.Add(LblTotalAtivo);
            groupBox5.Location = new System.Drawing.Point(404, 187);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Size = new System.Drawing.Size(281, 115);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "Informações sobre a parcela";
            // 
            // LblTotalGeral
            // 
            LblTotalGeral.AutoSize = true;
            LblTotalGeral.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblTotalGeral.Location = new System.Drawing.Point(7, 70);
            LblTotalGeral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblTotalGeral.Name = "LblTotalGeral";
            LblTotalGeral.Size = new System.Drawing.Size(140, 14);
            LblTotalGeral.TabIndex = 2;
            LblTotalGeral.Text = "Total Geral..: 0,00";
            // 
            // LblTotalNAtivo
            // 
            LblTotalNAtivo.AutoSize = true;
            LblTotalNAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblTotalNAtivo.Location = new System.Drawing.Point(7, 50);
            LblTotalNAtivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblTotalNAtivo.Name = "LblTotalNAtivo";
            LblTotalNAtivo.Size = new System.Drawing.Size(140, 14);
            LblTotalNAtivo.TabIndex = 1;
            LblTotalNAtivo.Text = "Total Ñ Ativo: 0,00";
            // 
            // LblTotalAtivo
            // 
            LblTotalAtivo.AutoSize = true;
            LblTotalAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblTotalAtivo.Location = new System.Drawing.Point(7, 28);
            LblTotalAtivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblTotalAtivo.Name = "LblTotalAtivo";
            LblTotalAtivo.Size = new System.Drawing.Size(140, 14);
            LblTotalAtivo.TabIndex = 0;
            LblTotalAtivo.Text = "Total Ativo..: 0,00";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(BtnGerar);
            groupBox6.Location = new System.Drawing.Point(581, 134);
            groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox6.Size = new System.Drawing.Size(104, 51);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            // 
            // BtnGerar
            // 
            BtnGerar.Enabled = false;
            BtnGerar.Location = new System.Drawing.Point(8, 17);
            BtnGerar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnGerar.Name = "BtnGerar";
            BtnGerar.Size = new System.Drawing.Size(88, 27);
            BtnGerar.TabIndex = 0;
            BtnGerar.Text = "Gerar Mov.";
            BtnGerar.UseVisualStyleBackColor = true;
            BtnGerar.Click += BtnGerar_Click;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 42;
            // 
            // DataInicio
            // 
            DataInicio.DataPropertyName = "DataInicio";
            DataInicio.HeaderText = "Data Inicio";
            DataInicio.Name = "DataInicio";
            DataInicio.ReadOnly = true;
            DataInicio.Width = 88;
            // 
            // Descricao
            // 
            Descricao.DataPropertyName = "Descricao";
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 83;
            // 
            // ValorEmprestado
            // 
            ValorEmprestado.DataPropertyName = "ValorEmprestado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            ValorEmprestado.DefaultCellStyle = dataGridViewCellStyle1;
            ValorEmprestado.HeaderText = "Valor Emprestado";
            ValorEmprestado.Name = "ValorEmprestado";
            ValorEmprestado.ReadOnly = true;
            ValorEmprestado.Width = 114;
            // 
            // ValorParcela
            // 
            ValorParcela.DataPropertyName = "ValorParcela";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            ValorParcela.DefaultCellStyle = dataGridViewCellStyle2;
            ValorParcela.HeaderText = "Valor Parcela";
            ValorParcela.Name = "ValorParcela";
            ValorParcela.ReadOnly = true;
            ValorParcela.Width = 91;
            // 
            // Parcelas
            // 
            Parcelas.DataPropertyName = "Parcelas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            Parcelas.DefaultCellStyle = dataGridViewCellStyle3;
            Parcelas.HeaderText = "Parcelas";
            Parcelas.Name = "Parcelas";
            Parcelas.ReadOnly = true;
            Parcelas.Width = 75;
            // 
            // ValorAPagar
            // 
            ValorAPagar.DataPropertyName = "ValorAPagar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            ValorAPagar.DefaultCellStyle = dataGridViewCellStyle4;
            ValorAPagar.HeaderText = "Valor a Pagar";
            ValorAPagar.Name = "ValorAPagar";
            ValorAPagar.ReadOnly = true;
            ValorAPagar.Width = 92;
            // 
            // Ativo
            // 
            Ativo.DataPropertyName = "Ativo";
            Ativo.HeaderText = "Ativo";
            Ativo.Name = "Ativo";
            Ativo.ReadOnly = true;
            Ativo.Width = 60;
            // 
            // Login
            // 
            Login.DataPropertyName = "Login";
            Login.HeaderText = "Login";
            Login.Name = "Login";
            Login.ReadOnly = true;
            Login.Visible = false;
            Login.Width = 62;
            // 
            // ClienteId
            // 
            ClienteId.DataPropertyName = "ClienteId";
            ClienteId.HeaderText = "ClienteId";
            ClienteId.Name = "ClienteId";
            ClienteId.ReadOnly = true;
            ClienteId.Visible = false;
            ClienteId.Width = 79;
            // 
            // DataCadastro
            // 
            DataCadastro.DataPropertyName = "DataCadastro";
            DataCadastro.HeaderText = "Data Cadastro";
            DataCadastro.Name = "DataCadastro";
            DataCadastro.ReadOnly = true;
            DataCadastro.Width = 97;
            // 
            // FrmCadEmprestimo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(699, 564);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCadEmprestimo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cadastro Empréstimo";
            FormClosing += FrmCadEmprestimo_FormClosing;
            Load += FrmCadEmprestimo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvListaEmprestimos).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtnGerar;
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
    }
}