using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class PurchaseRecord : ISerializable
    {   
        public Purchase[] Purchases { get; set; }
        public Guid PurchaseRecordId { get; set; }

        public PurchaseRecord()
        {
        }

        public PurchaseRecord(Purchase[] purchases)
        {
            PurchaseRecordId = Guid.NewGuid();
            Purchases = purchases;
        }

        public PurchaseRecord(SerializationInfo serializationInfo)
        {
            PurchaseRecordId = Guid.Parse((string)serializationInfo.GetValue("PurchaseRecordId_", typeof(string)));
            List<Purchase> purchases = new List<Purchase>();
            int index = 0;
            while (false)
            {
                
            }
            Console.WriteLine(PurchaseRecordId);
            foreach (SerializationEntry item in serializationInfo)
            {
                Console.WriteLine(item.Name + item.Value);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PurchaseRecordId_", PurchaseRecordId);
            int index = 0;
            foreach (Purchase purchase in Purchases)
            {
                purchase.GetObjectData(info, context, index);
                index++;
            }
        }

        public override bool Equals(object obj)
        {
            PurchaseRecord purchaseRecord = (PurchaseRecord)obj;
            Boolean purchaseEqual = true;

            for (int i = 0; i < Purchases.Length; i++)
            {
                if (!Purchases[i].Equals(purchaseRecord.Purchases[i]))
                {
                    purchaseEqual = false;
                    break;
                }
            }
            return purchaseEqual &&
                   PurchaseRecordId.Equals(purchaseRecord.PurchaseRecordId);
        }
    }
}
