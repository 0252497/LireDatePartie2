/* Fichier d'utilitaires. */

using System;
using System.Text;
using static System.Console;
using static System.ConsoleColor;

namespace Prog2
{
    public static class ConsolePlus
    {
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
            Write(message, args);
            ForegroundColor = couleurInitiale;
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
            WriteLine(message, args);
            ForegroundColor = couleurInitiale;
        }

        /// <summary>
        /// Demande une question quelconque à l'utilisateur.
        /// </summary>
        /// <param name="propriété">la propriété de la question à demander</param>
        /// <param name="défaut">la propriété par défaut</param>
        /// <returns></returns>
        public static string Demander(string propriété, string défaut)
        {
            if (défaut == null)
            {
                défaut = "";
            }

            if (défaut != "")
            {
                propriété += $"[{défaut}]";
            }

            ColorWrite(Cyan, $"{propriété}: ");
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
            ColorWriteLine(Red, message);
            Poursuivre();
        }

        /// <summary>
        /// Permet d'afficher un message en vert.
        /// </summary>
        /// <param name="message">le message</param>
        /// <param name="args">argument facultatif</param>
        public static void MessageOk(string message, params object[] args)
        {
            ColorWrite(Green, message);
            Poursuivre();
        }

        /// <summary>
        /// Demande à l'utilisateur d'appuyer sur une touche pour poursuivre.
        /// </summary>
        public static void Poursuivre()
        {
            ColorWrite(Gray, "\nAppuyez sur une touche pour poursuivre...");
            ReadKey(true);
            WriteLine();
        }
    }
}
