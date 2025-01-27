using Csharp2_A1.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Amphibians : Animal
    {
        private string primaryHabitat;

        internal Amphibians()
        {
            primaryHabitat = string.Empty;
        }

        public override List<string> GetQuestions()
        {
            return new List<string> { "Primary habitat" };
        }

        public override void SaveInput(string firstInput, string secondInput)
        {
            PrimaryHabitat = firstInput;
        }

        public string PrimaryHabitat
        {
            get => primaryHabitat;
            set
            {
                if (!InputVal.ValidateHabitat(value, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }
                else
                {
                    primaryHabitat = value;
                }
            }
        }
    }
}
