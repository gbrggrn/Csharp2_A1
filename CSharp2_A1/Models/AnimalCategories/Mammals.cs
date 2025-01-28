using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Mammals : Animal
    {
        private string isBipedal;

        public Mammals()
        {
            isBipedal = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Bipedal" };
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            IsBipedal = categorySpecificInput;
        }

        public string IsBipedal
        {
            get => isBipedal;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    isBipedal = value;
                }
            }
        }
    }
}
