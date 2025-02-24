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

        private bool AddInstruction(string instructionIn)
        {
            if (FoodList != null)
            {
                foodList.Add(instructionIn);
                return true;
            }

            return false;
        }

        private string GetSpecificInstruction(int indexIn)
        {
            if (FoodList != null && FoodList.Count <= indexIn)
            {
                return FoodList[indexIn];
            }

            return string.Empty;
        }

        private bool EditInstruction(string newInstructionIn, int indexIn)
        {
            if (FoodList != null && FoodList.Count <= indexIn)
            {
                FoodList[indexIn] = newInstructionIn;
                return true;
            }

            return false;
        }

        private bool RemoveInstruction(int indexIn)
        {
            if (FoodList != null && FoodList.Count <= indexIn)
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
