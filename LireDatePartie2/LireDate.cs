/* Ce programme permet de lire une date, soit l'année, le mois et le jour, et la fait ensuite afficher en texte.
 * Il permet aussi l'affichage de différents formats, validations, et le calendrier associé à cette date.
 */
using static System.Console;
using static Prog2.DateUtil;
using static Prog2.ConsolePlus;
using static Prog2.Date;
using static System.ConsoleColor;
using System.Diagnostics;
using System.Collections.Generic;
using System;

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
                if (!LireDate("Date à analyser", "1000-01-01", "3000-12-31", out date))
                {
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

            WriteLine();

            // Affichage IFormattable :
            Afficher("   Format G", $"{date:G}");
            Afficher("   Format -", $"{date:-}");
            Afficher("   Format L", $"{date:L}");
            Afficher("   Format S", $"{date:S}", couleurValeur: Magenta);
            Afficher("   Format .", $"{date:.}", couleurValeur: Magenta);
            Afficher("   Format /", $"{date:/}", couleurValeur: Magenta);

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

            // Afficher si Noël, jour de l'an, St-Jean-Baptiste ou pas, et le jour de l'année :
            ColorWriteLine(DarkYellow,   $" \n\n Jour de l'an : {date.EstJourDeLAn.OuiNon()}");
            ColorWriteLine(DarkYellow,   $"      St-Jean : {date.EstStJean.OuiNon()}");
            ColorWriteLine(DarkYellow,   $"         Noël : {date.EstNoël.OuiNon()}");
            ColorWriteLine(Magenta,      $"  Jour numéro : {date.JourDeLAnnée}");
            ColorWriteLine(Blue,         $" Jour semaine : {date.JourDeLaSemaine}");

            try
            {
                ColorWriteLine(Cyan,     $"  Dans 3 mois : {date.ModifierMois(n => n + 3)}");
            }
            catch (ArgumentOutOfRangeException)
            {
                ColorWriteLine(Red,     $"   Dans 3 mois : date impossible");
            }

            WriteLine("");

            // Afficher le calendrier :
            Calendrier calendrier = new Calendrier(date.Année, date.MoisTypé);
            calendrier.Afficher(date);
            WriteLine("");

            // Utiliser ICalendrier :
            Debug.Assert(calendrier is object);
            Debug.Assert(calendrier is Calendrier);
            Debug.Assert(calendrier is ICalendrier);
            ICalendrier ical = default(ICalendrier);
            Debug.Assert(ical == null);

            Poursuivre();
        }
    }
}
