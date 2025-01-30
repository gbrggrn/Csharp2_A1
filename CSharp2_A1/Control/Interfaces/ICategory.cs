using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    internal interface ICategory : IAnimal
    {
        string CategoryTrait { get; set; }
        string CategoryQuestion { get; }
        bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage);
    }
}
