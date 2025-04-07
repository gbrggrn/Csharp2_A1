using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;

namespace Csharp2_A1.Control.Serializers
{
    internal class JSONSerializer : IFileSerializer<ObservableCollection<Animal>>
    {
        public void Serialize(string filePath, ObservableCollection<Animal> animalsIn)
        {
            try
            {
                List<AnimalDTO> animalDTOList = [];

                foreach (Animal animal in animalsIn)
                {
                    AnimalDTO animalDTO = new()
                    {
                        Species = animal.GetType().Name,
                        Category = AssemblyHelpers.GetCorrespondingCategory(animal.GetType().Name),
                        IsDomesticated = animal.IsDomesticated,
                        Gender = animal.Gender.ToString(),
                        EaterType = animal.EaterType.ToString(),
                        Name = animal.Name,
                        Age = animal.Age,
                        CategoryTrait = animal.CategoryTrait,
                        SpeciesTrait = animal.SpeciesTrait
                    };

                    animalDTOList.Add(animalDTO);
                }

                using (StreamWriter write = new(filePath))
                {
                    string jsonString = JsonSerializer.Serialize(animalDTOList);

                    write.WriteLine(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Create exception here");
            }
        }

        public ObservableCollection<Animal> Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
