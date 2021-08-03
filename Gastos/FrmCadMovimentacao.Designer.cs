
namespace Gastos
{
    partial class FrmCadMovimentacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblDataCadastro = new System.Windows.Forms.Label();
            this.LblCompetencia = new System.Windows.Forms.Label();
            this.CbxNome = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CbCheque = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbxTipo0 = new System.Windows.Forms.ComboBox();
            this.CbxTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.MktDataMovimento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DgvListaMovimentacao = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblSaldo0 = new System.Windows.Forms.Label();
            this.LblValorPago = new System.Windows.Forms.Label();
            this.LblValorRecebido = new System.Windows.Forms.Label();
            this.LblSaldo = new System.Windows.Forms.Label();
            this.LblValorSaida = new System.Windows.Forms.Label();
            this.LblValorEntrada = new System.Windows.Forms.Label();
            this.LblValPenEnt = new System.Windows.Forms.Label();
            this.LblValPenSai = new System.Windows.Forms.Label();
            this.LblSalPen = new System.Windows.Forms.Label();
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LblSalES = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblSalPR = new System.Windows.Forms.Label();
            this.LblSalPend = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaMovimentacao)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblDataCadastro);
            this.groupBox1.Controls.Add(this.LblCompetencia);
            this.groupBox1.Controls.Add(this.CbxNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // LblDataCadastro
            // 
            this.LblDataCadastro.AutoSize = true;
            this.LblDataCadastro.Location = new System.Drawing.Point(6, 77);
            this.LblDataCadastro.Name = "LblDataCadastro";
            this.LblDataCadastro.Size = new System.Drawing.Size(139, 13);
            this.LblDataCadastro.TabIndex = 3;
            this.LblDataCadastro.Text = "Data Cadastro: 00/00/0000";
            // 
            // LblCompetencia
            // 
            this.LblCompetencia.AutoSize = true;
            this.LblCompetencia.Location = new System.Drawing.Point(6, 61);
            this.LblCompetencia.Name = "LblCompetencia";
            this.LblCompetencia.Size = new System.Drawing.Size(116, 13);
            this.LblCompetencia.TabIndex = 2;
            this.LblCompetencia.Text = "Competência: 00/0000";
            // 
            // CbxNome
            // 
            this.CbxNome.DisplayMember = "Nome";
            this.CbxNome.FormattingEnabled = true;
            this.CbxNome.Location = new System.Drawing.Point(6, 32);
            this.CbxNome.Name = "CbxNome";
            this.CbxNome.Size = new System.Drawing.Size(220, 21);
            this.CbxNome.TabIndex = 1;
            this.CbxNome.ValueMember = "Id";
            this.CbxNome.SelectedIndexChanged += new System.EventHandler(this.CbxNome_SelectedIndexChanged);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CbCheque);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CbxTipo0);
            this.groupBox2.Controls.Add(this.CbxTipo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtValor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtDescricao);
            this.groupBox2.Controls.Add(this.MktDataMovimento);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(11, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastro Movimentação";
            // 
            // CbCheque
            // 
            this.CbCheque.AutoSize = true;
            this.CbCheque.Location = new System.Drawing.Point(9, 71);
            this.CbCheque.Name = "CbCheque";
            this.CbCheque.Size = new System.Drawing.Size(63, 17);
            this.CbCheque.TabIndex = 8;
            this.CbCheque.Text = "Cheque";
            this.CbCheque.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tipo Lanc.";
            // 
            // CbxTipo0
            // 
            this.CbxTipo0.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbxTipo0.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbxTipo0.FormattingEnabled = true;
            this.CbxTipo0.Items.AddRange(new object[] {
            "Pendente",
            "Pago",
            "Recebido"});
            this.CbxTipo0.Location = new System.Drawing.Point(499, 32);
            this.CbxTipo0.Name = "CbxTipo0";
            this.CbxTipo0.Size = new System.Drawing.Size(72, 21);
            this.CbxTipo0.TabIndex = 6;
            // 
            // CbxTipo
            // 
            this.CbxTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbxTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbxTipo.FormattingEnabled = true;
            this.CbxTipo.Items.AddRange(new object[] {
            "Entrada",
            "Saída"});
            this.CbxTipo.Location = new System.Drawing.Point(421, 32);
            this.CbxTipo.Name = "CbxTipo";
            this.CbxTipo.Size = new System.Drawing.Size(72, 21);
            this.CbxTipo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor";
            // 
            // TxtValor
            // 
            this.TxtValor.Location = new System.Drawing.Point(353, 32);
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
            this.label5.Location = new System.Drawing.Point(84, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Descrição";
            // 
            // TxtDescricao
            // 
            this.TxtDescricao.Location = new System.Drawing.Point(86, 32);
            this.TxtDescricao.MaxLength = 200;
            this.TxtDescricao.Name = "TxtDescricao";
            this.TxtDescricao.Size = new System.Drawing.Size(261, 20);
            this.TxtDescricao.TabIndex = 2;
            // 
            // MktDataMovimento
            // 
            this.MktDataMovimento.Location = new System.Drawing.Point(6, 32);
            this.MktDataMovimento.Mask = "00/00/0000";
            this.MktDataMovimento.Name = "MktDataMovimento";
            this.MktDataMovimento.Size = new System.Drawing.Size(74, 20);
            this.MktDataMovimento.TabIndex = 1;
            this.MktDataMovimento.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnExcluir);
            this.groupBox3.Controls.Add(this.BtnAlterar);
            this.groupBox3.Controls.Add(this.BtnSalvar);
            this.groupBox3.Location = new System.Drawing.Point(504, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.Location = new System.Drawing.Point(6, 70);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 0;
            this.BtnExcluir.Text = "&Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DgvListaMovimentacao);
            this.groupBox4.Location = new System.Drawing.Point(11, 220);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 256);
            this.groupBox4.TabIndex = 3;
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
            this.DgvListaMovimentacao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaMovimentacao_CellDoubleClick);
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
            this.groupBox5.Location = new System.Drawing.Point(11, 482);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(581, 122);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informações";
            // 
            // LblSaldo0
            // 
            this.LblSaldo0.AutoSize = true;
            this.LblSaldo0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaldo0.Location = new System.Drawing.Point(292, 42);
            this.LblSaldo0.Name = "LblSaldo0";
            this.LblSaldo0.Size = new System.Drawing.Size(84, 14);
            this.LblSaldo0.TabIndex = 3;
            this.LblSaldo0.Text = "Saldo: 0,00";
            // 
            // LblValorPago
            // 
            this.LblValorPago.AutoSize = true;
            this.LblValorPago.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorPago.Location = new System.Drawing.Point(292, 27);
            this.LblValorPago.Name = "LblValorPago";
            this.LblValorPago.Size = new System.Drawing.Size(119, 14);
            this.LblValorPago.TabIndex = 3;
            this.LblValorPago.Text = "Valor Pago: 0,00";
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
            this.LblSaldo.Size = new System.Drawing.Size(84, 14);
            this.LblSaldo.TabIndex = 2;
            this.LblSaldo.Text = "Saldo: 0,00";
            // 
            // LblValorSaida
            // 
            this.LblValorSaida.AutoSize = true;
            this.LblValorSaida.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorSaida.Location = new System.Drawing.Point(6, 27);
            this.LblValorSaida.Name = "LblValorSaida";
            this.LblValorSaida.Size = new System.Drawing.Size(126, 14);
            this.LblValorSaida.TabIndex = 1;
            this.LblValorSaida.Text = "Valor Saída: 0,00";
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
            // LblValPenSai
            // 
            this.LblValPenSai.AutoSize = true;
            this.LblValPenSai.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValPenSai.Location = new System.Drawing.Point(6, 85);
            this.LblValPenSai.Name = "LblValPenSai";
            this.LblValPenSai.Size = new System.Drawing.Size(189, 14);
            this.LblValPenSai.TabIndex = 4;
            this.LblValPenSai.Text = "Valor Pendente Saída: 0,00";
            // 
            // LblSalPen
            // 
            this.LblSalPen.AutoSize = true;
            this.LblSalPen.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalPen.Location = new System.Drawing.Point(6, 101);
            this.LblSalPen.Name = "LblSalPen";
            this.LblSalPen.Size = new System.Drawing.Size(126, 14);
            this.LblSalPen.TabIndex = 4;
            this.LblSalPen.Text = "Valor Saldo: 0,00";
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LblSalPend);
            this.groupBox6.Controls.Add(this.LblSalPR);
            this.groupBox6.Controls.Add(this.LblSalES);
            this.groupBox6.Location = new System.Drawing.Point(253, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(245, 100);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Saldo mês Anterior";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pago/Receb.";
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
            // FrmCadMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 619);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadMovimentacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Movimentação";
            this.Load += new System.EventHandler(this.FrmCadMovimentacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaMovimentacao)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDataCadastro;
        private System.Windows.Forms.Label LblCompetencia;
        private System.Windows.Forms.ComboBox CbxNome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox MktDataMovimento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.ComboBox CbxTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbxTipo0;
        private System.Windows.Forms.CheckBox CbCheque;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DgvListaMovimentacao;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblSaldo;
        private System.Windows.Forms.Label LblValorSaida;
        private System.Windows.Forms.Label LblValorEntrada;
        private System.Windows.Forms.Label LblSaldo0;
        private System.Windows.Forms.Label LblValorPago;
        private System.Windows.Forms.Label LblValorRecebido;
        private System.Windows.Forms.Label LblValPenEnt;
        private System.Windows.Forms.Label LblValPenSai;
        private System.Windows.Forms.Label LblSalPen;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label LblSalES;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblSalPend;
        private System.Windows.Forms.Label LblSalPR;
    }
}