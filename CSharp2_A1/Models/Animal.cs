using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Csharp2_A1.Models
{
    abstract internal class Animal : IAnimal
    {
        private const int minAge = 1;
        private const int maxAge = 100;
        private const int maxChar = 20;

        public bool ValidateAnimalTraits(string ageIn, string nameIn, out string errorMessages)
        {
            string errors = string.Empty;

            if (!int.TryParse(ageIn, out int result))
            {
                errors += "Age must be a number without decimals";
            }
            else
            {
                if (result < minAge || result > maxAge)
                {
                    errors += $"\nAge must be between {minAge} and {maxAge}";
                }
            }

            if (string.IsNullOrWhiteSpace(nameIn))
            {
                errors += $"\nName can not be empty";
            }
            else
            {
                if (nameIn.Length > maxChar)
                {
                    errors += $"\nName has to be max {maxChar} characters";
                }
            }

            errorMessages = errors;
            return string.IsNullOrEmpty(errors);
        }

        public Animal ThisAnimal { get => this; }
        public string Id { get; set; } = string.Empty;
        public Enums.Enums.EaterType EaterType { get; set; } = Enums.Enums.EaterType.Unknown;
        public Enums.Enums.Gender Gender { get; set; } = Enums.Enums.Gender.Unknown;
        public bool IsDomesticated { get; set; } = false;
        public string Age { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public abstract string CategoryTrait { get; set; }
        public abstract string CategoryQuestion { get; }
        public abstract string SpeciesTrait {  get; set; }
        public abstract string SpeciesQuestion { get; }
        public abstract bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage);
        public abstract bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage);
    }
}
