using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Csharp2_A1.Models
{
    /// <summary>
    /// Contains operations pertaining to the FoodSchedule class
    /// </summary>
    internal class FoodSchedule
    {
        private Enums.Enums.EaterType eaterType;
        private List<string> foodList;

        /// <summary>
        /// Constructor initializes instance variables
        /// </summary>
        public FoodSchedule() 
        { 
            eaterType = Enums.Enums.EaterType.Unknown;
            foodList = new();
        }

        /// <summary>
        /// Adds an instruction to the FoodList so long as it is not null
        /// </summary>
        /// <param name="instructionIn">The instruction to be added</param>
        /// <returns>A boolean value true if succesful : false if not</returns>
        internal bool AddInstruction(string instructionIn)
        {
            if (FoodList != null)
            {
                foodList.Add(instructionIn);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a specific instruction in the FoodList
        /// </summary>
        /// <param name="indexIn">Index of instruction to get</param>
        /// <returns>The specified instruction or an empty string</returns>
        internal string GetSpecificInstruction(int indexIn)
        {
            if (FoodList != null && indexIn >= 0 && indexIn < FoodList.Count)
            {
                return FoodList[indexIn];
            }

            return string.Empty;
        }

        /// <summary>
        /// Replaces an existing instruction with an edited one
        /// </summary>
        /// <param name="newInstructionIn">The edited instruction</param>
        /// <param name="indexIn">Index of the edited instruction</param>
        /// <returns>A boolean value true if successful : false if not</returns>
        internal bool EditInstruction(string newInstructionIn, int indexIn)
        {
            if (FoodList != null && indexIn >= 0 && indexIn < FoodList.Count)
            {
                FoodList[indexIn] = newInstructionIn;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes an existing instruction
        /// </summary>
        /// <param name="indexIn">Index of the instruction to remove</param>
        /// <returns>A boolean value true if succesful : false if not</returns>
        internal bool RemoveInstruction(int indexIn)
        {
            if (FoodList != null && indexIn >= 0 && indexIn < FoodList.Count)
            {
                FoodList.RemoveAt(indexIn);
                return true;
            }

            return false;
        }
        
        //Properties
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
