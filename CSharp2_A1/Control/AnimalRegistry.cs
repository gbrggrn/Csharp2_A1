using Csharp2_A1.Models;
using Csharp2_A1.Control.Interfaces;
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
        ObservableCollection<IAnimal> animals;
        MainWindow mainWindow;
        IdGenerator idGenerator;
        private int registrySize;

        internal AnimalRegistry(MainWindow mainWindowIn, int registrySizeIn, IdGenerator idGeneratorIn)
        {
            animals = new ObservableCollection<IAnimal>();
            mainWindow = mainWindowIn;
            animals.CollectionChanged += mainWindow.ObserveRegistry!;
            this.registrySize = registrySizeIn;
            this.idGenerator = idGeneratorIn;
        }

        public ObservableCollection<IAnimal> Animals => animals;

        internal void AddAnimal(IAnimal animalIn)
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

        internal void RemoveAnimal(IAnimal animalIn)
        {
            int id = int.Parse(animalIn.Id);
            idGenerator.DeleteId(id);
            animals.Remove(animalIn);
        }
    }
}