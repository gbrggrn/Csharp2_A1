using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians
{
    class Newt : Amphibians
    {
        private string appropriateFoods;

        public Newt()
        {
            appropriateFoods = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Appropriate foods");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            AppropriateFoods = secondInput;
        }

        public string AppropriateFoods
        {
            get => appropriateFoods;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                appropriateFoods = value;
            }
        }
    }
}
