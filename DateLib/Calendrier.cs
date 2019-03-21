using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2.JourDeLaSemaine;
using static System.Console;

namespace Prog2
{
    public class Calendrier
    {
        public const int NbRangées = 6;
        public const int NbColonnes = 7;

        public int Année { get; }
        public Mois Mois { get; }
        public int[,] Jours { get; }

        public Calendrier(int année, Mois mois)
        {
            Année = année;
            Mois = mois;
            Jours = new int[NbRangées, NbColonnes];
            RemplirTableau();
        }

        private void RemplirTableau()
        {
            //! Code temporaire

            // Première case du tableau, en haut à gauche :
            Jours[0, 0] = 1;

            // Rangée 3, colonne 6 :
            Jours[2, 5] = 20;

            Jours[NbRangées - 1, NbColonnes - 1] = 42;

            int jour = 22;

            for (int colonne = 0; colonne < NbColonnes; ++colonne)
            {
                Jours[3, colonne] = jour;
                ++jour;
            }

            jour = 5;

            for (int rangée = 0; rangée < NbRangées; ++rangée)
            {
                Jours[rangée, 4] = jour;
                jour += 7;
            }
        }
    }
}
