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
            this.cmboxPerfiles = new System.Windows.Forms.ComboBox();
            this.chbSeleccionado = new System.Windows.Forms.CheckBox();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnEngadir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnModificar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnDirPerfiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnOpcions = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuPrincipalIconizado = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipalInicioWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIconaNotificacion.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(84, 100);
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
            this.lblPerfil.Location = new System.Drawing.Point(17, 43);
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
            // cmboxPerfiles
            // 
            this.cmboxPerfiles.FormattingEnabled = true;
            this.cmboxPerfiles.Location = new System.Drawing.Point(56, 39);
            this.cmboxPerfiles.Name = "cmboxPerfiles";
            this.cmboxPerfiles.Size = new System.Drawing.Size(283, 21);
            this.cmboxPerfiles.TabIndex = 12;
            this.cmboxPerfiles.SelectedIndexChanged += new System.EventHandler(this.cmboxPerfiles_SelectedIndexChanged);
            // 
            // chbSeleccionado
            // 
            this.chbSeleccionado.AutoSize = true;
            this.chbSeleccionado.Location = new System.Drawing.Point(56, 66);
            this.chbSeleccionado.Name = "chbSeleccionado";
            this.chbSeleccionado.Size = new System.Drawing.Size(133, 17);
            this.chbSeleccionado.TabIndex = 19;
            this.chbSeleccionado.Text = "Selecionar por defecto";
            this.chbSeleccionado.UseVisualStyleBackColor = true;
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEngadir,
            this.tsBtnModificar,
            this.tsBtnEliminar,
            this.toolStripSeparator3,
            this.tsBtnDirPerfiles,
            this.toolStripSeparator4,
            this.tsBtnOpcions});
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(357, 25);
            this.tsPrincipal.TabIndex = 20;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsBtnEngadir
            // 
            this.tsBtnEngadir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEngadir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEngadir.Image")));
            this.tsBtnEngadir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEngadir.Name = "tsBtnEngadir";
            this.tsBtnEngadir.Size = new System.Drawing.Size(23, 22);
            this.tsBtnEngadir.Text = "toolStripButton1";
            this.tsBtnEngadir.Click += new System.EventHandler(this.engadirModificarPerfil);
            // 
            // tsBtnModificar
            // 
            this.tsBtnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnModificar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnModificar.Image")));
            this.tsBtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModificar.Name = "tsBtnModificar";
            this.tsBtnModificar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnModificar.Text = "toolStripButton3";
            this.tsBtnModificar.Click += new System.EventHandler(this.engadirModificarPerfil);
            // 
            // tsBtnEliminar
            // 
            this.tsBtnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEliminar.Image")));
            this.tsBtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEliminar.Name = "tsBtnEliminar";
            this.tsBtnEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnEliminar.Text = "toolStripButton5";
            this.tsBtnEliminar.Click += new System.EventHandler(this.tsBtnEliminar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnDirPerfiles
            // 
            this.tsBtnDirPerfiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDirPerfiles.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDirPerfiles.Image")));
            this.tsBtnDirPerfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDirPerfiles.Name = "tsBtnDirPerfiles";
            this.tsBtnDirPerfiles.Size = new System.Drawing.Size(23, 22);
            this.tsBtnDirPerfiles.Text = "toolStripButton2";
            this.tsBtnDirPerfiles.Click += new System.EventHandler(this.tsBtnDirPerfiles_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnOpcions
            // 
            this.tsBtnOpcions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnOpcions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrincipalIconizado,
            this.menuPrincipalInicioWindows});
            this.tsBtnOpcions.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpcions.Image")));
            this.tsBtnOpcions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpcions.Name = "tsBtnOpcions";
            this.tsBtnOpcions.Size = new System.Drawing.Size(29, 22);
            this.tsBtnOpcions.Text = "toolStripDropDownButton1";
            // 
            // menuPrincipalIconizado
            // 
            this.menuPrincipalIconizado.CheckOnClick = true;
            this.menuPrincipalIconizado.Name = "menuPrincipalIconizado";
            this.menuPrincipalIconizado.Size = new System.Drawing.Size(181, 22);
            this.menuPrincipalIconizado.Text = "Inicar iconizado";
            this.menuPrincipalIconizado.Click += new System.EventHandler(this.menuPrincipalIconizado_Click);
            // 
            // menuPrincipalInicioWindows
            // 
            this.menuPrincipalInicioWindows.Name = "menuPrincipalInicioWindows";
            this.menuPrincipalInicioWindows.Size = new System.Drawing.Size(181, 22);
            this.menuPrincipalInicioWindows.Text = "Iniciar con Windows";
            this.menuPrincipalInicioWindows.Click += new System.EventHandler(this.menuPrincipalInicioWindows_Click);
            // 
            // FRMPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 150);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.chbSeleccionado);
            this.Controls.Add(this.cmboxPerfiles);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.btnOnOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FRMPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProxyON";
            this.Load += new System.EventHandler(this.FRMPrincipal_Load);
            this.Shown += new System.EventHandler(this.FRMPrincipal_Shown);
            this.Resize += new System.EventHandler(this.FRMPrincipal_Resize);
            this.MenuIconaNotificacion.ResumeLayout(false);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmboxPerfiles;
        private System.Windows.Forms.CheckBox chbSeleccionado;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnOpcions;
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalIconizado;
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalInicioWindows;
        private System.Windows.Forms.ToolStripButton tsBtnEngadir;
        private System.Windows.Forms.ToolStripButton tsBtnModificar;
        private System.Windows.Forms.ToolStripButton tsBtnEliminar;
        private System.Windows.Forms.ToolStripButton tsBtnDirPerfiles;
    }
}

