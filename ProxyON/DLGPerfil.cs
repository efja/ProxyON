using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyON
{
    public partial class DLGPerfil : Form
    {
        public Perfil perfilNovo { get; set; }

        public DLGPerfil()
        {
            InitializeComponent();
        }

        public void encherDatos(Perfil perfil)
        {
            tbNome.Text = perfil.nome;
            tbServidor.Text = perfil.servidor;
            tbPorto.Text = perfil.porto;
            tbExcepcions.Text = perfil.excepcions;
            chbDireccionsLocais.Checked = perfil.direccionsLocais;
        }

        private void btnGardar_Click(object sender, EventArgs e)
        {
            perfilNovo = new Perfil(
                tbNome.Text,
                tbServidor.Text,
                tbPorto.Text,
                tbExcepcions.Text,
                chbDireccionsLocais.Checked
            );

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
