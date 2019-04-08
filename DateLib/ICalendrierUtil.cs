/* Fichier d'utilitaires ICalendrierUtil. */
using static System.Console;
using static Prog2.ConsolePlus;
using static System.ConsoleColor;

namespace Prog2
{
    public static class ICalendrierUtil
    {
        // --- Attributs ---

        // Pour le nombre de rangées et de colonnes du calendrier :
        public const int NbRangées = 6;
        public const int NbColonnes = 7;

        // --- Méthodes ---

        /// <summary>
        /// Affiche un calendrier couleur sur la console.
        /// </summary>
        /// <param name="calendrier">le calendrier à afficher</param>
        /// <param name="dateÀSurligner">la date à surligner, null si non fournie</param>
        public static void Afficher(this ICalendrier calendrier, Date dateÀSurligner = null)
        {
            // String avec le mois et l'année pour en connaître sa longueur qui variera 
            // selon la longueur du mois. Comme on connaît la longueur de l'arrière-plan de
            // l'entête, on peut s'assurer qu'elle aura toujours un centrage uniforme :
            string moisAnnée = $"{calendrier.Mois} {calendrier.Année}";
            int longueurBackground = 20;

            Write(" ");

            // Affichage de l'entête :
            BackgroundColor = DarkYellow;
            ColorWriteLine(Black, moisAnnée.PadLeft(((longueurBackground - moisAnnée.Length) / 2)
                + moisAnnée.Length).PadRight(longueurBackground));
            ResetColor();

            // Array de jours qui correspondent aux valeurs des jours de l'enum JourDeLaSemaine...
            int[] jours = { 7, 1, 2, 3, 4, 5, 6 };

            // ... pour en afficher les deux premières lettres de leur contenu en string :
            foreach (int jour in jours)
            {
                ColorWrite(DarkYellow, $" {((JourDeLaSemaine)jour).ToString().Substring(0, 2)}");
            }

            WriteLine();

            // Affichage du calendrier, avec la date entrée surlignée, si celle-ci est spécifiée en 
            // paramètre :
            for (int rangée = 0; rangée < NbRangées; ++rangée)
            {
                for (int colonne = 0; colonne < NbColonnes; ++colonne)
                {
                    if (calendrier[rangée, colonne] != 0)
                    {
                        if (calendrier.Localiser(
                            dateÀSurligner, out int rangéeDate, out int colonneDate) &&
                            rangée == rangéeDate && colonne == colonneDate)
                        {
                            Write(" ");
                            BackgroundColor = Green;
                            ColorWrite(Black, "{0, 2}", calendrier[rangée, colonne]);
                            ResetColor();
                        }
                        else
                        {
                            Write("{0, 3}", calendrier[rangée, colonne]);
                        }
                    }
                    else
                    {
                        Write("{0, 3}", ".");
                    }
                }

                WriteLine();
            }
        }
    }
}
