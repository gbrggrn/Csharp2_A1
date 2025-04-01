using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Serializers
{
    internal class TxtSerializer : IFileSerializer<ObservableCollection<Animal>>
    {
        public void Serialize(string filePath, ObservableCollection<Animal> data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Animal> Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
