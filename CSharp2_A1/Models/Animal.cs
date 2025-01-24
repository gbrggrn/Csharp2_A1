using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Csharp2_A1.Models
{
    class Animal
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
            get { return id; }
            set { id = value; }
        }

        public Enums.Enums.Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public bool IsDomesticated
        {
            get { return isDomesticated; }
            set { isDomesticated = value; }
        }

    }
}
