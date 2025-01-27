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

        public override void SaveInput(string firstInput, string secondInput)
        {
            base.SaveInput(firstInput, secondInput);
            FrogColor = secondInput;
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
