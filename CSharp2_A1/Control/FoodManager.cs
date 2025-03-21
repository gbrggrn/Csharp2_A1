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
    internal class FoodManager : ObservableCollectionManager<FoodItem>
    {
        private readonly Dictionary<Animal, List<FoodItem>> connections;

        internal FoodManager()
        {
            connections = [];
        }

        internal bool AddConnection(Animal animal, FoodItem item)
        {
            if (connections.TryGetValue(animal, out List<FoodItem>? items))
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
                    connections.Add(animal, newItems);
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

        internal void RemoveConnection(Animal animal, int removalIndex)
        {
            if (connections.TryGetValue(animal, out List<FoodItem>? items))
            {
                items.RemoveAt(removalIndex);
            }
            else
            {
                MessageBoxes.DisplayErrorBox("Something went wrong - could not remove fooditem");
            }
        }

        public Dictionary<Animal, List<FoodItem>> Connections => connections;
    }
}