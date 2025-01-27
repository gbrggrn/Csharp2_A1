using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models.AnimalCategories
{
    class Reptiles : Animal
    {
        private bool hasScales;
        private readonly string hasScalesQ;

        public Reptiles()
        {
            hasScales = false;
            hasScalesQ = "Has scales";
        }

        public override List<string> GetQuestion()
        {
            return new List<string> { "Has scales" };
        }

        public bool HasScales
        {
            get => hasScales;
            set => hasScales = value;
        }

        public string HasScalesQ => hasScalesQ;
    }
}
