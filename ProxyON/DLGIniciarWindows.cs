using System;
using System.Windows.Forms;

namespace ProxyON
{
    public partial class DLGIniciarWindows : Form
    {
        public DLGIniciarWindows()
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

        private void DLGIniciarWindows_Load(object sender, EventArgs e)
        {
            picBoxIcono.Image = System.Drawing.SystemIcons.Information.ToBitmap();
        }
    }
}
