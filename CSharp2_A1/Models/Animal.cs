using Csharp2_A1.Control;
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
    abstract class Animal
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

        public abstract List<string> GetQuestions();

        public virtual void SaveInput(string idIn, string age, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            Id = idIn;
            Age = age;
            Name = nameIn;
            Gender = genderIn;
            IsDomesticated = isDomesticatedIn;
        }

        public string Age
        {
            get => age;
            set
            {
                if (!InputVal.ValidateAge(value, out string errorMessage))
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
                if (!Control.InputVal.ValidateName(value, out string errorMessage))
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
