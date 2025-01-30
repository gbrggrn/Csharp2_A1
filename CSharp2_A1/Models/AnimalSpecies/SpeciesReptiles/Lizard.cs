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
    class Lizard : Reptiles, ISpecies
    {
        private string speciesTrait;
        private const int maxLength = 200;
        private const int minLength = 5;

        public Lizard()
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

            if (result < minLength || result > maxLength)
            {
                errorMessage = $"{SpeciesQuestion} has to be between {minLength} and {maxLength}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public string SpeciesTrait { get; set; }
        public string SpeciesQuestion { get { return "Length of tail (cm)"; } }
    }
}
