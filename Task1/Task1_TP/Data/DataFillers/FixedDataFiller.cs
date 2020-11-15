using System;
using Task1_TP.Data.ObjectModel;

namespace Task1_TP.Data.DataFillers
{
    public class FixedDataFiller : IDataFiller
    {
        public void Fill(IDataRepository dataRepository)
        {
            Client adam = new Client("Adam", "Kowalski", 28);
            Client maciej = new Client("Maciej", "Jankowski", 21);
            Client marta = new Client("Marta", "Borkowska", 35);
            Client adrianna = new Client("Adrianna", "Sarna", 19);
            Client andrea = new Client("Andrea", "Sovilile", 94);

            dataRepository.AddClient(adam);
            dataRepository.AddClient(maciej);
            dataRepository.AddClient(marta);
            dataRepository.AddClient(adrianna);
            dataRepository.AddClient(andrea);

            Book book1 = new Book("Uncle Tom's Cabin", "Harriet Beecher Stowe", CoverType.Paperback, "Mystery");
            Book book2 = new Book("Brainwalker", "Robyn Mundell", CoverType.Other, "Horror");
            Book book3 = new Book("Inferno", "Dante Alighieri", CoverType.HardcoverCaseWrap, "Science");
            Book book4 = new Book("The Shadow Girl", "Robyn Mundell", CoverType.HardcoverDustJacket, "Guide");
            Book book5 = new Book("Schindler's List", "Thomas Keneally", CoverType.Paperback, "History");

            dataRepository.AddBook(book1);
            dataRepository.AddBook(book2);
            dataRepository.AddBook(book3);
            dataRepository.AddBook(book4);
            dataRepository.AddBook(book5);

            BookState bookState1 = new BookState(book1, 30, 20);
            BookState bookState2 = new BookState(book2, 70, 67);
            BookState bookState3 = new BookState(book3, 50, 25);
            BookState bookState4 = new BookState(book4, 48, 57);
            BookState bookState5 = new BookState(book5, 25, 200);

            dataRepository.AddBookState(bookState1);
            dataRepository.AddBookState(bookState2);
            dataRepository.AddBookState(bookState3);
            dataRepository.AddBookState(bookState4);
            dataRepository.AddBookState(bookState5);

            Purchase purchase1 = new Purchase(adam, bookState1, DateTimeOffset.Now, 1);
            Purchase purchase2 = new Purchase(adam, bookState2, DateTimeOffset.Now, 32);
            Purchase purchase3 = new Purchase(maciej, bookState5, DateTimeOffset.Now, 100);
            Purchase purchase4 = new Purchase(adrianna, bookState4, DateTimeOffset.Now, 12);
            Purchase purchase5 = new Purchase(andrea, bookState1, DateTimeOffset.Now, 10);

            dataRepository.AddPurchase(purchase1);
            dataRepository.AddPurchase(purchase2);
            dataRepository.AddPurchase(purchase3);
            dataRepository.AddPurchase(purchase4);
            dataRepository.AddPurchase(purchase5);

        }
    }
}
