using System;
using System.Drawing;
using System.Configuration;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

        // Valores da configuración do PROXY 
        string configuracionInternet = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        string proxyEnableClave = "ProxyEnable";
        int proxyEnableValorON = 1;
        int proxyEnableValorOFF = 0;

        // Claves para a configuración do PROXY
        string proxyServerClave = "ProxyServer";
        string proxyOverrideClave = "ProxyOverride";

        /****************************************************************************************************************************
         * Configuración pr defecto
         ****************************************************************************************************************************/
        bool arrancarIconizado = false;
        string servidorActual = "127.0.0.1";
        string portoActual = "80";
        string excepcionsActual = "";
        bool direccionsLocaisActual = false;
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
                servidorActual = ConfigurationManager.AppSettings.Get("servidor");
                portoActual = ConfigurationManager.AppSettings.Get("porto");
                excepcionsActual = ConfigurationManager.AppSettings.Get("excepcions");
                direccionsLocaisActual = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("direccionsLocais"));

                // Asigna os datos ó formulario
                tbServidor.Text = servidorActual;
                tbPorto.Text = portoActual;
                tbExcepcions.Text = excepcionsActual;
                chbDireccionsLocais.Checked = direccionsLocaisActual;

                // Mostra a información no menú
                menuPrincipalIconizado.Checked = arrancarIconizado;
            }
            catch
            { }
        }

        /****************************************************************************************************************************
         * Garda a información do ficheiro de configuración nos cadros de texto
         ****************************************************************************************************************************/
        private void gardarOpcions()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["servidor"].Value = tbServidor.Text;
                config.AppSettings.Settings["porto"].Value = tbPorto.Text;
                config.AppSettings.Settings["excepcions"].Value = tbExcepcions.Text;
                config.AppSettings.Settings["direccionsLocais"].Value = (chbDireccionsLocais.Checked) ? "true" : "false";
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                MessageBox.Show("Non se atopou o ficheiro de configuración", "Erro ó gardar a configuración");
            }
        }
        #endregion

        #region LÓXICA
        /* ##########################################################################################################################
         * #
         * #  Inicio da lóxica do programa
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Estado do PROXY
         ****************************************************************************************************************************/
        private int estadoProxy()
        {
            int status = 0;
            string cadeaActivarProxy = "Activar PROXY";
            string cadeaDesactivarProxy = "Desactivar PROXY";

            Color corActivarProxy = Color.Maroon;
            Color corDesactivarProxy = Color.Green;

            try
            {
                RegistryKey registry = Registry.CurrentUser.OpenSubKey(configuracionInternet, true);
                status = (int)registry.GetValue("ProxyEnable");
                if (status == 0)
                {
                    btnOnOff.Text = cadeaActivarProxy;
                    btnOnOff.ForeColor = corActivarProxy;

                    menuON.Text = cadeaActivarProxy;
                    menuON.ForeColor = corActivarProxy;
                    IconaNotificacion.Icon = Properties.Resources.NotifyIconGrey;
                }
                else
                {
                    btnOnOff.Text = cadeaDesactivarProxy;
                    btnOnOff.ForeColor = corDesactivarProxy;

                    menuON.Text = cadeaDesactivarProxy;
                    menuON.ForeColor = corDesactivarProxy;
                    IconaNotificacion.Icon = Properties.Resources.NotifyIcon;
                }

                registry.Close();
            }
            catch
            { }

            return status;
        }

        /****************************************************************************************************************************
         * Cambiar o estado do PROXY
         ****************************************************************************************************************************/
        private void cambiarProxy()
        {
            string proxyServerValor = "";
            string proxyOverrideValor = "";

            if (!tbServidor.Text.Equals("") && !tbPorto.Text.Equals(""))
            {
                proxyServerValor = tbServidor.Text + ":" + tbPorto.Text;
            }

            if (!tbExcepcions.Text.Equals(""))
            {
                proxyOverrideValor = tbExcepcions.Text;
            }

            if (chbDireccionsLocais.Checked)
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
            catch
            { }
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

        /****************************************************************************************************************************
         * Garda a información da conexión no ficheiro de configuración
         ****************************************************************************************************************************/
        private void btnGardar_Click(object sender, EventArgs e)
        {
            gardarOpcions();
        }
        #endregion

        #region MENU PRINCIPAL
        /* ##########################################################################################################################
         * #
         * #  Menú Formulario principal
         * #
         * ########################################################################################################################## */

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
         * Sae da aplicación
         ****************************************************************************************************************************/
        private void pecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
