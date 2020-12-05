﻿using System;

namespace Task2_TP.ObjectModel
{
    public class Client
    {
        public Guid ClientId { get; }
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
                " Name: " + Name + "\n" +
                " Surname: " + Surname + "\n" +
                " Age: " + Age + "\n";

            return result;
        }
    }
}
