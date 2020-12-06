using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Task2_TP.ObjectModel;

namespace Task2Tests_TP.ObjectModel
{
    [TestClass]
    public class PurchaseRecordTest
    {
        private Book Book1;
        private Book Book2;
        private Client Client;
        private Purchase Purchase;
        private PurchaseRecord PurchaseRecord;

        public PurchaseRecordTest()
        {
            Book1 = new Book("Uncle Tom's Cabin", "Harriet Beecher Stowe", CoverType.Paperback, "Mystery");
            Book2 = new Book("Brainwalker", "Robyn Mundell", CoverType.Other, "Horror");
            Client = new Client("Adam", "Kowalski", 28);
            Purchase = new Purchase(Client, new Book[] { Book1, Book2 });

            PurchaseRecord = new PurchaseRecord(new Purchase[] { Purchase });
        }

        [TestMethod]
        public void PurchaseRecordGetPurchaseTest()
        {
            Assert.AreEqual(Purchase, PurchaseRecord.Purchases[0]);
        }


        [TestMethod]
        public void PurchaseRecordGetBookTest()
        {
            Assert.AreEqual(Book1, PurchaseRecord.Purchases[0].Books[0]);
            Assert.AreEqual(Book2, PurchaseRecord.Purchases[0].Books[1]);
        }
    }
}
