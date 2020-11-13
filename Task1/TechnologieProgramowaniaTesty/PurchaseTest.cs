using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_TP.Objects;

namespace Task1Tests_TP

{
    [TestClass]
    public class PurchaseTest
    {
        Book Book;
        BookState BookState;
        Client Client;
        Purchase Purchase;
        System.DateTimeOffset DataTimeOffset;

        public PurchaseTest()
        {
            this.Book = new Book("tytuł", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.BookState = new BookState(Book, 50, 30);
            this.Client = new Client("imie", "nazwisko", 20);
            this.DataTimeOffset = System.DateTimeOffset.Now;
            this.Purchase = new Purchase(Client, BookState, DataTimeOffset, 10);
        }

        [TestMethod]
        public void PurchaseGetClientTest()
        {
            Assert.AreEqual(Client, Purchase.Client);
        }

        [TestMethod]
        public void PurchaseGetBookStateTest()
        {
            Assert.AreEqual( BookState, Purchase.BookState);
        }

        [TestMethod]
        public void PurchaseGetPurchaseDateTest()
        {
            Assert.AreEqual(DataTimeOffset, Purchase.PurchaseTime);
        }

        [TestMethod]
        public void PurchaseGetBoughtQuantityTest()
        {
            Assert.AreEqual(10, Purchase.BoughtQuantity);
        }
    }
}
