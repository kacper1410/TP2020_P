﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private Book Book1;
        private Book Book2;
        private Book Book3;
        private Book Book4;
        private Book Book5;
        private Client Adam;
        private Client Maciej;
        private Purchase Purchase1;
        private Purchase Purchase2;
        private Purchase Purchase3;
        private PurchaseRecord PurchaseRecord;
        private Formatter Formatter;
        private String Path;
        
        public CustomFormatterTest()
        {
            this.Book1 = new Book("Uncle Tom's Cabin", "Harriet Beecher Stowe", CoverType.Paperback, "Mystery");
            this.Book2 = new Book("Brainwalker", "Robyn Mundell", CoverType.Other, "Horror");
            this.Book3 = new Book("Inferno", "Dante Alighieri", CoverType.HardcoverCaseWrap, "Science");
            this.Book4 = new Book("The Shadow Girl", "Robyn Mundell", CoverType.HardcoverDustJacket, "Guide");
            this.Book5 = new Book("Schindler's List", "Thomas Keneally", CoverType.Paperback, "History");
            this.Adam = new Client("Adam", "Kowalski", 28);
            this.Maciej = new Client("Maciej", "Jankowski", 21);
            this.Purchase1 = new Purchase(Adam, new Book[] { Book1, Book2 });
            this.Purchase2 = new Purchase(Adam, new Book[] { Book3 });
            this.Purchase3 = new Purchase(Maciej, new Book[] { Book4, Book5 });
            this.PurchaseRecord = new PurchaseRecord(new Purchase[] { Purchase1, Purchase2, Purchase3 });
            this.Formatter = new CustomFormatter();
            this.Path = "..\\..\\..\\..\\TestResults\\testCustomSerialization.xml";
        }

        [TestMethod]
        public void SerializationAndDeserializationCustomFormatterTest()
        {
            PurchaseRecord purchaseRecord;
            using (Stream stream = new FileStream(Path, FileMode.Create))
            {
                Formatter.Serialize(stream, PurchaseRecord);
            }

            using (Stream stream = new FileStream(Path, FileMode.Open))
            {
                purchaseRecord = (PurchaseRecord)Formatter.Deserialize(stream);
            }
            Assert.IsNotNull(purchaseRecord);
            Assert.AreEqual(PurchaseRecord, purchaseRecord);
            Assert.AreEqual(Purchase1, purchaseRecord.Purchases[0]);
            Assert.AreEqual(Purchase2, purchaseRecord.Purchases[1]);
            Assert.AreEqual(Purchase3, purchaseRecord.Purchases[2]);
            Assert.AreEqual(Book1, purchaseRecord.Purchases[0].Books[0]);
            Assert.AreEqual(Book2, purchaseRecord.Purchases[0].Books[1]);
            Assert.AreEqual(Book3, purchaseRecord.Purchases[1].Books[0]);
            Assert.AreEqual(Book4, purchaseRecord.Purchases[2].Books[0]);
            Assert.AreEqual(Book5, purchaseRecord.Purchases[2].Books[1]);
        }
    }
}