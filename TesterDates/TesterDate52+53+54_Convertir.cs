using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;
using static Prog2.NomsDesMois;


namespace Prog2
{

    public partial class TesterDateBase
    {
   
        static void TesterConvertir(Func<int, string> convertir)
        {
            AreEqual("janvier", Janvier);
            AreEqual("décembre", Décembre);
            AreEqual(Janvier, convertir(1));
            AreEqual(Février, convertir(2));
            AreEqual(Mars, convertir(3));
            AreEqual(Avril, convertir(4));
            AreEqual(Mai, convertir(5));
            AreEqual(Juin, convertir(6));
            AreEqual(Juillet, convertir(7));
            AreEqual(Août, convertir(8));
            AreEqual(Septembre, convertir(9));
            AreEqual(Octobre, convertir(10));
            AreEqual(Novembre, convertir(11));
            AreEqual(Décembre, convertir(12));
            IsNull(convertir(0));
            IsNull(convertir(13));
        }

        [TestMethod]
        public void _52_Convertir1()
        {
            TesterConvertir(Convertir1);
        }

        [TestMethod]
        public void _53_Convertir2()
        {
            TesterConvertir(Convertir2);
        }

        [TestMethod]
        public void _54_Convertir3()
        {
            TesterConvertir(Convertir3);
        }

    }
}
