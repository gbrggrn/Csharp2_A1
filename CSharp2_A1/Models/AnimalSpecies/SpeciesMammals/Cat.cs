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
    class Cat : Mammals
    {
        private string speciesTrait;
        private const int maxLength = 20;

        public Cat()
        {
            speciesTrait = string.Empty;
        }

        public override bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (!Validator.EmptyOrNot(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} can not be empty";
                return false;
            }

            if (speciesTraitIn.Length > maxLength)
            {
                errorMessage = $"{SpeciesQuestion} has to be max {maxLength} characters";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override string SpeciesTrait { get; set; }
        public override string SpeciesQuestion { get { return "Type of fur"; } }
    }
}
