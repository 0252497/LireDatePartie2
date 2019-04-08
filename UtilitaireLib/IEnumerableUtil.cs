/* Fichier d'utilitaires IEnumerableUtil. */
using System.Collections.Generic;
using System.Linq;

namespace Prog2
{
    public static class IEnumerableUtil
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
            string enTexte = "";    // La string à renvoyer

            // Pour connaître notre position dans l'énumération, on ne veut pas de séparateur 
            // à la fin de celle-ci :
            int i = 1;  

            foreach (T elem in elems)
            {
                enTexte += texteAvant != null ? texteAvant : "";
                enTexte += elem;
                enTexte += texteAprès != null ? texteAprès : "";

                if (i != elems.Count())
                {
                    enTexte += séparateur != null ? séparateur : " ";
                }

                ++i;
            }

            return enTexte;
        }

        /// <summary>
        /// Génère une énumération d'entiers de début à fin.
        /// </summary>
        /// <param name="début">début</param>
        /// <param name="fin">fin</param>
        /// <param name="step">pas entre les nombres</param>
        /// <returns>énumération</returns>
        public static IEnumerable<int> Jusqua(this int début, int fin, int step = 0)
        {
            if (début <= fin && step >= 0)
            {
                for (int i = début; i <= fin; i += step != 0 ? step : 1)
                {
                    yield return i;
                }
            }
            else if (début > fin && step <= 0)
            {
                for (int i = début; i >= fin; i += step != 0 ? step : -1)
                {
                    yield return i;
                }
            }
        }
    }
}
