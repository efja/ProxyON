using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ProxyON
{
    class Operacions
    {
        /* ##########################################################################################################################
         * #
         * #  Atributos
         * #
         * ########################################################################################################################## */
        private List<Perfil> listaPerfiles;
        private string dirPerfiles;
        
        /* ##########################################################################################################################
         * #
         * #  Constructores
         * #
         * ########################################################################################################################## */
        public Operacions(string dirPerfiles)
        {
            this.listaPerfiles = new List<Perfil>();
            this.dirPerfiles = dirPerfiles;
        }

        public Operacions(string dirPerfiles, List<Perfil> listaPerfiles)
        {
            this.listaPerfiles = listaPerfiles;
            this.dirPerfiles = dirPerfiles;
        }

        /* ##########################################################################################################################
         * #
         * #  Getters
         * #
         * ########################################################################################################################## */
        public List<Perfil> getListaPerfiles()
        {
            return this.listaPerfiles;
        }

        public string getDirPerfiles()
        {
            return this.dirPerfiles;
        }

        /* ##########################################################################################################################
         * #
         * #  Setters
         * #
         * ########################################################################################################################## */
        public void setDirPerfiles(string dirPerfiles)
        {
            this.dirPerfiles = dirPerfiles;
        }

        #region OPERACIÓNS
        /* ##########################################################################################################################
         * #
         * #  Outros métodos
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Carga un perfil dende un ficheiro dado
         ****************************************************************************************************************************/
        private Perfil cargarPerfilDefecto()
        {
            Perfil resultado = null;

            try
            {
                resultado = new Perfil(
                    ConfigurationManager.AppSettings.Get("Por defecto"),
                    ConfigurationManager.AppSettings.Get("servidor"),
                    ConfigurationManager.AppSettings.Get("porto"),
                    ConfigurationManager.AppSettings.Get("excepcions"),
                    Convert.ToBoolean(ConfigurationManager.AppSettings.Get("direccionsLocais"))
                );
            }
            catch
            {
                MessageBox.Show("Erro ó cargar o perfil por defecto", "Erro ó cargar o perfil");
            }

            return resultado;
        }


        /****************************************************************************************************************************
         * Carga un perfil dende un ficheiro dado
         ****************************************************************************************************************************/
        private Perfil cargarPerfil(string rutaPerfil)
        {
            Perfil resultado = null;

            try
            {
                if (File.Exists(rutaPerfil))
                {
                    XmlDocument documento = new XmlDocument();
                    documento.Load(rutaPerfil);

                    XmlNodeList xPerfil = documento.GetElementsByTagName("perfil");

                    resultado = new Perfil(
                        documento.GetElementById("nome").InnerText,
                        documento.GetElementById("servidor").InnerText,
                        documento.GetElementById("porto").InnerText,
                        documento.GetElementById("excepcions").InnerText,
                        Convert.ToBoolean(documento.GetElementById("direccionsLocais").InnerText)
                    );
                }
            }
            catch
            {
                MessageBox.Show("Erro ó cargar o perfil: <" + rutaPerfil + ">", "Erro ó cargar o perfil");
            }

            return resultado;
        }

        /****************************************************************************************************************************
         * Carga os perfiles
         ****************************************************************************************************************************/
        private void cargarListaPerfiles()
        {
            if (Directory.Exists(this.dirPerfiles))
            {
                DirectoryInfo directorio = new DirectoryInfo(this.dirPerfiles);

                foreach (var fPerfil in directorio.GetFiles("*.xml"))
                {
                    this.listaPerfiles.Add(cargarPerfil(fPerfil.Name));
                }
            }
            else
            {
                this.listaPerfiles.Add(cargarPerfilDefecto());
            }
        }

        /****************************************************************************************************************************
         * Garda (sobrescribindo) a información do perfil pasado no ficheiro dados
         ****************************************************************************************************************************/
        private void gardarPerfil(string rutaPerfil, Perfil perfilGardar)
        {
            try
            {
                XmlTextWriter ficheiroXML;
                ficheiroXML = new XmlTextWriter(rutaPerfil, Encoding.UTF8);
                ficheiroXML.Formatting = Formatting.Indented;
                ficheiroXML.WriteStartDocument();

                ficheiroXML.WriteStartElement("perfil");

                ficheiroXML.WriteElementString("nome", perfilGardar.getNome());
                ficheiroXML.WriteElementString("servidor", perfilGardar.getServidor());
                ficheiroXML.WriteElementString("porto", perfilGardar.getPorto());
                ficheiroXML.WriteElementString("excepcions", perfilGardar.getExcepcions());
                ficheiroXML.WriteElementString("direccionsLocais", (perfilGardar.getDireccionsLocais()) ? "true" : "false");

                ficheiroXML.WriteEndElement();

                ficheiroXML.WriteEndDocument();
                ficheiroXML.Flush();
                ficheiroXML.Close();
            }
            catch
            {
                MessageBox.Show("Erro ó gardar o perfil: <" + rutaPerfil + ">", "Erro ó gardar o perfil");
            }
        }

        /****************************************************************************************************************************
         * Garda a información dos perfiles no directorio de perfiles
         ****************************************************************************************************************************/
        private void gardarPerfiles()
        {
            foreach (Perfil perfil in this.listaPerfiles)
            {
                gardarPerfil(this.dirPerfiles + "\\" + perfil.getNome() + ".xml", perfil);
            }
        }
        #endregion
    }
}
