using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    public static class BoolUtil
    {
        /// <summary>
        /// Convertit un booléen en "oui" ou "non".
        /// </summary>
        /// <param name="b">le booléen à convertir</param>
        /// <returns>"oui" ou "non"</returns>
        public static string OuiNon(this bool b)
            => b ? "oui" : "non";

        /// <summary>
        /// Convertit un booléen en "vrai" ou "faux".
        /// </summary>
        /// <param name="b">le booléen à convertir</param>
        /// <returns>"oui" ou "non"</returns>
        public static string VraiFaux(this bool b)
            => b ? "vrai" : "faux";
    }
}
