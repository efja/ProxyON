using System.Collections.Generic;

namespace ProxyON
{
    class Perfil
    {
        /* ##########################################################################################################################
         * #
         * #  Atributos
         * #
         * ########################################################################################################################## */
        private string nome;
        private string servidor;
        private string porto;
        private string excepcions;
        private bool direccionsLocais;

        /* ##########################################################################################################################
         * #
         * #  Constructores
         * #
         * ########################################################################################################################## */
        public Perfil(string nome, string servidor, string porto, string excepcions, bool direccionsLocais)
        {
            this.servidor = nome;
            this.servidor = servidor;
            this.porto = porto;
            this.excepcions = excepcions;
            this.direccionsLocais = direccionsLocais;
        }
        
        /* ##########################################################################################################################
         * #
         * #  Equals e HashCode
         * #
         * ########################################################################################################################## */
        public override bool Equals(object obj)
        {
            return obj is Perfil perfil &&
                   servidor == perfil.servidor &&
                   porto == perfil.porto &&
                   excepcions == perfil.excepcions &&
                   direccionsLocais == perfil.direccionsLocais;
        }

        public override int GetHashCode()
        {
            var hashCode = 838977613;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(servidor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(porto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(excepcions);
            hashCode = hashCode * -1521134295 + direccionsLocais.GetHashCode();
            return hashCode;
        }

        /* ##########################################################################################################################
         * #
         * #  Getters
         * #
         * ########################################################################################################################## */
        public string getNome()
        {
            return this.nome;
        }

        public string getServidor()
        {
            return this.servidor;
        }

        public string getPorto()
        {
            return this.porto;
        }

        public string getExcepcions()
        {
            return this.excepcions;
        }

        public bool getDireccionsLocais()
        {
            return this.direccionsLocais;
        }

        /* ##########################################################################################################################
         * #
         * #  Setters
         * #
         * ########################################################################################################################## */
        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setServidor(string servidor)
        {
            this.servidor = servidor;
        }

        public void setPorto(string porto)
        {
            this.porto = porto;
        }

        public void setExcepcions(string excepcions)
        {
            this.excepcions = excepcions;
        }

        public void setDireccionsLocais(bool direccionsLocais)
        {
            this.direccionsLocais = direccionsLocais;
        }
    }
}
