using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesReptiles
{
    class Lizard : Reptiles
    {
        private string tailLength;

        public Lizard()
        {
            tailLength = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Length of tail");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            TailLength = speciesSpecificInput;
        }

        public string TailLength
        {
            get => tailLength;
            set
            {
                if (!InputVal.ValidateLength(value, out string errorMessage))
                {

                }
                else
                {
                    tailLength = value;
                }
            }
        }
    }
}
