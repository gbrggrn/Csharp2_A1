using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesReptiles
{
    class Snake : Reptiles
    {
        private string straightOrBent;

        public Snake()
        {
            straightOrBent = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Straight or bent");

            return questions;
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            StraightOrBent = speciesSpecificInput;
        }

        public string StraightOrBent
        {
            get => straightOrBent;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    straightOrBent = value;
                }
            }
        }
    }
}
