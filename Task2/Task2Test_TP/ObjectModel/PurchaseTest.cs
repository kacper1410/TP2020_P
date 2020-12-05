using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2_TP.ObjectModel;

namespace Task1Tests_TP

{
    [TestClass]
    public class PurchaseTest
    {
        Book Book;
        Client Client;
        Purchase Purchase;
        Guid Guid;

        public PurchaseTest()
        {
            this.Book = new Book("tytuł", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.Client = new Client("imie", "nazwisko", 20);
            this.Purchase = new Purchase(Client, new Book[] { Book });
            this.Guid = Purchase.PurchaseId;
        }

        [TestMethod]
        public void PurchaseGetClientTest()
        {
            Assert.AreEqual(Client, Purchase.Client);
        }

        [TestMethod]
        public void PurchaseGetGuidTest()
        {
            Assert.AreEqual(Guid, Purchase.PurchaseId);
        }

        [TestMethod]
        public void PurchaseGetBooksTest()
        {
            Assert.AreEqual(Book, Purchase.Books[0]);
        }
    }
}
