using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Task2_TP;
using Task2_TP.ObjectModel;

namespace Task2Test_TP
{
    [TestClass]
    public class XmlFileTest
    {
        private Book Book;
        private Book Book1;
        private Client Client;
        private Purchase Purchase;
        private PurchaseRecord PurchaseRecord;

        public XmlFileTest()
        {
            this.Book = new Book("tytu³", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.Book1 = new Book("tytu³1", "autor1", CoverType.HardcoverCaseWrap, "gatunek");
            this.Client = new Client("imie", "nazwisko", 20);
            this.Purchase = new Purchase(Client, new Book[] { Book, Book1 });
            this.PurchaseRecord = new PurchaseRecord(new Purchase[] { Purchase });
        }

        [TestMethod]
        public void SerializationAndDeserializationXmlFileTest()
        {
            XmlFile.PurchasesToXmlFile(PurchaseRecord, "..\\..\\..\\..\\TestResults\\test.xml");
            PurchaseRecord purchaseRecord = XmlFile.XmlFileToPurchase("..\\..\\..\\..\\testresults\\test.xml");
            Assert.AreEqual(PurchaseRecord, purchaseRecord);
            Assert.AreEqual(Purchase, purchaseRecord.Purchases[0]);
            Assert.AreEqual(Book, purchaseRecord.Purchases[0].Books[0]);
            Assert.AreEqual(Book1, purchaseRecord.Purchases[0].Books[1]);
        }
    }
}
