using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task2_TP.ObjectModel
{
    public class B : ISerializable
    {
        public C C { get; set; }
        public int BField { get; set; }

        public B() { }

        public B(C c, int bField)
        {
            C= c;
            BField = bField;
        }

        public B(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("C", C);
            info.AddValue("BField", BField);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            C = (C)info.GetValue("C", typeof(C));
            BField = info.GetInt32("BField");
        }

        public override bool Equals(object obj)
        {
            return obj is B b &&
                   EqualityComparer<C>.Default.Equals(C, b.C) &&
                   BField == b.BField;
        }
    }
}
