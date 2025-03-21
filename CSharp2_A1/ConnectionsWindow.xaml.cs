using Csharp2_A1.Control;
using Csharp2_A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Csharp2_A1
{
    /// <summary>
    /// Interaction logic for ConnectionsWindow.xaml
    /// </summary>
    public partial class ConnectionsWindow : Window
    {
        private readonly AnimalRegistry currentRegistry;
        private readonly FoodManager currentFoodManager;

        internal ConnectionsWindow(AnimalRegistry currentRegistryIn, FoodManager currentFoodManagerIn)
        {
            InitializeComponent();
            currentRegistry = currentRegistryIn;
            currentFoodManager = currentFoodManagerIn;
            LoadAnimals();
            LoadFoodItems();
            SetSubscriptions();
        }

        private void SetSubscriptions()
        {
            animalsListView.SelectionChanged += DisplayCurrentlyConnected;
        }

        private void LoadAnimals()
        {
            foreach (Animal animal in currentRegistry.Collection)
            {
                animalsListView.Items.Add($"{animal.Name} {animal.GetType().Name}");
            }
        }

        private void LoadFoodItems()
        {
            foreach (FoodItem item in currentFoodManager.Collection)
            {
                foodItemsListBox.Items.Add(item.Name);
            }
        }

        private void DisplayCurrentlyConnected(Object sender, EventArgs e)
        {
            if (animalsListView.SelectedIndex != -1)
            {
                currentConnectedListBox.Items.Clear();

                Animal displayAnimal = currentRegistry.GetAt(animalsListView.SelectedIndex);
                if (displayAnimal != null)
                {
                    currentConnectedLabel.Content = $"Food items currently connected to: {displayAnimal.Name} the {displayAnimal.GetType().Name}";
                    if (currentFoodManager.Connections.TryGetValue(displayAnimal, out List<FoodItem>? foodItems))
                    {
                        foreach (FoodItem item in foodItems)
                        {
                            currentConnectedListBox.Items.Add(item.Name);
                        }
                    }
                }
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (animalsListView.SelectedIndex != -1)
            {
                if (foodItemsListBox.SelectedIndex != -1)
                {
                    int animalIndex = animalsListView.SelectedIndex;
                    int foodItemIndex = foodItemsListBox.SelectedIndex;

                    currentFoodManager.AddConnection(currentRegistry.GetAt(animalIndex), currentFoodManager.GetAt(foodItemIndex));
                }
                else
                {
                    MessageBoxes.DisplayErrorBox("No food item selected!");
                    return;
                }
            }
            else
            {
                MessageBoxes.DisplayErrorBox("No animal selected!");
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentConnectedListBox.Items != null)
            {
                int animalIndex = animalsListView.SelectedIndex;
                Animal animal = currentRegistry.GetAt(animalIndex);
                int itemIndex = currentConnectedListBox.SelectedIndex;
                currentFoodManager.RemoveConnection(animal, itemIndex);
            }
            else
            {
                MessageBoxes.DisplayErrorBox("No food items connected to this animal yet!");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
