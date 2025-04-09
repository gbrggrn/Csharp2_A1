using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Csharp2_A1.Control.UserDefinedExceptions;

namespace Csharp2_A1.Control.Serializers
{
    /// <summary>
    /// Custom generic XML serializer class. Handles serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">The type of object to be serialized</typeparam>
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
            catch (Exception e)
            {
                throw new UserDefinedException("Unable to deserialize XML", e.Message);
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
                throw new UserDefinedException("XML deserialization failed", e.Message);
            }
            return result;
        }
    }
}
