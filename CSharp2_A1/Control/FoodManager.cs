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
        Dictionary<Animal, List<FoodItem>> connections;

        internal FoodManager()
        {
            connections = new();
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

        internal bool RemoveConnection(Animal animal, FoodItem itemToRemove)
        {
            if (connections.TryGetValue(animal, out List<FoodItem>? items))
            {
                items.Remove(itemToRemove);
                return true;
            }
            else
            {
                MessageBoxes.DisplayErrorBox("Something went wrong - could not remove fooditem");
                return false;
            }
        }
    }
}