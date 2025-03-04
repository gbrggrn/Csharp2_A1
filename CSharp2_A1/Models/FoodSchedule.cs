using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        internal bool AddInstruction(string instructionIn)
        {
            if (FoodList != null)
            {
                foodList.Add(instructionIn);
                return true;
            }

            return false;
        }

        internal string GetSpecificInstruction(int indexIn)
        {
            if (FoodList != null && indexIn >= 0 && indexIn < FoodList.Count)
            {
                return FoodList[indexIn];
            }

            return string.Empty;
        }

        internal bool EditInstruction(string newInstructionIn, int indexIn)
        {
            if (FoodList != null && indexIn >= 0 && indexIn < FoodList.Count)
            {
                FoodList[indexIn] = newInstructionIn;
                return true;
            }

            return false;
        }

        internal bool RemoveInstruction(int indexIn)
        {
            if (FoodList != null && indexIn >= 0 && indexIn < FoodList.Count)
            {
                FoodList.RemoveAt(indexIn);
                return true;
            }

            return false;
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
