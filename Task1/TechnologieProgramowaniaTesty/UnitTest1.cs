using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1_TP;

namespace TechnologieProgramowaniaTesty
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 a = new Class1();
            Assert.AreEqual(8, a.Add(5, 3));
        }
    }
}
