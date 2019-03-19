/* Fichier d'utilitaires StringUtil. */
using System.Linq;
using System.Text;

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

        /// <summary>
        /// Tente de convertir un mot en booléen.
        /// </summary>
        /// <param name="strBool">le mot à convertir</param>
        /// <param name="booléen">le mot converti</param>
        /// <returns>vrai si la convertion réussit</returns>
        public static bool TryParseBool(this string strBool, out bool booléen)
        {
            booléen = false;

            switch (strBool.ToLower().Trim())
            {
                case "vrai":
                case "yes":
                case "y":
                case "t":
                case "v":
                case "oui":
                case "o":
                case "1":
                case "true":
                    booléen = true;
                    return true;
                case "faux":
                case "non":
                case "n":
                case "no":
                case "f":
                case "0":
                case "false":
                    return true;
                default:
                    return false;
            }
        }
    }
}
