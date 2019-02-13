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
                ColorWriteLine(Green, $"\nDate = {EnTexte(date, "/")}");
            }

            ColorWrite(Green, "\nNB : Cette date est ");

            if (EstTrèsSpéciale(date))
            {
                MessageOk("très spéciale\n");
            }
            else if (EstSpéciale(date))
            {
                MessageOk("spéciale\n");
            }
            else
            {
                MessageOk("sans particularité numérologique\n");
            }
        }
    }
}
