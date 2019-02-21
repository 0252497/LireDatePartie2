using System;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Prog2
{

    public partial class TesterDateBase
    {
   
        void TesterNuméroDuMois(Func<string, int> numéroDuMois)
        {
            AreEqual(1, numéroDuMois("janvier"));
            AreEqual(12, numéroDuMois("décembre"));
        }

        void TesterNuméroDuMoisInsemsibleÀLaCasse(Func<string, int> numéroDuMois)
        {
            TesterNuméroDuMois(numéroDuMois);
            AreEqual(1, numéroDuMois("Janvier"));
            AreEqual(1, numéroDuMois("JANVIER"));
        }

        void TesterNuméroDuMoisInsemsibleAuxAccents(Func<string, int> numéroDuMois)
        {
            TesterNuméroDuMoisInsemsibleÀLaCasse(numéroDuMois);
            AreEqual(2, numéroDuMois("FEVRIER"));
            AreEqual(12, numéroDuMois("decembre"));
            AreEqual(12, numéroDuMois("décèmbrê"));
        }

        void TesterNuméroDuMoisCommencePar(Func<string, int> numéroDuMois)
        {
            TesterNuméroDuMoisInsemsibleAuxAccents(numéroDuMois);
            AreEqual(12, numéroDuMois("déc"));
            AreEqual(12, numéroDuMois("d"));
            AreEqual(12, numéroDuMois("dec"));
            AreEqual(12, numéroDuMois("DEC"));
            AreEqual(5, numéroDuMois("mai"));
            AreEqual(0, numéroDuMois("ma"));
            AreEqual(3, numéroDuMois("mar"));
            AreEqual(0, numéroDuMois("jui"));
            AreEqual(0, numéroDuMois("j"));
            AreEqual(6, numéroDuMois("JUIN"));
            AreEqual(0, numéroDuMois("marss"));
        }

    }
}
