using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesInsects
{
    class Bee : Insects
    {
        private string makesHoney;

        public Bee()
        {
            makesHoney = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Produces honey");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            MakesHoney = speciesSpecificInput;
        }

        public string MakesHoney
        {
            get => makesHoney;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {

                }
                else
                {
                    makesHoney = value;
                }
            }
        }
    }
}
