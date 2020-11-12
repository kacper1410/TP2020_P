using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_TP.Objects;

namespace Task1Tests_TP

{
    [TestClass]
    public class BookTest
    {
        Book book = new Book("tytu³", "autor", CoverType.HardcoverCaseWrap, "gatunek");
        [TestMethod]
        public void BookGetTitleTest()
        {
            Assert.AreEqual("tytu³", book.Title);
        }

        [TestMethod]
        public void BookGetAuthorTest()
        {
            Assert.AreEqual("autor", book.Author);
        }

        [TestMethod]
        public void BookGetGenreTest()
        {
            Assert.AreEqual("gatunek", book.Genre);
        }

        [TestMethod]
        public void BookGetCoverTypeTest()
        {
            Assert.AreEqual(CoverType.HardcoverCaseWrap, book.CoverType);
        }
    }
}
