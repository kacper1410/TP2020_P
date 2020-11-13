using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_TP.Objects
{
    public class Client
    {
        public Guid UserId { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Client(string name, string surname, int age)
        {
            UserId = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
