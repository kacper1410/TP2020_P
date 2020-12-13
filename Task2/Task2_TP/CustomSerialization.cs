using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Task2_TP.ObjectModel;

namespace Task2_TP
{
    public class CustomSerialization : Formatter, ISerialization
    {
        public A Deserialize(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                return (A)Deserialize(stream);
            }
        }

        public void Serialize(A purchaseRecord, string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                Serialize(stream, purchaseRecord);
            }
        }

        private List<XElement> values = new List<XElement>();

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable serializable)
            {
                SerializationInfo serializationInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
                StreamingContext streamingContext = new StreamingContext(StreamingContextStates.File);
                serializable.GetObjectData(serializationInfo, streamingContext);
                foreach (SerializationEntry item in serializationInfo)
                {
                    this.WriteMember(item.Name, item.Value);
                }
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                    foreach (XElement element in values)
                    {
                        writer.Write($"{element.Name} {element.Value}\n");
                    }
                }
            } 
            else
            {
                throw new Exception("Graph does not implement ISerializable");
            }

        }

        public override object Deserialize(Stream serializationStream)
        {
            A purchaseRecord;
            using (StreamReader reader = new StreamReader(serializationStream))
            {
                SerializationInfo serializationInfo = new SerializationInfo(typeof(A), new FormatterConverter());
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] splitLine = line.Split("_ ");
                    if (splitLine.Length > 2)
                    {
                        for (int i = 1; i < splitLine.Length; i++)
                        {
                            splitLine[1] += splitLine[i];
                        }
                    }
                    serializationInfo.AddValue(splitLine[0] + "_", splitLine[1]);
                    line = reader.ReadLine();
                }
                purchaseRecord = new A(serializationInfo);
            }

            return purchaseRecord;
        }

        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            values.Add(new XElement(name, val));
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            values.Add(new XElement(name, obj));
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            values.Add(new XElement(name, obj.ToString()));
        }
    }
}
