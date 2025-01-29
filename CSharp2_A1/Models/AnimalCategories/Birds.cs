using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Birds : Animal, ICategory
    {
        private string wingspanCm;

        public Birds()
        {
            wingspanCm = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Wingspan (cm)" };
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            WingspanCm = categorySpecificInput;
        }

        public bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public string WingspanCm
        {
            get => wingspanCm;
            set
            {
                if (!Validator.ValidateWingspan(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    wingspanCm = value;
                }
            }
        }

        public string CategoryTrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CategoryQuestion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
