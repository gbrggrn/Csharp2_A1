using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Fish : Animal
    {
        private string lengthCm;

        public Fish()
        {
            lengthCm = string.Empty;
        }

        public override List<string> GetQuestion()
        {
            return new List<string> { "Length (cm)" };
        }

        public string LengthCm
        {
            get => lengthCm;
            set
            {
                if (!InputVal.ValidateLength(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                lengthCm = value;
            }
        }
    }
}
