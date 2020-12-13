using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2_TP.ObjectModel
{
    public class B : ISerializable
    {
        public B(C c, int bField)
        {
            C = c;
            BField = bField;
        }

        public C C { get; set; }
        public int BField { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
