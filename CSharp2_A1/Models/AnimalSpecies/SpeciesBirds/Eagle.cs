﻿using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Eagle : Birds
    {
        public override List<string> GetQuestion()
        {
            List<string> questions = base.GetQuestion();
            questions.Add("Type (bald or normal)");

            return questions;
        }
    }
}
