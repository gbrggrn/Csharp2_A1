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
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using Csharp2_A1.Models.Enums;
using Csharp2_A1.Control;

namespace Csharp2_A1
{
    /// <summary>
    /// Interaction logic for FoodScheduleWindow.xaml
    /// </summary>
    public partial class FoodScheduleWindow : Window
    {
        private FoodManager foodManager;
        private bool editing;

        /// <summary>
        /// Constructor loads controls and initializes instance variables
        /// </summary>
        /// <param name="currentAnimalIn">The current instance of animal being edited</param>
        internal FoodScheduleWindow(FoodManager foodManagerIn)
        {
            InitializeComponent();
            foodManager = foodManagerIn;
            UpdateItems();
            editing = false;
            foodItemNamesListBox.SelectionChanged += UpdateIngredients;
        }

        /// <summary>
        /// Closes the window upon click of the exit-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Executes upon addbutton-click.
        /// Saves the instruction and calls an update of the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(Object sender, EventArgs e)
        {
            string itemContent = GetRichTextBoxString(itemEntryRichTextBox);

            if (foodItemNameTextBox.Text != string.Empty)
            {
                foodManager.Collection.Add(new FoodItem(foodItemNameTextBox.Text));
                if (itemContent != string.Empty)
                {
                    foodManager.Collection[foodManager.Collection.Count - 1].AddIngredient(itemContent);
                }
                UpdateItems();
                itemEntryRichTextBox.Document.Blocks.Clear();
                foodItemNameTextBox.Text = string.Empty;
            }
            else
            {
                MessageBoxes.DisplayErrorBox("No content to add!");
            }
        }

        /// <summary>
        /// Retrieves the string from the FlowDocument of the RichTextBox.
        /// </summary>
        /// <param name="textBox">The RichTextBox to be retrieved from</param>
        /// <returns>The content of the FlowDocument</returns>
        private string GetRichTextBoxString(RichTextBox textBox)
        {
            TextRange textRange = new(textBox.Document.ContentStart, textBox.Document.ContentEnd);

            return textRange.Text;
        }

        /// <summary>
        /// Displays the instruction in short form in the listbox.
        /// If the item is longer than 20 char, a substring is created of the first 20 chars.
        /// </summary>
        private void UpdateItems()
        {
            foodItemNamesListBox.Items.Clear();

            if (foodManager.Collection.Count > 0)
            {
                foreach (FoodItem item in foodManager.Collection)
                {
                    foodItemNamesListBox.Items.Add(item.Name);
                }
            }
        }

        /// <summary>
        /// Updates the ingredients rich textbox based on selection of food item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateIngredients(Object sender, EventArgs e)
        {
            ingredientsShortListBox.Items.Clear();

            if (foodItemNamesListBox.SelectedIndex != -1)
            {
                int index = foodItemNamesListBox.SelectedIndex;
                foreach (string ingredient in foodManager.Collection[index].Ingredients)
                {
                    string ingredientView = ingredient.Length > 15 ? ingredient[..10] : ingredient;
                    ingredientsShortListBox.Items.Add(ingredientView);
                }
            }
        }

        /// <summary>
        /// Toggles controls on or off dependning on boolean value passed.
        /// </summary>
        /// <param name="onOrOff">On if true : Off if false</param>
        private void ToggleControlsUponEdit(bool onOrOff)
        {
            if (onOrOff)
            {
                addButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
                foodItemNamesListBox.IsEnabled = true;
                editButton.Content = "Edit";
            }
            if (!onOrOff)
            {
                addButton.IsEnabled = false;
                deleteButton.IsEnabled = false;
                foodItemNamesListBox.IsEnabled = false;
                editButton.Content = "Save";
            }
        }

        /// <summary>
        /// Reacts to editbutton-click.
        /// Depending on value of editing flag 
        /// - loads item to be edited and toggles controls
        /// - or saves item edited
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int foodItemIndex = foodItemNamesListBox.SelectedIndex;
            //If not editing:
            if (foodItemNamesListBox.SelectedIndex != -1 && !editing)
            {
                editing = true;
                int ingredientIndex = ingredientsShortListBox.SelectedIndex;
                ToggleControlsUponEdit(false);
                itemEntryRichTextBox.Document.Blocks.Clear();
                string toEdit = foodManager.Collection[foodItemIndex].GetSpecificIngredient(ingredientIndex);
                itemEntryRichTextBox.Document.Blocks.Add(new Paragraph(new Run(toEdit)));
                foodItemNameTextBox.Text = foodManager.GetAt(foodItemIndex).Name;
            }
            //If editing:
            else if (foodItemNamesListBox.SelectedIndex != -1 && ingredientsShortListBox.SelectedIndex != -1 && editing)
            {
                foodManager.Collection[foodItemIndex].EditIngredient(GetRichTextBoxString(itemEntryRichTextBox), ingredientsShortListBox.SelectedIndex);
                itemEntryRichTextBox.Document.Blocks.Clear();
                foodItemNameTextBox.Text = string.Empty;
                UpdateItems();
                editing = false;
                ToggleControlsUponEdit(true);
            }
            else if (foodItemNamesListBox.SelectedIndex != -1 && editing)
            {
                foodManager.Collection[foodItemIndex].AddIngredient(GetRichTextBoxString(itemEntryRichTextBox));
                foodManager.Collection[foodItemIndex].Name = foodItemNameTextBox.Text;
                itemEntryRichTextBox.Document.Blocks.Clear();
                foodItemNameTextBox.Text = string.Empty;
                UpdateItems();
                editing = false;
                ToggleControlsUponEdit(true);
            }
            else if (foodItemNamesListBox.Items == null)
            {
                MessageBoxes.DisplayInfoBox("No entries yet!", "No entries");
            }
            else
            {
                MessageBoxes.DisplayInfoBox("No entry selected!", "No selection");
            }
        }

        /// <summary>
        /// Reacts to deletebutton-click.
        /// Calls removal of selected instruction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (foodItemNamesListBox.SelectedIndex != -1 && ingredientsShortListBox.SelectedIndex == -1)
            {
                int index = foodItemNamesListBox.SelectedIndex;
                if (MessageBoxes.DisplayQuestion($"Remove {foodManager.Collection[index].Name} and all its ingredients?", "Remove?"))
                {
                    foodManager.Collection.RemoveAt(index);
                    UpdateItems();
                }
                else
                {
                    return;
                }
            }

            if (foodItemNamesListBox.SelectedIndex != -1 && ingredientsShortListBox.SelectedIndex != -1)
            {
                int ingredientIndex = ingredientsShortListBox.SelectedIndex;
                int foodItemIndex = foodItemNamesListBox.SelectedIndex;
                if (MessageBoxes.DisplayQuestion("Remove the selected ingredient?", "Remove?"))
                {
                    foodManager.Collection[foodItemIndex].RemoveIngredient(ingredientIndex);
                    UpdateIngredients(sender, e);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
