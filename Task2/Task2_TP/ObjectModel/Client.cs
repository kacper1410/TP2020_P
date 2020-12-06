using System;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        public Client() { }

        public Client(SerializationInfo serializationInfo, int index)
        {
            ClientId = Guid.Parse((string)serializationInfo.GetValue("ClientId_" + index + "_", typeof(string)));
            Name = (string)serializationInfo.GetValue("Name_" + index + "_", typeof(string));
            Surname = (string)serializationInfo.GetValue("Surname_" + index + "_", typeof(string));
            Age = serializationInfo.GetInt32("Age_" + index + "_");
        }

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

        public void GetObjectData(SerializationInfo info, StreamingContext context, int index)
        {
            info.AddValue("ClientId_" + index + "_", ClientId);
            info.AddValue("Name_" + index + "_", Name);
            info.AddValue("Surname_" + index + "_", Surname);
            info.AddValue("Age_" + index + "_", Age);
        }
    }
}
