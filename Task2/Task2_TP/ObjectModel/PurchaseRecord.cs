using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class PurchaseRecord : ISerializable
    {   
        public Purchase[] Purchases { get; set; }
        public int PurchasesNumber { get; set; }
        public Guid PurchaseRecordId { get; set; }

        public PurchaseRecord()
        {
        }

        public PurchaseRecord(Purchase[] purchases)
        {
            PurchaseRecordId = Guid.NewGuid();
            Purchases = purchases;
            PurchasesNumber = purchases.Length;
        }

        public PurchaseRecord(SerializationInfo serializationInfo)
        {
            PurchaseRecordId = Guid.Parse((string)serializationInfo.GetValue("PurchaseRecordId_", typeof(string)));
            PurchasesNumber = serializationInfo.GetInt32("PurchasesNumber_");
            
            List<Purchase> purchases = new List<Purchase>();
            for (int i = 0; i < PurchasesNumber; i++)
            {
                purchases.Add(new Purchase(serializationInfo, i));
            }

            Purchases = purchases.ToArray();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PurchaseRecordId_", PurchaseRecordId);
            info.AddValue("PurchasesNumber_", PurchasesNumber);
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
