/* Fichier de méthodes DateUtil. */

using static Prog2.ConsolePlus;
using static System.ConsoleColor;
using System;

namespace Prog2
{
    public static class DateUtil
    {
        // --- Attributs ---
        public static readonly Date dateAttentatWTC = Date.New(2001, 09, 11);
        public const int Dummy = 10;
        public static readonly Date dateDecesMJ = Date.New(2012, 01, 31);
        public static readonly Date dateExplosionNC = Date.New(2018, 07, 11);

        // --- Méthodes ---
        /// <summary>
        /// Pour lire une date sur la console; année, mois et jour séparément. 
        /// </summary>
        /// <param name="propriété">nom de la propriété</param>
        /// <param name="date">date lue</param>
        /// <returns>faux si la date ne peut être lue</returns>
        public static bool LireDate(string propriété, out Date date)
        {
            ColorWriteLine(Magenta, propriété);

            // L'année, le mois et le jour de la date à lire :
            int année;
            int mois;
            int jour;

            LireEntier("\tAnnée\t", "", out année);

            while (!LireEntier("\tMois\t", "", 1, 12, out mois)) ;

            while (!LireEntier("\tJour\t", "", 1, 31, out jour)) ;

            date = new Date
            {
                Année = année,
                Mois = mois,
                Jour = jour
            };

            return true;
        }
    }
}
