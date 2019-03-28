/* Fichier d'utilitaires ConsolePlus. */
using System;
using static System.Console;
using static System.ConsoleColor;

namespace Prog2
{
    public static class ConsolePlus
    {
        /// <summary>
        /// Affiche une propriété et sa valeur à l'écran.
        /// </summary>
        /// <param name="propriété">le nom de la propriété</param>
        /// <param name="valeur">sa valeur</param>
        /// <param name="offset">l'offset (0 pour aucun offset)</param>
        /// <param name="couleurValeur">la couleur de la valeur (0 pour la valeur par défaut)</param>
        /// <param name="couleurPropriété">la couleur de la propriété (0 pour la valeur par défaut)</param>
        public static void Afficher(
            string propriété, object valeur, int offset = 0, ConsoleColor couleurValeur = 0,
            ConsoleColor couleurPropriété = 0)
        {
            if (couleurValeur == 0)
            {
                couleurValeur = White;
            }

            if (couleurPropriété == 0)
            {
                couleurPropriété = Cyan;
            }

            ColorWrite(couleurPropriété, $"{propriété.PadLeft(offset)}:");
            ColorWriteLine(couleurValeur, $" {valeur}");
        }
        /// <summary>
        /// Précise si les messages d'erreurs ou ok sont bloquants ou pas. Un message bloquant demande
        /// à l'utilisateur d'appuyer sur une touche avant de poursuivre.
        /// </summary>
        public static bool Bloquant = false;

        /// <summary>
        /// Permet d'afficher un message en couleur.
        /// </summary>
        /// <param name="color">la couleur désirée</param>
        /// <param name="message">le message</param>
        /// <param name="args">argument facultatif</param>
        public static void ColorWrite(ConsoleColor color, string message, params object[] args)
        {
            var couleurInitiale = ForegroundColor;
            ForegroundColor = color;

            try
            {
                Write(message, args);
            }
            finally
            {
                ForegroundColor = couleurInitiale;
            }
        }

        /// <summary>
        /// Permet d'afficher un message en couleur avec un saut de ligne.
        /// </summary>
        /// <param name="color">la couleur désirée</param>
        /// <param name="message">le message</param>
        /// <param name="args">argument facultatif</param>
        public static void ColorWriteLine(ConsoleColor color, string message, params object[] args)
        {
            var couleurInitiale = ForegroundColor;
            ForegroundColor = color;

            try
            {
                WriteLine(message, args);
            }
            finally
            {
                ForegroundColor = couleurInitiale;
            }
        }

        /// <summary>
        /// Demande une question quelconque à l'utilisateur.
        /// </summary>
        /// <param name="propriété">la propriété de la question à demander</param>
        /// <param name="défaut">la propriété par défaut</param>
        /// <param name="caractère">le caractère par défaut</param>
        /// <returns>la réponse de l'utilisateur</returns>
        public static string Demander(string propriété, string défaut, string caractère = ": ")
        {
            if (défaut == null)
            {
                défaut = "";
            }

            if (défaut != "")
            {
                propriété += $" [{défaut}]";
            }

            ColorWrite(Cyan, $"{propriété}{caractère} ");
            var réponse = ReadLine().Trim();

            if (réponse == "")
            {
                return défaut;
            }
            else
            {
                return réponse;
            }
        }

        /// <summary>
        /// Demande et tente de lire une propriété booléenne à la console. Affiche un message d'erreur 
        /// si ça ne marche pas.
        /// </summary>
        /// <param name="propriété">la propriété</param>
        /// <param name="booléen">le booléen lu</param>
        /// <param name="défaut">la valeur par défaut, null ou vide si aucune</param>
        /// <returns>vrai si la lecture réussi</returns>
        public static bool LireBooléen(string propriété, out bool booléen, string défaut = null)
        {
            if (!StringUtil.TryParseBool(Demander(propriété, défaut, " ? "), out booléen))
            {
                MessageErreur($"Il faut entrer oui/non ou o/n ou en anglais!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Permet de lire un entier sur la console.
        /// </summary>
        /// <param name="propriété">Nom de la propriété</param>
        /// <param name="défaut">Valeur par défaut</param>
        /// <param name="min">Valeur minimale permise</param>
        /// <param name="max">Valeur maximale permise</param>
        /// <param name="entier">Valeur lue</param>
        /// <returns>faux si une erreur se produit</returns>
        public static bool LireEntier(string propriété, string défaut, int min, int max, out int entier)
        {
            if (int.TryParse(Demander(propriété, défaut), out entier))
            {
                if (entier < min)
                {
                    MessageErreur($"Le nombre doit être plus grand ou égal à {min}");
                }
                else if (entier > max)
                {
                    MessageErreur($"Le nombre doit être plus grand ou égal à {max}");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageErreur("Il faut entrer un nombre entier svp");
            }

            return false;
        }

        /// <summary>
        /// Lit un entier sans préciser les minimum et maximum.
        /// </summary>
        /// <param name="propriété">nom de la propriété</param>
        /// <param name="défaut">la valeur par défaut</param>
        /// <param name="entier">faux si une erreur se produit</param>
        /// <returns></returns>
        public static bool LireEntier(string propriété, string défaut, out int entier) 
            => LireEntier(propriété, défaut, int.MinValue, int.MaxValue, out entier);

        /// <summary>
        /// Permet d'afficher un message d'erreur en rouge.
        /// </summary>
        /// <param name="message">le message</param>
        /// <param name="args">argument facultatif</param>
        public static void MessageErreur(string message, params object[] args)
        {
            ColorWriteLine(Red, message, args);
            if (Bloquant) Poursuivre();
        }

        /// <summary>
        /// Permet d'afficher un message en vert.
        /// </summary>
        /// <param name="message">le message</param>
        /// <param name="args">argument facultatif</param>
        public static void MessageOk(string message, params object[] args)
        {
            ColorWrite(Green, message, args);
            if (Bloquant) Poursuivre();
        }

        /// <summary>
        /// Demande à l'utilisateur d'appuyer sur une touche pour poursuivre.
        /// </summary>
        public static void Poursuivre(string message = null)
        {
            if (message != null)
            {
                ColorWrite(White, message);
            }
            else
            {
                ColorWrite(Magenta, "\nAppuyez sur une touche pour poursuivre...");
            }


            ReadKey(true);
            WriteLine();
        }
    }
}
