using System;
using System.Drawing;
using System.Configuration;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Security.Principal;
using System.Diagnostics;
using System.Collections.Generic;

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

        private Operacions operacions;
        private string directorioPerfiles;

        private Dictionary<string, Perfil> listadoPerfiles = new Dictionary<string, Perfil>();
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
            operacions = new Operacions(directorioPerfiles);

            operacions.cargarListaPerfiles();

            try
            {
                foreach (Perfil perfil in operacions.listaPerfiles)
                {
                    listadoPerfiles.Add(perfil.nome, perfil);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listadoPerfiles.Count > 0)
            {
                cmboxPerfiles.DataSource = new BindingSource(listadoPerfiles, null);

                cmboxPerfiles.ValueMember = "Value";
                cmboxPerfiles.DisplayMember = "Key";
                cmboxPerfiles.SelectedIndex = 0;
            }
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
                directorioPerfiles = ConfigurationManager.AppSettings.Get("perfiles");

                // Mostra a información no menú
                menuPrincipalIconizado.Checked = arrancarIconizado;
                comprobarIniciarWin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /****************************************************************************************************************************
         * Garda a información do ficheiro de configuración nos cadros de texto
         ****************************************************************************************************************************/
        private void gardarOpcions()
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("Non se atopou o ficheiro de configuración", "Erro ó gardar a configuración");
            }
        }

        private void cmboxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                perfilActual = cmboxPerfiles.SelectedIndex;
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
                    this.Close();
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

                        inicio.SetValue(inicioWindowsClave, System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase, RegistryValueKind.String);
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
            string cadeaActivarProxy = "Activar PROXY";
            string cadeaDesactivarProxy = "Desactivar PROXY";

            Color corActivarProxy = Color.Maroon;
            Color corDesactivarProxy = Color.Green;

            // mentres non se implemente a funcionalidade queda desactivado sempre
            chbSeleccionado.Enabled = false;
            try
            {
                RegistryKey registry = Registry.CurrentUser.OpenSubKey(configuracionInternet, true);
                status = (int)registry.GetValue(proxyEnableClave);

                if (status == 0)
                {
                    btnOnOff.Text = cadeaActivarProxy;
                    btnOnOff.ForeColor = corActivarProxy;

                    menuON.Text = cadeaActivarProxy;
                    menuON.ForeColor = corActivarProxy;
                    IconaNotificacion.Icon = Properties.Resources.NotifyIconGrey;

                    activarTSPrincipal(true);
                    cmboxPerfiles.Enabled = true;
                    // chbSeleccionado.Enabled = true; // mentres non se implemente a funcionalidade queda desactivado sempre
                }
                else
                {
                    btnOnOff.Text = cadeaDesactivarProxy;
                    btnOnOff.ForeColor = corDesactivarProxy;

                    menuON.Text = cadeaDesactivarProxy;
                    menuON.ForeColor = corDesactivarProxy;
                    IconaNotificacion.Icon = Properties.Resources.NotifyIcon;

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
         * #  Eventos de botóns
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
            catch
            {
                MessageBox.Show("Non se atopou o ficheiro de configuración", "Erro ó gardar a configuración");
            }
        }

        /****************************************************************************************************************************
         * Abre un subformulario para engadir un novo perfil
         ****************************************************************************************************************************/
        private void tsBtnEngadir_Click(object sender, EventArgs e)
        {
            DLGPerfil frmAux = new DLGPerfil();
            frmAux.ShowDialog();
        }


        /****************************************************************************************************************************
         * Abre un subformulario cos datos do perfil activo para modificalo
         ****************************************************************************************************************************/
        private void tsBtnModificar_Click(object sender, EventArgs e)
        {
            DLGPerfil frmAux = new DLGPerfil();

            // Carganse os datos do perfil actual
            frmAux.encherDatos(operacions.listaPerfiles[perfilActual]);

            frmAux.ShowDialog();

            if (frmAux.DialogResult == DialogResult.OK)
            {
                operacions.listaPerfiles[perfilActual] = frmAux.perfilNovo;
            }

        }


        /****************************************************************************************************************************
         * Elimina o perfil activo
         ****************************************************************************************************************************/
        private void tsBtnEliminar_Click(object sender, EventArgs e)
        {

        }


        /****************************************************************************************************************************
         * Abre un dialogo para cambiar o directorio onde se almacenarán os perfiles
         ****************************************************************************************************************************/
        private void tsBtnDirPerfiles_Click(object sender, EventArgs e)
        {

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
