using Task2_TP.ObjectModel;

namespace Task2_TP
{
    public class Filler
    {
        public static PurchaseRecord GetDefaultClass()
        {
            Book book1 = new Book("Uncle Tom's Cabin", "Harriet Beecher Stowe", CoverType.Paperback, "Mystery");
            Book book2 = new Book("Brainwalker", "Robyn Mundell", CoverType.Other, "Horror");
            Book book3 = new Book("Inferno", "Dante Alighieri", CoverType.HardcoverCaseWrap, "Science");
            Book book4 = new Book("The Shadow Girl", "Robyn Mundell", CoverType.HardcoverDustJacket, "Guide");
            Book book5 = new Book("Schindler's List", "Thomas Keneally", CoverType.Paperback, "History");
            Client adam = new Client("Adam", "Kowalski", 28);
            Client maciej = new Client("Maciej", "Jankowski", 21);
            Purchase purchase1 = new Purchase(adam, new Book[] { book1, book2 });
            Purchase purchase2 = new Purchase(adam, new Book[] { book3 });
            Purchase purchase3 = new Purchase(maciej, new Book[] { book4, book5 });
            return new PurchaseRecord(new Purchase[] { purchase1, purchase2, purchase3 });
        }
    }
}
