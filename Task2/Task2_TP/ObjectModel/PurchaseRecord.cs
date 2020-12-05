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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PurchaseRecordId", PurchaseRecordId);
            foreach (Purchase purchase in Purchases)
            {
                purchase.GetObjectData(info, context);
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
