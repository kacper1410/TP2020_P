using System;

namespace Task2_TP.ObjectModel
{
    public class Purchase
    {
        public Guid PurchaseId { get; }
        public Client Client { get; set; }
        public BookState BookState { get; set; }
        public DateTimeOffset PurchaseTime { get; set; }
        public int BoughtQuantity { get; set; }


        public Purchase(Client client, BookState bookState, DateTimeOffset purchaseTime, int boughtQuantity)
        {
            PurchaseId = Guid.NewGuid();
            Client = client;
            BookState = bookState;
            PurchaseTime = purchaseTime;
            BoughtQuantity = boughtQuantity;
        }

        public override string ToString()
        {
            string result = "Purchase: \n" +
                "  " + Client.ToString() + "\n" +
                "  " + BookState.ToString() + "\n" +
                " PurchaseTime: " + PurchaseTime + "\n" +
                " BoughtQuantity: " + BoughtQuantity + "\n";

            return result;
        }
    }
}
