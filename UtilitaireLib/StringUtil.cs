/* --- Utilitaires StringUtil --- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2.BoolUtil;

namespace Prog2
{
    public static class StringUtil
    {
        /// <summary>
        /// Détermine si une chaîne de caractères est purement alphabétique, donc composée 
        /// uniquement de lettres.
        /// </summary>
        /// <param name="str">la chaîne de caractères</param>
        /// <returns>vrai ou faux</returns>
        public static bool EstAlpha(this string str) 
            => str.All(char.IsLetter);

        /// <summary>
        /// Détermine si une chaîne de caractères est purement numérique, donc composée 
        /// uniquement de chiffres.
        /// </summary>
        /// <param name="str">la chaîne de caractères</param>
        /// <returns>vrai ou faux</returns>
        public static bool EstNumérique(this string str) 
            => str.All(char.IsDigit);

        /// <summary>
        /// Supprime les accents.
        /// </summary>
        /// <param name="str">la string dont il faut supprimer les accents</param>
        /// <returns>une nouvelle chaîne sans les accents</returns>
        public static string SansAccents(this string str)
            => Encoding.ASCII.GetString(Encoding.GetEncoding(1251).GetBytes(str));

        public static bool TryParseBool(this string strBool, out bool booléen)
        {
            strBool = strBool.Trim().ToLower().SansAccents();
            booléen = false;

            if (bool.TryParse(strBool, out booléen))
                return true;

            switch (strBool)
            {
                case "vrai":
                case "yes":
                case "y":
                case "t":
                case "v":
                case "oui":
                case "o":
                case "1":
                    booléen = true;
                    return true;
                case "faux":
                case "non":
                case "n":
                case "no":
                case "f":
                case "0":
                    return true;
                default:
                    return false;
            }
        }
    }
}
