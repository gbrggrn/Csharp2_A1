using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesFish
{
    class Cod : Fish
    {
        private string whichSea;

        public Cod()
        {
            whichSea = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("From which sea");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            WhichSea = secondInput;
        }

        public string WhichSea
        {
            get => whichSea;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                whichSea = value;
            }
        }
    }
}
