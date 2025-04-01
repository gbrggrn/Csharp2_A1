using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    internal interface IFileSerializer<T>
    {
        void Serialize(string filePath, T data);
        T Deserialize(string filePath);
    }
}
