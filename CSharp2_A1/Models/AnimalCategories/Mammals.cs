using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    abstract class Mammals : Animal
    {
        private string categoryTrait;
        private const int maxChar = 20;

        public Mammals()
        {
            categoryTrait = string.Empty;
        }

        public override bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(categoryTraitIn))
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

        public override string CategoryTrait { get; set; }
        public override string CategoryQuestion { get { return "Callsign"; } }
    }
}
