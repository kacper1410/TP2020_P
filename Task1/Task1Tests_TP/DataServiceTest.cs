using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Task1_TP.Data;
using Task1_TP.Data.DataFillers;
using Task1_TP.Data.ObjectModel;
using Task1_TP.Logic;

namespace Task1Tests_TP
{
    [TestClass]
    public class DataServiceTest
    {
        DataService DataService;
        DataRepository DataRepository;
        Book Book;
        BookState BookState;
        Client Client;
        Purchase Purchase;
        System.DateTimeOffset DateTimeOffset;

        public DataServiceTest()
        {
            this.DataRepository = new DataRepository(new EmptyDataFiller());
            this.Book = new Book("tytuł", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            this.BookState = new BookState(Book, 50, 30);
            this.Client = new Client("imie", "nazwisko", 20);
            this.DateTimeOffset = System.DateTimeOffset.Now;
            this.Purchase = new Purchase(Client, BookState, DateTimeOffset, 10);
            this.DataService = new DataService(this.DataRepository);
        }

        [TestMethod]
        public void GetAllBooksTest()
        {
            DataService.AddBookState(BookState);
            IEnumerator<Book> enumerator = DataService.GetAllBooks().GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(Book, enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void AddBookStateTest()
        {
            Book book2 = new Book("tytuł2", "autor2", CoverType.HardcoverCaseWrap, "gatunek2");
            BookState bookState2 = new BookState(book2, 500, 300);
            DataService.AddBookState(bookState2);
            IEnumerator enumerator = DataService.GetAllBookStatesForBook(book2).GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(bookState2, enumerator.Current);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetAllBookStatesForBookTest()
        {
            DataService.AddBookState(BookState);
            IEnumerator<BookState> enumerator = DataService.GetAllBookStatesForBook(Book).GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(enumerator.Current, BookState);
            }
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void PurchaseBookTest()
        {
            DataService.AddBookState(BookState);
            DataService.PurchaseBook(Client, BookState, 10);
            // Check GetAllPurchasesForClient
            IEnumerator<Purchase> enumerator = DataService.GetAllPurchasesForClient(Client).GetEnumerator();
            int size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(enumerator.Current.ToString(), Purchase.ToString());
            }
            Assert.AreEqual(1, size);
            // Check GetAllPurchasesForBookState
            enumerator = DataService.GetAllPurchasesForBookState(BookState).GetEnumerator();
            size = 0;
            while (enumerator.MoveNext())
            {
                size++;
                Assert.AreEqual(enumerator.Current.ToString(), Purchase.ToString());
            }
            Assert.AreEqual(1, size);
            // Check if quantity of bought books was substracted in BookState
            IEnumerator<BookState> enumerator2 = DataService.GetAllBookStatesForBook(Book).GetEnumerator();
            while (enumerator2.MoveNext())
            {
                Assert.AreEqual(20, ((BookState)enumerator2.Current).Quantity);
            }
            // Check if quantity of bought books is higer then book state quantity
            Assert.IsNull(DataService.PurchaseBook(Client, BookState, 21));
        }

        [TestMethod]
        public void AddBooksToBookStateTest()
        {
            DataService.AddBookState(BookState);
            IEnumerator<BookState> enumerator = DataService.GetAllBookStatesForBook(Book).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(30, ((BookState)enumerator.Current).Quantity);
            }
            DataService.AddBooksToBookState(BookState, 20);
            enumerator = DataService.GetAllBookStatesForBook(Book).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(50, ((BookState)enumerator.Current).Quantity);
            }
        }

        [TestMethod]
        public void ChangePriceTest()
        {
            DataService.AddBookState(BookState);
            IEnumerator<BookState> enumerator = DataService.GetAllBookStatesForBook(Book).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(50, ((BookState)enumerator.Current).Price);
            }
            DataService.ChangePrice(BookState, 45);
            enumerator = DataService.GetAllBookStatesForBook(Book).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(45, ((BookState)enumerator.Current).Price);
            }
        }
    }
}
