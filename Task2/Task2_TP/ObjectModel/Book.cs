using System;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class Book : ISerializable
    {
        public Guid BookId { get; set; }
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
                " " + BookId + "\n" +
                " Title: " + Title + "\n" +
                " Author: " + Author + "\n" +
                " CoverType: " + Enum.GetName(typeof(CoverType), BookCoverType) + "\n" +
                " Genre: " + Genre + "\n"; 

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   BookId.Equals(book.BookId) &&
                   Title == book.Title &&
                   Author == book.Author &&
                   BookCoverType == book.BookCoverType &&
                   Genre == book.Genre;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BookId", BookId);
            info.AddValue("Title", Title);
            info.AddValue("Author", Author);
            info.AddValue("BookCoverType", BookCoverType);
            info.AddValue("Genre", Genre);
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
