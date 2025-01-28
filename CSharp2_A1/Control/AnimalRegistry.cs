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

        internal AnimalRegistry(MainWindow mainWindowIn)
        {
            animals = new ObservableCollection<Animal>();
            mainWindow = mainWindowIn;
            animals.CollectionChanged += mainWindow.ObserveRegistry!;
        }

        internal void AddAnimal(Models.Animal animalIn)
        {
            animals.Add(animalIn);
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
            animals.Remove(animalIn);
        }
    }
}