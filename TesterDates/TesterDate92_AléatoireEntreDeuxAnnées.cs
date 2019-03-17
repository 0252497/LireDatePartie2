using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    public partial class TesterDateBase
    {
        void TesterDateAléatoireAnnée(int nb, Func<Random, int, int, Date> dateAléatoire)
        {
            var r1 = new Random(0);
            var r2 = new Random(0);
            var r3 = new Random(1);
            var d1 = dateAléatoire(r1, 1999, 2001);
            var d2 = dateAléatoire(r2, 1999, 2001);
            var d3 = dateAléatoire(r3, 1999, 2001);

            // Objet différent retourné à chaque fois
            IsFalse(d1 == d2);

            // Même germe => même date
            IsTrue(Date.SontÉgales(d1, d2));

            // Germe différent => date différente (en général)
            IsTrue(!Date.SontÉgales(d1, d3));

            // L'année max doit être supérieure à l'année min
            ThrowsException<ArgumentException>(() => dateAléatoire(r2, 2000, 1999));

            // Toutes les années, tous les mois et tous les jours sont générés
            var années = new int[5];
            var mois = new int[13];
            var jours = new int[32];
            for (int i = 0; i < 1200 * nb; i++)
            {
                var d = dateAléatoire(r1, 1, 4);
                années[d.Année]++;
                mois[d.Mois]++;
                jours[d.Jour]++;
            }
            // Répartition uniforme des années
            for (int i = 1; i <= 4; i++)
            {
                IsTrue(années[i] > 250 * nb && années[i] < 350 * nb, $"année {i}: {années[i]}");
            }
            // Répartition uniforme des mois
            for (int i = 1; i <= 12; i++)
            {
                IsTrue(mois[i] > 70 * nb && mois[i] < 140 * nb, $"mois {i}: {mois[i]}");
            }
            // Répartition uniforme des jours
            for (int i = 1; i <= 30; i++)
            {
                IsTrue(jours[i] > 30 * nb && jours[i] < 55 * nb, $"jours {i}: {jours[i]}");
            }
            IsTrue(jours[31] > 15 * nb && jours[31] < 30 * nb, $"jour 31: {jours[31]}");
        }

        [TestMethod]
        public void _92_AléatoireEntreDeuxAnnées()
        {
            TesterDateAléatoireAnnée(10, Date.Aléatoire);
        }

    }
}
