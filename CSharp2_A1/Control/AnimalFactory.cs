using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians;
using Csharp2_A1.Models.AnimalSpecies.SpeciesArachnids;
using Csharp2_A1.Models.AnimalSpecies.SpeciesBirds;
using Csharp2_A1.Models.AnimalSpecies.SpeciesFish;
using Csharp2_A1.Models.AnimalSpecies.SpeciesInsects;
using Csharp2_A1.Models.AnimalSpecies.SpeciesMammals;
using Csharp2_A1.Models.AnimalSpecies.SpeciesReptiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    internal class AnimalFactory
    {
        /// <summary>
        /// Declares an array of triples (tuples, but with 3 columns) and maps categories
        /// and species to the instantiation of that specific class. Compares the first
        /// two columns of each row to the parameters to decide which instantiation to call.
        /// This method returns an instance of InterfaceService which has property access
        /// to the interface IAnimal.
        /// Basically:
        /// "Hey, this IS a cat, but you can interact with its' properties using the
        /// interface IAnimal!"
        /// </summary>
        /// <param name="category">Category of the species</param>
        /// <param name="species">Species of the animal</param>
        /// <returns>An instance of InterfaceService</returns>
        /// <exception cref="ArgumentException">Throws if category/species match not found</exception>
        internal static InterfaceService CreateAnimal(string category, string species)
        {
            //Init new tuple array with three elements
            //Elements: (string, string, function reference)
            //Function reference explanation:
            //-- () = no parameters/arguments for this function
            //-- => = anonymous function, has no "callsign"
            //-- new Frog() = when called - return instance of "Frog"
            (string, string, Func<Animal>)[] animalMap =
            {
                ("Amphibians", "Frog", () => new Frog()),
                ("Amphibians", "Newt", () => new Newt()),
                ("Amphibians", "Salamander", () => new Salamander()),
                ("Arachnids", "Scorpion", () => new Scorpion()),
                ("Arachnids", "Spider", () => new Spider()),
                ("Arachnids", "Tick", () => new Tick()),
                ("Birds", "Dove", () => new Dove()),
                ("Birds", "Eagle", () => new Eagle()),
                ("Birds", "Falcon", () => new Falcon()),
                ("Birds", "Sparrow", () => new Sparrow()),
                ("Fish", "Cod", () => new Cod()),
                ("Fish", "Goldfish", () => new Goldfish()),
                ("Fish", "Salmon", () => new Salmon()),
                ("Insects", "Ant", () => new Ant()),
                ("Insects", "Bee", () => new Bee()),
                ("Insects", "Butterfly", () => new Butterfly()),
                ("Mammals", "Cat", () => new Cat()),
                ("Mammals", "Dog", () => new Dog()),
                ("Mammals", "Elephant", () => new Elephant()),
                ("Reptiles", "Crocodile", () => new Crocodile()),
                ("Reptiles", "Lizard", () => new Lizard()),
                ("Reptiles", "Snake", () => new Snake())
            };

            foreach (var (cat, spec, init) in animalMap)
            {
                if (cat == category && spec == species)
                {
                    Animal currentAnimal = init();
                    return new InterfaceService(currentAnimal);
                }
            }

            throw new ArgumentException($"Could not create [{category} - {species}]");
        }
    }
}
