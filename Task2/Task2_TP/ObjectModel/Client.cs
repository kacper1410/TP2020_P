using System;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class Client : ISerializable
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        public Client() { }
        public Client(string name, string surname, int age)
        {
            ClientId = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Age = age;
        }

        public override string ToString()
        {
            string result = "Client: \n" +
                " " + ClientId + "\n" +
                " Name: " + Name + "\n" +
                " Surname: " + Surname + "\n" +
                " Age: " + Age + "\n";

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   ClientId.Equals(client.ClientId) &&
                   Name == client.Name &&
                   Surname == client.Surname &&
                   Age == client.Age;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClientId", ClientId);
            info.AddValue("Name", Name);
            info.AddValue("Surname", Surname);
            info.AddValue("Age", Age);
        }
    }
}
