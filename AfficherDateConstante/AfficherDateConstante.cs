﻿/* Programme d'affichage de dates constantes. */
using static Prog2.ConsolePlus;
using static System.Console;

namespace Prog2
{
    static class AfficherDateConstante
    {
        static void Main(string[] args)
        {
            Title = "Afficher Date Constante";

            var dateConst = new DateConstante(2001, 9, 11);

            Afficher("        ToString", dateConst);
            Afficher("     EnTexteLong", $"{dateConst:L}");
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
            Afficher("       Cloner OK", dateConst.Cloner() is DateConstante);
            Afficher("    Dupliquer OK", dateConst.Dupliquer() is DateConstante);
        }
    }
}
