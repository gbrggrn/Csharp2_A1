using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Eagle : Birds
    {
        private string eagleType;
        private List<string> allowedTypes = ["bald", "normal"];

        public Eagle()
        {
            eagleType = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Type (bald or normal)");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            EagleType = secondInput;
        }

        public string EagleType
        {
            get => eagleType;
            set
            {
                if (!InputVal.ValidateBirdType(value, allowedTypes, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                eagleType = value;
            }
        }
    }
}
