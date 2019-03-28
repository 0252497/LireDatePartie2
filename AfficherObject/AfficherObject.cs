/* Programme permettant l'affichage de différents objets. */
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
            ColorWrite(DarkRed, InfoObjet(new ArgumentException()));
            ColorWrite(DarkYellow, InfoObjet(5));       // boxage
            ColorWrite(Yellow, InfoObjet(true));        // boxage
            ColorWrite(Green, InfoObjet(Mois.Mars));    // boxage

            var tableau1 = new int[0];

            // Opérateur is :
            obj = true;
            Debug.Assert(obj is object);
            Debug.Assert(obj is Object);
            Debug.Assert(obj is ValueType);
            Debug.Assert(obj is Boolean);
            Debug.Assert(obj is bool);
            Debug.Assert(!(obj is int));
            Debug.Assert(!(obj is Mois));
            Debug.Assert(!(obj is null));

            // Boxage :
            int i = 10;
            obj = i;    // boxage ici

            Debug.Assert(obj.GetType().IsValueType);
            Debug.Assert(obj.GetType().IsPrimitive);
            Debug.Assert(obj.GetType() == typeof(int));
            Debug.Assert(obj.ToString() == "10"); ;
            Debug.Assert(obj.Equals(10));   // boxage implicite
            Debug.Assert(obj != (object)10);    // boxage implicite
            Debug.Assert((int)obj == 10);   // déboxage explicite

            int j = (int)obj;   // déboxage
            ++j;

            Debug.Assert(object.Equals((object)10, (object)10));    // double boxage implicite
            Debug.Assert(Equals(10, 10));    // double boxage implicite
            Debug.Assert(!object.ReferenceEquals(10, 10));    // double boxage implicite

            // Tableau d'objets :
            var objets = new object[]
            {
                null, 100, true, Mois.Janvier,   // triple boxage implicite
                Date.Aléatoire(new Random(), 1900, 2000), new Calendrier(2019, Mois.Mars)
            };

            WriteLine("\nTableau d'objets :");

            foreach (var objet in objets)
            {
                ColorWriteLine(Blue, $"* {EnTexte(objet)}");
            }

            // ToString : 
            WriteLine("\nTableau d'objets (ToString):");

            foreach (var objet in objets)
            {
                ColorWriteLine(DarkYellow, " * " + objet?.ToString());
            }

            WriteLine("\nTableau d'objets (ToString implicite 1):");

            foreach (var objet in objets)
            {
                ColorWriteLine(DarkRed, " * " + objet);
            }

            WriteLine("\nTableau d'objets (ToString implicite 2):");

            foreach (var objet in objets)
            {
                ColorWriteLine(DarkMagenta, $" * {objet}");
            }

            ColorWriteLine(Magenta, $"\n{10} + {20} = {30}\n");
        }

        private static string InfoObjet(object obj)
        {
            if (obj == null)
                return "\nobjet: null\n";
            else
            {
                // Variables pour les parents de l'objet, s'ils existent, null sinon :
                var parent = obj.GetType().BaseType;
                var grandParent = parent?.BaseType;
                var arrièreGrandParent = grandParent?.BaseType;

                return
                    $"\n 1. objet:              {EnTexte(obj)}"
                  + $"\n 2. type d'objet:       {obj.GetType()}"
                  + $"\n 3. type de Date:       {typeof(Date)}"
                  + $"\n 4. type == Date:       {EnTexte(typeof(Date) == obj.GetType())}"
                  + $"\n 5. nom du type:        {obj.GetType().Name}"
                  + $"\n 6. parent:             {EnTexte(parent)}"
                  + $"\n 7. parent == object:   {EnTexte(obj.GetType().BaseType == typeof(object))}"
                  + $"\n 8. grand-parent:       {EnTexte(grandParent)}"
                  + $"\n 9. arr-grand-parent:   {EnTexte(arrièreGrandParent)}"
                  + "\n";
            }
        }
    }
}
