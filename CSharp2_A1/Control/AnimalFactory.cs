using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    internal class AnimalFactory
    {
        public static Models.Animal CreateAnimal(string category, string species)
        {
            switch (category)
            {
                case "Amphibians":
                    switch (species)
                    {
                        case "Frog":
                            return new Models.AnimalSpecies.SpeciesAmphibians.Frog();
                        case "Newt":
                            return new Models.AnimalSpecies.SpeciesAmphibians.Newt();
                        case "Salamander":
                            return new Models.AnimalSpecies.SpeciesAmphibians.Salamander();
                        default:
                            throw new ArgumentException("Not valid species for amphibians");
                    }

                case "Arachnids":
                    switch (species)
                    {
                        case "Scorpion":
                            return new Models.AnimalSpecies.SpeciesArachnids.Scorpion();
                        case "Spider":
                            return new Models.AnimalSpecies.SpeciesArachnids.Spider();
                        case "Tick":
                            return new Models.AnimalSpecies.SpeciesArachnids.Tick();
                        default:
                            throw new ArgumentException("Not valid species for arachnids");
                    }

                case "Birds":
                    switch (species)
                    {
                        case "Dove":
                            return new Models.AnimalSpecies.SpeciesBirds.Dove();
                        case "Eagle":
                            return new Models.AnimalSpecies.SpeciesBirds.Eagle();
                        case "Falcon":
                            return new Models.AnimalSpecies.SpeciesBirds.Falcon();
                        case "Sparrow":
                            return new Models.AnimalSpecies.SpeciesBirds.Sparrow();
                        default:
                            throw new ArgumentException("Not valid species for birds");
                    }

                case "Fish":
                    switch (species)
                    {
                        case "Cod":
                            return new Models.AnimalSpecies.SpeciesFish.Cod();
                        case "Goldfish":
                            return new Models.AnimalSpecies.SpeciesFish.Goldfish();
                        case "Salmon":
                            return new Models.AnimalSpecies.SpeciesFish.Salmon();
                        default:
                            throw new ArgumentException("Not valid species for fish");
                    }

                case "Insects":
                    switch (species)
                    {
                        case "Ant":
                            return new Models.AnimalSpecies.SpeciesInsects.Ant();
                        case "Bee":
                            return new Models.AnimalSpecies.SpeciesInsects.Bee();
                        case "Butterfly":
                            return new Models.AnimalSpecies.SpeciesInsects.Butterfly();
                        default:
                            throw new ArgumentException("Not valid species for insects");
                    }

                case "Mammals":
                    switch (species)
                    {
                        case "Cat":
                            return new Models.AnimalSpecies.SpeciesMammals.Cat();
                        case "Dog":
                            return new Models.AnimalSpecies.SpeciesMammals.Dog();
                        case "Elephant":
                            return new Models.AnimalSpecies.SpeciesMammals.Elephant();
                        default:
                            throw new ArgumentException("Not valid species for mammals");
                    }

                case "Reptiles":
                    switch (species)
                    {
                        case "Crocodile":
                            return new Models.AnimalSpecies.SpeciesReptiles.Crocodile();
                        case "Lizard":
                            return new Models.AnimalSpecies.SpeciesReptiles.Lizard();
                        case "Snake":
                            return new Models.AnimalSpecies.SpeciesReptiles.Snake();
                        default:
                            throw new ArgumentException("Not valid species for reptiles");
                    }

                default:
                    throw new ArgumentException("Nothing works and everything falls apart");
            }
        }
    }
}
