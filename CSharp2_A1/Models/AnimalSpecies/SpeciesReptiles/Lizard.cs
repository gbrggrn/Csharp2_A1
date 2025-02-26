using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesReptiles
{
    class Lizard : Reptiles
    {
        private const int maxLength = 200;
        private const int minLength = 5;

        public Lizard()
        {
            FoodSchedule = new FoodSchedule();
        }

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

            if (result < minLength || result > maxLength)
            {
                errorMessage = $"{SpeciesQuestion} has to be between {minLength} and {maxLength}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override FoodSchedule FoodSchedule { get; }
        public override string SpeciesTrait { get; set; } = string.Empty;
        public override string SpeciesQuestion { get { return "Length of tail (cm)"; } }
    }
}
