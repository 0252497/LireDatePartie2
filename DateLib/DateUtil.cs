/* Fichier de méthodes DateUtil. */

using static Prog2.ConsolePlus;
using static System.ConsoleColor;
using static Prog2.Date;
using System;

namespace Prog2
{
    public static class DateUtil
    {
        // --- Attributs ---
        public static readonly Date DateAttentatWTC = Date.New(2001, 09, 11);
        public static readonly Date DateDecesMJ = Date.New(2012, 01, 31);
        public static readonly Date DateExplosionNC = Date.New(2018, 07, 11);

        // --- Méthodes ---

        /// <summary>
        /// Pour cloner une date en modifiant certains attributs au besoin.
        /// </summary>
        /// <param name="date">date à cloner</param>
        /// <param name="année">année modifiée au besoin</param>
        /// <param name="mois">mois modifié au besoin</param>
        /// <param name="jour">jour modifié au besoin</param>
        /// <returns>la date clonée</returns>
        public static Date Cloner(this Date date, int année = 0, int mois = 0, int jour = 0)
        {
            Date clone = New(date.Année, date.Mois, date.Jour); // On clone la date entrée

            if (année > 0)
            {
                clone.Année = année;
            }

            if (mois > 0)
            {
                clone.Mois = mois;
            }

            if (jour > 0)
            {
                clone.Jour = jour;
            }

            return clone;
        }

        /// <summary>
        /// Renvoie si une année est bissextile.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <returns>vrai si l'année est bissextile</returns>
        public static bool EstBissextile(this int année) 
            => année % 4 == 0 && année % 100 != 0 || année % 400 == 0 ? true : false;

        /// <summary>
        /// Pour savoir si une date est spéciale. Une date est spéciale si le mois et le jour sont
        /// identiques.
        /// </summary>
        /// <param name="date">la date</param>
        /// <returns>vrai si elle est spéciale</returns>
        public static bool EstSpéciale(this Date date)
            => date.Jour == date.Mois;

        /// <summary>
        /// Pour savoir si une date est très spéciale. Une date est très spéciale si le jour, le mois et
        /// les deux derniers chiffres de l'année sont identiques.
        /// </summary>
        /// <param name="date">la date</param>
        /// <returns>vrai si elle est très spéciale</returns>
        public static bool EstTrèsSpéciale(this Date date)
            => EstSpéciale(date) && date.Mois == date.Année % 100;

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

        /// <summary>
        /// Renvoie le nombre de jours dans le mois entré.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        /// <returns></returns>
        public static int NbJoursDsMois(this int année, int mois)
        {
            int joursDsMois;    // Le nombre de jours selon le mois

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
                    joursDsMois = 31;
                    break;
                // Pour le mois de février :
                case 2:
                    joursDsMois = année.EstBissextile() ? 29 : 28;
                    break;
                // Pour les mois d'avril, juin, septembre et novembre :
                case 4:
                case 6:
                case 9:
                case 11:
                    joursDsMois = 30;
                    break;
                default:
                    joursDsMois = 0;
                    break;
            }

            return joursDsMois;
        }
    }
}
