using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesArachnids
{
    class Tick : Arachnids
    {
        private string howDisgusting;

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("How disgusting");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            HowDisgusting = secondInput;
        }

        public string HowDisgusting
        {
            get => howDisgusting;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                howDisgusting = value;
            }
        }
    }
}
