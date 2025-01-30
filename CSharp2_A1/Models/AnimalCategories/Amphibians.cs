using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Amphibians : Animal, ICategory
    {
        private string categoryTrait;

        internal Amphibians()
        {
            categoryTrait = string.Empty;
        }

        public bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!Validator.EmptyOrNot(categoryTraitIn))
            {
                errorMessage = $"{CategoryQuestion} can not be empty";
                return false;
            }

            if (categoryTraitIn.Length > 20)
            {
                errorMessage = "Habitat must be max 20 characters";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string CategoryTrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CategoryQuestion { get { return "Primary habitat"; } }
    }
}
