/* Fichier de méthodes DateUtil. */

using static Prog2.ConsolePlus;
using static System.ConsoleColor;
using static Prog2.Date;

namespace Prog2
{
    public static class DateUtil
    {
        // --- Attributs ---
        public static readonly Date DateAttentatWTC = New(2001, 09, 11);
        public static readonly Date DateDecesMJ = New(2012, 01, 31);
        public static readonly Date DateExplosionNC = New(2018, 07, 11);

        // --- Méthodes ---

        /// <summary>
        /// Renvoie si une année est bissextile.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <returns>vrai si l'année est bissextile</returns>
        public static bool EstBissextile(this int année)
            => année % 4 == 0 && année % 100 != 0 || année % 400 == 0;

        /// <summary>
        /// Pour lire une date sur la console; année, mois et jour séparément. 
        /// </summary>
        /// <param name="propriété">nom de la propriété</param>
        /// <param name="date">date lue</param>
        /// <returns>faux si la date ne peut être lue</returns>
        public static bool LireDate(string propriété, out Date date)
        {
            ColorWriteLine(Magenta, propriété);

            LireEntier("\tAnnée ", "", out int année);
            LireEntier("\tMois ", "", 1, 12, out int mois);

            // On détermine le nombre de jours dans le mois entré pour savoir le maximum de 
            // jours possibles :
            int nbJoursDsMois = NbJoursDsMois(année, mois); 

            LireEntier("\tJour ", "", 1, nbJoursDsMois, out int jour);
            
            date = New(année, mois, jour);

            if (date == null) date = Aujourdhui();

            return true;
        }

        /// <summary>
        /// Renvoie le nombre de jours dans le mois entré.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        /// <returns></returns>
        public static int NbJoursDsMois(this int année, int mois)
        {
            switch (mois)
            {
                // Pour les mois de janvier, mars, mai, juillet, août, octobre et décembre :
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                // Pour le mois de février :
                case 2:
                    return année.EstBissextile() ? 29 : 28;
                // Pour les mois d'avril, juin, septembre et novembre :
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 0;
            }
        }
    }
}
