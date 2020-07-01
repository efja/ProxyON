namespace ProxyON
{
    partial class DLGIniciarWindows
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnSistema = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.picBoxIcono = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(85, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(315, 60);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Como queres que o aplicativo se inicie con Windows?";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(10, 73);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(127, 30);
            this.btnUsuario.TabIndex = 1;
            this.btnUsuario.Text = "Para este usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnSistema
            // 
            this.btnSistema.Location = new System.Drawing.Point(149, 73);
            this.btnSistema.Name = "btnSistema";
            this.btnSistema.Size = new System.Drawing.Size(127, 30);
            this.btnSistema.TabIndex = 2;
            this.btnSistema.Text = "Tódolos usuarios";
            this.btnSistema.UseVisualStyleBackColor = true;
            this.btnSistema.Click += new System.EventHandler(this.btnSistema_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(288, 73);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // picBoxIcono
            // 
            this.picBoxIcono.Location = new System.Drawing.Point(25, 9);
            this.picBoxIcono.Name = "picBoxIcono";
            this.picBoxIcono.Size = new System.Drawing.Size(60, 60);
            this.picBoxIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxIcono.TabIndex = 4;
            this.picBoxIcono.TabStop = false;
            // 
            // DLGIniciarWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(424, 110);
            this.Controls.Add(this.picBoxIcono);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSistema);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DLGIniciarWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inicar con Windows";
            this.Load += new System.EventHandler(this.DLGIniciarWindows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnSistema;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox picBoxIcono;
    }
}