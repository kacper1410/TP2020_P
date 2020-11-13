using System;

namespace Task1_TP.Objects
{
    public class Book
    {
        public Guid BookId { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public CoverType CoverType { get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, CoverType coverType, string genre)
        {
            this.BookId = Guid.NewGuid();
            this.Title = title;
            this.Author = author;
            this.CoverType = coverType;
            this.Genre = genre;
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
