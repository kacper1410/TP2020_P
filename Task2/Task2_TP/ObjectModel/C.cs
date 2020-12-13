using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2_TP.ObjectModel
{
    public class C : ISerializable
    {
        public C(A a, int cField)
        {
            A = a;
            CField = cField;
        }

        public A A { get; set; }
        public int CField { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
