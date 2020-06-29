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
using System.Xml.Serialization;

namespace ProxyON
{
    class Operacions
    {
        /* ##########################################################################################################################
         * #
         * #  Atributos
         * #
         * ########################################################################################################################## */
        public List<Perfil> listaPerfiles { get; set; }
        public string dirPerfiles { get; set; }

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

        #region OPERACIÓNS
        /* ##########################################################################################################################
         * #
         * #  Outros métodos
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Carga un perfil dende un ficheiro dado
         ****************************************************************************************************************************/
        public Perfil cargarPerfilDefecto()
        {
            Perfil resultado = null;

            try
            {
                resultado = new Perfil(
                    ConfigurationManager.AppSettings.Get("nome"),
                    ConfigurationManager.AppSettings.Get("servidor"),
                    ConfigurationManager.AppSettings.Get("porto"),
                    ConfigurationManager.AppSettings.Get("excepcions"),
                    Convert.ToBoolean(ConfigurationManager.AppSettings.Get("direccionsLocais"))
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ó cargar o perfil por defecto\n" + ex.Message, "Erro ó cargar o perfil");
            }

            return resultado;
        }


        /****************************************************************************************************************************
         * Carga un perfil dende un ficheiro dado
         ****************************************************************************************************************************/
        public Perfil cargarPerfil(string rutaPerfil)
        {
            Perfil resultado = null;

            try
            {
                if (File.Exists(rutaPerfil))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Perfil), new XmlRootAttribute("perfil"));
                    using (FileStream fileStream = new FileStream(rutaPerfil, FileMode.Open))
                    {
                        resultado = (Perfil)serializer.Deserialize(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ó cargar o perfil: <" + rutaPerfil + ">\n" + ex.Message, "Erro ó cargar o perfil");
            }

            return resultado;
        }

        /****************************************************************************************************************************
         * Carga os perfiles
         ****************************************************************************************************************************/
        public void cargarListaPerfiles()
        {
            if (Directory.Exists(this.dirPerfiles))
            {
                DirectoryInfo directorio = new DirectoryInfo(this.dirPerfiles);

                foreach (var fPerfil in directorio.GetFiles("*.xml"))
                {
                    this.listaPerfiles.Add(cargarPerfil(fPerfil.FullName));
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
        public void gardarPerfil(string rutaPerfil, Perfil perfilGardar)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Perfil));
                Stream fs = new FileStream(rutaPerfil, FileMode.Create);
                XmlWriter writer = new XmlTextWriter(fs, Encoding.UTF8);

                serializer.Serialize(writer, perfilGardar);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ó gardar o perfil: <" + rutaPerfil + ">\n" + ex.Message, "Erro ó gardar o perfil");
            }
        }

        /****************************************************************************************************************************
         * Garda a información dos perfiles no directorio de perfiles
         ****************************************************************************************************************************/
        public void gardarPerfiles()
        {
            foreach (Perfil perfil in this.listaPerfiles)
            {
                gardarPerfil(this.dirPerfiles + "\\" + perfil.nome + ".xml", perfil);
            }
        }
        #endregion
    }
}
