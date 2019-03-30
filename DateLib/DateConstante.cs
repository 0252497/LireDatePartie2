/* Fichier pour les attributs, les méthodes et les propriétés de la classe DateConstante. */
using System;

namespace Prog2
{
    public class DateConstante : Date
    {
        /// <summary>
        /// Constructeur de date constante.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        /// <param name="jour">le jour</param>
        public DateConstante(int année, int mois, int jour) 
            : base(année, mois, jour)
        {
        }

        private int JourDeLAnnéeCaché = 0;

        // --- Propriétés ---

        /// <summary>
        /// L'année.
        /// </summary>
        public override int Année
        {
            get => base.Année;
            set => throw OpérationInvalide();
        }

        /// <summary>
        /// Le jour.
        /// </summary>
        public override int Jour
        {
            get => base.Jour;
            set => throw OpérationInvalide();
        }
        /// <summary>
        /// Le jour de l'année. 
        /// </summary>
        public override int JourDeLAnnée
        {
            get
            {
                if (JourDeLAnnéeCaché == 0)
                    JourDeLAnnéeCaché = base.JourDeLAnnée;
                return JourDeLAnnéeCaché;
            }
        }

        /// <summary>
        /// Le mois.
        /// </summary>
        public override int Mois
        {
            get => base.Mois;
            set => throw OpérationInvalide();
        }

        // --- Méthodes ---

        /// <summary>
        /// Pour cloner une date constante.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        /// <param name="jour">le jour</param>
        /// <returns>le clone de la date constante</returns>
        public override Date Cloner(int année = 0, int mois = 0, int jour = 0)
        {
            var annéeClone = Année;
            var moisClone = Mois;
            var jourClone = Jour;

            if (année > 0)
            {
                annéeClone = année;
            }

            if (mois > 0)
            {
                moisClone = mois;
            }

            if (jour > 0)
            {
                jourClone = jour;
            }

            return new DateConstante(annéeClone, moisClone, jourClone);
        }
        
        // Opérations invalides :

        public override Date Décrémenter(int décrément = 1)
        {
            throw OpérationInvalide();
        }

        public override Date Incrémenter(int incrément = 1)
        {
            throw OpérationInvalide();
        }

        public override Date MettreÀJour()
        {
            throw OpérationInvalide();
        }

        private Exception OpérationInvalide() 
            => new DateConstanteException();
    }
}
