using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesReptiles
{
    class Crocodile : Reptiles
    {
        private const int maxJaw = 150;
        private const int minJaw = 5;

        public Crocodile()
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

            if (result < minJaw || result > maxJaw)
            {
                errorMessage = $"{SpeciesQuestion} has to be between {minJaw} and {maxJaw}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override FoodSchedule FoodSchedule { get; }
        public override string SpeciesTrait { get; set; } = string.Empty;
        public override string SpeciesQuestion { get { return "Size of bit (cm)"; } }
    }
}
