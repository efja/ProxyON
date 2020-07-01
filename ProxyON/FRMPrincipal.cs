using System;
using System.Drawing;
using System.Configuration;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Security.Principal;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ProxyON
{
    public partial class FRMPrincipal : Form
    {
        #region VARIABLES
        /* ##########################################################################################################################
         * #
         * #  Variables globais
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Valores necesarios para refrescar o estado do PROXY
         ****************************************************************************************************************************/
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        // Valores da configuración para o inicio con Windows
        private string inicioWindows = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private string inicioWindowsClave = "ProxyON";

        // Valores da configuración do PROXY
        private string configuracionInternet = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        private string proxyEnableClave = "ProxyEnable";
        private int proxyEnableValorON = 1;
        private int proxyEnableValorOFF = 0;

        // Claves para a configuración do PROXY
        private string proxyServerClave = "ProxyServer";
        private string proxyOverrideClave = "ProxyOverride";

        /****************************************************************************************************************************
         * Configuración pr defecto
         ****************************************************************************************************************************/
        private bool arrancarIconizado = false;

        private Operacions operacions = Operacions.Instancia;
        private string directorioPerfiles;
        private string perfilPorDefecto;

        private List<string> listadoPerfiles = new List<string>();
        private int perfilActual = 0;
        #endregion

        #region EVENTOS FORMULARIO
        /* ##########################################################################################################################
         * #
         * #  Eventos de formulario
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Inicaliza o formulario
         ****************************************************************************************************************************/
        public FRMPrincipal()
        {
            InitializeComponent();
        }

        /****************************************************************************************************************************
         * Carga a información no formulario
         ****************************************************************************************************************************/
        private void FRMPrincipal_Load(object sender, EventArgs e)
        {
            estadoProxy();
            cargarOpcions();

            cargarComboBoxPerfiles();
        }

        /****************************************************************************************************************************
         * Aplica a configuración inicial do programa
         ****************************************************************************************************************************/
        private void FRMPrincipal_Shown(object sender, EventArgs e)
        {

            // Oculta (ou non) o formulario
            this.Visible = !arrancarIconizado;
        }

        /****************************************************************************************************************************
         * Oculta o formulario principal ao minimizalo
         ****************************************************************************************************************************/
        private void FRMPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        #endregion

        #region CONFIGURACIÓN
        /* ##########################################################################################################################
         * #
         * #  Configuración do programa
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Carga a información do ficheiro de configuración nos cadros de texto
         ****************************************************************************************************************************/
        private void cargarOpcions()
        {
            try
            {
                // Carga a información do ficheiro de configuración
                arrancarIconizado = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("iconizado"));

                // Directorio de perfiles
                directorioPerfiles = ConfigurationManager.AppSettings.Get("perfiles");

                // Se non hai valor gardado xenerase o directorio por defecto na ruta do executable
                if (directorioPerfiles.Equals(""))
                {
                    directorioPerfiles = Application.StartupPath + "\\Perfiles";

                    // Gardase o directorio por defecto coa ruta absoluta
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["perfiles"].Value = directorioPerfiles;
                    config.Save(ConfigurationSaveMode.Modified);
                }

                perfilPorDefecto = ConfigurationManager.AppSettings.Get("perfilPorDefecto");

                // Actualiza a información do formulario
                menuPrincipalIconizado.Checked = arrancarIconizado;
                comprobarIniciarWin();
                comprobarPorDefecto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /****************************************************************************************************************************
         * Carga a información no ComboBox para seleccionar o Perfil a activar
         ****************************************************************************************************************************/
        private void cargarComboBoxPerfiles()
        {
            operacions.listaPerfiles.Clear();
            listadoPerfiles.Clear();
            cmboxPerfiles.Items.Clear();

            operacions.cargarListaPerfiles(directorioPerfiles);

            try
            {
                foreach (Perfil perfil in operacions.listaPerfiles)
                {
                    listadoPerfiles.Add(perfil.nome);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listadoPerfiles.Count > 0)
            {
                cmboxPerfiles.Items.AddRange(listadoPerfiles.ToArray());

                if (cmboxPerfiles.Items.Count > 0)
                {
                    if (perfilPorDefecto.Equals(""))
                    {
                        cmboxPerfiles.SelectedIndex = 0;
                    }
                    else
                    {
                        cmboxPerfiles.SelectedItem = perfilPorDefecto;
                    }
                }
                else
                {
                    cmboxPerfiles.SelectedIndex = -1;
                }
            }
        }

        private void cmboxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                perfilActual = cmboxPerfiles.SelectedIndex;
                comprobarPorDefecto();
            }
            catch
            { }
        }

        #endregion

        #region LÓXICA
        /* ##########################################################################################################################
         * #
         * #  Inicio da lóxica do programa
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Comproba se o perfil actual é o perfil por defecto para marcar ou desmarcar o checkbox
         ****************************************************************************************************************************/
        private void comprobarPorDefecto()
        {
            bool valor = false;

            try
            {
                if (!perfilPorDefecto.Equals("") && operacions != null && operacions.listaPerfiles != null)
                {
                    if (perfilPorDefecto.Equals(operacions.listaPerfiles[perfilActual].nome))
                    {
                        valor = true;
                    }
                }
            }
            catch
            { }

            chbSeleccionado.Checked = valor;
        }

        /****************************************************************************************************************************
         * Cambia a execución do programa a administrador
         ****************************************************************************************************************************/
        private void executarAdmin()
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                // relaunch the application with admin rights
                string fileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";
                processInfo.FileName = fileName;

                try
                {
                    MessageBox.Show("O proceso de elvación de permisos cancela calquera operación anterior polo que terás que volver " +
                        "a iniciar o proceso que provocou esta mensaxe ou non se producirá ningún cambio.\n\nDesculpa as molestias",
                        "Cambiando permisos de execución como administrador",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );

                    this.Close();
                    Thread.Sleep(12); // Para darlle tempo a pechar a aplicación antes de volver a abrirse (só pode haber unha instancia aberta)
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /****************************************************************************************************************************
         * Comproba o estado inicio da aplicación con Windows
         * 
         * return:  0   non inicia con Windows
         *          1   inicia co usuario actual
         *          2   inicia co sistema
         ****************************************************************************************************************************/
        private int comprobarIniciarWin()
        {
            int arrancarWindows = 0;
            string valor = "";
            try
            {
                RegistryKey registry = Registry.CurrentUser.OpenSubKey(inicioWindows);
                valor = (string)registry.GetValue(inicioWindowsClave);
                if (valor != null)
                {
                    arrancarWindows = 1;
                }
                else
                {
                    registry = Registry.LocalMachine.OpenSubKey(inicioWindows);
                    valor = (string)registry.GetValue(inicioWindowsClave);
                    if (valor != null)
                    {
                        arrancarWindows = 2;
                    }
                }

                registry.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Establece o valor do estado do menú
            menuPrincipalInicioWindows.Checked = (arrancarWindows > 0) ? true : false;
            return arrancarWindows;
        }

        /****************************************************************************************************************************
         * Facer que a aplicación inicie con Windows
         ****************************************************************************************************************************/
        private void iniciarWindows()
        {
            RegistryKey inicio = null;
            string rutaAplicacion = "";

            try
            {
                switch (comprobarIniciarWin())
                {
                    case 0:
                        DLGIniciarWindows dialogo = new DLGIniciarWindows();

                        dialogo.ShowDialog();

                        switch (dialogo.DialogResult)
                        {
                            case DialogResult.Yes:
                                inicio = Registry.CurrentUser.OpenSubKey(inicioWindows, true);
                                break;
                            case DialogResult.No:
                                executarAdmin();
                                inicio = Registry.LocalMachine.OpenSubKey(inicioWindows, true);
                                break;
                            case DialogResult.Cancel:
                                return;
                        }

                        rutaAplicacion = "\"" + Application.StartupPath + "\\" + AppDomain.CurrentDomain.FriendlyName + "\"";

                        if (rutaAplicacion.Equals(""))
                        {
                            MessageBox.Show("Erro IMPORTANTE:\n\nNon se atopou a ruta do executable", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        inicio.SetValue(inicioWindowsClave, rutaAplicacion, RegistryValueKind.String);
                        break;
                    case 1:
                        inicio = Registry.CurrentUser.OpenSubKey(inicioWindows, true);
                        inicio.DeleteValue(inicioWindowsClave);
                        break;
                    case 2:
                        executarAdmin();
                        inicio = Registry.LocalMachine.OpenSubKey(inicioWindows, true);
                        inicio.DeleteValue(inicioWindowsClave);
                        break;
                }

                if (inicio != null)
                {
                    inicio.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            comprobarIniciarWin();
        }

        /****************************************************************************************************************************
         * Estado do PROXY
         ****************************************************************************************************************************/
        private int estadoProxy()
        {
            int status = 0;

            // Cambios de estética
            string cadeaProxyActivar = "Activar PROXY";
            string cadeaProxyDesactivar = "Desactivar PROXY";

            string cadeaIcoActivado = Application.ProductName +  " - (Activado)";
            string cadeaIcoDesactivado = Application.ProductName + " - (Desctivado)";

            Color corActivarProxy = Color.Maroon;
            Color corDesactivarProxy = Color.Green;

            try
            {
                RegistryKey registry = Registry.CurrentUser.OpenSubKey(configuracionInternet, true);
                status = (int)registry.GetValue(proxyEnableClave);

                if (status == 0)
                {
                    btnOnOff.Text = cadeaProxyActivar;
                    btnOnOff.ForeColor = corActivarProxy;


                    menuON.Text = cadeaProxyActivar;
                    menuON.ForeColor = corActivarProxy;

                    IconaNotificacion.Icon = Properties.Resources.NotifyIconGrey;
                    IconaNotificacion.Text = cadeaIcoDesactivado;

                    activarTSPrincipal(true);
                    cmboxPerfiles.Enabled = true;
                    chbSeleccionado.Enabled = true;
                }
                else
                {
                    btnOnOff.Text = cadeaProxyDesactivar;
                    btnOnOff.ForeColor = corDesactivarProxy;
                    
                    menuON.Text = cadeaProxyDesactivar;
                    menuON.ForeColor = corDesactivarProxy;

                    IconaNotificacion.Icon = Properties.Resources.NotifyIcon;
                    IconaNotificacion.Text = cadeaIcoActivado;

                    activarTSPrincipal(false);
                    cmboxPerfiles.Enabled = false;
                    chbSeleccionado.Enabled = false;
                }

                registry.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return status;
        }

        /****************************************************************************************************************************
         * Cambiar o estado do PROXY
         ****************************************************************************************************************************/
        private void cambiarProxy()
        {
            string proxyServerValor = "";
            string proxyOverrideValor = "";

            if (!operacions.listaPerfiles[perfilActual].servidor.Equals("") && !operacions.listaPerfiles[perfilActual].porto.Equals(""))
            {
                proxyServerValor = operacions.listaPerfiles[perfilActual].servidor + ":" + operacions.listaPerfiles[perfilActual].porto;
            }

            if (!operacions.listaPerfiles[perfilActual].excepcions.Equals(""))
            {
                proxyOverrideValor = operacions.listaPerfiles[perfilActual].excepcions;
            }

            if (operacions.listaPerfiles[perfilActual].direccionsLocais)
            {
                string pecharExcepcions = "";
                if (proxyOverrideValor.Length > 0)
                {
                    if (!proxyOverrideValor.Substring(proxyOverrideValor.Length - 1).Equals(";"))
                    {
                        pecharExcepcions = ";";
                    }
                }
                proxyOverrideValor += pecharExcepcions + "<local>";
            }

            try
            {
                RegistryKey proxy = Registry.CurrentUser.OpenSubKey(name: configuracionInternet, writable: true);

                if (estadoProxy() == 0)
                {
                    proxy.SetValue(proxyEnableClave, proxyEnableValorON, RegistryValueKind.DWord);
                    proxy.SetValue(proxyServerClave, proxyServerValor);
                    proxy.SetValue(proxyOverrideClave, proxyOverrideValor);
                }
                else if (estadoProxy() == 1)
                {
                    proxy.DeleteValue(proxyServerClave);
                    proxy.DeleteValue(proxyOverrideClave);
                    proxy.SetValue(proxyEnableClave, proxyEnableValorOFF);
                }

                // Refresh System Settings
                settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
                refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

                proxy.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region BOTÓNS
        /* ##########################################################################################################################
         * #
         * #  Eventos de botóns e checkboxes
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Cambia o estado do PROXY
         ****************************************************************************************************************************/
        private void onOff_Click(object sender, EventArgs e)
        {
            cambiarProxy();
            estadoProxy();
        }

        /****************************************************************************************************************************
         * Garda a información do ficheiro de configuración nos cadros de texto
         ****************************************************************************************************************************/
        private void chbSeleccionado_Click(object sender, EventArgs e)
        {
            try
            {
                perfilPorDefecto = (chbSeleccionado.Checked) ? operacions.listaPerfiles[perfilActual].nome : "";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["perfilPorDefecto"].Value = perfilPorDefecto;
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Non se atopou o ficheiro de configuración\n" + ex.Message, "Erro ó gardar a configuración");
            }
        }
        #endregion

        #region MENU PRINCIPAL
        /* ##########################################################################################################################
         * #
         * #  Menú Formulario principal
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Cambia o estado dos botóns da cinta que non se poden activar se o PROXY está activado
         ****************************************************************************************************************************/
        private void activarTSPrincipal(bool activado)
        {
            tsBtnModificar.Enabled = activado;
            tsBtnEliminar.Enabled = activado;
            tsBtnDirPerfiles.Enabled = activado;
        }

        /****************************************************************************************************************************
         * Establece se se debe mostrar o formulario ó iniciar a aplicación ou non
         ****************************************************************************************************************************/
        private void menuPrincipalIconizado_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["iconizado"].Value = (menuPrincipalIconizado.Checked) ? "true" : "false";
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Non se atopou o ficheiro de configuración\n" + ex.Message, "Erro ó gardar a configuración");
            }
        }

        /****************************************************************************************************************************
         * Abre un subformulario para engadir un novo perfil ou cos datos do perfil activo para modificalo segundo que botón o
         * invoque
         ****************************************************************************************************************************/
        private void perfilEngadirModificarCopiar(object sender, EventArgs e)
        {
            try
            {
                bool modificar = false;
                DLGPerfil frmAux = new DLGPerfil();
                ToolStripButton chamador = (ToolStripButton)sender;

                if (chamador.Name.Equals("tsBtnModificar"))
                {
                    modificar = true;
                }

                if (chamador.Name.Equals("tsBtnCopiar") || modificar)
                {
                    // Carganse os datos do perfil actual
                    frmAux.encherDatos(operacions.listaPerfiles[perfilActual], modificar);
                }

                frmAux.ShowDialog();

                if (frmAux.DialogResult == DialogResult.OK)
                {
                    if (modificar)
                    {
                        operacions.listaPerfiles[perfilActual] = frmAux.perfilNovo;
                    }
                    else
                    {
                        foreach (Perfil perfil in operacions.listaPerfiles)
                        {
                            if (operacions.comprobarPerfil(@directorioPerfiles, frmAux.perfilNovo.nome))
                            {
                                MessageBox.Show("Non se pode gardar 2 perfiles co mesmo <Nome>", "Perfil duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                // Volvese a lanzar o formulario
                                perfilEngadirModificarCopiar(sender, e);
                                return;
                            }
                        }
                    }

                    operacions.gardarPerfil(@directorioPerfiles, frmAux.perfilNovo);
                    cargarComboBoxPerfiles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /****************************************************************************************************************************
         * Elimina o perfil activo
         ****************************************************************************************************************************/
        private void tsBtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(
                    "ATENCIÓN!!\n\nEste proceso é irreversible estás seguro de que queres borrar definitivamente o perfil <" + operacions.listaPerfiles[perfilActual].nome + ">?",
                    "BORRAR PERFIL",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                );
                if (dialogResult == DialogResult.Yes)
                {
                    // Se é o perfil por defecto borrase a configuración
                    if (chbSeleccionado.Checked)
                    {
                        perfilPorDefecto =  "";

                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["perfilPorDefecto"].Value = perfilPorDefecto;
                        config.Save(ConfigurationSaveMode.Modified);
                    }

                    operacions.borrarPerfil(@directorioPerfiles, operacions.listaPerfiles[perfilActual]);
                    operacions.listaPerfiles.RemoveAt(perfilActual);
                    cargarComboBoxPerfiles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /****************************************************************************************************************************
         * Abre un dialogo para cambiar o directorio onde se almacenarán os perfiles
         ****************************************************************************************************************************/
        private void tsBtnDirPerfiles_Click(object sender, EventArgs e)
        {
            string rutaPrevia = Path.GetFullPath(operacions.comprobarDirectorio(@directorioPerfiles) ? @directorioPerfiles : ".");

            folderBrowserDialog1.Description = "Escolle a ubicación onde queres gardar os Perfiles dos teus PROXYs";
            folderBrowserDialog1.SelectedPath = rutaPrevia;

            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!rutaPrevia.Equals(folderBrowserDialog1.SelectedPath))
                {
                    directorioPerfiles = folderBrowserDialog1.SelectedPath;

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["perfiles"].Value = @directorioPerfiles;
                    config.Save(ConfigurationSaveMode.Modified);

                    DialogResult moverPerfiles = MessageBox.Show("Queres intentar mover os perfiles que teñas gardados á nova ubicación?\n\nNOTA: Esta operación implica borrar os perfiles da ubicación actual",
                        "Mover Perfiles",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (moverPerfiles == DialogResult.Yes)
                    {
                        operacions.gardarPerfiles(directorioPerfiles);
                        operacions.borrarPerfiles(rutaPrevia);
                    }
                }
            }

        }

        /****************************************************************************************************************************
         * Establece se se debe arrancar a aplicación con windows ou non
         ****************************************************************************************************************************/
        private void menuPrincipalInicioWindows_Click(object sender, EventArgs e)
        {
            iniciarWindows();
        }

        #endregion

        #region ÁREA DE NOTIFICACIÓN
        /* ##########################################################################################################################
         * #
         * #  Área de notificación
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Cambia o estado do PROXY
         ****************************************************************************************************************************/
        private void IconaNotificacion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            onOff_Click(null, null);
        }

        /****************************************************************************************************************************
         * Cambia o estado do PROXY
         ****************************************************************************************************************************/
        private void menuON_Click(object sender, EventArgs e)
        {
            onOff_Click(null, null);
        }

        /****************************************************************************************************************************
         * Mostra ou oculta o formulario principal ao facer dobre click sobre a icona de notificación
         ****************************************************************************************************************************/
        private void menuMostrarOcultarAplicacion_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;

            // Se o formulario esta minimizado restaurao
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        /****************************************************************************************************************************
         * Sae da aplicación
         ****************************************************************************************************************************/
        private void menuPechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion
    }
}
