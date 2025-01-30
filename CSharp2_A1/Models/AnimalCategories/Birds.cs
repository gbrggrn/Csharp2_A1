﻿using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Birds : Animal, ICategory
    {
        private string categoryTrait;
        private const int maxWingSpan = 600;
        private const int minWingSpan = 0;

        public Birds()
        {
            categoryTrait = string.Empty;
        }

        public bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            if (!Validator.DoubleOrNot(categoryTraitIn))
            {
                errorMessage = $"{CategoryQuestion} has to be a number";
                return false;
            }

            double result = double.Parse(categoryTraitIn);

            if (result < 0 || result > 600)
            {
                errorMessage = $"{CategoryQuestion} has to be between {minWingSpan} and {maxWingSpan}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string CategoryTrait { get; set; }
        public string CategoryQuestion { get { return "Wingspan (cm)"; } }
    }
}
