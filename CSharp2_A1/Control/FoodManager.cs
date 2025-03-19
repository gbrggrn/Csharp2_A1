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

        internal bool AddConnection(Animal animal, List<FoodItem> item)
        {
            try
            {
                connections.Add(animal, item);
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxes.DisplayErrorBox("Something went wrong - no connection made");
                return false;
            }
        }

        internal bool RemoveConnection(Animal animal, FoodItem itemToRemove)
        {
            try
            {
                connections[animal].Remove(itemToRemove);
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxes.DisplayErrorBox("Something went wrong - could not remove fooditem");
                return false;
            }
        }
    }
}