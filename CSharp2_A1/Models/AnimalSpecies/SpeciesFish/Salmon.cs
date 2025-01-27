using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesFish
{
    class Salmon : Fish
    {
        private string salmonColor;

        public Salmon()
        {
            salmonColor = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Color");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            SalmonColor = secondInput;
        }

        public string SalmonColor
        {
            get => salmonColor;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                salmonColor = value;
            }
        }
    }
}
