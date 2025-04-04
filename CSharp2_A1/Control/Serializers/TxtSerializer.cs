using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using Csharp2_A1.Models.Enums;
using CSharp2_A1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Serializers
{
    internal class TxtSerializer : IFileSerializer<ObservableCollection<Animal>>
    {
        public void Serialize(string filePath, ObservableCollection<Animal> data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Animal animal in data)
                    {
                        writer.WriteLine($"{animal.GetType()}|{animal.IsDomesticated}|{animal.Gender}|{animal.EaterType}|{animal.Name}|{animal.Age}|{animal.CategoryTrait}|{animal.SpeciesTrait}");
                    }
                }
            } 
            catch (Exception ex)
            {
                throw new Exception("Create custom Exception here!");
            }
        }

        public ObservableCollection<Animal> Deserialize(string filePath)
        {
            ObservableCollection<Animal> data = [];

            try
            {
                using (StreamReader read = new StreamReader(filePath))
                {
                    string line;
                    while ((line = read.ReadLine()!) != null)
                    {
                        string[] splitLine = line.Split("|");
                        if (splitLine.Length == 8)
                        {
                            InterfaceService currentInterface = AnimalFactory.CreateAnimal(AssemblyHelpers.GetCorrespondingCategory(splitLine[0]), splitLine[0]);
                            bool.TryParse(splitLine[1], out bool domesticated);
                            currentInterface.Animal.IsDomesticated = domesticated;
                            currentInterface.Animal.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), splitLine[2]);
                            currentInterface.Animal.EaterType = (Enums.EaterType)Enum.Parse(typeof(Enums.EaterType), splitLine[3]);
                            currentInterface.Animal.Name = splitLine[4];
                            currentInterface.Animal.Age = splitLine[5];
                            currentInterface.Animal.CategoryTrait = splitLine[6];
                            currentInterface.Animal.SpeciesTrait = splitLine[7];

                            data.Add(currentInterface.Animal.ThisAnimal);
                        }
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception("Custom exception here!");
            }

            return data;
        }
    }
}
