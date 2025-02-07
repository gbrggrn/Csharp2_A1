using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    /// <summary>
    /// Contains properties for the Interface-classes.
    /// Represents the main access-point for all three interfaces.
    /// </summary>
    internal class InterfaceService
    {
        public IAnimal Animal { get; set; }
        public ICategory? Category { get; set; }
        public ISpecies? Species { get; set; }

        /// <summary>
        /// Constructor sets the type of animal for the interfaces.
        /// </summary>
        /// <param name="animalIn"></param>
        public InterfaceService(IAnimal animalIn)
        {
            Animal = animalIn;
            Category = animalIn as ICategory;
            Species = animalIn as ISpecies;
        }
    }
}
