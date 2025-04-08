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
using Csharp2_A1.Models.Enums;
using Csharp2_A1.Control.UserDefinedExceptions;

namespace Csharp2_A1.Control.Serializers
{
    /// <summary>
    /// Custom JSON serializer class. Handles serialization and deserialization.
    /// Organizes the collection elements in DTOs instead of using a nuget-package (see AnimalDTO.cs)
    /// </summary>
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

                    write.Write(jsonString);
                }
            }
            catch (Exception e)
            {
                throw new UserDefinedException("Could not write to file", e.Message);
            }
        }

        public ObservableCollection<Animal> Deserialize(string filePath)
        {
            ObservableCollection<Animal> deserializedAnimals = [];

            try
            {
                using (StreamReader read = new(filePath))
                {
                    string jsonString = read.ReadToEnd();
                    List<AnimalDTO> animalDTOList = JsonSerializer.Deserialize<List<AnimalDTO>>(jsonString)!;

                    foreach (AnimalDTO animalDTO in animalDTOList)
                    {
                        InterfaceService currentInterface = AnimalFactory.CreateAnimal(animalDTO.Category, animalDTO.Species);

                        currentInterface.Animal.IsDomesticated = animalDTO.IsDomesticated;
                        currentInterface.Animal.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), animalDTO.Gender);
                        currentInterface.Animal.EaterType = (Enums.EaterType)Enum.Parse(typeof(Enums.EaterType), animalDTO.EaterType);
                        currentInterface.Animal.Name = animalDTO.Name;
                        currentInterface.Animal.Age = animalDTO.Age;
                        currentInterface.Animal.CategoryTrait = animalDTO.CategoryTrait;
                        currentInterface.Animal.SpeciesTrait = animalDTO.SpeciesTrait;

                        deserializedAnimals.Add(currentInterface.Animal.ThisAnimal);
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                throw new UserDefinedException("File not found", fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                throw new UserDefinedException("Directory not found", dnfe.Message);
            }
            catch (IOException ioe)
            {
                throw new UserDefinedException("File could not be read", ioe.Message);
            }
            catch (Exception e)
            {
                throw new UserDefinedException("Something went wrong", e.Message);
            }

            return deserializedAnimals;
        }
    }
}
