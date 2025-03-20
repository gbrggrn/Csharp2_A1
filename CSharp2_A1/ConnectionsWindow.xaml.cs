﻿using Csharp2_A1.Control;
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
                Animal displayAnimal = currentRegistry.GetAt(animalsListView.SelectedIndex);
                if (displayAnimal != null)
                {
                    currentConnectedLabel.Content = $"Food items currently connected to: {displayAnimal.Name} the {displayAnimal.GetType().Name}";
                    if (currentFoodManager.Connections.TryGetValue(displayAnimal, out List<FoodItem> foodItems))
                    {
                        foreach (FoodItem item in foodItems)
                        {
                            currentconnectedListBox.Items.Add(item.Name);
                        }
                    }
                }
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButtonsOnEdit(bool toggle)
        {

        }
    }
}
