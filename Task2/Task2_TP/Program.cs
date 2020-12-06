using System;
using System.IO;
using System.Runtime.Serialization;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Uncle Tom's Cabin", "Harriet Beecher Stowe", CoverType.Paperback, "Mystery");
            Book book2 = new Book("Brainwalker", "Robyn Mundell", CoverType.Other, "Horror");
            Book book3 = new Book("Inferno", "Dante Alighieri", CoverType.HardcoverCaseWrap, "Science");
            Book book4 = new Book("The Shadow Girl", "Robyn Mundell", CoverType.HardcoverDustJacket, "Guide");
            Book book5 = new Book("Schindler's List", "Thomas Keneally", CoverType.Paperback, "History");
            Client adam = new Client("Adam", "Kowalski", 28);
            Client maciej = new Client("Maciej", "Jankowski", 21);
            Purchase purchase1 = new Purchase(adam, new Book[] { book1, book2 });
            Purchase purchase2 = new Purchase(adam, new Book[] { book4 });
            Purchase purchase3 = new Purchase(maciej, new Book[] { book3, book5 });

            PurchaseRecord purchaseRecord = new PurchaseRecord(new Purchase[] { purchase3, purchase2, purchase1 });

            Formatter formatter = new CustomFormatter();

            String path = "..\\..\\..\\..\\TestResults\\testCustomSerialization.xml";
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, purchaseRecord);
            }

            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                formatter.Deserialize(stream);
            }

            //SerializationInfo serializationInfo = new SerializationInfo(purchaseRecord.GetType(), new FormatterConverter());
            //StreamingContext streamingContext = new StreamingContext(StreamingContextStates.File);
            //purchaseRecord.GetObjectData(serializationInfo, streamingContext);
            //foreach (SerializationEntry item in serializationInfo)
            //{
            //    Console.WriteLine(item.Name + item.Value);
            //}


            //int choose;
            //Console.WriteLine("***MENU***");
            //Console.WriteLine("[1] Read");
            //Console.WriteLine("[2] Write");
            //choose = Console.Read();

            //switch (choose)
            //{
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        Console.WriteLine("Wrong option");
            //        break;
            //}
        }
    }
}
