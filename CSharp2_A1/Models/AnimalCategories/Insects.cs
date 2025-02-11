using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    abstract class Insects : Animal
    {
        private string categoryTrait;
        private const int minLegs = 0;
        private const int maxLegs = 100;

        public Insects()
        {
            categoryTrait = string.Empty;
        }

        public override bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!int.TryParse(categoryTraitIn, out int result))
            {
                errorMessage = $"{CategoryQuestion} needs to be a number";
                return false;
            }
            else
            {
                if (result < minLegs || result > maxLegs)
                {
                    errorMessage = $"{CategoryQuestion} has to be between {minLegs} and {maxLegs}";
                    return false;
                }
            }

            errorMessage = "Success";
            return true;
        }

        public override string CategoryTrait { get; set; }
        public override string CategoryQuestion { get { return "Number of legs"; } }
    }
}
