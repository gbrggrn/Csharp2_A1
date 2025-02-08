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
    /// <summary>
    /// Class responsible for maintaining and manipulating the animal registry.
    /// </summary>
    internal class AnimalRegistry
    {
        ObservableCollection<Animal> animals;
        MainWindow mainWindow;
        IdGenerator idGenerator;
        private int registrySize;

        /// <summary>
        /// Constructor initializes the instance variables and sets the subscription for
        /// CollectionChanged of the ObservableCollection.
        /// </summary>
        /// <param name="mainWindowIn">A reference to the current instance of the MainWindow-class</param>
        /// <param name="registrySizeIn">The size of the registry</param>
        /// <param name="idGeneratorIn">A reference to the current instance of the idGenerator-class</param>
        internal AnimalRegistry(MainWindow mainWindowIn, int registrySizeIn, IdGenerator idGeneratorIn)
        {
            animals = new ObservableCollection<Animal>();
            mainWindow = mainWindowIn;
            animals.CollectionChanged += mainWindow.ObserveRegistry!;
            this.registrySize = registrySizeIn;
            this.idGenerator = idGeneratorIn;
        }

        /// <summary>
        /// Get-property for the ObservableCollection.
        /// </summary>
        public ObservableCollection<Animal> Animals => animals;

        /// <summary>
        /// If the registry is not full - adds the animal received.
        /// </summary>
        /// <param name="animalIn">The current instance of Animal</param>
        /// <exception cref="ArgumentException">Thrown if registry is full</exception>
        internal void AddAnimal(Animal animalIn)
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

        /// <summary>
        /// Removes an animal from the list, and its associated ID from the list of generated IDs.
        /// </summary>
        /// <param name="animalIn"></param>
        internal bool RemoveAnimal(Animal animalIn)
        {
            if (Animals.Contains(animalIn))
            {
                int id = int.Parse(animalIn.Id);
                idGenerator.DeleteId(id);
                animals.Remove(animalIn);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}