using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
            Assert.AreEqual(Book, DataRepository.GetBook(Book.BookId));
        }

        [TestMethod]
        public void AddAndGetBookStateTest()
        {
            DataRepository.AddBookState(BookState);
            Assert.AreEqual(BookState, DataRepository.GetBookState(BookState.BookStateId));
        }

        [TestMethod]
        public void AddAndGetClientTest()
        {
            DataRepository.AddClient(Client);
            Assert.AreEqual(Client, DataRepository.GetClient(Client.ClientId));
        }

        [TestMethod]
        public void AddAndGetPurchaseTest()
        {
            DataRepository.AddPurchase(Purchase);
            Assert.AreEqual(Purchase, DataRepository.GetPurchase(Purchase.PurchaseId));
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
            DataRepository.AddBook(Book);
            IEnumerator<Book> enumerator = DataRepository.GetAllBooks().GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(Book, enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetAllBookStateTest()
        {
            DataRepository.AddBookState(BookState);
            IEnumerator<BookState> enumerator = DataRepository.GetAllBookStates().GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(BookState, enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            DataRepository.AddClient(Client);
            IEnumerator<Client> enumerator = DataRepository.GetAllClients().GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(Client, enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetAllPurchasesTest()
        {
            DataRepository.AddPurchase(Purchase);
            IEnumerator<Purchase> enumerator = DataRepository.GetAllPurchases().GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(Purchase, enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }


        [TestMethod]
        public void UpdateBookTest()
        {
            Book book2 = new Book("tytuł2", "autor2", CoverType.Paperback, "gatunek2");

            DataRepository.AddBook(Book);
            DataRepository.UpdateBook(Book.BookId, book2);

            Assert.IsNull(DataRepository.GetBook(Book.BookId));
            Assert.AreEqual(book2, DataRepository.GetBook(book2.BookId));
        }

        [TestMethod]
        public void UpdateBookStateTest()
        {
            BookState bookState2 = new BookState(Book, 500, 300);

            DataRepository.AddBookState(BookState);
            DataRepository.UpdateBookState(BookState.BookStateId , bookState2);

            Assert.IsNull(DataRepository.GetBookState(BookState.BookStateId));
            Assert.AreEqual(bookState2, DataRepository.GetBookState(bookState2.BookStateId));
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            Client client2 = new Client("imie2", "nazwisko2", 200);
            
            DataRepository.AddClient(Client);
            DataRepository.UpdateClient(Client.ClientId, client2);

            Assert.IsNull(DataRepository.GetClient(Client.ClientId));
            Assert.AreEqual(client2, DataRepository.GetClient(client2.ClientId));
        }

        [TestMethod]
        public void UpdatePurchaseTest()
        {
            Purchase purchase2 = new Purchase(Client, BookState, DateTimeOffset, 10);

            DataRepository.AddPurchase(Purchase);
            DataRepository.UpdatePurchase(Purchase.PurchaseId, purchase2);

            Assert.IsNull(DataRepository.GetPurchase(Purchase.PurchaseId));
            Assert.AreEqual(purchase2, DataRepository.GetPurchase(purchase2.PurchaseId));
        }
        
        [TestMethod]
        public void DataRepositoryEmptyFillerTest()
        {
            DataRepository = new DataRepository(new EmptyDataFiller());

            Assert.IsFalse(DataRepository.GetAllBooks().GetEnumerator().MoveNext());
            Assert.IsFalse(DataRepository.GetAllBookStates().GetEnumerator().MoveNext());
            Assert.IsFalse(DataRepository.GetAllClients().GetEnumerator().MoveNext());
            Assert.IsFalse(DataRepository.GetAllPurchases().GetEnumerator().MoveNext());
        }
        
        [TestMethod]
        public void DataRepositoryFixedFillerTest()
        {
            DataRepository = new DataRepository(new FixedDataFiller());
            int size = 0;
            foreach (Book book in DataRepository.GetAllBooks())
            {
                size++;
            }
            Assert.AreEqual(5, size);

            size = 0;
            foreach (BookState bookState in DataRepository.GetAllBookStates())
            {
                size++;
            }
            Assert.AreEqual(5, size);

            size = 0;
            foreach (Client client in DataRepository.GetAllClients())
            {
                size++;
            }
            Assert.AreEqual(5, size);

            size = 0;
            foreach (Purchase purchase in DataRepository.GetAllPurchases())
            {
                size++;
            }
            Assert.AreEqual(5, size);
        }
    }
}
