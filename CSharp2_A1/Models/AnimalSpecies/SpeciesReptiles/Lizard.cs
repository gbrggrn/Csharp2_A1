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

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            TailLength = secondInput;
        }

        public string TailLength
        {
            get => tailLength;
            set
            {
                if (!InputVal.ValidateLength(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                tailLength = value;
            }
        }
    }
}
