/* Programme faisant afficher divers booléens.
 * 
 * Auteure : Véronique Giguère
 * Création : 5 février 2019
 */

using static System.Console;
using static Prog2.ConsolePlus;
using static System.ConsoleColor;

namespace Prog2
{
    static class AfficherBool
    {
        static void Main(string[] args)
        {
            Title = "Afficher Booléen";

            var fumeurOk = LireBooléen("\nFumeur", out bool fumeur);
            var joueurOk = LireBooléen("Joueur", out bool joueur, "o");
            var offset = 10;

            WriteLine();
            Afficher("Fumeur", fumeurOk ? fumeur.OuiNon() : "non renseigné", offset);
            Afficher("Joueur", joueurOk ? joueur.VraiFaux() : "non renseigné", offset, Magenta, DarkYellow);
            WriteLine();

            for (offset = 5; offset <= 50; offset += 5)
            {
                Afficher(":", "::", offset, Blue);
            }

            Poursuivre("Merci de votre participation au sondage! ...");
        }
    }
}
