using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    abstract class Fish : Animal
    {
        private string categoryTrait;
        private const double minLength = 1;
        private const double maxLength = 500;

        public Fish()
        {
            categoryTrait = string.Empty;
        }

        public override bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!double.TryParse(categoryTraitIn, out double result))
            {
                errorMessage = $"{CategoryQuestion} has to be a number";
                return false;
            }

            if (result < minLength || result > maxLength)
            {
                errorMessage = $"{CategoryQuestion} has to be between {minLength} and {maxLength}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override string CategoryTrait { get; set; }
        public override string CategoryQuestion { get { return "Length (cm)"; } }
    }
}
