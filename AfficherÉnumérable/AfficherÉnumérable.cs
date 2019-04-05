using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static Prog2.Mois;
using System.Collections.Generic;
using static Prog2.Date;
using static Prog2.IEnumerableUtil;
using static System.ConsoleColor;

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
