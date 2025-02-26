using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesFish
{
    class Salmon : Fish
    {
        public Salmon()
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

            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                if (speciesTraitIn == knownColor.ToString())
                {
                    errorMessage = "Success";
                    return true;
                }
            }

            errorMessage = $"{SpeciesQuestion} has to be a known color";
            return false;
        }

        public override FoodSchedule FoodSchedule { get; }
        public override string SpeciesTrait { get; set; } = string.Empty;
        public override string SpeciesQuestion { get { return "Color"; } }
    }
}
