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
    abstract class Animal : IAnimal
    {
        private Animal thisAnimal;
        private string id;
        private string age;
        private string name;
        private Enums.Enums.Gender gender;
        private bool isDomesticated;

        private const int minAge = 1;
        private const int maxAge = 100;
        private const int maxChar = 20;

        public Animal()
        {
            thisAnimal = this;
            id = string.Empty;
            age = string.Empty;
            name = string.Empty;
            gender = Enums.Enums.Gender.Unknown;
            isDomesticated = false;
        }

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

        public Animal ThisAnimal { get => thisAnimal; }
        public string Id { get; set; }
        public Enums.Enums.Gender Gender { get; set; }
        public bool IsDomesticated { get; set; }
        public string Age { get; set; }
        public string Name { get; set; }

        public virtual string CategoryTrait { get; set; }
        public virtual string CategoryQuestion { get; }
        public virtual string SpeciesTrait {  get; set; }
        public virtual string SpeciesQuestion { get; }
        public abstract bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage);
        public abstract bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage);

    }
}
