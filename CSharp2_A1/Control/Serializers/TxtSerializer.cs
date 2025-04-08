using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using Csharp2_A1.Models.Enums;
using Csharp2_A1.Control.UserDefinedExceptions;
using CSharp2_A1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Serializers
{
    /// <summary>
    /// Custom TXTSerializer class. Handles serialization and deserialization.
    /// </summary>
    internal class TxtSerializer : IFileSerializer<ObservableCollection<Animal>>
    {
        public void Serialize(string filePath, ObservableCollection<Animal> data)
        {
            try
            {
                using (StreamWriter writer = new(filePath))
                {
                    foreach (Animal animal in data)
                    {
                        writer.WriteLine($"{animal.GetType()}|" +
                            $"{animal.IsDomesticated}|" +
                            $"{animal.Gender}|" +
                            $"{animal.EaterType}|" +
                            $"{animal.Name}|" +
                            $"{animal.Age}|" +
                            $"{animal.CategoryTrait}|" +
                            $"{animal.SpeciesTrait}");
                    }
                }
            } 
            catch (IOException ioe)
            {
                throw new UserDefinedException("Could not write to file", ioe.Message);
            }
        }

        public ObservableCollection<Animal> Deserialize(string filePath)
        {
            ObservableCollection<Animal> data = [];
            StreamReader? read = null;

            try
            {
                using (read = new(filePath))
                {
                    string line;
                    //Read line by line - not all at once
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
            } 
            catch (FileNotFoundException fnfe)
            {
                throw new UserDefinedException("File could not be found", fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                throw new UserDefinedException("Directory could not be found", dnfe.Message);
            }
            catch (IOException ioe)
            {
                throw new UserDefinedException("Filepath could not be read", ioe.Message);
            }
            catch (Exception e)
            {
                throw new UserDefinedException("Something went wrong", e.Message);
            }
            //"using" already handles disposal - this just to show usage of "finally"
            finally
            {
                if (read != null)
                {
                    read.Dispose();
                }
            }

            return data;
        }
    }
}
