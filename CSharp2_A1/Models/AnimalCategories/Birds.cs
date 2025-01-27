using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Birds : Animal
    {
        private string wingspanCm;

        public Birds()
        {
            wingspanCm = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Wingspan (cm)" };
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            WingspanCm = firstInput;
        }

        public string WingspanCm
        {
            get => wingspanCm;
            set
            {
                if (!InputVal.ValidateWingspan(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                wingspanCm = value;
            }
        }
    }
}
