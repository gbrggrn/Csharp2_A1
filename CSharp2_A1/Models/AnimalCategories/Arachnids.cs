﻿using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    abstract class Arachnids : Animal
    {
        private const int minLegs = 0;
        private const int maxLegs = 10;

        public override bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!int.TryParse(categoryTraitIn, out int result))
            {
                errorMessage = $"{CategoryQuestion} has to be a number without decimals";
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

        public override string CategoryTrait { get; set; } = string.Empty;
        public override string CategoryQuestion { get { return "Number of legs"; } }
    }
}
