
namespace Gastos
{
    partial class FrmCadDevedores
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
            groupBox4 = new System.Windows.Forms.GroupBox();
            BtnExcluir = new System.Windows.Forms.Button();
            BtnAlterar = new System.Windows.Forms.Button();
            BtnSalvar = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            DgvListaDevedores = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ClienteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            MktDataInicio = new System.Windows.Forms.MaskedTextBox();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            TxtParcelas = new System.Windows.Forms.TextBox();
            TxtValor = new System.Windows.Forms.TextBox();
            CbAtivo = new System.Windows.Forms.CheckBox();
            TxtDescricao = new System.Windows.Forms.TextBox();
            TxtNome = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            LblDataCadastro = new System.Windows.Forms.Label();
            CbxNome = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            BtnGerar = new System.Windows.Forms.Button();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaDevedores).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnExcluir);
            groupBox4.Controls.Add(BtnAlterar);
            groupBox4.Controls.Add(BtnSalvar);
            groupBox4.Location = new System.Drawing.Point(482, 10);
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
            // groupBox3
            // 
            groupBox3.Controls.Add(DgvListaDevedores);
            groupBox3.Location = new System.Drawing.Point(12, 252);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(573, 307);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Devedores cadastrados";
            // 
            // DgvListaDevedores
            // 
            DgvListaDevedores.AllowUserToAddRows = false;
            DgvListaDevedores.AllowUserToDeleteRows = false;
            DgvListaDevedores.AllowUserToOrderColumns = true;
            DgvListaDevedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DgvListaDevedores.BackgroundColor = System.Drawing.SystemColors.Control;
            DgvListaDevedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvListaDevedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaDevedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, DataInicio, Nome, Descricao, Valor, Parcelas, Ativo, Login, ClienteId, DataCadastro });
            DgvListaDevedores.Location = new System.Drawing.Point(7, 22);
            DgvListaDevedores.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvListaDevedores.MultiSelect = false;
            DgvListaDevedores.Name = "DgvListaDevedores";
            DgvListaDevedores.ReadOnly = true;
            DgvListaDevedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvListaDevedores.Size = new System.Drawing.Size(560, 279);
            DgvListaDevedores.TabIndex = 0;
            DgvListaDevedores.CellDoubleClick += DgvListaDevedores_CellDoubleClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 42;
            // 
            // DataInicio
            // 
            DataInicio.DataPropertyName = "DataInicio";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            DataInicio.DefaultCellStyle = dataGridViewCellStyle1;
            DataInicio.HeaderText = "Data Início";
            DataInicio.Name = "DataInicio";
            DataInicio.ReadOnly = true;
            DataInicio.Width = 88;
            // 
            // Nome
            // 
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            Nome.Width = 65;
            // 
            // Descricao
            // 
            Descricao.DataPropertyName = "Descricao";
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 83;
            // 
            // Valor
            // 
            Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            Valor.DefaultCellStyle = dataGridViewCellStyle2;
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            Valor.Width = 58;
            // 
            // Parcelas
            // 
            Parcelas.DataPropertyName = "Parcelas";
            Parcelas.HeaderText = "Parcelas";
            Parcelas.Name = "Parcelas";
            Parcelas.ReadOnly = true;
            Parcelas.Width = 75;
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
            DataCadastro.Width = 106;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(MktDataInicio);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(TxtParcelas);
            groupBox2.Controls.Add(TxtValor);
            groupBox2.Controls.Add(CbAtivo);
            groupBox2.Controls.Add(TxtDescricao);
            groupBox2.Controls.Add(TxtNome);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new System.Drawing.Point(12, 123);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(462, 123);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Devedor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 68);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(31, 15);
            label6.TabIndex = 7;
            label6.Text = "Data";
            // 
            // MktDataInicio
            // 
            MktDataInicio.Location = new System.Drawing.Point(7, 86);
            MktDataInicio.Mask = "00/00/0000";
            MktDataInicio.Name = "MktDataInicio";
            MktDataInicio.Size = new System.Drawing.Size(100, 23);
            MktDataInicio.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(342, 19);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(50, 15);
            label5.TabIndex = 5;
            label5.Text = "Parcelas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(279, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 15);
            label3.TabIndex = 5;
            label3.Text = "Valor";
            // 
            // TxtParcelas
            // 
            TxtParcelas.Location = new System.Drawing.Point(342, 37);
            TxtParcelas.Name = "TxtParcelas";
            TxtParcelas.Size = new System.Drawing.Size(50, 23);
            TxtParcelas.TabIndex = 4;
            TxtParcelas.Text = "1";
            TxtParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            TxtParcelas.TextChanged += TxtParcelas_TextChanged;
            TxtParcelas.Enter += TxtParcelas_Enter;
            TxtParcelas.Leave += TxtParcelas_Leave;
            // 
            // TxtValor
            // 
            TxtValor.Location = new System.Drawing.Point(279, 37);
            TxtValor.Name = "TxtValor";
            TxtValor.Size = new System.Drawing.Size(57, 23);
            TxtValor.TabIndex = 4;
            TxtValor.Text = "0,00";
            TxtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            TxtValor.TextChanged += TxtValor_TextChanged;
            TxtValor.Enter += TxtValor_Enter;
            TxtValor.Leave += TxtValor_Leave;
            // 
            // CbAtivo
            // 
            CbAtivo.AutoSize = true;
            CbAtivo.Checked = true;
            CbAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            CbAtivo.Location = new System.Drawing.Point(399, 39);
            CbAtivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbAtivo.Name = "CbAtivo";
            CbAtivo.Size = new System.Drawing.Size(54, 19);
            CbAtivo.TabIndex = 3;
            CbAtivo.Text = "Ativo";
            CbAtivo.UseVisualStyleBackColor = true;
            // 
            // TxtDescricao
            // 
            TxtDescricao.Location = new System.Drawing.Point(118, 86);
            TxtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtDescricao.MaxLength = 200;
            TxtDescricao.Name = "TxtDescricao";
            TxtDescricao.Size = new System.Drawing.Size(335, 23);
            TxtDescricao.TabIndex = 1;
            // 
            // TxtNome
            // 
            TxtNome.Location = new System.Drawing.Point(7, 37);
            TxtNome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtNome.MaxLength = 200;
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new System.Drawing.Size(265, 23);
            TxtNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(118, 67);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Descrição";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 18);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(40, 15);
            label4.TabIndex = 2;
            label4.Text = "Nome";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblDataCadastro);
            groupBox1.Controls.Add(CbxNome);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 10);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(462, 106);
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
            CbxNome.Size = new System.Drawing.Size(446, 23);
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
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnGerar);
            groupBox5.Location = new System.Drawing.Point(482, 131);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox5.Size = new System.Drawing.Size(103, 48);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            // 
            // BtnGerar
            // 
            BtnGerar.Enabled = false;
            BtnGerar.Location = new System.Drawing.Point(7, 13);
            BtnGerar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnGerar.Name = "BtnGerar";
            BtnGerar.Size = new System.Drawing.Size(88, 27);
            BtnGerar.TabIndex = 0;
            BtnGerar.Text = "&Gerar";
            BtnGerar.UseVisualStyleBackColor = true;
            BtnGerar.Click += BtnGerar_Click;
            // 
            // FrmCadDevedores
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(596, 571);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCadDevedores";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cadastro Devedores";
            FormClosing += FrmCadDevedores_FormClosing;
            Load += FrmCadDevedores_Load;
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvListaDevedores).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DgvListaDevedores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbAtivo;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtParcelas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox MktDataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BtnGerar;
    }
}