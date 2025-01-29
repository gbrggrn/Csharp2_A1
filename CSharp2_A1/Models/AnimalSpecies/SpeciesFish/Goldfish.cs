﻿using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesFish
{
    class Goldfish : Fish, ISpecies
    {
        private string tankOrBowl;

        public Goldfish()
        {
            tankOrBowl = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            List<string> questions = base.GetQuestions();
            questions.Add("Tank or bowl");

            return questions;
        }

        public override void SaveInput(string idIn, string ageIn, string nameIn, Enums.Enums.Gender genderIn, bool isDomesticatedIn, string categorySpecificInput, string speciesSpecificInput)
        {
            base.SaveInput(idIn, ageIn, nameIn, genderIn, isDomesticatedIn, categorySpecificInput, speciesSpecificInput);
            TankOrBowl = speciesSpecificInput;
        }

        public bool ValidateSpeciesTrait(string speciesTraitIn, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public string TankOrBowl
        {
            get => tankOrBowl;
            set
            {
                if (!Validator.ValidateName(value, out string errorMessage))
                {
                    //Validation failed. Errormessage saved to InputVal.
                }
                else
                {
                    tankOrBowl = value;
                }
            }
        }

        public string SpeciesTrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpeciesQuestion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
