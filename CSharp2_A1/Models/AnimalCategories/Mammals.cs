using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Mammals : Animal
    {
        private bool isBipedal;

        public Mammals()
        {
            isBipedal = false;
        }

        public override List<string> GetQuestion()
        {
            return new List<string> { "Bipedal" };
        }

        public bool IsBipedal
        {
            get => isBipedal;
            set => isBipedal = value;
        }
    }
}
