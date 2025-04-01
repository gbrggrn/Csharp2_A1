using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Serializers
{
    internal class XMLSerializer<T> : IFileSerializer<T> where T : class
    {
        public void Serialize(string filePath, T data)
        {
            throw new NotImplementedException();
        }

        public T Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
