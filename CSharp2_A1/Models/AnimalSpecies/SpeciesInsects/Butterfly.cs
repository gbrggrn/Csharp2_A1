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

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            Pattern = secondInput;
        }

        public string Pattern
        {
            get => pattern;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                pattern = value;
            }
        }
    }
}
