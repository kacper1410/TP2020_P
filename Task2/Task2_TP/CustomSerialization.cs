using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
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

        public void Serialize(A a, string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                Serialize(stream, a);
            }
        }

        private List<XElement> values = new List<XElement>();

        private String FileContent = "";
        private bool FirstTime;

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable serializable)
            {
                SerializationInfo serializationInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
                serializationInfo.AddValue("ObjectId", m_idGenerator.GetId(graph, out FirstTime));
                serializationInfo.AddValue("ObjectType", graph.GetType().FullName);

                StreamingContext streamingContext = new StreamingContext(StreamingContextStates.File);

                serializable.GetObjectData(serializationInfo, streamingContext);
                foreach (SerializationEntry item in serializationInfo)
                {
                    this.WriteMember(item.Name, item.Value);
                }


                while (m_objectQueue.Count != 0)
                {
                    FileContent += "===\n";
                    Serialize(null, this.m_objectQueue.Dequeue());
                }

                if (m_objectQueue.Count == 0 && serializationStream != null)
                {
                    using (StreamWriter writer = new StreamWriter(serializationStream))
                    {
                        writer.Write(FileContent);
                        FileContent = "";
                    }
                }
            }
            else
            {
                throw new ArgumentException("Graph does not implement ISerializable");
            }
        }

        public override object Deserialize(Stream serializationStream)
        {
            if (serializationStream == null)
            {
                return null;
            }

            StreamReader streamReader = new StreamReader(serializationStream);
            string serializedText = streamReader.ReadToEnd();
            StreamingContext streamingContext = new StreamingContext(StreamingContextStates.File);
            List<string> serializedObject = serializedText.Split("===\n").ToList();

            Dictionary<long, object> createdObjects = new Dictionary<long, object>();
            Dictionary<long, List<long>> referencesToObject = new Dictionary<long, List<long>>();

            for (int i = 0; i < serializedObject.Count; i++)
            {
                List<string> rows = serializedObject[i].Split("\n").ToList();

                Type typeOfCurrentObject = GetTypeFromString(rows[1].Split('|').ToList()[2]);
                long currentObjectId = long.Parse(rows[0].Split('|').ToList()[2]);

                SerializationInfo serializationInfo = new SerializationInfo(typeOfCurrentObject, new FormatterConverter());
                List<long> referencesInCurrentObject = new List<long>();

                for (int j = 2; j < rows.Count - 1; j += 1)
                {
                    List<string> elements = rows[j].Split("|").ToList();
                    if (elements[0].Contains("Task2_TP"))
                    {
                        serializationInfo.AddValue(elements[1], null);
                        referencesInCurrentObject.Add(long.Parse(elements[2]));
                    } 
                    else
                    {
                        serializationInfo.AddValue(elements[1], elements[2]);
                    }
                }

                if (referencesInCurrentObject.Count != 0)
                {
                    referencesToObject.Add(currentObjectId, referencesInCurrentObject);
                }
                createdObjects.Add(currentObjectId, Activator.CreateInstance(typeOfCurrentObject, serializationInfo, streamingContext));
            }
            PutReferencesToObject(createdObjects, referencesToObject);
            return createdObjects.First().Value;

        }

        private Type GetTypeFromString(string type)
        {
            return Type.GetType(type + ", " + type.Split(".").ToList()[0]);
        }

        private void PutReferencesToObject(Dictionary<long, object> createdObjects, Dictionary<long, List<long>> referencesToObject)
        {
            foreach(long id in referencesToObject.Keys)
            {
                foreach (long referenceId in referencesToObject[id])
                {
                    foreach (PropertyInfo propertyInfo in createdObjects[id].GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == createdObjects[referenceId].GetType())
                        {
                            propertyInfo.SetValue(createdObjects[id], createdObjects[referenceId]);
                        }
                    }
                }
            }
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
            FileContent += val.GetType() + "|" + name + "|" + val + "\n";
        }

        protected override void WriteInt64(long val, string name)
        {
            FileContent += val.GetType() + "|" + name + "|" + val + "\n";
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(string)))
            {
                FileContent += obj.GetType() + "|" + name + "|" + obj + "\n";
            }
            else
            {
                FileContent += obj.GetType() + "|" + name + "|" + m_idGenerator.GetId(obj, out FirstTime) + "\n";

                if (FirstTime)
                {
                    m_objectQueue.Enqueue(obj);
                }
            }

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
            FileContent += obj.GetType() + "|" + name + "|" + obj + "\n";
        }
    }
}
