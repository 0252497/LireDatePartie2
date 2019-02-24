using System;
using System.Collections.Generic;
using static System.String;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    public static class NomsDesMois
    {
        public const string
            Janvier = "janvier",
            Février = "février",
            Mars = "mars",
            Avril = "avril",
            Mai = "mai",
            Juin = "juin",
            Juillet = "juillet",
            Août = "août",
            Septembre = "septembre",
            Octobre = "octobre",
            Novembre = "novembre",
            Décembre = "décembre";

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

        // --- Méthodes ---

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
        /// <returns>le nom du mois, ou null si le mois numérique n'est pas valide</returns>
        public static string Convertir3(int mois)
        {
            if (1 > mois || mois > 12)
                return null;
            else
                // Utiliser la table de conversion
                return TableauDesMois[mois - 1];
        }

        /// <summary>
        /// Obtient le numéro correspondant au nom du mois spécifié.
        /// </summary>
        /// <param name="nom">le nom du mois</param>
        /// <returns>le numéro du mois ou zéro s'il n'existe pas</returns>
        public static int NuméroDuMois1(string nom) 
            => ListeDesMois.IndexOf(nom) + 1;

        /// <summary>
        /// Obtient le numéro correspondant au nom du mois spécifié.
        /// </summary>
        /// <param name="nom">le nom du mois</param>
        /// <returns>le numéro du mois ou zéro s'il n'existe pas</returns>
        public static int NuméroDuMois2(string nom) 
            => Array.IndexOf(TableauDesMois, nom) + 1;

        /// <summary>
        /// Obtient le numéro correspondant au nom du mois spécifié. Insensible à la casse. 
        /// </summary>
        /// <param name="nom">le nom du mois</param>
        /// <returns>le numéro du mois ou zéro s'il n'existe pas</returns>
        public static int NuméroDuMois3(string nom) 
            => Array.IndexOf(TableauDesMois, nom.ToLower()) + 1;

        /// <summary>
        /// Obtient le numéro correspondant au nom du mois spécifié. Les accents et la casse ne comptent pas
        /// pour la recherche.
        /// </summary>
        /// <param name="nom">le nom du mois</param>
        /// <returns>le numéro du mois ou zéro s'il n'existe pas</returns>
        public static int NuméroDuMois4(string nom)
        {
            var nomMois = "";

            foreach (var mois in TableauDesMois)
            {
                if (string.Equals(mois.SansAccents(), nom.SansAccents(), StringComparison.OrdinalIgnoreCase))
                    nomMois = mois;
            }

            if (nomMois == "")
            {
                return 0;
            }
            else
            {
                return Array.IndexOf(TableauDesMois, nomMois) + 1;
            }
        }

        /// <summary>
        /// Obtient le numéro correspondant au nom du mois spécifié. Les accents et la casse ne comptent pas
        /// pour la recherche. On peut spécifier uniquement le début du mois, mais il ne doit pas y avoir 
        /// d'ambiguïté.
        /// </summary>
        /// <param name="nom">le nom du mois</param>
        /// <returns>le numéro du mois ou zéro si non trouvé</returns>
        public static int NuméroDuMois5(string nom)
        {
            var tour = 0;
            var nomMois = "";

            foreach (var mois in TableauDesMois)
            {
                if (mois.SansAccents().StartsWith(nom.ToLower().SansAccents()))
                {
                    ++tour;
                    nomMois = mois;
                }
            }
            if (tour > 1)
            {
                return 0;
            }

            return Array.IndexOf(TableauDesMois, nomMois) + 1;
        }
    }
}
