using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    internal class InterfaceService
    {
        public IAnimal Animal { get; set; }
        public ICategory? Category { get; set; }
        public ISpecies? Species { get; set; }

        public InterfaceService(IAnimal animalIn)
        {
            Animal = animalIn;
            Category = animalIn as ICategory;
            Species = animalIn as ISpecies;
        }
    }
}
