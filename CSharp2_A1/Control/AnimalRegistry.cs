using Csharp2_A1.Models;
using CSharp2_A1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Text;
using System.Windows.Media.Imaging;

namespace Csharp2_A1.Control
{
    internal class AnimalRegistry
    {
        ObservableCollection<Animal> animals;
        MainWindow mainWindow;
        IdGenerator idGenerator;
        private int registrySize;

        internal AnimalRegistry(MainWindow mainWindowIn, int registrySizeIn, IdGenerator idGeneratorIn)
        {
            animals = new ObservableCollection<Animal>();
            mainWindow = mainWindowIn;
            animals.CollectionChanged += mainWindow.ObserveRegistry!;
            this.registrySize = registrySizeIn;
            this.idGenerator = idGeneratorIn;
        }

        internal void AddAnimal(Models.Animal animalIn)
        {
            if (animals.Count < registrySize)
            {
                animals.Add(animalIn);
            }
            else
            {
                throw new ArgumentException("Can not register animal: registry is full");
            }
        }

        internal Models.Animal GetAnimal(int indexToGet)
        {
            return animals[indexToGet];
        }

        internal ObservableCollection<Animal> GetAllAnimals()
        {
            return animals;
        }

        internal void RemoveAnimal(Models.Animal animalIn)
        {
            int id = int.Parse(animalIn.Id);
            idGenerator.DeleteId(id);
            animals.Remove(animalIn);
        }
    }
}