using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Sparrow : Birds
    {
        private string favoriteSeeds;

        public Sparrow()
        {
            favoriteSeeds = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Favorite seeds");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            FavoriteSeeds = speciesSpecificInput;
        }

        public string FavoriteSeeds
        {
            get => favoriteSeeds;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                favoriteSeeds = value;
            }
        }
    }
}
