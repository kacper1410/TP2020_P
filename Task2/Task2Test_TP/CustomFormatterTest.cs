using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Serialization;
using Task2_TP.ObjectModel;
using Task2_TP;
using System.IO;

namespace Task2Tests_TP
{
    [TestClass]
    public class CustomFormatterTest
    {
        private A A;
        private Formatter Formatter;
        private String Path;
        
        public CustomFormatterTest()
        {
            this.A = Filler.GetDefaultClass();
            this.Formatter = new CustomSerialization();
            this.Path = "..\\..\\..\\..\\TestResults\\testCustomSerialization.xml";
        }

        [TestMethod]
        public void SerializationAndDeserializationCustomFormatterTest()
        {
            A a;
            using (Stream stream = new FileStream(Path, FileMode.Create))
            {
                Formatter.Serialize(stream, A);
            }

            using (Stream stream = new FileStream(Path, FileMode.Open))
            {
                a = (A)Formatter.Deserialize(stream);
            }
            Assert.IsNotNull(a);
            Assert.AreEqual(A.AField, a.AField);
            Assert.AreEqual(A.B.BField, a.B.BField);
            Assert.AreEqual(A.B.C.CField, a.B.C.CField);
            Assert.AreEqual(a, a.B.C.A);
        }
    }
}
