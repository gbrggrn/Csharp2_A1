using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesArachnids
{
    class Spider : Arachnids
    {
        private string howDeadly;

        public Spider()
        {
            howDeadly = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("How deadly");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            HowDeadly = secondInput;
        }

        public string HowDeadly
        {
            get => howDeadly;
            set
            {
                if (!InputVal.ValidateName(value, out string errormessage))
                {
                    throw new ArgumentException(errormessage);
                }

                howDeadly = value;
            }
        }
    }
}
