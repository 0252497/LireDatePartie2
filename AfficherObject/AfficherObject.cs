using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.DateUtil;
using static Prog2.Date;
using static System.Int32;
using System.Collections.Generic;
using System.Linq;
using static System.String;
using System.Diagnostics;

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

            ColorWriteLine(DarkCyan, $"date: {date}");

            obj = date;
            ColorWriteLine(Cyan, $"obj: {obj}");

            obj = "C#";
            ColorWriteLine(Cyan, $"obj: {obj}");

            obj = 5;
            ColorWriteLine(Cyan, $"obj: {obj}");

            obj = null;
            ColorWriteLine(Cyan, $"obj: {obj}");

            obj = "C#";
            ColorWriteLine(Cyan, $"obj: {obj}");

            // Caster depuis object
            obj = date;
            date = (Date)obj;

            // Mauvais cast avec interception
            obj = 5;
            
            try { date = (Date)obj; }
            catch (InvalidCastException) { };

            // Utiliser l'opérateur as
            obj = date;
            date = obj as Date;
            Debug.Assert(date != null);

            // Si le type est mauvais, as donne null
            obj = 5;
            date = obj as Date;
            Debug.Assert(date == null);
        }
    }
}
