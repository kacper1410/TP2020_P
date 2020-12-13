using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Task2_TP.ObjectModel
{
    public class A : ISerializable
    {
        public B B { get; set; }
        public int AField { get; set; }

        public A() { }

        public A(B b, int aField)
        {
            B = b;
            AField = aField;
        }

        public A(SerializationInfo info, StreamingContext context)
        {
            B = (B)info.GetValue("B", typeof(B));
            AField = info.GetInt32("AField");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("B", B);
            info.AddValue("AField", AField);
        }

        public void ReadXml()
        {
            B.C.A = this;
        }

        public override bool Equals(object obj)
        {
            return obj is A a &&
                   EqualityComparer<B>.Default.Equals(B, a.B) &&
                   AField == a.AField;
        }
    }
}
