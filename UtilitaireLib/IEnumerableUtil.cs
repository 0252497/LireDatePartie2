using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    static class IEnumerableUtil
    {
        /// <summary>
        /// Convertit un énumérable en texte.
        /// </summary>
        /// <typeparam name="T">type générique quelconque</typeparam>
        /// <param name="elems">les éléments énumérables</param>
        /// <param name="séparateur">le sépareteur à insérer entre les éléments</param>
        /// <param name="texteAvant">texte à ajouter devant chaque élément</param>
        /// <param name="texteAprès">texte à ajouter après chaque élément</param>
        /// <returns>l'énumérable sous forme textuelle</returns>
        /// <remarks>
        ///     Si un argument facultatif est null, on le remplace par sa valeur 
        ///     par défaut.
        /// </remarks>
        public static string EnTexte<T>(this IEnumerable<T> elems, string séparateur = " ",
            string texteAvant = "", string texteAprès = "")
        {
        }
    }
}
