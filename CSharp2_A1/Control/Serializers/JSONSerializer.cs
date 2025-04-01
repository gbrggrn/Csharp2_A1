using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;

namespace Csharp2_A1.Control.Serializers
{
    internal class JSONSerializer : IFileSerializer<ObservableCollection<Animal>>
    {
        public void Serialize(string filePath, ObservableCollection<Animal> animalsIn)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Animal> Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
