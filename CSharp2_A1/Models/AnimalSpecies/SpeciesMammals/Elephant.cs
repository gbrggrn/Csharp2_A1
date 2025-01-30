using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesMammals
{
    class Elephant : Mammals, ISpecies
    {
        private string speciesTrait;
        private const int maxWeight = 10000;
        private const int minWeight = 1;

        public Elephant()
        {
            speciesTrait = string.Empty;
        }

        public bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (!Validator.EmptyOrNot(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} can not be empty";
                return false;
            }

            if (!Validator.DoubleOrNot(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} has to be a number";
                return false;
            }

            double result = double.Parse(speciesTraitIn);

            if (result < minWeight || result > maxWeight)
            {
                errorMessage = $"{SpeciesQuestion} can not be less than {minWeight} or greater than {maxWeight}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string SpeciesTrait { get; set; }
        public string SpeciesQuestion { get { return "Weight (kg)"; } }
    }
}
