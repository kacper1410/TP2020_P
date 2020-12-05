using System.IO;
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
    }
}
