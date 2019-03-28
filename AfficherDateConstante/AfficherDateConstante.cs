using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.DateUtil;
using static System.Int32;
using System.Collections.Generic;
using System.Linq;

namespace Prog2
{
    static class AfficherDateConstante
    {
        static void Main(string[] args)
        {
            Title = "Afficher Date Constante";

            var dateConst = new DateConstante(2001, 9, 11);

            Afficher("        ToString", dateConst);
            Afficher("     EnTexteLong", dateConst.EnTexteLong());
            Afficher("    JourDeLAnnée", dateConst.JourDeLAnnée);
            Afficher(" JourDeLaSemaine", dateConst.JourDeLaSemaine);
            //dateConst.Incrémenter(365);
            //Afficher("  1 an plus tard", dateConst);
            //dateConst.Décrémenter(365);
            //Afficher("1 an plus tôt", dateConst);
            //dateConst.Mois--;
            //Afficher(" 1 mois plus tôt", dateConst);
            //dateConst.Jour--;
            //Afficher(" 1 jour plus tôt", dateConst);
            WriteLine();
        }
    }
}
