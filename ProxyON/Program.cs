using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace ProxyON
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool aberta;

            using (Mutex mtex = new Mutex(true, "ProxyON", out aberta))
            {
                if (aberta)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FRMPrincipal());
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("Xa se está a executar o aplicativo, só se pode exutar unha única instacia do mesmo");
                }
            }
        }
    }
}
