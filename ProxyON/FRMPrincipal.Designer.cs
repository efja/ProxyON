namespace ProxyON
{
    partial class FRMPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMPrincipal));
            this.btnOnOff = new System.Windows.Forms.Button();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.tbPorto = new System.Windows.Forms.TextBox();
            this.tbExcepcions = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.lblPorto = new System.Windows.Forms.Label();
            this.lblExcepcions = new System.Windows.Forms.Label();
            this.chbDireccionsLocais = new System.Windows.Forms.CheckBox();
            this.btnGardar = new System.Windows.Forms.Button();
            this.IconaNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuIconaNotificacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMostrarAplicativo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuON = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPechar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuPrincipalOpcions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipalIconizado = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipalPechar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIconaNotificacion.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(197, 159);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(148, 38);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Text = "ON";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.onOff_Click);
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(70, 24);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(159, 20);
            this.tbServidor.TabIndex = 3;
            // 
            // tbPorto
            // 
            this.tbPorto.Location = new System.Drawing.Point(295, 24);
            this.tbPorto.Name = "tbPorto";
            this.tbPorto.Size = new System.Drawing.Size(81, 20);
            this.tbPorto.TabIndex = 4;
            // 
            // tbExcepcions
            // 
            this.tbExcepcions.Location = new System.Drawing.Point(15, 72);
            this.tbExcepcions.Multiline = true;
            this.tbExcepcions.Name = "tbExcepcions";
            this.tbExcepcions.Size = new System.Drawing.Size(361, 58);
            this.tbExcepcions.TabIndex = 5;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(12, 28);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(49, 13);
            this.lblServidor.TabIndex = 6;
            this.lblServidor.Text = "Servidor:";
            // 
            // lblPorto
            // 
            this.lblPorto.AutoSize = true;
            this.lblPorto.Location = new System.Drawing.Point(254, 27);
            this.lblPorto.Name = "lblPorto";
            this.lblPorto.Size = new System.Drawing.Size(35, 13);
            this.lblPorto.TabIndex = 7;
            this.lblPorto.Text = "Porto:";
            // 
            // lblExcepcions
            // 
            this.lblExcepcions.AutoSize = true;
            this.lblExcepcions.Location = new System.Drawing.Point(12, 56);
            this.lblExcepcions.Name = "lblExcepcions";
            this.lblExcepcions.Size = new System.Drawing.Size(194, 13);
            this.lblExcepcions.TabIndex = 8;
            this.lblExcepcions.Text = "Excepcións (separa os valores con \";\"):";
            // 
            // chbDireccionsLocais
            // 
            this.chbDireccionsLocais.AutoSize = true;
            this.chbDireccionsLocais.Location = new System.Drawing.Point(15, 136);
            this.chbDireccionsLocais.Name = "chbDireccionsLocais";
            this.chbDireccionsLocais.Size = new System.Drawing.Size(140, 17);
            this.chbDireccionsLocais.TabIndex = 9;
            this.chbDireccionsLocais.Text = "Ignorar direccións locais";
            this.chbDireccionsLocais.UseVisualStyleBackColor = true;
            // 
            // btnGardar
            // 
            this.btnGardar.Location = new System.Drawing.Point(43, 159);
            this.btnGardar.Name = "btnGardar";
            this.btnGardar.Size = new System.Drawing.Size(148, 38);
            this.btnGardar.TabIndex = 10;
            this.btnGardar.Text = "GARDAR DATOS";
            this.btnGardar.UseVisualStyleBackColor = true;
            this.btnGardar.Click += new System.EventHandler(this.btnGardar_Click);
            // 
            // IconaNotificacion
            // 
            this.IconaNotificacion.ContextMenuStrip = this.MenuIconaNotificacion;
            this.IconaNotificacion.Icon = ((System.Drawing.Icon)(resources.GetObject("IconaNotificacion.Icon")));
            this.IconaNotificacion.Text = "notifyIcon1";
            this.IconaNotificacion.Visible = true;
            this.IconaNotificacion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IconaNotificacion_MouseDoubleClick);
            // 
            // MenuIconaNotificacion
            // 
            this.MenuIconaNotificacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMostrarAplicativo,
            this.toolStripSeparator1,
            this.menuON,
            this.toolStripSeparator2,
            this.menuPechar});
            this.MenuIconaNotificacion.Name = "MenuIconaNotificacion";
            this.MenuIconaNotificacion.Size = new System.Drawing.Size(222, 82);
            // 
            // menuMostrarAplicativo
            // 
            this.menuMostrarAplicativo.Name = "menuMostrarAplicativo";
            this.menuMostrarAplicativo.Size = new System.Drawing.Size(221, 22);
            this.menuMostrarAplicativo.Text = "Mostrar / Ocultar Aplicativo";
            this.menuMostrarAplicativo.Click += new System.EventHandler(this.menuMostrarOcultarAplicacion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // menuON
            // 
            this.menuON.Name = "menuON";
            this.menuON.Size = new System.Drawing.Size(221, 22);
            this.menuON.Text = "ON";
            this.menuON.Click += new System.EventHandler(this.menuON_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // menuPechar
            // 
            this.menuPechar.Name = "menuPechar";
            this.menuPechar.Size = new System.Drawing.Size(221, 22);
            this.menuPechar.Text = "Pechar";
            this.menuPechar.Click += new System.EventHandler(this.menuPechar_Click);
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrincipalOpcions,
            this.menuPrincipalPechar});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(388, 24);
            this.menuPrincipal.TabIndex = 11;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuPrincipalOpcions
            // 
            this.menuPrincipalOpcions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrincipalIconizado});
            this.menuPrincipalOpcions.Name = "menuPrincipalOpcions";
            this.menuPrincipalOpcions.Size = new System.Drawing.Size(63, 20);
            this.menuPrincipalOpcions.Text = "Opcións";
            // 
            // menuPrincipalIconizado
            // 
            this.menuPrincipalIconizado.CheckOnClick = true;
            this.menuPrincipalIconizado.Name = "menuPrincipalIconizado";
            this.menuPrincipalIconizado.Size = new System.Drawing.Size(180, 22);
            this.menuPrincipalIconizado.Text = "Iniciar iconizado";
            this.menuPrincipalIconizado.Click += new System.EventHandler(this.menuPrincipalIconizado_Click);
            // 
            // menuPrincipalPechar
            // 
            this.menuPrincipalPechar.Name = "menuPrincipalPechar";
            this.menuPrincipalPechar.Size = new System.Drawing.Size(55, 20);
            this.menuPrincipalPechar.Text = "Pechar";
            this.menuPrincipalPechar.Click += new System.EventHandler(this.pecharToolStripMenuItem_Click);
            // 
            // FRMPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 220);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.btnGardar);
            this.Controls.Add(this.chbDireccionsLocais);
            this.Controls.Add(this.lblExcepcions);
            this.Controls.Add(this.lblPorto);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.tbExcepcions);
            this.Controls.Add(this.tbPorto);
            this.Controls.Add(this.tbServidor);
            this.Controls.Add(this.btnOnOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.Name = "FRMPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProxyON";
            this.Load += new System.EventHandler(this.FRMPrincipal_Load);
            this.Shown += new System.EventHandler(this.FRMPrincipal_Shown);
            this.Resize += new System.EventHandler(this.FRMPrincipal_Resize);
            this.MenuIconaNotificacion.ResumeLayout(false);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.TextBox tbPorto;
        private System.Windows.Forms.TextBox tbExcepcions;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblPorto;
        private System.Windows.Forms.Label lblExcepcions;
        private System.Windows.Forms.CheckBox chbDireccionsLocais;
        private System.Windows.Forms.Button btnGardar;
        private System.Windows.Forms.NotifyIcon IconaNotificacion;
        private System.Windows.Forms.ContextMenuStrip MenuIconaNotificacion;
        private System.Windows.Forms.ToolStripMenuItem menuMostrarAplicativo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuPechar;
        private System.Windows.Forms.ToolStripMenuItem menuON;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalOpcions;
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalPechar;
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalIconizado;
    }
}

