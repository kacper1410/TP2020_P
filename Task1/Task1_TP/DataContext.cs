using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Task1_TP.Objects;

namespace Task1_TP
{
    class DataContext
    {
        public List<Client> Clients = new List<Client>();
        public Dictionary<Guid, Book> Books = new Dictionary<Guid, Book>();
        public ObservableCollection<Purchase> Purchuases = new ObservableCollection<Purchase>();
        public List<BookState> BookStates = new List<BookState>();
    }
}
