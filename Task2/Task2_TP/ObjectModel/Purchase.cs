using System;
using System.Xml.Serialization;

namespace Task2_TP.ObjectModel
{
    [XmlRoot("Purchase", IsNullable = false)]
    public class Purchase
    {
        public Guid PurchaseId { get; }
        public Client Client { get; set; }
        [XmlArrayAttribute("Books")]
        public Book[] Books { get; set; }

        public Purchase() { }
        public Purchase(Guid purchaseId, Client client, Book[] books)
        {
            PurchaseId = purchaseId;
            Client = client;
            Books = books;
        }

        public override string ToString()
        {
            string result = "Purchase: \n" +
                "  " + Client.ToString() + "\n";

            return result;
        }
    }
}
