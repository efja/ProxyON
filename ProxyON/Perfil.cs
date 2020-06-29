using System.Collections.Generic;

namespace ProxyON
{

    public class Perfil
    {
        /* ##########################################################################################################################
         * #
         * #  Atributos
         * #
         * ########################################################################################################################## */

        public string nome { get; set; }
        public string servidor { get; set; }
        public string porto { get; set; }
        public string excepcions { get; set; }
        public bool direccionsLocais { get; set; }

        /* ##########################################################################################################################
         * #
         * #  Constructores
         * #
         * ########################################################################################################################## */
        public Perfil()
        {
        }

        public Perfil(string nome, string servidor, string porto, string excepcions, bool direccionsLocais)
        {
            this.nome = nome;
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
    }
}
