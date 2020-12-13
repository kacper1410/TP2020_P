using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task2_TP.ObjectModel
{
    public class C : ISerializable
    {
        [XmlIgnore]
        public A A { get; set; }
        public int CField { get; set; }

        public C() { }

        public C(A a, int cField)
        {
            A = a;
            CField = cField;
        }

        public C(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", A);
            info.AddValue("CField", CField);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            A = (A)info.GetValue("A", typeof(A));
            CField = info.GetInt32("CField");
        }

        public override bool Equals(object obj)
        {
            return obj is C c &&
                   CField == c.CField && A.AField == c.A.AField;
        }
    }
}
