using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1.Models;

namespace Csharp2_A1.Control.Interfaces
{
    /// <summary>
    /// Contains properties for the Interface-classes.
    /// Represents the main access-point for all three interfaces.
    /// </summary>
    internal class InterfaceService
    {
        public IAnimal Animal { get; set; }

        /// <summary>
        /// Constructor sets the type of animal for the interfaces.
        /// </summary>
        /// <param name="animalIn"></param>
        public InterfaceService(Animal animalIn)
        {
            Animal = animalIn;
        }
    }
}
