using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_TP.ObjectModel;

namespace Task1Tests_TP

{
    [TestClass]
    public class BookTest
    {
        Book Book = new Book("tytu³", "autor", CoverType.HardcoverCaseWrap, "gatunek");

        [TestMethod]
        public void BookGetTitleTest()
        {
            Assert.AreEqual("tytu³", Book.Title);
        }

        [TestMethod]
        public void BookGetAuthorTest()
        {
            Assert.AreEqual("autor", Book.Author);
        }

        [TestMethod]
        public void BookGetGenreTest()
        {
            Assert.AreEqual("gatunek", Book.Genre);
        }

        [TestMethod]
        public void BookGetCoverTypeTest()
        {
            Assert.AreEqual(CoverType.HardcoverCaseWrap, Book.BookCoverType);
        }
    }
}
