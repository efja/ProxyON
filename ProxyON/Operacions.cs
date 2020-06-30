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
        // Variable estática para a instancia (patrón Singleton)
        private static readonly Lazy<Operacions> instancia = new Lazy<Operacions>(() => new Operacions());

        // Propiedade para acceder á instancia
        public static Operacions Instancia
        {
            get
            {
                return instancia.Value;
            }
        }

        public List<Perfil> listaPerfiles { get; set; }

        /* ##########################################################################################################################
         * #
         * #  Constructores
         * #
         * ########################################################################################################################## */

        // Constructor privado para evitar la instanciación directa
        private Operacions()
        {
            this.listaPerfiles = new List<Perfil>();
        }

        #region OPERACIÓNS
        /* ##########################################################################################################################
         * #
         * #  Operacións sobre ficheiros
         * #
         * ########################################################################################################################## */

        /****************************************************************************************************************************
         * Comproba se existe un direcotrio pasado
         ****************************************************************************************************************************/
        public bool comprobarDirectorio(string rutaFicheiro)
        {
            return Directory.Exists(rutaFicheiro);
        }
        /****************************************************************************************************************************
         * Comproba se existe un direcotrio pasado
         ****************************************************************************************************************************/
        public bool comprobarPerfil(string rutaFicheiro, string nomeFicheiro)
        {
            return File.Exists(@rutaFicheiro + "\\" + nomeFicheiro + ".xml");
        }

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
        public Perfil cargarPerfil(string @rutaPerfil)
        {
            Perfil resultado = null;

            try
            {
                if (File.Exists(@rutaPerfil))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Perfil), new XmlRootAttribute("Perfil"));
                    using (FileStream fileStream = new FileStream(@rutaPerfil, FileMode.Open))
                    {
                        resultado = (Perfil)serializer.Deserialize(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ó cargar o perfil: <" + @rutaPerfil + ">\n" + ex.Message, "Erro ó cargar o perfil");
            }

            return resultado;
        }

        /****************************************************************************************************************************
         * Carga os perfiles
         ****************************************************************************************************************************/
        public void cargarListaPerfiles(string dirPerfiles)
        {
            DirectoryInfo directorio = new DirectoryInfo(dirPerfiles);

            if (comprobarDirectorio(dirPerfiles) && directorio.GetFiles().Count() > 0)
            {

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
        public void gardarPerfil(string @rutaPerfil, Perfil perfilGardar)
        {
            try
            {
                // Crea o directorio se non existe
                if (!comprobarDirectorio(@rutaPerfil))
                {
                    Directory.CreateDirectory(@rutaPerfil);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(Perfil));
                Stream fs = new FileStream(@rutaPerfil + "\\" + perfilGardar.nome + ".xml", FileMode.Create);
                XmlWriter writer = new XmlTextWriter(fs, Encoding.UTF8);

                serializer.Serialize(writer, perfilGardar);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ó gardar o perfil: <" + @rutaPerfil + "\\" + perfilGardar.nome + ".xml" + ">\n" + ex.Message, "Erro ó gardar o perfil");
            }
        }

        /****************************************************************************************************************************
         * Garda a información dos perfiles no directorio de perfiles
         ****************************************************************************************************************************/
        public void gardarPerfiles(string dirPerfiles)
        {
            foreach (Perfil perfil in this.listaPerfiles)
            {
                gardarPerfil(dirPerfiles, perfil);
            }
        }

        /****************************************************************************************************************************
         * Borra o perfil pasado
         ****************************************************************************************************************************/
        public void borrarPerfil(string @rutaPerfil, Perfil perfilBorrar)
        {
            try
            {
                File.Delete(@rutaPerfil + "\\" + perfilBorrar.nome + ".xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ó borrar o perfil: <" + @rutaPerfil + "\\" + perfilBorrar.nome + ".xml" + ">\n" + ex.Message, "Erro ó borrar o perfil");
            }
        }

        /****************************************************************************************************************************
         * Borra tódolos perfiles da lista
         ****************************************************************************************************************************/
        public void borrarPerfiles(string rutaPerfil)
        {
            foreach (Perfil perfil in this.listaPerfiles)
            {
                borrarPerfil(rutaPerfil, perfil);
            }
        }

        #endregion
    }
}
