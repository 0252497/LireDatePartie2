/* Programme qui fait afficher des dates et des calendriers aléatoires dans un certain ordre et dans
 * un certain format grâce aux interfaces.  
 */
using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.DateUtil;
using static Prog2.Date;
using System.Collections.Generic;
using static Prog2.Mois;
using System.Diagnostics;

namespace Prog2
{
    static class AfficherEnOrdre
    {
        static void Main(string[] args)
        {
            // Tableau de dates aléatoires :
            Date[] datesAléatoires = new Date[10];

            // Random pour nos dates et calendriers aléatoires :
            Random random = new Random();

            WriteLine("Dix dates aléatoires:");

            for (int i = 0; i < datesAléatoires.Length; ++i)
            {
                datesAléatoires[i] = Aléatoire(random, new Date("1700-01-01"), Aujourdhui);
                ColorWriteLine(DarkYellow, $"  * {datesAléatoires[i]}");
            }
           
            Array.Sort(datesAléatoires, (a,b) => b.ComparerAvec(a));

            WriteLine("\nDix dates aléatoires (après sort lambda):");

            foreach (Date date in datesAléatoires)
            {
                ColorWriteLine(DarkCyan, $"  * {date}");
            }

            Array.Sort(datesAléatoires);

            WriteLine("\nDix dates aléatoires (après sort sans lambda):");

            foreach (Date date in datesAléatoires)
            {
                ColorWriteLine(Green, $"  * {date}");
            }

            // Liste de calendriers aléatoires :
            List<Calendrier> calendriersAléatoires = new List<Calendrier>();

            WriteLine("\nDix calendriers aléatoires (après sort):");

            for (int i = 0; i < 10; ++i)
            {
                calendriersAléatoires.Add(
                    new Calendrier(random.Next(1700, Aujourdhui.Année + 1), 
                    (Mois)random.Next((int)Janvier, (int)Décembre) + 1));
            }

            calendriersAléatoires.Sort();

            foreach (Calendrier calendrier in calendriersAléatoires)
            {
                ColorWriteLine(Magenta, $"  * {calendrier}");
            }

            WriteLine();

            // Validations :
            var cal199903 = new Calendrier(1999, Mars);
            var cal199905 = new Calendrier(1999, Mai);
            var cal200005 = new Calendrier(2000, Mai);

            Debug.Assert(cal199903 < cal199905);
            Debug.Assert(cal199905 < cal200005);
            Debug.Assert(cal199903 <= cal199905);
            Debug.Assert(cal199905 > cal199903);
            Debug.Assert(cal199905 >= cal199903);
            Debug.Assert(cal200005 > cal199905);
        }
    }
}
