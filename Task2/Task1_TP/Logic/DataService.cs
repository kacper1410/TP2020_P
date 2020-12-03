using System;
using System.Collections.Generic;
using Task1_TP.Data;
using Task1_TP.Data.ObjectModel;

namespace Task1_TP.Logic
{
    public class DataService : IDataService
    {
        public IDataRepository DataRepository { get; set; }

        public DataService(IDataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return DataRepository.GetAllBooks();
        }

        public Purchase PurchaseBook(Client client, BookState bookState, int quantity)
        {
            Purchase Purchase = null;

            if (quantity <= bookState.Quantity)
            {
                Purchase = new Purchase(client, bookState, DateTimeOffset.Now, quantity);
                bookState.Quantity -= quantity;
                DataRepository.AddPurchase(Purchase);
                if (DataRepository.GetClient(client.ClientId) == null)
                {
                    DataRepository.AddClient(client);
                }
            }

            return Purchase;
        }

        public void PrintAllBooks()
        {
            Console.WriteLine("Books: ");
            foreach (Book book in DataRepository.GetAllBooks())
            {
                Console.WriteLine(" " + book.ToString());
            }
        }

        public IEnumerable<BookState> GetAllBookStatesForBook(Book book)
        {
            List<BookState> BookStates = new List<BookState>();

            foreach (BookState bookState in DataRepository.GetAllBookStates())
            {
                if (bookState.Book.Equals(book))
                {
                    BookStates.Add(bookState);
                }
            }

            return BookStates;
        }

        public IEnumerable<Purchase> GetAllPurchasesForClient(Client client)
        {
            List<Purchase> Purchases = new List<Purchase>();

            foreach (Purchase purchase in DataRepository.GetAllPurchases())
            {
                if (purchase.Client.Equals(client))
                {
                    Purchases.Add(purchase);
                }
            }

            return Purchases;
        }

        public IEnumerable<Purchase> GetAllPurchasesForBookState(BookState bookState)
        {
            List<Purchase> Purchases = new List<Purchase>();

            foreach (Purchase purchase in DataRepository.GetAllPurchases())
            {
                if (purchase.BookState.Equals(bookState))
                {
                    Purchases.Add(purchase);
                }
            }

            return Purchases;
        }

        public void AddBookState(BookState bookState)
        {
            if (DataRepository.GetBook(bookState.Book.BookId) == null)
            {
                DataRepository.AddBook(bookState.Book);
            }
            DataRepository.AddBookState(bookState);
        }

        public void AddBooksToBookState(BookState bookState, int quantity)
        {
            DataRepository.UpdateBookState(bookState.BookStateId, new BookState(bookState.Book, bookState.Price, bookState.Quantity + quantity));
        }

        public void ChangePrice(BookState bookState, int newPrice)
        {
            DataRepository.UpdateBookState(bookState.BookStateId, new BookState(bookState.Book, newPrice, bookState.Quantity));
        }
    }
}
