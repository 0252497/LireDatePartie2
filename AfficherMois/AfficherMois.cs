using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.ConsolePlus;
namespace Prog2
{
    static class AfficherMois
    {
        static void Main(string[] args)
        {
            Title = "AfficherMois";

            // --- Conversion entier/enum ---
            ColorWriteLine(White, "\nConvertion entier-enum :");
            ColorWriteLine(Magenta, $"{Mois.Janvier,8} == {(int) Mois.Janvier}");
            ColorWriteLine(DarkYellow, $"{Mois.Décembre,8} == {(int)Mois.Décembre}");
            ColorWriteLine(DarkGreen, $"{(Mois)4,8} == {4}");
            Debug.Assert((int)Mois.Mars == 3);
            Debug.Assert(Mois.Juin == (Mois)6);

            // --- Addition et soustraction ---
            ColorWriteLine(White, "\nAdditions & soustractions");
            ColorWriteLine(DarkCyan, $"{Mois.Juin} + 1 == {Mois.Juin + 1}");
            ColorWriteLine(DarkCyan, $"{Mois.Août} - 1 == {Mois.Août - 1}");
            Mois mois = Mois.Décembre;
            mois -= 8;
            Debug.Assert(mois == Mois.Avril);
            ColorWriteLine(Blue, $"{Mois.Décembre} - 8 == {mois}");
            ColorWriteLine(DarkGreen, $"{Mois.Août} - {Mois.Avril} == {Mois.Août - Mois.Avril}");

            // --- Comparaisons ---
            ColorWriteLine(White, "\nComparaisons :");
            ColorWriteLine(DarkMagenta, $"({Mois.Mars} == {Mois.Avril}) == {Mois.Mars == Mois.Avril}");
            ColorWriteLine(DarkMagenta, $"({Mois.Mars} != {Mois.Avril}) == {Mois.Mars != Mois.Avril}");
            ColorWriteLine(DarkMagenta, $"({Mois.Mars} < {Mois.Avril}) == {Mois.Mars < Mois.Avril}");
            ColorWriteLine(DarkMagenta, $"({Mois.Mars} > {Mois.Avril}) == {Mois.Mars > Mois.Avril}");

            // --- Étrangetés ---
            ColorWriteLine(White, "\nBizarre... :");
            ColorWriteLine(DarkCyan, $"({Mois.Décembre} + 1 == {Mois.Décembre + 1}");
            ColorWriteLine(DarkCyan, $"({Mois.Décembre} + 2 == {Mois.Décembre + 2}");
            ColorWriteLine(DarkCyan, $"default(Mois) == {default(Mois)}");
            ColorWriteLine(DarkCyan, $"def(Mois) + 1 == {default(Mois) + 1}");
        }
    }
}
