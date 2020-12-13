using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_TP;
using Task2_TP.ObjectModel;

namespace Task2Test_TP
{
    [TestClass]
    public class XmlSerializationTest
    {
        private A A;
        private XmlSerialization XmlSerialization;

        public XmlSerializationTest()
        {
            this.A = Filler.GetDefaultClass();
            this.XmlSerialization = new XmlSerialization();
        }

        [TestMethod]
        public void SerializationAndDeserializationXmlFileTest()
        {
            XmlSerialization.Serialize(A, "..\\..\\..\\..\\TestResults\\test.xml");
            A a = XmlSerialization.Deserialize("..\\..\\..\\..\\testresults\\test.xml");
            Assert.IsNotNull(a);
            Assert.AreEqual(A, a);
            Assert.AreEqual(A.AField, a.AField);
            Assert.AreEqual(A.B.BField, a.B.BField);
            Assert.AreEqual(A.B.C.CField, a.B.C.CField);
            Assert.AreEqual(a, a.B.C.A);
            Assert.AreEqual(a.B, a.B.C.A.B);
            Assert.AreEqual(a.B.C, a.B.C.A.B.C);
        }
    }
}
