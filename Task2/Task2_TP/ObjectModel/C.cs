using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2_TP.ObjectModel
{
<<<<<<< HEAD
    public class C
=======
    public class C : ISerializable
>>>>>>> 0b3b472d152a95881a5d26cedda8c240b7883929
    {
        public C(A a, int cField)
        {
            A = a;
            CField = cField;
        }

        public A A { get; set; }
        public int CField { get; set; }
<<<<<<< HEAD
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
=======

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
>>>>>>> 0b3b472d152a95881a5d26cedda8c240b7883929
        }
    }
}
