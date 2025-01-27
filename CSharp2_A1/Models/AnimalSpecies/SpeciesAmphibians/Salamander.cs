using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesAmphibians
{
    class Salamander : Amphibians
    {
        private string favoriteFoods;

        public Salamander()
        {
            favoriteFoods = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Favorite foods");

            return questions;
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            FavoriteFoods = secondInput;
        }

        public string FavoriteFoods
        {
            get => favoriteFoods;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                favoriteFoods = value;
            }
        }
    }
}
