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

        public Animal()
        {
            id = string.Empty;
            age = string.Empty;
            name = string.Empty;
            gender = Enums.Enums.Gender.Unknown;
            isDomesticated = false;
        }

        internal List<string> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public void SaveInput(string idIn, string age, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            Id = idIn;
            Age = age;
            Name = nameIn;
            Gender = genderIn;
            IsDomesticated = isDomesticatedIn;
        }

        public bool ValidateAnimalTraits(string idIn, string ageIn, string nameIn, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        List<string> IAnimal.GetQuestions()
        {
            throw new NotImplementedException();
        }

        public string Age
        {
            get => age;
            set
            {
                if (!Validator.ValidateAge(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    age = value;
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!Control.Validator.ValidateName(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    name = value;
                }
            }
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public Enums.Enums.Gender Gender
        {
            get => gender;
            set => gender = value;
        }

        public bool IsDomesticated
        {
            get => isDomesticated;
            set => isDomesticated = value;
        }

    }
}
