using Csharp2_A1.Models.AnimalCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalSpecies.SpeciesBirds
{
    class Dove : Birds
    {
        public override List<string> GetQuestion()
        {
            List<string> questions = base.GetQuestion();
            questions.Add("Type (forest or city)");

            return questions;
        }
    }
}
