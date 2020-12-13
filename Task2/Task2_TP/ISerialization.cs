using Task2_TP.ObjectModel;

namespace Task2_TP
{
    interface ISerialization
    {
        public void Serialize(A graph, string path);
        public A Deserialize(string path);
    }
}
