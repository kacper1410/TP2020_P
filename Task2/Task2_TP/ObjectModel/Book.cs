using System;

namespace Task2_TP.ObjectModel
{
    public class Book
    {
        public Guid BookId { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public CoverType BookCoverType { get; set; }
        public string Genre { get; set; }

        public Book() { }

        public Book(string title, string author, CoverType coverType, string genre)
        {
            this.BookId = Guid.NewGuid();
            this.Title = title;
            this.Author = author;
            this.BookCoverType = coverType;
            this.Genre = genre;
        }

        public override string ToString()
        {
            string result = "Book: \n" +
                " Title: " + Title + "\n" +
                " Author: " + Author + "\n" +
                " CoverType: " + Enum.GetName(typeof(CoverType), BookCoverType) + "\n" +
                " Genre: " + Genre + "\n"; 

            return result;
        }
    }

    public enum CoverType
    {
        HardcoverCaseWrap,
        Paperback,
        HardcoverDustJacket,
        Other
    }
    
}
