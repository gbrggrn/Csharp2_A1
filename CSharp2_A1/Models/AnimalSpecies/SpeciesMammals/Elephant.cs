using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesMammals
{
    class Elephant : Mammals
    {
        private string weight;

        public Elephant()
        {
            weight = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Weighs");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);

        }

        public string Weight
        {
            get => weight;
            set
            {
                if (!InputVal.ValidateAvgAirSpeed(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                weight = value;
            }
        }
    }
}
