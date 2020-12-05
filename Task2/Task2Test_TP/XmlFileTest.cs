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
        Book Book;
        Book Book1;
        Client Client;
        Purchase Purchase;
        Guid Guid;

        public XmlFileTest()
        {
            this.Book = new Book("tytu³", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.Book1 = new Book("tytu³1", "autor1", CoverType.HardcoverCaseWrap, "gatunek");
            this.Client = new Client("imie", "nazwisko", 20);
            this.Guid = Guid.NewGuid();
            this.Purchase = new Purchase(Guid, Client, new Book[] { Book, Book1 });
        }

        [TestMethod]
        public void TestMethod1()
        {
            XmlFile.PurchasesToXmlFile(Purchase, "..\\..\\..\\..\\TestResults\\test.xml");
            Purchase purchase = XmlFile.XmlFileToPurchase("..\\..\\..\\..\\TestResults\\test.xml");
            Debug.Write(purchase);
        }
    }
}
