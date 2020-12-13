using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_TP.ObjectModel;

namespace Task2Tests_TP.ObjectModel
{
    [TestClass]
    public class ATest
    {
        private A A;
        private B B;
        private C C;
        private int AField = 15;

        public ATest()
        {
            A = new A(null, AField);
            B = new B(null, 30);
            C = new C(null, 60);

            A.B = B;
            B.C = C;
            C.A = A;
        }

        [TestMethod]
        public void GetAFieldTest()
        {
            Assert.AreEqual(AField, A.AField);
        }

        [TestMethod]
        public void GetBTest()
        {
            Assert.AreEqual(B, A.B);
        }
    }
}
