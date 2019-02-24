﻿/* Fichier de méthodes DateUtil. */

using static Prog2.ConsolePlus;
using static System.ConsoleColor;
using static Prog2.Date;

namespace Prog2
{
    public static class DateUtil
    {
        const int MoisMin = 1;
        const int MoisMax = 12;

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
            LireMois("\tMois ", "", out int mois);

            // On détermine le nombre de jours dans le mois entré pour savoir le maximum de 
            // jours possibles :
            int nbJoursDsMois = NbJoursDsMois(année, mois); 

            LireEntier("\tJour ", "", 1, nbJoursDsMois, out int jour);
            
            date = New(année, mois, jour);

            if (date == null)
                date = Aujourdhui();

            return true;
        }

        /// <summary>
        /// Lis un mois sur la console.
        /// </summary>
        /// <param name="propriété">nom de la propriété à afficher</param>
        /// <param name="défaut">valeur par défaut (null si aucune)</param>
        /// <param name="mois">le mois lu</param>
        /// <returns>vrai si ça marche</returns>
        public static bool LireMois(string propriété, string défaut, out int mois) 
            => TryParseMois(Demander(propriété, défaut), out mois) ? true : false;

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

        /// <summary>
        /// Tente d'interpréter une string comme un mois. Le texte peut être un texte ou une nombre.
        /// </summary>
        /// <param name="strMois">le mois sous forme de texte</param>
        /// <param name="mois">le mois numérique</param>
        /// <returns>vrai si l'interprétation a réussi</returns>
        public static bool TryParseMois(this string strMois, out int mois)
        {
            strMois = strMois.Trim();

            if (strMois == "")
                mois = 0;
            else
            {
                char caractère = strMois.ToCharArray()[0];

                if (char.IsLetter(caractère))
                {
                    mois = NomsDesMois.NuméroDuMois5(strMois);
                }
                else if (char.IsDigit(caractère))
                {
                    int.TryParse(strMois, out mois);

                    if (mois < 1 || 12 < mois)
                        mois = 0;
                }
                else
                {
                    mois = 0;
                }
            }

            return mois != 0 ? true : false;
        }
    }
}
