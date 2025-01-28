using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Fish : Animal
    {
        private string lengthCm;

        public Fish()
        {
            lengthCm = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Length (cm)" };
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            LengthCm = categorySpecificInput;
        }

        public string LengthCm
        {
            get => lengthCm;
            set
            {
                if (!InputVal.ValidateLength(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                lengthCm = value;
            }
        }
    }
}
