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
            this.lblPerfil = new System.Windows.Forms.Label();
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
            this.menuPrincipalInicioWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipalPechar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboxPerfiles = new System.Windows.Forms.ComboBox();
            this.btnEngadirPerfil = new System.Windows.Forms.Button();
            this.btnBorrarPerfil = new System.Windows.Forms.Button();
            this.chbSeleccionado = new System.Windows.Forms.CheckBox();
            this.MenuIconaNotificacion.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(100, 92);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(189, 38);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Text = "ON";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.onOff_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Location = new System.Drawing.Point(13, 37);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(33, 13);
            this.lblPerfil.TabIndex = 6;
            this.lblPerfil.Text = "Perfil:";
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
            this.menuPrincipal.Size = new System.Drawing.Size(389, 24);
            this.menuPrincipal.TabIndex = 11;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuPrincipalOpcions
            // 
            this.menuPrincipalOpcions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrincipalIconizado,
            this.menuPrincipalInicioWindows});
            this.menuPrincipalOpcions.Name = "menuPrincipalOpcions";
            this.menuPrincipalOpcions.Size = new System.Drawing.Size(63, 20);
            this.menuPrincipalOpcions.Text = "Opcións";
            // 
            // menuPrincipalIconizado
            // 
            this.menuPrincipalIconizado.CheckOnClick = true;
            this.menuPrincipalIconizado.Name = "menuPrincipalIconizado";
            this.menuPrincipalIconizado.Size = new System.Drawing.Size(181, 22);
            this.menuPrincipalIconizado.Text = "Iniciar iconizado";
            this.menuPrincipalIconizado.Click += new System.EventHandler(this.menuPrincipalIconizado_Click);
            // 
            // menuPrincipalInicioWindows
            // 
            this.menuPrincipalInicioWindows.CheckOnClick = true;
            this.menuPrincipalInicioWindows.Name = "menuPrincipalInicioWindows";
            this.menuPrincipalInicioWindows.Size = new System.Drawing.Size(181, 22);
            this.menuPrincipalInicioWindows.Text = "Iniciar con Windows";
            this.menuPrincipalInicioWindows.Click += new System.EventHandler(this.menuPrincipalInicioWindows_Click);
            // 
            // menuPrincipalPechar
            // 
            this.menuPrincipalPechar.Name = "menuPrincipalPechar";
            this.menuPrincipalPechar.Size = new System.Drawing.Size(55, 20);
            this.menuPrincipalPechar.Text = "Pechar";
            this.menuPrincipalPechar.Click += new System.EventHandler(this.pecharToolStripMenuItem_Click);
            // 
            // cmboxPerfiles
            // 
            this.cmboxPerfiles.FormattingEnabled = true;
            this.cmboxPerfiles.Location = new System.Drawing.Point(52, 33);
            this.cmboxPerfiles.Name = "cmboxPerfiles";
            this.cmboxPerfiles.Size = new System.Drawing.Size(251, 21);
            this.cmboxPerfiles.TabIndex = 12;
            this.cmboxPerfiles.SelectedIndexChanged += new System.EventHandler(this.cmboxPerfiles_SelectedIndexChanged);
            // 
            // btnEngadirPerfil
            // 
            this.btnEngadirPerfil.Location = new System.Drawing.Point(304, 32);
            this.btnEngadirPerfil.Name = "btnEngadirPerfil";
            this.btnEngadirPerfil.Size = new System.Drawing.Size(35, 23);
            this.btnEngadirPerfil.TabIndex = 13;
            this.btnEngadirPerfil.Text = "+";
            this.btnEngadirPerfil.UseVisualStyleBackColor = true;
            // 
            // btnBorrarPerfil
            // 
            this.btnBorrarPerfil.Location = new System.Drawing.Point(340, 32);
            this.btnBorrarPerfil.Name = "btnBorrarPerfil";
            this.btnBorrarPerfil.Size = new System.Drawing.Size(35, 23);
            this.btnBorrarPerfil.TabIndex = 14;
            this.btnBorrarPerfil.Text = "-";
            this.btnBorrarPerfil.UseVisualStyleBackColor = true;
            // 
            // chbSeleccionado
            // 
            this.chbSeleccionado.AutoSize = true;
            this.chbSeleccionado.Location = new System.Drawing.Point(52, 60);
            this.chbSeleccionado.Name = "chbSeleccionado";
            this.chbSeleccionado.Size = new System.Drawing.Size(133, 17);
            this.chbSeleccionado.TabIndex = 19;
            this.chbSeleccionado.Text = "Selecionar por defecto";
            this.chbSeleccionado.UseVisualStyleBackColor = true;
            // 
            // FRMPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 142);
            this.Controls.Add(this.chbSeleccionado);
            this.Controls.Add(this.btnBorrarPerfil);
            this.Controls.Add(this.btnEngadirPerfil);
            this.Controls.Add(this.cmboxPerfiles);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.lblPerfil);
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
        private System.Windows.Forms.Label lblPerfil;
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
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalInicioWindows;
        private System.Windows.Forms.ComboBox cmboxPerfiles;
        private System.Windows.Forms.Button btnEngadirPerfil;
        private System.Windows.Forms.Button btnBorrarPerfil;
        private System.Windows.Forms.CheckBox chbSeleccionado;
    }
}

