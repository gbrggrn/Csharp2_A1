using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Dove : Birds
    {
        private string doveType;
        private List<string> allowedTypes = ["forest", "city"];

        public Dove()
        {
            doveType = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Type (forest or city)");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            DoveType = secondInput;
        }

        public string DoveType
        {
            get => doveType;
            set
            {
                if (!InputVal.ValidateBirdType(value, allowedTypes, out string errormessage))
                {
                    throw new ArgumentException(errormessage);
                }

                doveType = value;
            }
        }
    }
}
