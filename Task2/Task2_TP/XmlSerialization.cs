using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    public class XmlSerialization : ISerialization
    {
        public void Serialize(PurchaseRecord purchaseRecord, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseRecord));
            TextWriter writer = new StreamWriter(path);
            xmlSerializer.Serialize(writer, purchaseRecord);
            writer.Close();
        }

        public PurchaseRecord Deserialize(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseRecord));
            PurchaseRecord purchase = null;

            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (XmlReader reader = XmlReader.Create(fileStream))
            {
                purchase = (PurchaseRecord)xmlSerializer.Deserialize(reader);
            }
            return purchase;
        }
    }
}
