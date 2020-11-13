using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_TP.Objects
{
    public class Purchase
    {
        public Guid PurchaseID { get; }
        public Client Client { get; set; }
        public BookState BookState { get; set; }
        public DateTimeOffset PurchaseTime { get; set; }
        public int BoughtQuantity { get; set; }


        public Purchase(Client client, BookState bookState, DateTimeOffset purchaseTime, int boughtQuantity)
        {
            PurchaseID = Guid.NewGuid();
            Client = client;
            BookState = bookState;
            PurchaseTime = purchaseTime;
            BoughtQuantity = boughtQuantity;
        }
    }
}
