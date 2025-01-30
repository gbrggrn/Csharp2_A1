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
    class Falcon : Birds, ISpecies
    {
        private string speciesTrait;
        private const double maxAvgAirspeed = 600;

        public Falcon()
        {
            speciesTrait = string.Empty;
        }

        public bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (!Validator.DoubleOrNot(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} has to be a number";
                return false;
            }

            double result = double.Parse(speciesTraitIn);

            if (result > maxAvgAirspeed)
            {
                errorMessage = $"{SpeciesQuestion} can not be greater than {maxAvgAirspeed}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string SpeciesTrait { get; set; }
        public string SpeciesQuestion { get { return "Avg airspeed (km/h)"; } }
    }
}
