using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Text;
using System.Windows.Media.Imaging;

namespace Csharp2_A1.Control
{
    internal class AnimalRegistry
    {
        List<Models.Animal> animals;

        internal AnimalRegistry()
        {
            animals = new List<Models.Animal>();
        }

        internal void AddAnimal(Models.Animal animalIn)
        {
            animals.Add(animalIn);
        }

        internal Models.Animal GetAnimal(int indexToGet)
        {
            return animals[indexToGet];
        }

        internal List<Models.Animal> GetAllAnimals()
        {
            return animals;
        }

        internal void RemoveAnimal(Models.Animal animalIn)
        {
            animals.Remove(animalIn);
        }
    }
}
