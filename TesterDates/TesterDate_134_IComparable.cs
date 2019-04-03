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
        public void __134a_DateIComparable()
        {
            IsTrue(new Date() is IComparable<Date>);

            var d0 = D(1999, 1, 12);
            var d1 = D(1999, 1, 13);
            var d2 = D(1999, 2, 12);
            var d3 = D(2000, 2, 12);
            var dates = new[] { d2, d1, d3, d0 };
            Array.Sort(dates);
            AreEqual(d0, dates[0]);
            AreEqual(d1, dates[1]);
            AreEqual(d2, dates[2]);
            AreEqual(d3, dates[3]);
        }

        [TestMethod]
        public void __134b_ICalendrierIComparale()
        {
            IsTrue(new Calendrier(2019, Mois.Mars) is IComparable<ICalendrier>);

            var cal0 = new Calendrier(1999, Mois.Mars);
            var cal1 = new Calendrier(1999, Mois.Mai);
            var cal2 = new Calendrier(2000, Mois.Mai);
            var cals = new[] { cal1, cal2, cal0 };
            Array.Sort(cals);
            AreEqual(cal0, cals[0]);
            AreEqual(cal1, cals[1]);
            AreEqual(cal2, cals[2]);

            IsTrue(cal0 < cal1);
            IsTrue(cal1 < cal2);
            IsTrue(cal0 <= cal1);
            IsTrue(cal0 <= cal0);
            IsTrue(cal1 > cal0);
            IsTrue(cal1 >= cal0);
            IsTrue(cal0 >= cal0);
            IsTrue(cal2 > cal1);
        }

    }
}
