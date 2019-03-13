/* Ce programme permet de lire une date, soit l'année, le mois et le jour, et la fait ensuite afficher en texte.
 * 
 * Auteure : Véronique Giguère
 * Création : 8 février 2019
 */
using static System.Console;
using static Prog2.DateUtil;
using static Prog2.ConsolePlus;
using static Prog2.Date;
using static System.ConsoleColor;

namespace Prog2
{
    static class LireDate
    {
        static void Main(string[] args)
        {
            Title = "LireDate";
            
            Date date;  // La date à reçevoir

            string strArg = string.Join(" ", args); // Les arguments convertis en texte

            if (args.Length == 0)
            {
                if (!LireDate("Entrez une date svp!", out date))
                {
                    MessageErreur($"Date invalide : {strArg}");
                    return;
                }
            }    
            else
            {
                if (!TryParse(strArg, out date))
                {
                    MessageErreur($"Date invalide : {strArg}");
                    return;
                }
            }

            var message = $"\nDate = {EnTexte(date)}";

            message += $"\n\nNB : Cette date est ";

            if (date.EstTrèsSpéciale)
            {
                message += "très spéciale";
            }
            else if (date.EstSpéciale)
            {
                message += "spéciale";
            }
            else
            {
                message += "sans particularité numérologique.";
            }

            message += $"\nPS : L'année {date.Année} ";
            message += date.Année.EstBissextile() ? "est" : "n'est pas";
            message += " bissextile.";

            MessageOk(message);

            // Afficher si Noël, jour de l'an, St-Jean-Baptiste ou pas
            ColorWriteLine(DarkYellow, "\n\nJour de l'an : {0}", date.EstJourDeLAn ? "oui" : "non");
            ColorWriteLine(DarkYellow, "     St-Jean : {0}", date.EstStJean ? "oui" : "non");
            ColorWriteLine(DarkYellow, "        Noël : {0}", date.EstNoël ? "oui" : "non");
            ColorWriteLine(DarkMagenta, $"\n  Jour numéro: {date.JourDeLAnnée}");
        }
    }
}
