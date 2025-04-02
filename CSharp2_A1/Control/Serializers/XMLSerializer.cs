using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Csharp2_A1.Control.Serializers
{
    internal class XMLSerializer<T> : IFileSerializer<T> where T : class
    {
        public void Serialize(string filePath, T data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StreamWriter write = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(write, data);
            }
        }

        public T Deserialize(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StreamReader read = new StreamReader(filePath))
            {
                var result = (T)xmlSerializer.Deserialize(read)!;
                if (result is not T validData)
                {
                    throw new Exception("Create custom exception here!");
                }
                return validData;
            }
        }
    }
}
