using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prog2
{

    [TestClass]
    public abstract partial class TesterDateBase
    {
        public abstract Date D(int année, int mois, int jour);
    }

    [TestClass]
    public class TesterDate : TesterDateBase
    {
        public override Date D(int année, int mois, int jour)
            => new Date { Année = année, Mois = mois, Jour = jour };
    }

}
