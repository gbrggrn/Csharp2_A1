using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesArachnids
{
    class Spider : Arachnids, ISpecies
    {
        private string howDeadly;

        public Spider()
        {
            howDeadly = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("How deadly");

            return questions;
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            HowDeadly = speciesSpecificInput;
        }

        public bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public string HowDeadly
        {
            get => howDeadly;
            set
            {
                if (!Validator.ValidateName(value, out string errormessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    howDeadly = value;
                }
            }
        }

        public string SpeciesTrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpeciesQuestion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
