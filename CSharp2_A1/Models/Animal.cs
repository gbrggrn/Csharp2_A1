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
    internal class Animal : IAnimal
    {
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
            id = string.Empty;
            age = string.Empty;
            name = string.Empty;
            gender = Enums.Enums.Gender.Unknown;
            isDomesticated = false;
        }

        public bool ValidateAnimalTraits(string ageIn, string nameIn, out string errorMessages)
        {
            string errors = string.Empty;

            if (!Validator.IntOrNot(ageIn))
            {
                errors += "Age must be a number";
            }
            else
            {
                int result = int.Parse(ageIn);

                if (result < minAge || result > maxAge)
                {
                    errors += $"\nAge must be between {minAge} and {maxAge}";
                }
            }

            if (!Validator.EmptyOrNot(nameIn))
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

            errorMessages = "Success";
            return true;
        }

        public string Id { get; set; }
        public Enums.Enums.Gender Gender { get; set; }
        public bool IsDomesticated { get; set; }
        public string Age { get; set; }
        public string Name { get; set; }
    }
}
