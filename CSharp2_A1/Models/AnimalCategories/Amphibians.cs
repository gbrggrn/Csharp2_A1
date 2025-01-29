using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Amphibians : Animal, ICategory
    {
        private string primaryHabitat;

        internal Amphibians()
        {
            primaryHabitat = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Primary habitat" };
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            PrimaryHabitat = categorySpecificInput;
        }

        public bool ValidateCategoryTrait(string categoryTraitIn, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public string PrimaryHabitat
        {
            get => primaryHabitat;
            set
            {
                if (!Validator.ValidateHabitat(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    primaryHabitat = value;
                }
            }
        }

        public string CategoryTrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CategoryQuestion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
