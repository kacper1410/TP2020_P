using System;
using System.Collections.Generic;

using Task1_TP.Objects;

namespace Task1_TP
{
    interface IDataRepository
    {
        void AddBook(Book book);
        Book GetBook(Guid bookId);
        IEnumerable<Book> GetAllBooks();
        void UpdateBook(Guid bookId, Book book);
        void DeleteBook(Book book);

        void AddClient(Client client);
        Client GetClient(Guid clientId);
        IEnumerable<Client> GetAllClients();
        void UpdateClient(Guid clientId, Client client);
        void DeleteClient(Client client);

        void AddBookState(BookState bookState);
        BookState GetBookState(Guid bookStateId);
        IEnumerable<BookState> GetAllBookStates();
        void UpdateBookState(Guid bookStateId, BookState bookState);
        void DeleteBookState(BookState bookState);

        void AddPurchase(Purchase purchase);
        Purchase GetPurchase(Guid purchaseId);
        IEnumerable<Purchase> GetAllPurchases();
        void UpdatePurchase(Guid purchaseId, Purchase purchase);
        void DeletePurchase(Purchase purchase);
    }
}
