
namespace Gastos
{
    partial class FrmCadFixos
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            LblDataCadastro = new System.Windows.Forms.Label();
            CbxCliente = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            TxtValor = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            TxtDescricao = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            MktDataFim = new System.Windows.Forms.MaskedTextBox();
            MktDataInicio = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            DgvListarFixos = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ClienteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox3 = new System.Windows.Forms.GroupBox();
            BtnExcluir = new System.Windows.Forms.Button();
            BtnAlterar = new System.Windows.Forms.Button();
            BtnSalvar = new System.Windows.Forms.Button();
            groupBox4 = new System.Windows.Forms.GroupBox();
            LblTotalGeral = new System.Windows.Forms.Label();
            LblTotalNAtivo = new System.Windows.Forms.Label();
            LblTotalAtivo = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListarFixos).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblDataCadastro);
            groupBox1.Controls.Add(CbxCliente);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(TxtValor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TxtDescricao);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(MktDataFim);
            groupBox1.Controls.Add(MktDataInicio);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(14, 14);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(424, 208);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastro Fixo";
            // 
            // LblDataCadastro
            // 
            LblDataCadastro.AutoSize = true;
            LblDataCadastro.Location = new System.Drawing.Point(7, 180);
            LblDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblDataCadastro.Name = "LblDataCadastro";
            LblDataCadastro.Size = new System.Drawing.Size(145, 15);
            LblDataCadastro.TabIndex = 10;
            LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // CbxCliente
            // 
            CbxCliente.DisplayMember = "Nome";
            CbxCliente.FormattingEnabled = true;
            CbxCliente.Location = new System.Drawing.Point(10, 37);
            CbxCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CbxCliente.Name = "CbxCliente";
            CbxCliente.Size = new System.Drawing.Size(403, 23);
            CbxCliente.TabIndex = 1;
            CbxCliente.ValueMember = "Id";
            CbxCliente.SelectedIndexChanged += CbxCliente_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 18);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 15);
            label5.TabIndex = 0;
            label5.Text = "Cliente";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(217, 109);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 15);
            label4.TabIndex = 8;
            label4.Text = "Data Fim";
            // 
            // TxtValor
            // 
            TxtValor.Location = new System.Drawing.Point(115, 127);
            TxtValor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtValor.Name = "TxtValor";
            TxtValor.Size = new System.Drawing.Size(97, 23);
            TxtValor.TabIndex = 7;
            TxtValor.Text = "0,00";
            TxtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            TxtValor.TextChanged += TxtValor_TextChanged;
            TxtValor.Enter += TxtValor_Enter;
            TxtValor.Leave += TxtValor_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(112, 109);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 15);
            label3.TabIndex = 6;
            label3.Text = "Valor";
            // 
            // TxtDescricao
            // 
            TxtDescricao.Location = new System.Drawing.Point(10, 83);
            TxtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TxtDescricao.MaxLength = 200;
            TxtDescricao.Name = "TxtDescricao";
            TxtDescricao.Size = new System.Drawing.Size(403, 23);
            TxtDescricao.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 63);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Descrição";
            // 
            // MktDataFim
            // 
            MktDataFim.Location = new System.Drawing.Point(220, 127);
            MktDataFim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MktDataFim.Mask = "00/00/0000";
            MktDataFim.Name = "MktDataFim";
            MktDataFim.Size = new System.Drawing.Size(97, 23);
            MktDataFim.TabIndex = 9;
            MktDataFim.ValidatingType = typeof(System.DateTime);
            // 
            // MktDataInicio
            // 
            MktDataInicio.Location = new System.Drawing.Point(10, 127);
            MktDataInicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MktDataInicio.Mask = "00/00/0000";
            MktDataInicio.Name = "MktDataInicio";
            MktDataInicio.Size = new System.Drawing.Size(97, 23);
            MktDataInicio.TabIndex = 5;
            MktDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 109);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 15);
            label1.TabIndex = 4;
            label1.Text = "Data Inicio";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvListarFixos);
            groupBox2.Location = new System.Drawing.Point(14, 228);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(702, 331);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Valores fixos cadastrados";
            // 
            // DgvListarFixos
            // 
            DgvListarFixos.AllowUserToAddRows = false;
            DgvListarFixos.AllowUserToDeleteRows = false;
            DgvListarFixos.AllowUserToOrderColumns = true;
            DgvListarFixos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DgvListarFixos.BackgroundColor = System.Drawing.SystemColors.Control;
            DgvListarFixos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvListarFixos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListarFixos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, DataInicio, Descricao, Valor, DataFim, Ativo, DataCadastro, Login, ClienteId });
            DgvListarFixos.Location = new System.Drawing.Point(10, 22);
            DgvListarFixos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvListarFixos.MultiSelect = false;
            DgvListarFixos.Name = "DgvListarFixos";
            DgvListarFixos.ReadOnly = true;
            DgvListarFixos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvListarFixos.Size = new System.Drawing.Size(685, 300);
            DgvListarFixos.TabIndex = 0;
            DgvListarFixos.CellDoubleClick += DgvListarFixos_CellDoubleClick;
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
            // Valor
            // 
            Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            Valor.DefaultCellStyle = dataGridViewCellStyle1;
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            Valor.Width = 58;
            // 
            // DataFim
            // 
            DataFim.DataPropertyName = "DataFim";
            DataFim.HeaderText = "Data Fim";
            DataFim.Name = "DataFim";
            DataFim.ReadOnly = true;
            DataFim.Width = 79;
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
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnExcluir);
            groupBox3.Controls.Add(BtnAlterar);
            groupBox3.Controls.Add(BtnSalvar);
            groupBox3.Location = new System.Drawing.Point(611, 14);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(105, 111);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
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
            // groupBox4
            // 
            groupBox4.Controls.Add(LblTotalGeral);
            groupBox4.Controls.Add(LblTotalNAtivo);
            groupBox4.Controls.Add(LblTotalAtivo);
            groupBox4.Location = new System.Drawing.Point(444, 135);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Size = new System.Drawing.Size(272, 87);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Informações";
            // 
            // LblTotalGeral
            // 
            LblTotalGeral.AutoSize = true;
            LblTotalGeral.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblTotalGeral.Location = new System.Drawing.Point(7, 60);
            LblTotalGeral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblTotalGeral.Name = "LblTotalGeral";
            LblTotalGeral.Size = new System.Drawing.Size(126, 14);
            LblTotalGeral.TabIndex = 2;
            LblTotalGeral.Text = "Total Geral: 0,00";
            // 
            // LblTotalNAtivo
            // 
            LblTotalNAtivo.AutoSize = true;
            LblTotalNAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblTotalNAtivo.Location = new System.Drawing.Point(7, 42);
            LblTotalNAtivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblTotalNAtivo.Name = "LblTotalNAtivo";
            LblTotalNAtivo.Size = new System.Drawing.Size(147, 14);
            LblTotalNAtivo.TabIndex = 1;
            LblTotalNAtivo.Text = "Total Ñ Ativo.: 0,00";
            // 
            // LblTotalAtivo
            // 
            LblTotalAtivo.AutoSize = true;
            LblTotalAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LblTotalAtivo.Location = new System.Drawing.Point(7, 22);
            LblTotalAtivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LblTotalAtivo.Name = "LblTotalAtivo";
            LblTotalAtivo.Size = new System.Drawing.Size(126, 14);
            LblTotalAtivo.TabIndex = 0;
            LblTotalAtivo.Text = "Total Ativo: 0,00";
            // 
            // FrmCadFixos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(730, 572);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCadFixos";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cadastro Valores Fixos";
            FormClosing += FrmCadFixos_FormClosing;
            Load += FrmCadFixos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvListarFixos).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox MktDataInicio;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox MktDataFim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.ComboBox CbxCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DgvListarFixos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblTotalGeral;
        private System.Windows.Forms.Label LblTotalNAtivo;
        private System.Windows.Forms.Label LblTotalAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteId;
    }
}