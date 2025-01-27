using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Mammals : Animal
    {
        private string isBipedal;

        public Mammals()
        {
            isBipedal = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Bipedal" };
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            IsBipedal = firstInput;
        }

        public string IsBipedal
        {
            get => isBipedal;
            set
            {
                if (!InputVal.ValidateName(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                isBipedal = value;
            }
        }
    }
}
