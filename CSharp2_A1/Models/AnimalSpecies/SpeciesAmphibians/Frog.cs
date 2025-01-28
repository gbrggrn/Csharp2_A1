using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians
{
    class Frog : Amphibians
    {
        private string frogColor;

        public Frog()
        {
            frogColor = String.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Color");

            return questions;   
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            FrogColor = speciesSpecificInput;
        }

        public string FrogColor
        {
            get => frogColor;
            set
            {
                if (!InputVal.ValidateHabitat(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                frogColor = value;
            }
        }
    }
}
