using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    abstract class Birds : Animal
    {
        private const int maxWingSpan = 600;
        private const int minWingSpan = 0;

        public override bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!double.TryParse(categoryTraitIn, out double result))
            {
                errorMessage = $"{CategoryQuestion} has to be a number";
                return false;
            }

            if (result < 0 || result > 600)
            {
                errorMessage = $"{CategoryQuestion} has to be between {minWingSpan} and {maxWingSpan}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override string CategoryTrait { get; set; } = string.Empty;
        public override string CategoryQuestion { get { return "Wingspan (cm)"; } }
    }
}
