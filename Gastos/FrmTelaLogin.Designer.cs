
namespace Gastos
{
    partial class FrmTelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTelaLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LkLblLembreSenha = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAcessar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtSenha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados para Acesso";
            // 
            // TxtSenha
            // 
            this.TxtSenha.Location = new System.Drawing.Point(6, 88);
            this.TxtSenha.MaxLength = 20;
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(154, 20);
            this.TxtSenha.TabIndex = 1;
            this.TxtSenha.UseSystemPasswordChar = true;
            this.TxtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSenha_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // TxtLogin
            // 
            this.TxtLogin.Location = new System.Drawing.Point(6, 38);
            this.TxtLogin.MaxLength = 20;
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.Size = new System.Drawing.Size(154, 20);
            this.TxtLogin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário";
            // 
            // LkLblLembreSenha
            // 
            this.LkLblLembreSenha.AutoSize = true;
            this.LkLblLembreSenha.Location = new System.Drawing.Point(16, 147);
            this.LkLblLembreSenha.Name = "LkLblLembreSenha";
            this.LkLblLembreSenha.Size = new System.Drawing.Size(85, 13);
            this.LkLblLembreSenha.TabIndex = 2;
            this.LkLblLembreSenha.TabStop = true;
            this.LkLblLembreSenha.Text = "Lembrete Senha";
            this.LkLblLembreSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LkLblLembreSenha_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCancelar);
            this.groupBox2.Controls.Add(this.BtnAcessar);
            this.groupBox2.Location = new System.Drawing.Point(199, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(16, 70);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(101, 23);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAcessar
            // 
            this.BtnAcessar.Location = new System.Drawing.Point(16, 30);
            this.BtnAcessar.Name = "BtnAcessar";
            this.BtnAcessar.Size = new System.Drawing.Size(101, 23);
            this.BtnAcessar.TabIndex = 0;
            this.BtnAcessar.Text = "&Acessar";
            this.BtnAcessar.UseVisualStyleBackColor = true;
            this.BtnAcessar.Click += new System.EventHandler(this.BtnAcessar_Click);
            // 
            // FrmTelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 171);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LkLblLembreSenha);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acesso ao Sistema";
            this.Load += new System.EventHandler(this.FrmTelaLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTelaLogin_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LkLblLembreSenha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAcessar;
    }
}