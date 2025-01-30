using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Arachnids : Animal, ICategory
    {
        private string categoryTrait;
        private const int minLegs = 0;
        private const int maxLegs = 10;

        public Arachnids()
        {
            categoryTrait = string.Empty;
        }

        public bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!Validator.IntOrNot(categoryTraitIn))
            {
                errorMessage = $"{CategoryQuestion} has to be a number";
                return false;
            }

            int result = int.Parse(categoryTraitIn);
            
            if (result < minLegs || result > maxLegs)
            {
                errorMessage = $"{CategoryQuestion} has to be between {minLegs} and {maxLegs}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string CategoryTrait { get; set; }
        public string CategoryQuestion { get { return "Number of legs"; } }
    }
}
