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
        private string name;
        private Enums.Enums.Gender gender;
        private bool isDomesticated;

        public Animal()
        {
            id = string.Empty;
            name = string.Empty;
            gender = Enums.Enums.Gender.Unknown;
            isDomesticated = false;
        }

        public abstract List<string> GetQuestions();

        public abstract void SaveInput(string firstInput, string secondInput);

        public string Name
        {
            get { return name; }
            set
            {
                if (!Control.InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                name = value;
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
