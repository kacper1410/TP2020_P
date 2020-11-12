using System;

namespace Task1_TP.Objects
{
    public class Book
    {
        public Guid BookId { get; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public CoverType CoverType { get; private set; }
        public string Genre { get; private set; }

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
