using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Mammals : Animal, ICategory
    {
        private string categoryTrait;
        private const int maxChar = 20;

        public Mammals()
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
                errorMessage = $"{CategoryQuestion} can not be longer than {maxChar} characters";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string CategoryTrait { get; set; }
        public string CategoryQuestion { get { return "Callsign"} }
    }
}
