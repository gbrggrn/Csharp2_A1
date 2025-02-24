using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models
{
    internal class FoodSchedule
    {
        private Enums.Enums.EaterType eaterType;
        private List<string> foodList;

        public FoodSchedule() 
        { 
            eaterType = Enums.Enums.EaterType.Unknown;
            foodList = new();
        }

        

        public Enums.Enums.EaterType EaterType
        {
            get => eaterType;
            set => eaterType = value;
        }

        public List<string> FoodList
        {
            get => foodList;
            set => foodList = value;
        }
    }
}
