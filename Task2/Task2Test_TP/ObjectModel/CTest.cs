using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Task2_TP.ObjectModel;

namespace Task2Tests_TP.ObjectModel
{
    [TestClass]
    public class CTest
    {
        private A A;
        private C C;
        private int CField = 60;

        public CTest()
        {
            A = new A(null, 15);
            B b = new B(null, 30);
            C = new C(null, CField);

            A.B = b;
            b.C = C;
            C.A = A;
        }

        [TestMethod]
        public void GetCFieldTest()
        {
            Assert.AreEqual(CField, C.CField);
        }

        [TestMethod]
        public void GetATest()
        {
            Assert.AreEqual(A, C.A);
        }
    }
}
