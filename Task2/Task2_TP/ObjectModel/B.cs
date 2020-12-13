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

<<<<<<< HEAD
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
=======
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
>>>>>>> 0b3b472d152a95881a5d26cedda8c240b7883929
        }
    }
}
