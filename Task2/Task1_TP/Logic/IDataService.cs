using System.Collections.Generic;
using Task1_TP.Data.ObjectModel;

namespace Task1_TP.Logic
{
    public interface IDataService
    {
        IEnumerable<Book> GetAllBooks();
        Purchase PurchaseBook(Client client, BookState bookState, int quantity);
        void PrintAllBooks();

        IEnumerable<BookState> GetAllBookStatesForBook(Book book);
        IEnumerable<Purchase> GetAllPurchasesForClient(Client client);
        IEnumerable<Purchase> GetAllPurchasesForBookState(BookState bookState);
        void AddBookState(BookState bookState);
        void AddBooksToBookState(BookState bookState, int quantity);
        void ChangePrice(BookState bookState, int newPrice);
    }
}
