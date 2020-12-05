using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    public static class XmlFile
    {
        public static void PurchasesToXmlFile(PurchaseRecord purchase, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseRecord));
            TextWriter writer = new StreamWriter(path);
            xmlSerializer.Serialize(writer, purchase);
            writer.Close();
        }

        public static PurchaseRecord XmlFileToPurchase(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseRecord));
            PurchaseRecord purchase = null;

            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (XmlReader reader = XmlReader.Create(fileStream))
            purchase = (PurchaseRecord)xmlSerializer.Deserialize(reader);
            return purchase;
        }
    }
}
