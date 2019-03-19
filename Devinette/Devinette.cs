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
            int germe = 0;
            bool verbeux = false;
            Random random;

            switch (args.Length)
            {
                case 0:
                    random = new Random();
                    break;

                case 1:
                    if (args[0].EstNumérique())
                    {
                        germe = Parse(args[0]);
                        random = new Random(germe);
                        ColorWrite(Red, $"\tGerme: ");
                        ColorWriteLine(DarkYellow, $"{germe}\n");
                    }
                    else
                    {
                        MessageErreur($"L'argument entier '{args[0]}' n'est pas valide\n");
                        random = new Random();
                    }
                    break;

                case 2:
                    if (args[0].EstNumérique())
                    {
                        germe = Parse(args[0]);
                        random = new Random(germe);
                        ColorWrite(Red, $"\tGerme: ");
                        ColorWriteLine(DarkYellow, $"{germe}\n");
                    }
                    else
                    {
                        MessageErreur($"L'argument entier '{args[0]}' n'est pas valide\n");
                        random = new Random();
                    }

                    if (!args[1].TryParseBool(out verbeux))
                    {
                        MessageErreur($"L'argument booléen '{args[1]}' n'est pas valide\n");
                    }

                    break;
                    
                default:
                    random = new Random();
                    ColorWriteLine(DarkYellow, "USAGE: DEVINETTE [germe:int [verbeux:bool]]\n");
                    break;
            }

            Date dateMin = new Date(1700, 01, 01);
            Date dateUtilisateur;
            bool choix;
            bool réussi = true;
            bool quitter = false;
            Date dateAléatoire;
            
            do
            {
                dateAléatoire = Aléatoire(random, dateMin, Aujourdhui);

                if (verbeux)
                {
                    ColorWrite(Red, "\tChoix: ");
                    ColorWriteLine(DarkYellow, $"{EnTexte(dateAléatoire)}\n");
                }

                int nbEssais = 0;

                ColorWriteLine(DarkYellow,
                    "J'ai choisi une date aléatoirement, entre le 1er janvier 1700 et aujourd'hui...");
                ColorWriteLine(DarkYellow, "\nPouvez-vous trouver laquelle?");
                ColorWriteLine(Magenta, EnTexte(dateAléatoire));

                for (; ; )
                {
                    if (nbEssais % 3 == 0 && nbEssais != 0)
                    {
                        while (!LireBooléen("\nDésirez-vous quitter", out quitter));
                    }

                    /***/
                    if (quitter)
                    {
                        réussi = false;
                        break;
                    }
                    /***/

                    ++nbEssais;

                    while(!LireDate("\nDate", "1700-01-01", EnTexte(Aujourdhui), out dateUtilisateur));

                    /***/
                    if (SontÉgales(dateUtilisateur, dateAléatoire)) break;
                    /***/

                    if (dateUtilisateur.ComparerAvec(dateAléatoire) == 1)
                    {
                        ColorWriteLine(DarkYellow, "Trop grand!");
                    }
                    else if (dateAléatoire.ComparerAvec(dateUtilisateur) == 1)
                    {
                        ColorWriteLine(DarkYellow, "Trop petit!");
                    }
                }

                MessageOk(réussi ? $"Bravo! Vous avec trouvé après {nbEssais} essai(s)!" : "Vous n'avez pas réussi...");
                WriteLine("\n");

                if(LireBooléen("Rejouer", out choix))
                { 
                    dateAléatoire = Aléatoire(random, dateMin, Aujourdhui);
                }
            }
            while (choix);

            Poursuivre("Merci d'avoir jouer...");
        }
    }
}
