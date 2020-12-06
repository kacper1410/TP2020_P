using System.IO;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    class CustomSerialization : ISerialization
    {
        public PurchaseRecord Deserialize(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                CustomFormatter formatter = new CustomFormatter();
                return (PurchaseRecord)formatter.Deserialize(stream);
            }
        }

        public void Serialize(PurchaseRecord purchaseRecord, string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                CustomFormatter formatter = new CustomFormatter();
                formatter.Serialize(stream, purchaseRecord);
            }
        }
    }
}
