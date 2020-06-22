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
        /* ##########################################################################################################################
         * #
         * #  Variables globais
         * #
         * ##########################################################################################################################/
        
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
         * Carga a información do ficheiro de configuración
         ****************************************************************************************************************************/
        string servidorActual = ConfigurationManager.AppSettings.Get("servidor");
        string portoActual = ConfigurationManager.AppSettings.Get("porto");
        string excepcionsActual = ConfigurationManager.AppSettings.Get("excepcions");
        bool direccionsLocaisActual = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("direccionsLocais"));


        /* ##########################################################################################################################
         * #
         * #  Inicio da lóxica do programa
         * #
         * ##########################################################################################################################/

        /****************************************************************************************************************************
         * Inicaliza o formulario
         ****************************************************************************************************************************/
        public FRMPrincipal()
        {
            InitializeComponent();
        }

        /****************************************************************************************************************************
         * Cambia o estado do PROXY
         ****************************************************************************************************************************/
        private void onOff_Click(object sender, EventArgs e)
        {
            cambiarProxy();
            estadoProxy();
        }

        /****************************************************************************************************************************
         * Cambia o estado do PROXY
         ****************************************************************************************************************************/
        private void FRMPrincipal_Load(object sender, EventArgs e)
        {
            estadoProxy();
            cargarOpcions();
        }

        /****************************************************************************************************************************
         * Garda a información da conexión no ficheiro de configuración
         ****************************************************************************************************************************/
        private void btnGardar_Click(object sender, EventArgs e)
        {
            gardarOpcions();
        }

        /****************************************************************************************************************************
         * Carga a información do ficheiro de configuración nos cadros de texto
         ****************************************************************************************************************************/
        private void cargarOpcions()
        {
            tbServidor.Text = servidorActual;
            tbPorto.Text = portoActual;
            tbExcepcions.Text = excepcionsActual;
            chbDireccionsLocais.Checked = direccionsLocaisActual;
        }

        /****************************************************************************************************************************
         * Garda a información do ficheiro de configuración nos cadros de texto
         ****************************************************************************************************************************/
        private void gardarOpcions()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["servidor"].Value = tbServidor.Text;
            config.AppSettings.Settings["porto"].Value = tbPorto.Text;
            config.AppSettings.Settings["excepcions"].Value = tbExcepcions.Text;
            config.AppSettings.Settings["direccionsLocais"].Value = (chbDireccionsLocais.Checked) ? "true" : "false";
            config.Save(ConfigurationSaveMode.Modified);
        }

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

        /* ##########################################################################################################################
         * #
         * #  Área de notificación
         * #
         * ##########################################################################################################################/

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

    }
}
