using Csharp2_A1.Models.Enums;
using Csharp2_A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    /// <summary>
    /// Defines the interface IAnimal for the Animal-class.
    /// </summary>
    internal interface IAnimal
    {
        Animal ThisAnimal { get; }
        string Id { get; set; }
        string Age { get; set; }
        string Name { get; set; }
        Enums.Gender Gender { get; set; }
        bool IsDomesticated { get; set; }
        string CategoryTrait { get; set; }
        string CategoryQuestion { get; }
        string SpeciesTrait { get; set; }
        string SpeciesQuestion { get; }


        bool ValidateAnimalTraits(string ageIn, string nameIn, out string errorMessages);
        bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage);
        bool ValidateSpeciesTrait(string categoryTraitIn, out string errorMessage);
    }
}
