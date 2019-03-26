using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Prog2.ConsolePlus;
using static System.ConsoleColor;

namespace Prog2
{
    static class AfficherObject
    {
        static void Main(string[] args)
        {
            Title = "Afficher Object";

            object obj = new object();

            ColorWriteLine(Cyan, $"obj: {obj}");

            Date date = new Date(2011, 09, 11);

            ColorWriteLine(DarkCyan, "date: {date}");
        }
    }
}
