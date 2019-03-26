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

            // S'informer sur des objets :
            ColorWrite(DarkCyan, InfoObjet(new Date(2011, 09, 11)));
            ColorWrite(DarkGreen, InfoObjet(new Calendrier(2019, Mois.Mars)));
            ColorWrite(DarkMagenta, InfoObjet("C#"));
            ColorWrite(Cyan, InfoObjet(new object()));
            ColorWrite(Blue, InfoObjet(new List<int>()));
            ColorWrite(Magenta, InfoObjet(new int[0]));

            var tableau1 = new int[0];

        }

        private static string InfoObjet(object obj)
        {
            if (obj == null)
                return "\nobjet: null\n";
            else
            {
                return
                    $"\n 1. objet:              {obj}"
                  + $"\n 2. type d'objet:       {obj.GetType()}"
                  + $"\n 3. type de Date:       {typeof(Date)}"
                  + $"\n 4. type == Date:       {typeof(Date) == obj.GetType()}"
                  + $"\n 5. nom du type:        {obj.GetType().Name}"
                  + $"\n 6. parent:             {obj.GetType().BaseType}"
                  + $"\n 7. parent == object:   {obj.GetType().BaseType == typeof(object)}"
                  + $"\n 7. grand-parents  {obj.GetType().BaseType.BaseType == typeof(object)}"
                  + $"\n 7. parent == object:   {obj.GetType().BaseType == typeof(object)}"
                  + "\n";
            }
        }
    }
}
