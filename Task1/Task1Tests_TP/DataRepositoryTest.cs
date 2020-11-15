using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Task1_TP.Data;
using Task1_TP.Data.DataFillers;
using Task1_TP.Data.ObjectModel;

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
            this.DataRepository = new DataRepository(new EmptyDataFiller());
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

        [TestMethod]
        public void DeleteBookTest()
        {
            DataRepository.AddBook(Book);
            DataRepository.DeleteBook(Book);
            Assert.IsNull(DataRepository.GetBook(Book.BookId));
        }

        [TestMethod]
        public void DeleteBookStateTest()
        {
            DataRepository.AddBookState(BookState);
            DataRepository.DeleteBookState(BookState);
            Assert.IsNull(DataRepository.GetBookState(BookState.BookStateId));
        }

        [TestMethod]
        public void DeleteClientTest()
        {
            DataRepository.AddClient(Client);
            DataRepository.DeleteClient(Client);
            Assert.IsNull(DataRepository.GetClient(Client.ClientId));
        }

        [TestMethod]
        public void DeletePurchaseTest()
        {
            DataRepository.AddPurchase(Purchase);
            DataRepository.DeletePurchase(Purchase);
            Assert.IsNull(DataRepository.GetPurchase(Purchase.PurchaseId));
        }

        [TestMethod]
        public void GetAllBooksTest()
        {
            List<Book> Books = new List<Book>();
            Books.Add(Book);
            DataRepository.AddBook(Book);
            Assert.AreEqual(DataRepository.GetAllBooks().ToString(), Books.ToString());
        }

        [TestMethod]
        public void GetAllBookStateTest()
        {
            List<BookState> BookStates = new List<BookState>();
            BookStates.Add(BookState);
            DataRepository.AddBookState(BookState);
            Assert.AreEqual(DataRepository.GetAllBookStates().ToString(), BookStates.ToString());
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            DataRepository.AddClient(Client);
            IEnumerator<Client> Enumerator = DataRepository.GetAllClients().GetEnumerator();
            int size = 0;
            while (Enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(Client, Enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetAllPurchasesTest()
        {
            ObservableCollection<Purchase> Purchases = new ObservableCollection<Purchase>();
            Purchases.Add(Purchase);
            DataRepository.AddPurchase(Purchase);
            Assert.AreEqual(DataRepository.GetAllPurchases().ToString(), Purchases.ToString());
        }


        [TestMethod]
        public void UpdateBookTest()
        {
            Book Book2 = new Book("tytuł2", "autor2", CoverType.Paperback, "gatunek2");

            DataRepository.AddBook(Book);
            DataRepository.UpdateBook(Book.BookId, Book2);

            Assert.IsNull(DataRepository.GetBook(Book.BookId));
            Assert.AreEqual(DataRepository.GetBook(Book2.BookId), Book2);
        }

        [TestMethod]
        public void UpdateBookStateTest()
        {
            BookState BookState2 = new BookState(Book, 500, 300);

            DataRepository.AddBookState(BookState);
            DataRepository.UpdateBookState(BookState.BookStateId , BookState2);

            Assert.IsNull(DataRepository.GetBookState(BookState.BookStateId));
            Assert.AreEqual(DataRepository.GetBookState(BookState2.BookStateId), BookState2);
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            Client Client2 = new Client("imie2", "nazwisko2", 200);
            
            DataRepository.AddClient(Client);
            DataRepository.UpdateClient(Client.ClientId, Client2);

            Assert.IsNull(DataRepository.GetClient(Client.ClientId));
            Assert.AreEqual(DataRepository.GetClient(Client2.ClientId), Client2);
        }

        [TestMethod]
        public void UpdatePurchaseTest()
        {
            Purchase Purchase2 = new Purchase(Client, BookState, DateTimeOffset, 10);

            DataRepository.AddPurchase(Purchase);
            DataRepository.UpdatePurchase(Purchase.PurchaseId, Purchase2);

            Assert.IsNull(DataRepository.GetPurchase(Purchase.PurchaseId));
            Assert.AreEqual(DataRepository.GetPurchase(Purchase2.PurchaseId), Purchase2);
        }
    }
}
