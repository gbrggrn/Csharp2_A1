using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models
{
    internal class FoodItem
    {
        private List<string> ingredients;
        private string name;

        /// <summary>
        /// Constructor initializes instance variables
        /// </summary>
        public FoodItem(string nameIn)
        {
            ingredients = new();
            name = nameIn;
        }

        /// <summary>
        /// Adds an instruction to the foodItems list so long as it is not null
        /// </summary>
        /// <param name="instructionIn">The instruction to be added</param>
        /// <returns>A boolean value true if succesful : false if not</returns>
        internal bool AddIngredient(string instructionIn)
        {
            if (Ingredients != null)
            {
                ingredients.Add(instructionIn);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a specific instruction in the FoodItems list
        /// </summary>
        /// <param name="indexIn">Index of instruction to get</param>
        /// <returns>The specified instruction or an empty string</returns>
        internal string GetSpecificIngredient(int indexIn)
        {
            if (Ingredients != null && indexIn >= 0 && indexIn < Ingredients.Count)
            {
                return Ingredients[indexIn];
            }

            return string.Empty;
        }

        /// <summary>
        /// Replaces an existing instruction with an edited one
        /// </summary>
        /// <param name="newInstructionIn">The edited instruction</param>
        /// <param name="indexIn">Index of the edited instruction</param>
        /// <returns>A boolean value true if successful : false if not</returns>
        internal bool EditIngredient(string newInstructionIn, int indexIn)
        {
            if (Ingredients != null && indexIn >= 0 && indexIn < Ingredients.Count)
            {
                Ingredients[indexIn] = newInstructionIn;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes an existing instruction
        /// </summary>
        /// <param name="indexIn">Index of the instruction to remove</param>
        /// <returns>A boolean value true if succesful : false if not</returns>
        internal bool RemoveIngredient(int indexIn)
        {
            if (Ingredients != null && indexIn >= 0 && indexIn < Ingredients.Count)
            {
                Ingredients.RemoveAt(indexIn);
                return true;
            }

            return false;
        }

        //Properties
        public List<string> Ingredients
        {
            get => ingredients;
            set => ingredients = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
