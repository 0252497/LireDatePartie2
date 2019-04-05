using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static Prog2.Mois;
using System.Collections.Generic;
using static Prog2.Date;
using static Prog2.IEnumerableUtil;
using static System.ConsoleColor;
using System.Linq;

namespace Prog2
{
    static class AfficherÉnumérable
    {
        static void Main(string[] args)
        {
            Title = "Afficher Énumérable";

            Date date = new Date();

            object              objet = date;
            IEquatable<Date>    equatable = date;
            IComparable<Date>   comparable = date;
            IFormattable        formattable = date;

            Afficher("Même objet",
                ReferenceEquals(date, objet) &&
                ReferenceEquals(objet, equatable) &&
                ReferenceEquals(equatable, comparable) &&
                ReferenceEquals(comparable, formattable));
            
            ICalendrier cal = new Calendrier(2000, Mai);

            // IEnumerable polymorphe 1 :
            int[] impairs = new[] { 1, 3, 5, 7, 9 };
            List<int> pairs = new List<int> { 2, 4, 6, 8, 10 };
            IEnumerable<int> entiers;
            
            // IEnumerable et foreach :
            Write("\nEntiers: ");
            entiers = pairs;

            foreach (int entier in entiers)
                Write(entier + " ");

            entiers = impairs;

            foreach (int entier in entiers)
                Write(entier + " ");

            WriteLine();

            Write("\nEntiers: ");
            WriteAll(pairs);
            WriteAll(impairs);

            WriteLine();

            WriteLine($"\nEntiers: " + EnTexte(pairs) + " " + EnTexte(impairs));

            // IEnumerable polymorphe 2
            char[] voyelles = new[] { 'a', 'e', 'i', 'o', 'u' };
            List<char> consonnes = new List<char> { 'b', 'c', 'd', 'f', 'g' };
            string chiffres = "12345";
            IEnumerable<char> caractères;
            caractères = voyelles;
            caractères = consonnes; caractères = chiffres;

            Write("\nCaractères: ");
            WriteAllChar(voyelles);
            WriteAllChar(consonnes);
            WriteAllChar(chiffres);
            WriteLine();

            Write("\nAny: ");
            WriteAny(new[] { 1, 2, 3 });    // T = int
            WriteAny(new List<bool> { true, true, false });    // T = bool
            WriteAny("C#");    // T = char
            WriteAny(new[] { Hier, Demain });    // T = Date

            WriteLine();

            // Utiliser EnTexte générique :
            Afficher("Voyelles", "aeiouy".EnTexte());
            Afficher("Nombres", new[] { 10, 20, 30, 40 }.EnTexte(", "), 
                couleurValeur: Green);
            Afficher("Dates", 
                "\n" + new[] { Hier, Aujourdhui, Demain }.EnTexte("", " * ", "\n"), 
                couleurValeur: DarkYellow);

            // Utiliser les prédicats :
            Afficher("12 est pair", 12.EstPair());
            Afficher("80 est impair", 12.EstImpair());
            Afficher("80 est divisible par 5", 80.EstDivisiblePar5());
            Afficher("80 est divisible par 8", 80.EstDivisiblePar(8));
            Afficher("C# contient #", "C#".Contient('#'));

            // Utiliser les types fonctionnels :
            WriteLine();
            Func<int, bool> estQuoi;
            estQuoi = EstPair;
            Afficher("12 est pair", estQuoi(12));
            estQuoi = EstImpair;
            Afficher("80 est impair", estQuoi(80));
            estQuoi = EstDivisiblePar5;
            Afficher("80 est divisible par 5", estQuoi(80));

            // Type fonctionnel en argument :
            WriteLine();

            void opérerSur50et10(Func<int, int, int> opérerSur)
            {
                Afficher("Résultat", opérerSur(50, 10));
            }

            opérerSur50et10(Somme);
            opérerSur50et10(Soustraction);
            opérerSur50et10(Multiplication);
            opérerSur50et10(Division);

            WriteLine();

            // Lambdas en argument :
            opérerSur50et10((a, b) => a + b);
            opérerSur50et10((a, b) => a - b);
            opérerSur50et10((a, b) => a * b);
            opérerSur50et10((a, b) => a / b);

            // Lambda dans une variable :
            WriteLine();
            estQuoi = n => n % 7 == 0;
            Afficher("91 est divisible par 7", estQuoi(91));
            Func<int, int> carréDe = n => n * n;
            Afficher("Le carré de 12 est", carréDe(12));

            WriteLine();

            // Périmètre d'un rectangle :
            opérerSur50et10((a, b) => 2 * a + 2 * b);

            // Calcul des pièces d'or :
            opérerSur50et10((a, b) => 13 * a + 27 * b);

            WriteLine();

            // LINQ: All et Any
            WriteLine();
            Afficher("         Nombres", impairs.EnTexte());
            Afficher("    Tous impairs", impairs.All(EstImpair));
            Afficher("       Tous < 10", impairs.All(n => n < 10));
            Afficher("        Tous < 5", impairs.All(n => n < 5));
            Afficher(" Au moins un < 5", impairs.Any(n => n < 5));
            Afficher("Au moins un pair", impairs.Any(EstPair));
            Afficher("        Pas vide", impairs.Any());

            // LINQ: Max, Min, Average, First, Last
            WriteLine();
            var nombres = new int[] { 3, 2, 7, 4, 1, 5 };
            Afficher("     Nombres", nombres.EnTexte());
            Afficher("         Max", nombres.Max());
            Afficher("         Min", nombres.Min());
            Afficher("     Moyenne", nombres.Average());
            Afficher("       First", nombres.First());
            Afficher("        Last", nombres.Last());
            Afficher("  First pair", nombres.First(EstPair));
            Afficher("   Last pair", nombres.Last(EstPair));
            Afficher("   Last > 10", nombres.LastOrDefault(n => n > 10));

            // LINQ: Reverse, Skip, Take
            WriteLine();
            var lettres = "ABCDEFG";
            Afficher("Lettres", lettres.EnTexte(), couleurValeur: ConsoleColor.DarkYellow);
            Afficher("Reverse", lettres.Reverse().EnTexte());
            Afficher("Skip 2", lettres.Skip(2));
            Afficher("Take 3", lettres.Take(3).EnTexte());
            Afficher("Skip 2 Take3", lettres.Skip(2).Take(3).EnTexte());

            // LINQ: Count, Distinct
            WriteLine();
            lettres = "abracadabra";
            Afficher("    Lettres", lettres.EnTexte(), couleurValeur: ConsoleColor.DarkYellow);
            Afficher("      Count", lettres.Count());
            Afficher("    Nb de a", lettres.Count(c => c == 'a'));
            Afficher("   Distinct", lettres.Distinct().EnTexte());
            Afficher("Dist. Count", lettres.Distinct().Count());

            // LINQ: ElementAt, ToString, ToList
            WriteLine();
            nombres = new int[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(2).ToArray();
            Afficher("    Nombres", nombres.EnTexte(), couleurValeur: ConsoleColor.DarkYellow);
            Afficher("Element  #1", nombres.ElementAt(1));
            Afficher("Element #10", nombres.ElementAtOrDefault(10));

            // LINQ: Where, Select, OrderBy
            WriteLine();
            nombres = new int[] { 3, 2, 7, 4, 1, 5 };
            Afficher("  Nombres", nombres.EnTexte(), couleurValeur: ConsoleColor.DarkYellow);
            Afficher("    pairs", nombres.Where(EstPair).EnTexte());
            Afficher("  impairs", nombres.Where(EstImpair).EnTexte());
            Afficher("   plus 1", nombres.Select(n => n + 1).EnTexte());
            Afficher("  doubler", nombres.Select(n => 2 * n).EnTexte());
            Afficher("croissant", nombres.OrderBy(n => n).EnTexte());
            Afficher("décrois 1", nombres.OrderBy(n => -n).EnTexte());
            Afficher("décrois 2", nombres.OrderByDescending(n => n).EnTexte());
            // Doubler seulement les impairs et les placer en ordre croissants
            Afficher(" la total", nombres.Where(EstImpair).Select(n => n * 2).OrderBy(n => n).EnTexte());
            // LINQ: Chaînage de méthodes d'extension
            var chaînage = nombres.Where(EstImpair).OrderBy(n => n).Select(n => n * 2);

            // LINQ: langage de requête
            var requête = from n in nombres where n % 2 == 1 orderby n select n * 2;

            Afficher("la totale (chaînage)", chaînage.EnTexte());
            Afficher("la totale  (requête)", requête.EnTexte());

            // Utiliser des fonctions génératrices :
            WriteLine();
            Afficher("  Générer 123", Générer123().EnTexte());
            var énumérateur = Générer123().GetEnumerator();
            while (énumérateur.MoveNext())
                Afficher("        Appel", énumérateur.Current);
            foreach (var courant in Générer123())
                Afficher("      Courant", courant);
            Afficher("Générer 5 à 10", GénérerEntiers(5, 10).EnTexte());
        }

        // Fonction génératrice simple :
        static IEnumerable<int> Générer123()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static string EnTexte(IEnumerable<int> p_entiers, string séparateur = " ")
            => string.Join(séparateur, p_entiers);

        // Méthode générique :
        static void WriteAny<T>(IEnumerable<T> elems, string séparateur = " ")
        {
            foreach (T elem in elems)
            {
                Write(elem + séparateur);
            }
        }

        static IEnumerable<int> GénérerEntiers(int début, int fin)
        {
            for (int i = début; i <= fin; ++i)
            {
                yield return i;
            }
        }

        // Paramètres IEnumerable 3
        static void WriteAllChar(IEnumerable<char> p_chars, string séparateur = " ")
        {
            foreach (char c in p_chars)
            {
                Write(c + séparateur);
            }
        }

        // Paramètre IEnumerable 1
        static void WriteAll(IEnumerable<int> p_entiers, string séparateur = " ")
        {
            foreach (int entier in p_entiers)
            {
                Write(entier + séparateur);
            }
        }

        // Prédicats :
        static bool EstPair(this int i)                         => i % 2 == 0;
        static bool EstImpair(this int i)                       => !EstPair(i);
        static bool EstDivisiblePar5(this int i)                => i % 5 == 0;
        static bool EstDivisiblePar(this int i, int diviseur)   => i % diviseur == 0;
        static bool Contient(this string S, char c)             => S.IndexOf(c) >= 0;

        // Opérations arithmétiques  :
        static int Somme(int i, int j)          => i + j;
        static int Soustraction(int i, int j)   => i - j;
        static int Multiplication(int i, int j) => i * j;
        static int Division(int i, int j)       => i / j;
    }
}
