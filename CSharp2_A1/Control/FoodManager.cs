using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    [Serializable]
    internal class FoodManager : ObservableCollectionManager<FoodItem>
    {
        private readonly Dictionary<Animal, List<FoodItem>> connections;

        /// <summary>
        /// Constructor initializes the dictionary.
        /// </summary>
        internal FoodManager()
        {
            connections = [];
        }

        /// <summary>
        /// If animal is already added: adds new foodItem to its corresponding list.
        /// If animal is not added: adds the animal and a new corresponding list containing the fooditem.
        /// </summary>
        /// <param name="animal">The animal to be added</param>
        /// <param name="item">The item to be added</param>
        /// <returns>true if successful : false if not</returns>
        internal bool AddConnection(Animal animal, FoodItem item)
        {
            if (Connections.TryGetValue(animal, out List<FoodItem>? items))
            {
                items.Add(item);
                return true;
            }
            else
            {
                try
                {
                    List<FoodItem> newItems = [];
                    newItems.Add(item);
                    Connections.Add(animal, newItems);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBoxes.DisplayErrorBox($"Something went wrong - no connection made\n" +
                        $"Exception: {ex}");
                    return false;
                }
            }
        }

        /// <summary>
        /// If animal exists: removes the specified fooditem from its corresponding list.
        /// If animal does not exist: prompts error message.
        /// </summary>
        /// <param name="animal">The animal from which to remove a food item connection</param>
        /// <param name="removalIndex">The fooditem to be removed</param>
        internal void RemoveConnection(Animal animal, int removalIndex)
        {
            if (Connections.TryGetValue(animal, out List<FoodItem>? items))
            {
                items.RemoveAt(removalIndex);
            }
            else
            {
                MessageBoxes.DisplayErrorBox("Something went wrong - could not remove fooditem");
            }
        }

        //Properties
        public Dictionary<Animal, List<FoodItem>> Connections => connections;
    }
}