﻿using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesMammals
{
    class Elephant : Mammals
    {
        private const int maxWeight = 10000;
        private const int minWeight = 1;

        public override bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} can not be empty";
                return false;
            }

            if (!double.TryParse(speciesTraitIn, out double result))
            {
                errorMessage = $"{SpeciesQuestion} has to be a number";
                return false;
            }

            if (result < minWeight || result > maxWeight)
            {
                errorMessage = $"{SpeciesQuestion} can not be less than {minWeight} or greater than {maxWeight}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override string SpeciesTrait { get; set; } = string.Empty;
        public override string SpeciesQuestion { get { return "Weight (kg)"; } }
    }
}
