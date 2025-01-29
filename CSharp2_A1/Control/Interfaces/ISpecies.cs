using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    internal interface ISpecies : ICategory
    {
        string SpeciesTrait { get; set; }
        string SpeciesQuestion { get; set; }
        bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage);
    }
}
