using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Falcon : Birds
    {
        private string avgAirSpeed;

        public Falcon()
        {
            avgAirSpeed = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Avg airspeed (km/h)");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            AvgAirSpeed = speciesSpecificInput;
        }

        public string AvgAirSpeed
        {
            get => avgAirSpeed;
            set
            {
                if (!InputVal.ValidateAvgAirSpeed(value, out string errorMessage))
                {

                }
                else
                {
                    avgAirSpeed = value;
                }
            }
        }
    }
}
