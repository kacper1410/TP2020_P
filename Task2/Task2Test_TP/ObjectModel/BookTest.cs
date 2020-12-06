using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
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

        [TestMethod]
        public void BookGetObjectDataTest()
        {
            SerializationInfo serializationInfo = new SerializationInfo(Book.GetType(), new FormatterConverter());
            StreamingContext streamingContext = new StreamingContext(StreamingContextStates.File);
            Assert.AreEqual(false, serializationInfo.GetEnumerator().MoveNext());
        }
    }
}
