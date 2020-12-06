using Task2_TP.ObjectModel;

namespace Task2_TP
{
    interface ISerialization
    {
        public void Serialize(PurchaseRecord purchaseRecord, string path);
        public PurchaseRecord Deserialize(string path);
    }
}
