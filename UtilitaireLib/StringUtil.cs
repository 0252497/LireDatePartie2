using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    public static class StringUtil
    {
        /// <summary>
        /// Supprime les accents.
        /// </summary>
        /// <param name="str">la string dont il faut supprimer les accents</param>
        /// <returns>une nouvelle chaîne sans les accents</returns>
        public static string SansAccents(this string str)
            => Encoding.ASCII.GetString(Encoding.GetEncoding(1251).GetBytes(str));
    }
}
