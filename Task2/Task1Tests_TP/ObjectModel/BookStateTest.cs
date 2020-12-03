using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_TP.Data.ObjectModel;

namespace Task1Tests_TP

{
    [TestClass]
    public class BookStateTest
    {
        Book Book;
        BookState BookState;

        public BookStateTest()
        {
            this.Book = new Book("tytuł", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.BookState = new BookState(Book, 50, 30);
        }

        [TestMethod]
        public void BookStateGetBookTest()
        {
            Assert.AreEqual(Book, BookState.Book);
        }

        [TestMethod]
        public void BookStateGetPriceTest()
        {
            Assert.AreEqual(50, BookState.Price);
        }

        [TestMethod]
        public void BookStateGetQuantityTest()
        {
            Assert.AreEqual(30, BookState.Quantity);
        }

    }
}
