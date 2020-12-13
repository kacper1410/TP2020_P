using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_TP.ObjectModel;

namespace Task2Tests_TP.ObjectModel
{
    [TestClass]
    public class BTest
    {
        private A A;
        private B B;
        private C C;
        private int BField = 30;

        public BTest()
        {
            A = new A(null, 15);
            B = new B(null, BField);
            C = new C(null, 60);

            A.B = B;
            B.C = C;
            C.A = A;
        }

        [TestMethod]
        public void GetBFieldTest()
        {
            Assert.AreEqual(BField, B.BField);
        }

        [TestMethod]
        public void GetCTest()
        {
            Assert.AreEqual(C, B.C);
        }
    }
}
