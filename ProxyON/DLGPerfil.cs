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
            if (!tbNome.Text.Equals("") && !tbServidor.Text.Equals("") && !tbPorto.Text.Equals(""))
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
            else
            {
                MessageBox.Show("Non se introduciron tódolos dataos requeridos:\n\n<Nome>\n<tbServidor>\n<tbPorto>", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
