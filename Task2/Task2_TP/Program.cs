using System;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose;
            int method;
            string path;
            ISerialization serialization;
            PurchaseRecord purchaseRecord;

            Console.WriteLine("***MENU***");
            Console.WriteLine("Choose method");
            Console.WriteLine("[1] XML");
            Console.WriteLine("[2] Custom formatter");
            method = Console.Read() - 48;

            switch (method)
            {
                case 1:
                    serialization = new XmlSerialization();
                    break;
                case 2:
                    serialization = new CustomSerialization();
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    return;
            }

            Console.WriteLine("Write path");
            Console.ReadLine();
            path = Console.ReadLine();

            Console.WriteLine("[1] Serialize");
            Console.WriteLine("[2] Deserialize");
            choose = Console.Read() - 48;
            try
            {
                switch (choose)
                {
                    case 1:
                        purchaseRecord = PurchaseRecordFiller.GetDefaultPurchaseRecord();
                        serialization.Serialize(purchaseRecord, path);
                        break;
                    case 2:
                        purchaseRecord = serialization.Deserialize(path);
                        Console.WriteLine(purchaseRecord.ToString());
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        return;
                }
            } 
            catch (Exception e)
            {
                Console.Write("Blad serializacji");
            }
        }
    }
}
