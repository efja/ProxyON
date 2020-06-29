namespace ProxyON
{
    partial class DLGPerfil
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
            this.btnGardar = new System.Windows.Forms.Button();
            this.chbDireccionsLocais = new System.Windows.Forms.CheckBox();
            this.lblExcepcions = new System.Windows.Forms.Label();
            this.lblPorto = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.tbExcepcions = new System.Windows.Forms.TextBox();
            this.tbPorto = new System.Windows.Forms.TextBox();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGardar
            // 
            this.btnGardar.Location = new System.Drawing.Point(43, 177);
            this.btnGardar.Name = "btnGardar";
            this.btnGardar.Size = new System.Drawing.Size(148, 38);
            this.btnGardar.TabIndex = 5;
            this.btnGardar.Text = "GARDAR DATOS";
            this.btnGardar.UseVisualStyleBackColor = true;
            this.btnGardar.Click += new System.EventHandler(this.btnGardar_Click);
            // 
            // chbDireccionsLocais
            // 
            this.chbDireccionsLocais.AutoSize = true;
            this.chbDireccionsLocais.Location = new System.Drawing.Point(15, 154);
            this.chbDireccionsLocais.Name = "chbDireccionsLocais";
            this.chbDireccionsLocais.Size = new System.Drawing.Size(140, 17);
            this.chbDireccionsLocais.TabIndex = 18;
            this.chbDireccionsLocais.Text = "Ignorar direccións locais";
            this.chbDireccionsLocais.UseVisualStyleBackColor = true;
            // 
            // lblExcepcions
            // 
            this.lblExcepcions.AutoSize = true;
            this.lblExcepcions.Location = new System.Drawing.Point(12, 74);
            this.lblExcepcions.Name = "lblExcepcions";
            this.lblExcepcions.Size = new System.Drawing.Size(194, 13);
            this.lblExcepcions.TabIndex = 17;
            this.lblExcepcions.Text = "Excepcións (separa os valores con \";\"):";
            // 
            // lblPorto
            // 
            this.lblPorto.AutoSize = true;
            this.lblPorto.Location = new System.Drawing.Point(254, 45);
            this.lblPorto.Name = "lblPorto";
            this.lblPorto.Size = new System.Drawing.Size(35, 13);
            this.lblPorto.TabIndex = 16;
            this.lblPorto.Text = "Porto:";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(12, 46);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(49, 13);
            this.lblServidor.TabIndex = 15;
            this.lblServidor.Text = "Servidor:";
            // 
            // tbExcepcions
            // 
            this.tbExcepcions.Location = new System.Drawing.Point(15, 90);
            this.tbExcepcions.Multiline = true;
            this.tbExcepcions.Name = "tbExcepcions";
            this.tbExcepcions.Size = new System.Drawing.Size(361, 58);
            this.tbExcepcions.TabIndex = 4;
            // 
            // tbPorto
            // 
            this.tbPorto.Location = new System.Drawing.Point(295, 42);
            this.tbPorto.Name = "tbPorto";
            this.tbPorto.Size = new System.Drawing.Size(81, 20);
            this.tbPorto.TabIndex = 3;
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(70, 42);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(159, 20);
            this.tbServidor.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(197, 177);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 38);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 19);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 21;
            this.lblNome.Text = "Nome:";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(70, 15);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(306, 20);
            this.tbNome.TabIndex = 1;
            // 
            // DLGPerfil
            // 
            this.AcceptButton = this.btnGardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(389, 231);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.btnGardar);
            this.Controls.Add(this.chbDireccionsLocais);
            this.Controls.Add(this.lblExcepcions);
            this.Controls.Add(this.lblPorto);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.tbExcepcions);
            this.Controls.Add(this.tbPorto);
            this.Controls.Add(this.tbServidor);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "DLGPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Perfil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGardar;
        private System.Windows.Forms.CheckBox chbDireccionsLocais;
        private System.Windows.Forms.Label lblExcepcions;
        private System.Windows.Forms.Label lblPorto;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox tbExcepcions;
        private System.Windows.Forms.TextBox tbPorto;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox tbNome;
    }
}