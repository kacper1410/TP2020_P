using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_TP.Data.ObjectModel
{
    public class Client
    {
        public Guid ClientId { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

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
                " Name: " + Name + "\n" +
                " Surname: " + Surname + "\n" +
                " Age: " + Age + "\n";

            return result;
        }
    }
}
