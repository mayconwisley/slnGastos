
namespace Gastos
{
    partial class FrmConEmprestimo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblTotalGeral = new System.Windows.Forms.Label();
            this.LblTotalNAtivo = new System.Windows.Forms.Label();
            this.LblTotalAtivo = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbxNome = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaEmprestimos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LblTotalGeral);
            this.groupBox5.Controls.Add(this.LblTotalNAtivo);
            this.groupBox5.Controls.Add(this.LblTotalAtivo);
            this.groupBox5.Location = new System.Drawing.Point(346, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 74);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informações sobre a parcela";
            // 
            // LblTotalGeral
            // 
            this.LblTotalGeral.AutoSize = true;
            this.LblTotalGeral.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalGeral.Location = new System.Drawing.Point(6, 49);
            this.LblTotalGeral.Name = "LblTotalGeral";
            this.LblTotalGeral.Size = new System.Drawing.Size(140, 14);
            this.LblTotalGeral.TabIndex = 2;
            this.LblTotalGeral.Text = "Total Geral..: 0,00";
            // 
            // LblTotalNAtivo
            // 
            this.LblTotalNAtivo.AutoSize = true;
            this.LblTotalNAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalNAtivo.Location = new System.Drawing.Point(6, 34);
            this.LblTotalNAtivo.Name = "LblTotalNAtivo";
            this.LblTotalNAtivo.Size = new System.Drawing.Size(140, 14);
            this.LblTotalNAtivo.TabIndex = 1;
            this.LblTotalNAtivo.Text = "Total Ñ Ativo: 0,00";
            // 
            // LblTotalAtivo
            // 
            this.LblTotalAtivo.AutoSize = true;
            this.LblTotalAtivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalAtivo.Location = new System.Drawing.Point(6, 17);
            this.LblTotalAtivo.Name = "LblTotalAtivo";
            this.LblTotalAtivo.Size = new System.Drawing.Size(140, 14);
            this.LblTotalAtivo.TabIndex = 0;
            this.LblTotalAtivo.Text = "Total Ativo..: 0,00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DgvListaEmprestimos);
            this.groupBox3.Location = new System.Drawing.Point(12, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 287);
            this.groupBox3.TabIndex = 10;
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
            this.DgvListaEmprestimos.Size = new System.Drawing.Size(562, 262);
            this.DgvListaEmprestimos.TabIndex = 0;
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
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Format = "N2";
            this.ValorEmprestado.DefaultCellStyle = dataGridViewCellStyle33;
            this.ValorEmprestado.HeaderText = "Valor Emprestado";
            this.ValorEmprestado.Name = "ValorEmprestado";
            this.ValorEmprestado.ReadOnly = true;
            this.ValorEmprestado.Width = 105;
            // 
            // ValorParcela
            // 
            this.ValorParcela.DataPropertyName = "ValorParcela";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "N2";
            this.ValorParcela.DefaultCellStyle = dataGridViewCellStyle34;
            this.ValorParcela.HeaderText = "Valor Parcela";
            this.ValorParcela.Name = "ValorParcela";
            this.ValorParcela.ReadOnly = true;
            this.ValorParcela.Width = 87;
            // 
            // Parcelas
            // 
            this.Parcelas.DataPropertyName = "Parcelas";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "N0";
            dataGridViewCellStyle35.NullValue = null;
            this.Parcelas.DefaultCellStyle = dataGridViewCellStyle35;
            this.Parcelas.HeaderText = "Parcelas";
            this.Parcelas.Name = "Parcelas";
            this.Parcelas.ReadOnly = true;
            this.Parcelas.Width = 73;
            // 
            // ValorAPagar
            // 
            this.ValorAPagar.DataPropertyName = "ValorAPagar";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle36.Format = "N2";
            this.ValorAPagar.DefaultCellStyle = dataGridViewCellStyle36;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbxNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
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
            // FrmConEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 391);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConEmprestimo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Empréstimo";
            this.Load += new System.EventHandler(this.FrmConEmprestimo_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaEmprestimos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblTotalGeral;
        private System.Windows.Forms.Label LblTotalNAtivo;
        private System.Windows.Forms.Label LblTotalAtivo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DgvListaEmprestimos;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.Label label1;
    }
}