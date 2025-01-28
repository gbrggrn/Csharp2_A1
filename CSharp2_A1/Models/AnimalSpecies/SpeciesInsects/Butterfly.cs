using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesInsects
{
    class Butterfly : Insects
    {
        private string pattern;

        public Butterfly()
        {
            pattern = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Pattern");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            Pattern = speciesSpecificInput;
        }

        public string Pattern
        {
            get => pattern;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {

                }
                else
                {
                    pattern = value;
                }
            }
        }
    }
}
