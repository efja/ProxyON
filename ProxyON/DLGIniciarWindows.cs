using System;
using System.Windows.Forms;

namespace ProxyON
{
    public partial class FRMInicarWindows : Form
    {
        public FRMInicarWindows()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
