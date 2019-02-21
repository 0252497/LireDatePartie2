using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    public static class NomsDesMois
    {
        public const string
            Janvier     =   "janvier",
            Février     =   "février",
            Mars        =   "mars",
            Avril       =   "avril",
            Mai         =   "mai",
            Juin        =   "juin",
            Juillet     =   "juillet",
            Août        =   "août",
            Septembre   =   "septembre",
            Octobre     =   "octobre",
            Novembre    =   "novembre",
            Décembre    =   "décembre";

        /// <summary>
        /// Convertir un mois numérique en string.
        /// </summary>
        /// <param name="mois">le mois (1 = janvier)</param>
        /// <returns>le nom du mois, ou null si le mois numérique n'est pas valide</returns>
        public static string Convertir1(int mois)
        {
            switch (mois)
            {
                case 1:
                    return Janvier;
                case 2:
                    return Février;
                case 3:
                    return Mars;
                case 4:
                    return Avril;
                case 5:
                    return Mai;
                case 6:
                    return Juin;
                case 7:
                    return Juillet;
                case 8:
                    return Août;
                case 9:
                    return Septembre;
                case 10:
                    return Octobre;
                case 11:
                    return Novembre;
                case 12:
                    return Décembre;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convertit un mois numérique en string.
        /// </summary>
        /// <param name="mois">le mois (1 = janvier)</param>
        /// <returns>le nom du mois, ou null si le mois numérique n'est pas valide</returns>
        public static string Convertir2(int mois)
        {
            if (1 > mois || mois > 12)
                return null;
            else
                // Utiliser la table de conversion
                return ListeDesMois[mois - 1];
        }

        /// <summary>
        /// Convertit un mois numérique en string.
        /// </summary>
        /// <param name="mois">le mois (1 = janvier)</param>
        /// <returns></returns>
        public static string Convertir3(int mois)
        {
            if (1 > mois || mois > 12)
                return null;
            else
                // Utiliser la table de conversion
                return ListeDesMois[mois - 1];
        }

        // --- Tables de conversion ---

        public static readonly List<string>
            ListeDesMois = new List<string>
        {
                Janvier,
                Février,
                Mars,
                Avril,
                Mai,
                Juin,
                Juillet,
                Août,
                Septembre,
                Octobre,
                Novembre,
                Décembre,
        };

        public static readonly string[]
            TableauDesMois = new string[]
        {

        };
    }
}
