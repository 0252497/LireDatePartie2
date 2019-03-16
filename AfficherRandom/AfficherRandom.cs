using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.DateUtil;
using static Prog2.Date;
using static System.Int32;
using System.Collections.Generic;
using System.Linq;

namespace Prog2
{
    static class AfficherRandom
    {
        static void Main(string[] args)
        {
            Title = "Afficher Random --- Nombres Aléatoires";

            LireEntier("Germe", "0", out int germe);
            LireEntier("Quantité", "10", out int quantitéNb);
            LireEntier("Nb faces", "6", out int nbFacesDuDé);

            ColorWriteLine(DarkYellow, $"\nGerme : {germe}");

            var random = new Random(germe);

            ColorWriteLine(Cyan, $"Nombres aléatoires de 1 à 6");

            List<int> nombres = new List<int>();
            
            for (int i = 0; i < quantitéNb; ++i)
            {
                var dé6 = random.Next(1, nbFacesDuDé + 1);
                nombres.Add(dé6);
                Write($" {dé6}");
            }

            WriteLine("\n");

            for (int i = 1; i <= nbFacesDuDé; ++i)
            {
                ColorWriteLine(Magenta, $"#{i} = {nombres.Count(n => n == i)}");
            }

            WriteLine();
        }
    }
}
