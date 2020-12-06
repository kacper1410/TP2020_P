using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task2_TP.ObjectModel
{
    [XmlRoot("Purchase", IsNullable = false)]
    public class Purchase
    {
        public Guid PurchaseId { get; set; }
        public Client Client { get; set; }
        [XmlArrayAttribute("Books")]
        public Book[] Books { get; set; }

        public Purchase() { }
        public Purchase(Client client, Book[] books)
        {
            PurchaseId = Guid.NewGuid();
            Client = client;
            Books = books;
        }

        public override string ToString()
        {
            string result = "Purchase: \n" +
                " " + PurchaseId + "\n" +
                "  " + Client.ToString() + "\n";
            foreach (Book book in Books)
            {
                result += book + "\n";
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Purchase purchase = (Purchase)obj;
            Boolean booksEqual = true;

            for (int i = 0; i < Books.Length; i++)
            {
                if (!Books[i].Equals(purchase.Books[i])) 
                {
                    booksEqual = false;
                    break;
                }
            }

            return PurchaseId.Equals(purchase.PurchaseId) &&
                   EqualityComparer<Client>.Default.Equals(Client, purchase.Client) &&
                   booksEqual;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context, int index)
        {
            info.AddValue("PurchaseId_" + index + "_", PurchaseId);
            Client.GetObjectData(info, context, index);
            int indexB = 0;
            foreach (Book book in Books)
            {
                book.GetObjectData(info, context, index, indexB);
                indexB++;
            }
        }
    }
}
