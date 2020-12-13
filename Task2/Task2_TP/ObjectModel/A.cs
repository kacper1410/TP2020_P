using System;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class A : ISerializable
    {
        public B B { get; set; }
        public int AField { get; set; }

        public A() { }

        public A(B b, AField aField)
        {
            B = b;
            AField = aField;
        }

        public A(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("B", B);
            info.AddValue("AField", AField);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            B = (B)info.GetValue("B", typeof(B));
            AField = info.GetInt32("AField");
        }
    }
}
