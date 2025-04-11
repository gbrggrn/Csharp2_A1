using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    /// <summary>
    /// Interface for the custom JSONSerializer, TxtSerializer and XMLSerializer.
    /// </summary>
    /// <typeparam name="T">Type of serializer</typeparam>
    internal interface IFileSerializer<T>
    {
        void Serialize(string filePath, T data);
        T Deserialize(string filePath);
    }
}
