using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_TP.Objects
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
    }
}
