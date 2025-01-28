﻿using Csharp2_A1.Control;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesMammals
{
    class Elephant : Mammals
    {
        private string weight;

        public Elephant()
        {
            weight = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Weighs");

            return questions;
        }

        public override void SaveInput(string idIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            Weight = speciesSpecificInput;
        }

        public string Weight
        {
            get => weight;
            set
            {
                if (!InputVal.ValidateAvgAirSpeed(value, out string errorMessage))
                {

                }
                else
                {
                    weight = value;
                }
            }
        }
    }
}
