using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1.Control.Serializers;
using Csharp2_A1.Models;

namespace Csharp2_A1.Control.Interfaces
{
    /// <summary>
    /// A wrapper class for the interface IAnimal to provide a single accesspoint to
    /// interfaces if they were to be extended.
    /// I tested out a solution for fun utilizing multiple interfaces, and decided to leave the wrapper.
    /// </summary>
    internal class InterfaceService
    {
        public IAnimal Animal { get; }

        /// <summary>
        /// Constructor sets the type of animal for the IAnimal interface.
        /// </summary>
        /// <param name="animalIn">The current instance of Animal</param>
        public InterfaceService(Animal animalIn)
        {
            Animal = animalIn;
        }
    }
}
