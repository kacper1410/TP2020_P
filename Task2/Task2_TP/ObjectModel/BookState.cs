using System;

namespace Task2_TP.ObjectModel
{
    public class BookState
    {
        public Guid BookStateId { get; }
        public Book Book { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public BookState(Book book, double price, int quantity)
        {
            BookStateId = Guid.NewGuid();
            Book = book;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            string result = "BookState: \n" +
                " " + Book.ToString() + "\n" +
                " Price: " + Price + "\n" +
                " Quantity: " + Quantity + "\n";

            return result;
        }
    }
}
