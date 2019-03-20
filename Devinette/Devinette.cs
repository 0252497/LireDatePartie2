/* Jeu de devinette de dates. */
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

namespace Prog2
{
    public static class Devinette
    {
        static void Main(string[] args)
        {
            // Le random pour notre date aléatoire :
            Random random;
            int germe = 0;  // Le germe par défaut s'il n'est pas précisé en argument

            // Si le booléen est passé en argument, l'utilisateur a la possibilité de voir la 
            // date aléatoire générée :
            bool verbeux = false;

            switch (args.Length)
            {
                // Aucun argument, on débute le programme en créant un Random sans germe :
                case 0:
                    random = new Random();
                    break;

                // S'il n'y a qu'un seul argument, on doit vérifier si on obtient le germe
                // ou le booléen verbeux. Si un germe est précisé, on l'insère dans notre Random :
                case 1:
                    if (args[0].EstNumérique())
                    {
                        germe = Parse(args[0]);
                        random = new Random(germe);
                        ColorWrite(Red, $"\tGerme: ");
                        ColorWriteLine(DarkYellow, $"{germe}\n");
                    }
                    else if (args[0].TryParseBool(out verbeux))
                    {
                        random = new Random();
                    }
                    else
                    {
                        MessageErreur($"L'argument '{args[0]}' n'est pas valide\n");
                        random = new Random();
                    }
                    break;

                // Dans le cas où 2 arguments sont entrés par l'utilisateur, un pour le germe et l'autre 
                // pour le booléen verbeux :
                case 2:
                    if (args[0].EstNumérique())
                    {
                        germe = Parse(args[0]);
                        random = new Random(germe);
                        ColorWrite(Red, $"\tGerme: ");
                        ColorWriteLine(DarkYellow, $"{germe}");
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

                // Dans tous les autres cas, on affiche un message d'usage avant de débuter le 
                // programme normalement :
                default:
                    random = new Random();
                    ColorWriteLine(DarkYellow, "USAGE: DEVINETTE [germe:int [verbeux:bool]]\n");
                    break;
            }

            Date dateMin = new Date(1700, 01, 01);  // La date minimale
            bool choix; // Pour l'arrêt du jeu
            Date dateAléatoire; // La date aléatoire générée à chaque partie
            Date dateUtilisateur;   // Pour les essais de dates de l'utilisateur

            do
            {
                // Initialisation de la date aléatoire :
                dateAléatoire = Aléatoire(random, dateMin, Aujourdhui);

                bool quitter = false; // Pour la sortie rapide

                // Pour savoir si l'utilisateur a réussi ou s'il a utilisé la sortie rapide :
                bool réussi = true;

                // Affichage de la date, si le booléen verbeux est vrai :
                if (verbeux)
                {
                    ColorWrite(Red, "\tChoix: ");
                    ColorWriteLine(DarkYellow, $"{EnTexte(dateAléatoire)}\n");
                }

                // Le nombre d'essais de l'utilisateur, sera incrémenté à chaque tour de boucle :
                int nbEssais = 0;

                ColorWriteLine(DarkYellow,
                    "J'ai choisi une date aléatoirement, entre le 1er janvier 1700 et aujourd'hui...");
                ColorWriteLine(DarkYellow, "\nPouvez-vous trouver laquelle?");

                for (; ; )
                {
                    // À tous les 3 essais, on demande à l'utilisateur s'il préfère quitter :
                    if (nbEssais % 3 == 0 && nbEssais != 0)
                    {
                        while (!LireBooléen("\nDésirez-vous quitter", out quitter)) ;
                    }

                    /***/
                    if (quitter)
                    {
                        // Si l'utilisateur quitte ici, çela veut dire qu'il n'a pas trouvé 
                        // la date recherchée... :
                        réussi = false;
                        break;
                    }
                    /***/

                    do
                    {
                        LireDate("\nDate", "1700-01-01", EnTexte(Aujourdhui), out dateUtilisateur);
                        ++nbEssais;

                        if (nbEssais % 3 == 0 && nbEssais != 0)
                        {
                            while (!LireBooléen("\nDésirez-vous quitter", out quitter)) ;
                        }
                    }
                    while ((dateUtilisateur == null || EnTexte(dateUtilisateur) == "") && !quitter);

                    /***/
                    if (quitter)
                    {
                        // Si l'utilisateur quitte ici, çela veut dire qu'il n'a pas trouvé 
                        // la date recherchée... :
                        réussi = false;
                        break;
                    }
                    /***/

                    /***/
                    if (SontÉgales(dateUtilisateur, dateAléatoire)) break;
                    /***/

                    if (dateUtilisateur.ComparerAvec(dateMin) == 1 && 
                        dateUtilisateur.ComparerAvec(Aujourdhui) == -1)
                    {
                        if (dateUtilisateur.ComparerAvec(dateAléatoire) == 1)
                        {
                            ColorWriteLine(DarkYellow, "Trop grand!");
                        }
                        else if (dateAléatoire.ComparerAvec(dateUtilisateur) == 1)
                        {
                            ColorWriteLine(DarkYellow, "Trop petit!");
                        }
                    }
                }

                MessageOk(
                    réussi ? $"Bravo! Vous avec trouvé après {nbEssais} essai(s)!" : "Vous n'avez pas réussi...");

                while (!LireBooléen("\n\nRejouer", out choix)) ;
            }
            while (choix);

            Poursuivre("\nMerci d'avoir jouer...");
        }
    }
}
