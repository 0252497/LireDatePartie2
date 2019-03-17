using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void _94_AléatoireEntreDeuxDates()
        {
            TesterDateAléatoireAnnée(4, (random, min, max) 
                => Date.Aléatoire(random, D(min, 1, 1), D(max, 12, 31)));

            var r = new Random(0);
            var dates = new int[3];
            for(int i = 0; i < 1500; i++)
            {
                var date = Date.EnTexte(Date.Aléatoire(r, D(2018, 12, 31), D(2019, 1, 2)));
                switch (date)
                {
                    case "2018-12-31":
                        dates[0]++;
                        break;

                    case "2019-01-01":
                        dates[1]++;
                        break;

                    case "2019-01-02":
                        dates[2]++;
                        break;

                    default:
                        throw new Exception("Inattendu: " + date);
                }
            }
            IsTrue(dates[2] > 350 && dates[2] < 650, "Hors compte: " + dates[2]);
            IsTrue(dates[1] > 350 && dates[1] < 650, "Hors compte: " + dates[1]);
            IsTrue(dates[0] > 350 && dates[0] < 650, "Hors compte: " + dates[0]);
        }

    }
}
