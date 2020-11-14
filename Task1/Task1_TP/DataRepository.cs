using System;
using System.Collections.Generic;
using System.Text;
using Task1_TP.Objects;

namespace Task1_TP
{
    public class DataRepository : IDataRepository
    {
        private DataContext DataContext;

        public DataRepository()
        {
            DataContext = new DataContext();
        }

        public void AddBook(Book book)
        {
            DataContext.Books.Add(book.BookId, book);
        }

        public void AddBookState(BookState bookState)
        {
            DataContext.BookStates.Add(bookState);
        }

        public void AddClient(Client client)
        {
            DataContext.Clients.Add(client);
        }

        public void AddPurchase(Purchase purchase)
        {
            DataContext.Purchuases.Add(purchase);
        }

        public void DeleteBook(Book book)
        {
            DataContext.Books.Remove(book.BookId);
        }

        public void DeleteBookState(BookState bookState)
        {
            DataContext.BookStates.Remove(bookState);
        }

        public void DeleteClient(Client client)
        {
            DataContext.Clients.Remove(client);
        }

        public void DeletePurchase(Purchase purchase)
        {
            DataContext.Purchuases.Remove(purchase);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return (IEnumerable<Book>)DataContext.Books;
        }

        public IEnumerable<BookState> GetAllBookStates()
        {
            return DataContext.BookStates;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return DataContext.Clients;
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return DataContext.Purchuases;
        }

        public Book GetBook(Guid bookId)
        {
            return DataContext.Books[bookId];
        }

        public BookState GetBookState(Guid bookStateId)
        {
            foreach (BookState bookState in DataContext.BookStates)
            {
                if (bookState.BookStateId.Equals(bookStateId))
                {
                    return bookState;
                }
            }

            return null;
        }

        public Client GetClient(Guid clientId)
        {
            foreach (Client client in DataContext.Clients)
            {
                if (client.ClientId.Equals(clientId))
                {
                    return client;
                }
            }

            return null;
        }

        public Purchase GetPurchase(Guid purchaseId)
        {
            foreach (Purchase purchase in DataContext.Purchuases)
            {
                if (purchase.PurchaseId.Equals(purchaseId))
                {
                    return purchase;
                }
            }

            return null;
        }

        public void UpdateBook(Guid bookId, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookState(Guid bookStateId, BookState bookState)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Guid clientId, Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchase(Guid purchaseId, Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
