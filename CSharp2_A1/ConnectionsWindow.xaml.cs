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
        private const int unselected = -1;

        /// <summary>
        /// Constructor initializes instance variables and calls setup methods.
        /// </summary>
        /// <param name="currentRegistryIn">The current instance of animalRegistry</param>
        /// <param name="currentFoodManagerIn">The current instance of FoodManager</param>
        internal ConnectionsWindow(AnimalRegistry currentRegistryIn, FoodManager currentFoodManagerIn)
        {
            InitializeComponent();
            currentRegistry = currentRegistryIn;
            currentFoodManager = currentFoodManagerIn;
            LoadAnimals();
            LoadFoodItems();
            SetSubscriptions();
        }

        /// <summary>
        /// Sets subscriptions for this form.
        /// </summary>
        private void SetSubscriptions()
        {
            animalsListView.SelectionChanged += DisplayCurrentlyConnected;
        }

        /// <summary>
        /// Loads animals to the animalsListView.
        /// </summary>
        private void LoadAnimals()
        {
            foreach (Animal animal in currentRegistry.Collection)
            {
                animalsListView.Items.Add($"{animal.Name} {animal.GetType().Name}");
            }
        }

        /// <summary>
        /// Loads food item names to the foodItemsListBox.
        /// </summary>
        private void LoadFoodItems()
        {
            foreach (FoodItem item in currentFoodManager.Collection)
            {
                foodItemsListBox.Items.Add(item.Name);
            }
        }

        /// <summary>
        /// Displays the current connections of food items to a chosen animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayCurrentlyConnected(Object sender, EventArgs e)
        {
            if (animalsListView.SelectedIndex != unselected)
            {
                currentConnectedListBox.Items.Clear();
                foodItemsListBox.SelectedIndex = unselected;

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

        /// <summary>
        /// Connects the chosen animal to the chosen foodItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (animalsListView.SelectedIndex != unselected)
            {
                if (foodItemsListBox.SelectedIndex != unselected)
                {
                    int animalIndex = animalsListView.SelectedIndex;
                    int foodItemIndex = foodItemsListBox.SelectedIndex;

                    currentFoodManager.AddConnection(currentRegistry.GetAt(animalIndex), currentFoodManager.GetAt(foodItemIndex));
                    //Update GUI
                    DisplayCurrentlyConnected(sender, e);
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

        /// <summary>
        /// Deletes a chosen foodItem connected to an animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!currentConnectedListBox.Items.IsEmpty)
            {
                int animalIndex = animalsListView.SelectedIndex;
                Animal animal = currentRegistry.GetAt(animalIndex);
                int itemIndex = currentConnectedListBox.SelectedIndex;
                currentFoodManager.RemoveConnection(animal, itemIndex);
                DisplayCurrentlyConnected(sender, e);
            }
            else
            {
                MessageBoxes.DisplayErrorBox("No food items connected yet!");
            }
        }

        /// <summary>
        /// Returns to MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
