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
    public static class Devinette
    {
        static void Main(string[] args)
        {
            Date dateMin = new Date(1700, 01, 01);
            Random random = new Random();
            Date dateAléatoire = Aléatoire(random, dateMin, Aujourdhui);
            Date dateUtilisateur;
            bool choix;
            bool réussi = true;

            do
            {
                int nbEssais = 0;
                ColorWriteLine(Magenta, EnTexte(dateAléatoire));
                ColorWriteLine(DarkYellow,
                    "J'ai choisi une date aléatoirement, entre le 1er janvier 1700 et aujourd'hui...");
                ColorWriteLine(DarkYellow, "\nPouvez-vous trouver laquelle?");
                
                for (; ; )
                {
                    if (nbEssais % 3 == 0 && nbEssais != 0)
                    {
                        /***/
                        if (LireBooléen("\nDésirez-vous quitter", out bool quitter))
                            réussi = false;
                            break;
                        /***/
                    }
                    
                    ++nbEssais;

                    LireDate("\nDate", "1700-01-01", EnTexte(Aujourdhui), out dateUtilisateur);

                    /***/
                    if (SontÉgales(dateUtilisateur, dateAléatoire)) break;
                    /***/
                    
                    if (dateUtilisateur.ComparerAvec(dateAléatoire) == 1)
                    {
                        ColorWriteLine(DarkYellow, "Trop grand!");
                    }
                    else if (dateUtilisateur.ComparerAvec(dateAléatoire) == -1)
                    {
                        ColorWriteLine(DarkYellow, "Trop petit!");
                    }
                }

                if (réussi)
                {
                    MessageOk($"Bravo! Vous avec trouvé après {nbEssais} essai(s)!\n\n");
                }
                else
                {
                    MessageOk("Vous n'avez pas réussi...\n\n");
                }

                if(LireBooléen("Rejouer", out choix))
                { 
                    dateAléatoire = Aléatoire(random, dateMin, Aujourdhui);
                }
            }
            while (choix);

            WriteLine("Merci d'avoir jouer...");
        }
    }
}
