using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians
{
    class Frog : Amphibians, ISpecies
    {
        private string speciesTrait;

        public Frog()
        {
            speciesTrait = String.Empty;
        }

        public bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            if (!Validator.EmptyOrNot(speciesTraitIn))
            {
                errorMessage = $"{SpeciesQuestion} can not be empty";
                return false;
            }

            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                if (knownColor.ToString() == speciesTraitIn)
                {
                    errorMessage = "Success";
                    return true;
                }
            }

            errorMessage = $"{SpeciesQuestion} has to be known color";
            return false;
        }

        public string SpeciesTrait { get; set; }
        public string SpeciesQuestion { get { return "Color"; } }
    }
}
