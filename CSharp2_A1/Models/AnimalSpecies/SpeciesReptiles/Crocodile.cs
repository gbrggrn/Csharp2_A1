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
        private string speciesTrait;
        private const int maxJaw = 150;
        private const int minJaw = 5;

        public Crocodile()
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

            if (!Validator.DoubleOrNot(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} has to be a number";
                return false;
            }

            double result = double.Parse(speciesTraitIn);
            
            if (result < minJaw || result > maxJaw)
            {
                errorMessage = $"{SpeciesQuestion} has to be between {minJaw} and {maxJaw}";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public override string SpeciesTrait { get; set; }
        public override string SpeciesQuestion { get { return "Size of bit (cm)"; } }
    }
}
