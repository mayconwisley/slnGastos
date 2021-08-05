
namespace Gastos
{
    partial class FrmConMovimentacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LblSalPend = new System.Windows.Forms.Label();
            this.LblSalPR = new System.Windows.Forms.Label();
            this.LblSalES = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblSalPen = new System.Windows.Forms.Label();
            this.LblValPenSai = new System.Windows.Forms.Label();
            this.LblValPenEnt = new System.Windows.Forms.Label();
            this.LblSaldo0 = new System.Windows.Forms.Label();
            this.LblValorPago = new System.Windows.Forms.Label();
            this.LblValorRecebido = new System.Windows.Forms.Label();
            this.LblSaldo = new System.Windows.Forms.Label();
            this.LblValorSaida = new System.Windows.Forms.Label();
            this.LblValorEntrada = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DgvListaMovimentacao = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataMovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoLancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMonetario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPagoRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompetenciaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MktCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.CbxNome = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaMovimentacao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LblSalPend);
            this.groupBox6.Controls.Add(this.LblSalPR);
            this.groupBox6.Controls.Add(this.LblSalES);
            this.groupBox6.Location = new System.Drawing.Point(347, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(245, 71);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Saldo mês Anterior";
            // 
            // LblSalPend
            // 
            this.LblSalPend.AutoSize = true;
            this.LblSalPend.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalPend.Location = new System.Drawing.Point(7, 46);
            this.LblSalPend.Name = "LblSalPend";
            this.LblSalPend.Size = new System.Drawing.Size(119, 14);
            this.LblSalPend.TabIndex = 0;
            this.LblSalPend.Text = "Sal. Pend.: 0,00";
            // 
            // LblSalPR
            // 
            this.LblSalPR.AutoSize = true;
            this.LblSalPR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalPR.Location = new System.Drawing.Point(7, 31);
            this.LblSalPR.Name = "LblSalPR";
            this.LblSalPR.Size = new System.Drawing.Size(119, 14);
            this.LblSalPR.TabIndex = 0;
            this.LblSalPR.Text = "Sal. P. R.: 0,00";
            // 
            // LblSalES
            // 
            this.LblSalES.AutoSize = true;
            this.LblSalES.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalES.Location = new System.Drawing.Point(7, 16);
            this.LblSalES.Name = "LblSalES";
            this.LblSalES.Size = new System.Drawing.Size(119, 14);
            this.LblSalES.TabIndex = 0;
            this.LblSalES.Text = "Sal. E. S.: 0,00";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LblSalPen);
            this.groupBox5.Controls.Add(this.LblValPenSai);
            this.groupBox5.Controls.Add(this.LblValPenEnt);
            this.groupBox5.Controls.Add(this.LblSaldo0);
            this.groupBox5.Controls.Add(this.LblValorPago);
            this.groupBox5.Controls.Add(this.LblValorRecebido);
            this.groupBox5.Controls.Add(this.LblSaldo);
            this.groupBox5.Controls.Add(this.LblValorSaida);
            this.groupBox5.Controls.Add(this.LblValorEntrada);
            this.groupBox5.Location = new System.Drawing.Point(11, 351);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(581, 122);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informações";
            // 
            // LblSalPen
            // 
            this.LblSalPen.AutoSize = true;
            this.LblSalPen.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalPen.Location = new System.Drawing.Point(6, 101);
            this.LblSalPen.Name = "LblSalPen";
            this.LblSalPen.Size = new System.Drawing.Size(203, 14);
            this.LblSalPen.TabIndex = 4;
            this.LblSalPen.Text = "Valor Saldo...........: 0,00";
            // 
            // LblValPenSai
            // 
            this.LblValPenSai.AutoSize = true;
            this.LblValPenSai.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValPenSai.Location = new System.Drawing.Point(6, 85);
            this.LblValPenSai.Name = "LblValPenSai";
            this.LblValPenSai.Size = new System.Drawing.Size(203, 14);
            this.LblValPenSai.TabIndex = 4;
            this.LblValPenSai.Text = "Valor Pendente Saída..: 0,00";
            // 
            // LblValPenEnt
            // 
            this.LblValPenEnt.AutoSize = true;
            this.LblValPenEnt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValPenEnt.Location = new System.Drawing.Point(6, 71);
            this.LblValPenEnt.Name = "LblValPenEnt";
            this.LblValPenEnt.Size = new System.Drawing.Size(203, 14);
            this.LblValPenEnt.TabIndex = 4;
            this.LblValPenEnt.Text = "Valor Pendente Entrada: 0,00";
            // 
            // LblSaldo0
            // 
            this.LblSaldo0.AutoSize = true;
            this.LblSaldo0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaldo0.Location = new System.Drawing.Point(292, 42);
            this.LblSaldo0.Name = "LblSaldo0";
            this.LblSaldo0.Size = new System.Drawing.Size(147, 14);
            this.LblSaldo0.TabIndex = 3;
            this.LblSaldo0.Text = "Saldo.........: 0,00";
            // 
            // LblValorPago
            // 
            this.LblValorPago.AutoSize = true;
            this.LblValorPago.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorPago.Location = new System.Drawing.Point(292, 27);
            this.LblValorPago.Name = "LblValorPago";
            this.LblValorPago.Size = new System.Drawing.Size(147, 14);
            this.LblValorPago.TabIndex = 3;
            this.LblValorPago.Text = "Valor Pago....: 0,00";
            // 
            // LblValorRecebido
            // 
            this.LblValorRecebido.AutoSize = true;
            this.LblValorRecebido.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorRecebido.Location = new System.Drawing.Point(292, 12);
            this.LblValorRecebido.Name = "LblValorRecebido";
            this.LblValorRecebido.Size = new System.Drawing.Size(147, 14);
            this.LblValorRecebido.TabIndex = 3;
            this.LblValorRecebido.Text = "Valor Recebido: 0,00";
            // 
            // LblSaldo
            // 
            this.LblSaldo.AutoSize = true;
            this.LblSaldo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaldo.Location = new System.Drawing.Point(6, 42);
            this.LblSaldo.Name = "LblSaldo";
            this.LblSaldo.Size = new System.Drawing.Size(140, 14);
            this.LblSaldo.TabIndex = 2;
            this.LblSaldo.Text = "Saldo........: 0,00";
            // 
            // LblValorSaida
            // 
            this.LblValorSaida.AutoSize = true;
            this.LblValorSaida.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorSaida.Location = new System.Drawing.Point(6, 27);
            this.LblValorSaida.Name = "LblValorSaida";
            this.LblValorSaida.Size = new System.Drawing.Size(140, 14);
            this.LblValorSaida.TabIndex = 1;
            this.LblValorSaida.Text = "Valor Saída..: 0,00";
            // 
            // LblValorEntrada
            // 
            this.LblValorEntrada.AutoSize = true;
            this.LblValorEntrada.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorEntrada.Location = new System.Drawing.Point(6, 12);
            this.LblValorEntrada.Name = "LblValorEntrada";
            this.LblValorEntrada.Size = new System.Drawing.Size(140, 14);
            this.LblValorEntrada.TabIndex = 0;
            this.LblValorEntrada.Text = "Valor Entrada: 0,00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DgvListaMovimentacao);
            this.groupBox4.Location = new System.Drawing.Point(11, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 256);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Movimentacões cadastradas";
            // 
            // DgvListaMovimentacao
            // 
            this.DgvListaMovimentacao.AllowUserToAddRows = false;
            this.DgvListaMovimentacao.AllowUserToDeleteRows = false;
            this.DgvListaMovimentacao.AllowUserToOrderColumns = true;
            this.DgvListaMovimentacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvListaMovimentacao.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvListaMovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvListaMovimentacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaMovimentacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DataMovimento,
            this.Descricao,
            this.Valor,
            this.TipoLancamento,
            this.TipoMonetario,
            this.TipoPagoRecebido,
            this.Login,
            this.ClienteId,
            this.CompetenciaId,
            this.DataCadastro});
            this.DgvListaMovimentacao.Location = new System.Drawing.Point(6, 19);
            this.DgvListaMovimentacao.MultiSelect = false;
            this.DgvListaMovimentacao.Name = "DgvListaMovimentacao";
            this.DgvListaMovimentacao.ReadOnly = true;
            this.DgvListaMovimentacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaMovimentacao.Size = new System.Drawing.Size(569, 231);
            this.DgvListaMovimentacao.TabIndex = 0;
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
            // DataMovimento
            // 
            this.DataMovimento.DataPropertyName = "DataMovimento";
            this.DataMovimento.HeaderText = "Data Movimento";
            this.DataMovimento.Name = "DataMovimento";
            this.DataMovimento.ReadOnly = true;
            this.DataMovimento.Width = 101;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 80;
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
            // TipoLancamento
            // 
            this.TipoLancamento.DataPropertyName = "TipoLancamento";
            this.TipoLancamento.HeaderText = "Tipo Lançamento";
            this.TipoLancamento.Name = "TipoLancamento";
            this.TipoLancamento.ReadOnly = true;
            this.TipoLancamento.Width = 105;
            // 
            // TipoMonetario
            // 
            this.TipoMonetario.DataPropertyName = "TipoMonetario";
            this.TipoMonetario.HeaderText = "Tipo Monetario";
            this.TipoMonetario.Name = "TipoMonetario";
            this.TipoMonetario.ReadOnly = true;
            this.TipoMonetario.Width = 95;
            // 
            // TipoPagoRecebido
            // 
            this.TipoPagoRecebido.DataPropertyName = "TipoPagoRecebido";
            this.TipoPagoRecebido.HeaderText = "Tipo Pago Recebido";
            this.TipoPagoRecebido.Name = "TipoPagoRecebido";
            this.TipoPagoRecebido.ReadOnly = true;
            this.TipoPagoRecebido.Width = 119;
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
            // CompetenciaId
            // 
            this.CompetenciaId.DataPropertyName = "CompetenciaId";
            this.CompetenciaId.HeaderText = "CompetenciaId";
            this.CompetenciaId.Name = "CompetenciaId";
            this.CompetenciaId.ReadOnly = true;
            this.CompetenciaId.Visible = false;
            this.CompetenciaId.Width = 103;
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
            this.groupBox1.Controls.Add(this.MktCompetencia);
            this.groupBox1.Controls.Add(this.CbxNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // MktCompetencia
            // 
            this.MktCompetencia.Location = new System.Drawing.Point(6, 28);
            this.MktCompetencia.Mask = "00/0000";
            this.MktCompetencia.Name = "MktCompetencia";
            this.MktCompetencia.Size = new System.Drawing.Size(69, 20);
            this.MktCompetencia.TabIndex = 0;
            this.MktCompetencia.ValidatingType = typeof(System.DateTime);
            this.MktCompetencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MktCompetencia_KeyDown);
            this.MktCompetencia.Leave += new System.EventHandler(this.MktCompetencia_Leave);
            // 
            // CbxNome
            // 
            this.CbxNome.DisplayMember = "Nome";
            this.CbxNome.FormattingEnabled = true;
            this.CbxNome.Location = new System.Drawing.Point(81, 27);
            this.CbxNome.Name = "CbxNome";
            this.CbxNome.Size = new System.Drawing.Size(243, 21);
            this.CbxNome.TabIndex = 1;
            this.CbxNome.ValueMember = "Id";
            this.CbxNome.SelectedIndexChanged += new System.EventHandler(this.CbxNome_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Competência";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // FrmConMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 485);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConMovimentacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Movimentação";
            this.Load += new System.EventHandler(this.FrmConMovimentacao_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaMovimentacao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label LblSalPend;
        private System.Windows.Forms.Label LblSalPR;
        private System.Windows.Forms.Label LblSalES;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblSalPen;
        private System.Windows.Forms.Label LblValPenSai;
        private System.Windows.Forms.Label LblValPenEnt;
        private System.Windows.Forms.Label LblSaldo0;
        private System.Windows.Forms.Label LblValorPago;
        private System.Windows.Forms.Label LblValorRecebido;
        private System.Windows.Forms.Label LblSaldo;
        private System.Windows.Forms.Label LblValorSaida;
        private System.Windows.Forms.Label LblValorEntrada;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DgvListaMovimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataMovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMonetario;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPagoRecebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompetenciaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox MktCompetencia;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}