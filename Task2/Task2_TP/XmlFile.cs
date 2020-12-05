using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    public static class XmlFile
    {
        public static void PurchasesToXmlFile(Purchase purchase, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Purchase));
            TextWriter writer = new StreamWriter(path);
            xmlSerializer.Serialize(writer, purchase);
            writer.Close();
        }

        public static Purchase XmlFileToPurchase(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Purchase));
            Purchase purchase = null;

            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (XmlReader reader = XmlReader.Create(fileStream))
                purchase = (Purchase)xmlSerializer.Deserialize(reader);
            return purchase;
        }
    }
}
