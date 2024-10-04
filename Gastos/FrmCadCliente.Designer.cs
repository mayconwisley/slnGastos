
namespace Gastos
{
    partial class FrmCadCliente
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            CbAtivo = new System.Windows.Forms.CheckBox();
            LblDataCadastro = new System.Windows.Forms.Label();
            TxtNome = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            DgvListarClientes = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox3 = new System.Windows.Forms.GroupBox();
            BtnExcluir = new System.Windows.Forms.Button();
            BtnAlterar = new System.Windows.Forms.Button();
            BtnSalvar = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListarClientes).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CbAtivo);
            groupBox1.Controls.Add(LblDataCadastro);
            groupBox1.Controls.Add(TxtNome);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(15, 12);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(365, 115);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastro Cliente";
            // 
            // CbAtivo
            // 
            CbAtivo.AutoSize = true;
            CbAtivo.Checked = true;
            CbAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            CbAtivo.Location = new System.Drawing.Point(194, 80);
            CbAtivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbAtivo.Name = "CbAtivo";
            CbAtivo.Size = new System.Drawing.Size(54, 19);
            CbAtivo.TabIndex = 1;
            CbAtivo.Text = "Ativo";
            CbAtivo.UseVisualStyleBackColor = true;
            // 
            // LblDataCadastro
            // 
            LblDataCadastro.AutoSize = true;
            LblDataCadastro.Location = new System.Drawing.Point(9, 81);
            LblDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDataCadastro.Name = "LblDataCadastro";
            LblDataCadastro.Size = new System.Drawing.Size(145, 15);
            LblDataCadastro.TabIndex = 2;
            LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // TxtNome
            // 
            TxtNome.Location = new System.Drawing.Point(13, 38);
            TxtNome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtNome.MaxLength = 200;
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new System.Drawing.Size(341, 23);
            TxtNome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvListarClientes);
            groupBox2.Location = new System.Drawing.Point(15, 134);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(476, 252);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Clientes cadastrados";
            // 
            // DgvListarClientes
            // 
            DgvListarClientes.AllowUserToAddRows = false;
            DgvListarClientes.AllowUserToDeleteRows = false;
            DgvListarClientes.AllowUserToOrderColumns = true;
            DgvListarClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            DgvListarClientes.BackgroundColor = System.Drawing.SystemColors.Control;
            DgvListarClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvListarClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListarClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, Nome, Ativo, DataCadastro, Login });
            DgvListarClientes.Location = new System.Drawing.Point(10, 15);
            DgvListarClientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvListarClientes.MultiSelect = false;
            DgvListarClientes.Name = "DgvListarClientes";
            DgvListarClientes.ReadOnly = true;
            DgvListarClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvListarClientes.Size = new System.Drawing.Size(456, 223);
            DgvListarClientes.TabIndex = 0;
            DgvListarClientes.CellDoubleClick += DgvListarClientes_CellDoubleClick;
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
            // Nome
            // 
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            Nome.Width = 65;
            // 
            // Ativo
            // 
            Ativo.DataPropertyName = "Ativo";
            Ativo.HeaderText = "Ativo";
            Ativo.Name = "Ativo";
            Ativo.ReadOnly = true;
            Ativo.Width = 60;
            // 
            // DataCadastro
            // 
            DataCadastro.DataPropertyName = "DataCadastro";
            DataCadastro.HeaderText = "Data Cadastro";
            DataCadastro.Name = "DataCadastro";
            DataCadastro.ReadOnly = true;
            DataCadastro.Width = 106;
            // 
            // Login
            // 
            Login.DataPropertyName = "Login";
            Login.HeaderText = "Login";
            Login.Name = "Login";
            Login.ReadOnly = true;
            Login.Visible = false;
            Login.Width = 58;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnExcluir);
            groupBox3.Controls.Add(BtnAlterar);
            groupBox3.Controls.Add(BtnSalvar);
            groupBox3.Location = new System.Drawing.Point(387, 12);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(104, 115);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Enabled = false;
            BtnExcluir.Location = new System.Drawing.Point(8, 78);
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
            BtnAlterar.Location = new System.Drawing.Point(8, 45);
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
            BtnSalvar.Location = new System.Drawing.Point(8, 10);
            BtnSalvar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new System.Drawing.Size(88, 27);
            BtnSalvar.TabIndex = 0;
            BtnSalvar.Text = "&Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // FrmCadCliente
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(506, 398);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCadCliente";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cadastro Cliente";
            FormClosing += FrmCadCliente_FormClosing;
            Load += FrmCadCliente_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvListarClientes).EndInit();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DgvListarClientes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.CheckBox CbAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
    }
}