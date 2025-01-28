using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesReptiles
{
    class Crocodile : Reptiles
    {
        private string jawSize;

        public Crocodile()
        {
            jawSize = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Size of jaws");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            JawSize = speciesSpecificInput;
        }

        public string JawSize
        {
            get => jawSize;
            set
            {
                if (!InputVal.ValidateLength(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                jawSize = value;
            }
        }
    }
}
