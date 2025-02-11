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
    class Frog : Amphibians
    {
        private string speciesTrait;

        public Frog()
        {
            speciesTrait = String.Empty;
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
                if (knownColor.ToString() == speciesTraitIn)
                {
                    errorMessage = "Success";
                    return true;
                }
            }

            errorMessage = $"{SpeciesQuestion} has to be known color";
            return false;
        }

        public override string SpeciesTrait { get; set; }
        public override string SpeciesQuestion { get { return "Color"; } }
    }
}
