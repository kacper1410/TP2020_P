using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2_TP;
using Task2_TP.ObjectModel;

namespace Task2Test_TP
{
    [TestClass]
    public class UnitTest1
    {
        Book Book;
        Book Book1;
        Client Client;
        Purchase Purchase;
        Guid Guid;

        public UnitTest1()
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
            XmlFile.PurchasesToXmlFile(Purchase, "C:\\Users\\Patryk\\Desktop\\test.xml");
        }
    }
}
