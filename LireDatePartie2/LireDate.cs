/* Ce programme permet de lire une date, soit l'année, le mois et le jour, et la fait ensuite afficher en texte.
 * 
 * Auteure : Véronique Giguère
 * 
 * Création : 8 février 2019
 */

using static System.Console;
using static Prog2.DateUtil;
using static Prog2.ConsolePlus;
using static System.ConsoleColor;
using static Prog2.Date;

namespace Prog2
{
    static class LireDate
    {
        static void Main(string[] args)
        {
            Title = "LireDate";

            if (LireDate("Entrez une date svp!", out Date date))
            {
                if (date == null) date = Aujourdhui();

                var message = $"\nDate = {EnTexte(date)}";

                message += $"\n\nNB : Cette date est ";

                if (date.EstTrèsSpéciale())
                    message += "très spéciale";
                else if (date.EstSpéciale())
                    message += "spéciale";
                else
                    message += "sans particularité numérologique.";

                message += $"\nPS : L'année {date.Année} ";
                message += date.Année.EstBissextile() ? "est" : "n'est pas";
                message += " bissextile.";

                MessageOk(message);
            }
        }
    }
}
