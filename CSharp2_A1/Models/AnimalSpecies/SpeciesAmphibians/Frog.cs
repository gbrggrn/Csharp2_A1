using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians
{
    class Frog : Amphibians, ISpecies
    {
        private string frogColor;

        public Frog()
        {
            frogColor = String.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Color");

            return questions;   
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            FrogColor = speciesSpecificInput;
        }

        public bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public string FrogColor
        {
            get => frogColor;
            set
            {
                if (!Validator.ValidateHabitat(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    frogColor = value;
                }
            }
        }

        public string SpeciesTrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpeciesQuestion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
