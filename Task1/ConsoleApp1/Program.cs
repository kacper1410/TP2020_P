using System;
using Task1_TP.Logic;
using Task1_TP.Data;
using Task1_TP.Data.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using Task1_TP.Data.DataFillers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService(new DataRepository(new EmptyDataFiller()));
            Book  book = new Book("tytuł", "autor", CoverType.HardcoverCaseWrap, "gatunek");
            BookState bookState = new BookState(book, 50, 30);
            Client client = new Client("imie", "nazwisko", 20);
            DateTimeOffset dateTimeOffset = System.DateTimeOffset.Now;
            Purchase purchase = new Purchase(client, bookState, dateTimeOffset, 10);
            dataService.AddBookState(bookState);
            List<BookState> bookStatesExpected = new List<BookState>();
            bookStatesExpected.Add(bookState);
            List<BookState> bookStatesActual = new List<BookState>();
            foreach (BookState bookState1 in dataService.GetAllBookStatesForBook(book))
            {
                bookStatesActual.Add(bookState1);
            }
            Print(bookStatesActual.Count);
            Print(bookStatesExpected.Count);

        }
        static void Print(Object obj)
        {
            Console.WriteLine();
            Console.WriteLine(obj);
            Console.WriteLine();
        }
    }
}
