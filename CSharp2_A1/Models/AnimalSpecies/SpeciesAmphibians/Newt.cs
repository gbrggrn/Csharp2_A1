﻿using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians
{
    class Newt : Amphibians
    {
        private const int maxLength = 20;

        public Newt()
        {
            FoodSchedule = new FoodSchedule();
        }

        public override bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(speciesTraitIn))
            {
                errorMessage = $"{CategoryQuestion} can not be empty";
                return false;
            }

            if (speciesTraitIn.Length > maxLength)
            {
                errorMessage = $"{CategoryQuestion} can be max {maxLength} characters";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public FoodSchedule FoodSchedule { get; }
        public override string SpeciesTrait { get; set; } = string.Empty;
        public override string SpeciesQuestion { get { return "Most appropriate food"; } }
    }
}
