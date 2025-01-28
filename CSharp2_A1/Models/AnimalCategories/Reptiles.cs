using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Reptiles : Animal
    {
        private string hasScales;

        public Reptiles()
        {
            hasScales = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Has scales" };
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            HasScales = categorySpecificInput;
        }

        public string HasScales
        {
            get => hasScales;
            set 
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    hasScales = value;
                }
            }
        }
    }
}
