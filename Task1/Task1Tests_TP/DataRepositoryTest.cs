using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_TP;
using Task1_TP.Objects;

namespace Task1Tests_TP
{
    [TestClass]
    public class DataRepositoryTest
    {
        DataRepository DataRepository;
        Book Book;
        BookState BookState;
        Client Client;
        Purchase Purchase;
        System.DateTimeOffset DateTimeOffset;

        public DataRepositoryTest()
        {
            this.DataRepository = new DataRepository();
            this.Book = new Book("tytuł", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.BookState = new BookState(Book, 50, 30);
            this.Client = new Client("imie", "nazwisko", 20);
            this.DateTimeOffset = System.DateTimeOffset.Now;
            this.Purchase = new Purchase(Client, BookState, DateTimeOffset, 10);
        }

        [TestMethod]
        public void AddAndGetBookTest()
        {
            DataRepository.AddBook(Book);
            Assert.AreEqual(DataRepository.GetBook(Book.BookId), Book);
        }

        [TestMethod]
        public void AddAndGetBookStateTest()
        {
            DataRepository.AddBookState(BookState);
            Assert.AreEqual(DataRepository.GetBookState(BookState.BookStateId), BookState);
        }

        [TestMethod]
        public void AddAndGetClientTest()
        {
            DataRepository.AddClient(Client);
            Assert.AreEqual(DataRepository.GetClient(Client.ClientId), Client);
        }

        [TestMethod]
        public void AddAndGetPurchaseTest()
        {
            DataRepository.AddPurchase(Purchase);
            Assert.AreEqual(DataRepository.GetPurchase(Purchase.PurchaseId), Purchase);
        }


    }
}
