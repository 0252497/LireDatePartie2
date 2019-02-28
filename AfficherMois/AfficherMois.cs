using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.ConsolePlus;
using static Prog2.Mois;

namespace Prog2
{
    static class AfficherMois
    {
        static void Main(string[] args)
        {
            Title = "AfficherMois";

            // --- Conversion entier/enum ---
            ColorWriteLine(White, "\nConvertion entier-enum :");
            ColorWriteLine(Magenta, $"{Janvier,8} == {(int) Janvier}");
            ColorWriteLine(DarkYellow, $"{Décembre,8} == {(int)Décembre}");
            ColorWriteLine(DarkGreen, $"{(Mois)4,8} == {4}");
            Debug.Assert((int)Mars == 3);
            Debug.Assert(Juin == (Mois)6);

            // --- Addition et soustraction ---
            ColorWriteLine(White, "\nAdditions & soustractions");
            ColorWriteLine(DarkCyan, $"{Juin} + 1 == {Juin + 1}");
            ColorWriteLine(DarkCyan, $"{Août} - 1 == {Août - 1}");
            Mois mois = Décembre;
            mois -= 8;
            Debug.Assert(mois == Avril);
            ColorWriteLine(Blue, $"{Décembre} - 8 == {mois}");
            ColorWriteLine(DarkGreen, $"{Août} - {Avril} == {Août - Avril}");

            // --- Comparaisons ---
            ColorWriteLine(White, "\nComparaisons :");
            ColorWriteLine(DarkMagenta, $"({Mars} == {Avril}) == {Mars == Avril}");
            ColorWriteLine(DarkMagenta, $"({Mars} != {Avril}) == {Mars != Avril}");
            ColorWriteLine(DarkMagenta, $"({Mars} < {Avril}) == {Mars < Avril}");
            ColorWriteLine(DarkMagenta, $"({Mars} > {Avril}) == {Mars > Avril}");

            // --- Étrangetés ---
            ColorWriteLine(White, "\nBizarre... :");
            ColorWriteLine(DarkCyan, $"({Décembre} + 1 == {Décembre + 1}");
            ColorWriteLine(DarkCyan, $"({Décembre} + 2 == {Décembre + 2}");
            ColorWriteLine(DarkCyan, $"default(Mois) == {default(Mois)}");
            ColorWriteLine(DarkCyan, $"def(Mois) + 1 == {default(Mois) + 1}");

            // --- Énumération ---
            ColorWrite(White, "\nLes mois sont : ");

            for (Mois m = Janvier; m <= Décembre; ++m)
            {
                ColorWrite(DarkRed, $"{m} ");
            }

            ColorWrite(DarkGray, "\nLes mois sont : ");

            foreach (Mois m in Enum.GetValues(typeof(Mois)))
            {
                ColorWrite(DarkYellow, $"{m} ");
            }
        }
    }
}
