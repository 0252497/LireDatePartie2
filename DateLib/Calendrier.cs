using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    public class Calendrier
    {
        private const int NbRangées = 6;
        private const int NbColonnes = 7;

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
        }
    }
}
