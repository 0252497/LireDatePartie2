/* Fichier pour les attributs et les méthodes de la classe Date. */
namespace Prog2
{
    /// <summary>
    /// Classe Date.
    /// </summary>
    public class Date
    {
        public int Année;
        public int Mois;
        public int Jour;

        /// <summary>
        /// Renvoie en texte l'année, le mois et le jour de la date lue avec le séparateur choisi.
        /// </summary>
        /// <param name="date">la date lue</param>
        /// <param name="séparateur">le séparateur désiré</param>
        /// <returns></returns>
        public static string EnTexte(Date date, string séparateur = "-")
            => string.Format("{0:D4}{3}{1:D2}{3}{2:D2}", date.Année, date.Mois, date.Jour, séparateur);

        /// <summary>
        /// Pour savoir si une date est spéciale. Une date est spéciale si le mois et le jour sont
        /// identiques.
        /// </summary>
        /// <param name="date">la date</param>
        /// <returns>vrai si elle est spéciale</returns>
        public static bool EstSpéciale(Date date) => date.Jour == date.Mois;

        /// <summary>
        /// Pour savoir si une date est très spéciale. Une date est très spéciale si le jour, le mois et
        /// les deux derniers chiffres de l'année sont identiques.
        /// </summary>
        /// <param name="date">la date</param>
        /// <returns>vrai si elle est très spéciale</returns>
        public static bool EstTrèsSpéciale(Date date)
            => EstSpéciale(date) && date.Mois == date.Année % 100;

        /// <summary>
        /// Pour aider à construire une nouvelle date.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois, 1 = janvier</param>
        /// <param name="jour">le jour du mois</param>
        /// <returns>une nouvelle date</returns>
        public static Date New(int année, int mois, int jour)
            => new Date { Année = année, Mois = mois, Jour = jour };

        /// <summary>
        /// Pour vérifier que deux dates sont pareilles.
        /// </summary>
        /// <param name="date1">première date</param>
        /// <param name="date2">deuxième date</param>
        /// <returns>vrai si égales</returns>
        public static bool SontÉgales(Date date1, Date date2)
            => date1.Année == date2.Année && date1.Mois == date2.Mois && date1.Jour == date2.Jour;

        /// <summary>
        /// Pour cloner une date en modifiant certains attributs au besoin.
        /// </summary>
        /// <param name="date">date à cloner</param>
        /// <param name="année">année modifiée au besoin</param>
        /// <param name="mois">mois modifié au besoin</param>
        /// <param name="jour">jour modifié au besoin</param>
        /// <returns>la date clonée</returns>
        public static Date Cloner(Date date, int année = 0, int mois = 0, int jour = 0)
        {
            if (année > 0)
            {
                date.Année = année;
            }
            else
            {
                année = date.Année;
            }

            if (mois > 0)
            {
                date.Mois = mois;
            }
            else
            {
                mois = date.Mois;
            }

            if (jour > 0)
            {
                date.Jour = jour;
            }
            else
            {
                jour = date.Jour;
            }

            return date;
        }
    }
}