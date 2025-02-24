using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Falcon : Birds
    {
        private const double maxAvgAirspeed = 600;

        public Falcon()
        {
            FoodSchedule = new FoodSchedule();
        }

        public override bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (!double.TryParse(speciesTraitIn, out double result))
            {
                errorMessage = $"{SpeciesQuestion} has to be a number";
                return false;
            }

            if (result > maxAvgAirspeed)
            {
                errorMessage = $"{SpeciesQuestion} can not be greater than {maxAvgAirspeed}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public FoodSchedule FoodSchedule { get; }
        public override string SpeciesTrait { get; set; } = string.Empty;
        public override string SpeciesQuestion { get { return "Avg airspeed (km/h)"; } }
    }
}
