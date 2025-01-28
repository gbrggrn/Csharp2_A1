using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Arachnids : Animal
    {
        private string numberOfLegs;

        public Arachnids()
        {
            numberOfLegs = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Number of legs" };
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            NumberOfLegs = categorySpecificInput;
        }

        public string NumberOfLegs
        {
            get => numberOfLegs;
            set
            {
                if (!InputVal.ValidateNumberOfLegs(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    numberOfLegs = value;
                }
            }
        }
    }
}
