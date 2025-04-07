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
            XmlSerializer xmlSerializer = new(typeof(T));

            try
            {
                using (StreamWriter write = new(filePath))
                {
                    xmlSerializer.Serialize(write, data);
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Unable to deserialize XML");
            }
        }

        public T Deserialize(string filePath)
        {
            XmlSerializer xmlSerializer = new(typeof(T));

            T result;

            try
            {
                using (StreamReader read = new(filePath))
                {
                    result = (T)xmlSerializer.Deserialize(read)!;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Create custom Exception here!");
            }

            return result;
        }
    }
}
