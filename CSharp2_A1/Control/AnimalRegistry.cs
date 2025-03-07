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
using Csharp2_A1.Models.Enums;

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

        /// <summary>
        /// Constructor initializes the instance variables and sets the subscription for
        /// CollectionChanged of the ObservableCollection.
        /// </summary>
        /// <param name="mainWindowIn">A reference to the current instance of the MainWindow-class</param>
        /// <param name="registrySizeIn">The size of the registry</param>
        /// <param name="idGeneratorIn">A reference to the current instance of the idGenerator-class</param>
        internal AnimalRegistry(MainWindow mainWindowIn, IdGenerator idGeneratorIn)
        {
            animals = new ObservableCollection<Animal>();
            mainWindow = mainWindowIn;
            animals.CollectionChanged += mainWindow.ObserveRegistry!;
            this.idGenerator = idGeneratorIn;
        }

        /// <summary>
        /// Get-property for the ObservableCollection.
        /// </summary>
        internal ObservableCollection<Animal> Animals
        {
            get => animals;
            set => animals = value;
        }

        /// <summary>
        /// Sorts the collection depending on which sortBy was passed.
        /// </summary>
        /// <param name="sortByIn">Enum deciding what to sort by</param>
        internal void SortCollection(Enums.SortBy sortByIn)
        {
            //New AnimalSorting instance
            AnimalSorting animalSorter = new AnimalSorting(sortByIn);
            //Pass to orderby-method and assign result to list
            List<Animal> sortedAnimals = animals.OrderBy(animal => animal, animalSorter).ToList();

            //Clear observablecollection
            Animals.Clear();
            //Add sorted animals
            foreach (Animal animal in sortedAnimals)
            {
                Animals.Add(animal);
            }
        }

        /// <summary>
        /// If the registry is not null - adds the animal received.
        /// </summary>
        /// <param name="animalIn">The current instance of Animal</param>
        /// <exception cref="ArgumentException">Thrown if registry is full</exception>
        internal void AddAnimal(Animal animalIn)
        {
            if (animals != null)
            {
                animals.Add(animalIn);
            }
            else
            {
                throw new ArgumentException("Can not register animal: registry is full");
            }
        }

        /// <summary>
        /// Replaces the animal at a specified index with a new, edited instance.
        /// </summary>
        /// <param name="animalIn">The edited instance</param>
        /// <param name="indexIn">Index of the instance to replace</param>
        /// <exception cref="ArgumentException">Throws is replacement fails</exception>
        internal void EditAnimal(Animal animalIn, int indexIn)
        {
            if (animals[indexIn] != null)
            {
                animals[indexIn] = animalIn;
            }
            else
            {
                throw new ArgumentException("Something went wrong. Could not save to animal");
            }
        }

        /// <summary>
        /// Removes an animal from the list, and its associated ID from the list of generated IDs.
        /// </summary>
        /// <param name="animalIn">The instance of Animal to be removed</param>
        /// <returns>true if registry contains the instance of Animal : false if not</returns>
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