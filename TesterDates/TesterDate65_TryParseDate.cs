using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;


namespace Prog2
{

    public partial class TesterDateBase
    {
   
        [TestMethod]
        public void _65_TryParseDate()
        {
            void parse(string strDate, string expected = "")
            {
                var succès = Date.TryParse(strDate, out Date date);
                var reçu = date == null ? "" : Date.EnTexte(date);
                AreEqual(expected, reçu);
                AreEqual(expected != "", succès);
            }

            foreach (var invalide in new[] {
                "", "12 juillet 99", "0012 juillet 1999", "12 07 1999",
                "1999 juillet 32", "1999 13 13"
            }) parse(invalide);

            foreach (var valide in new[] {
                "1999-07-12", "1999 7 12", "1999/7/12",
                "1999 juillet 12", "12 juillet 1999", "1999: 12 juillet)",
                "juil 12, 1999", "12 1999 juille", "juillet 1999, 12"
            }) parse(valide, "1999-07-12");

        }

    }
}
