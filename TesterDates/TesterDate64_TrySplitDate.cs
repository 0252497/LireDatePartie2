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
        public void _64_TrySplitDate()
        {
            var date = new PrivateType(typeof(Date));
            object[] args = new object[] {null, null, null, null };

            void split(string strDate, string expDate = null)
            {
                args[0] = strDate;
                var succès = (bool)date.InvokeStatic("TrySplitDate", args);
                var résultat = string.Join(" ", args.Skip(1));
                AreEqual(expDate == null ? "  " : expDate, résultat, strDate);
                AreEqual(expDate != null, succès);
            }

            foreach (var invalide in new []
            {
                "", "05-11-1999", "1999 mai 0005", "1999 005 011", "5 mai 99",
                "1999 mai 11 12", "1999 mai", "1999 5" 
            }) split(invalide);

            foreach (var valide in new[] {
                "1999-05-11", "1999/05/11", "1999.05.11", "1999, 05, 11", "1999 - 05 - 11",
            }) split(valide, "1999 05 11");

            foreach (var valide in new[] {
                "1999 5 11", "(1999, 5, 11)"
            }) split(valide, "1999 5 11");

            foreach (var valide in new[] {
                "1999-mai-11", "mai: 11, 1999",
                "1999, 11 mai", "11 mai 1999", "mai 1999, 11", "11;1999;mai"
            }) split(valide, "1999 mai 11");

        }

    }
}
