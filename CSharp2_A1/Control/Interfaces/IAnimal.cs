using Csharp2_A1.Models.Enums;
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
        string Id { get; set; }
        string Age { get; set; }
        string Name { get; set; }
        Enums.Gender Gender { get; set; }
        bool IsDomesticated { get; set; }
        bool ValidateAnimalTraits(string ageIn, string nameIn, out string errorMessages);
    }
}
