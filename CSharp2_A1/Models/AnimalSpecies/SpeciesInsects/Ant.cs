using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesInsects
{
    class Ant : Insects
    {
        private string livingSituation;

        public Ant()
        {
            livingSituation = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Colony or lonely?");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            LivingSituation = secondInput;
        }

        public string LivingSituation
        {
            get => livingSituation;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                livingSituation = value;
            }
        }
    }
}
