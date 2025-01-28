using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Insects : Animal
    {
        private string numOfLegs;

        public Insects()
        {
            numOfLegs = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Number of legs" };
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            NumOfLegs = categorySpecificInput;
        }

        public string NumOfLegs
        {
            get => numOfLegs;
            set
            {
                if (!InputVal.ValidateNumberOfLegs(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                value = numOfLegs;
            }
        }
    }
}
