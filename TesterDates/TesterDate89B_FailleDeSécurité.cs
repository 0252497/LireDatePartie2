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
        public void _89B_FailleDeSécurité()
        {
            Date d = null;
            ThrowsException<ArgumentOutOfRangeException>(
                () => D(0, 1, 1));
            d = D(0b011111010100, 0b0010, 0b00011101);
            ThrowsException<ArgumentOutOfRangeException>(
                () => a(d, 0b011111010011));
            d = D(0b011111010100, 0b0011, 0b00011111);
            ThrowsException<ArgumentOutOfRangeException>(
                () => m(d, 0b0100));

            void a(Date x, int i) => x.Année = i;
            void m(Date x, int i) => x.Mois = i;
        }
    }
}
