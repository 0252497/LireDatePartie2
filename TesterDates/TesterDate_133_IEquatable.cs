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
        public void __133a_DateIEquatable()
        {
            IsTrue(new Date() is IEquatable<Date>);
        }

        [TestMethod]
        public void __133b_ICalendrierIEquatable()
        {
            IsTrue(new Calendrier(2019, Mois.Mars) is IEquatable<ICalendrier>);
        }

    }
}
