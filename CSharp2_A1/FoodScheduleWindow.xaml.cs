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

namespace Csharp2_A1
{
    /// <summary>
    /// Interaction logic for FoodScheduleWindow.xaml
    /// </summary>
    public partial class FoodScheduleWindow : Window
    {
        private Animal currentAnimal;
        private bool editing;

        /// <summary>
        /// Constructor loads controls and initializes instance variables
        /// </summary>
        /// <param name="currentAnimalIn">The current instance of animal being edited</param>
        internal FoodScheduleWindow(Animal currentAnimalIn)
        {
            InitializeComponent();
            currentAnimal = currentAnimalIn;
            LoadItems();
            LoadEaterTypes();
            UpdateItems();
            editing = false;
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
        /// Loads existing FoodList-items to the scheduleItemsListBox
        /// </summary>
        private void LoadItems()
        {
            List<string> foodScheduleItems = currentAnimal.FoodSchedule.FoodList;

            if (foodScheduleItems != null && foodScheduleItems.Count > 0)
            {
                foreach (string item in foodScheduleItems)
                {
                    scheduleItemsListBox.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Loads the EaterType enum values to the eaterTypeComboBox
        /// </summary>
        private void LoadEaterTypes()
        {
            eaterTypeComboBox.ItemsSource = Enum.GetValues(typeof(Enums.EaterType)).Cast<Enums.EaterType>();
            eaterTypeComboBox.SelectedIndex = 3;
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

            if (itemContent != null && itemContent.Length > 0)
            {
                currentAnimal.FoodSchedule.AddInstruction(itemContent);
                currentAnimal.FoodSchedule.EaterType = (Enums.EaterType)eaterTypeComboBox.SelectedItem;
                UpdateItems();
                itemEntryRichTextBox.Document.Blocks.Clear();
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
            if (currentAnimal.FoodSchedule.FoodList.Count > 0)
            {
                scheduleItemsListBox.Items.Clear();

                foreach (string item in currentAnimal.FoodSchedule.FoodList)
                {
                    string listedView = item.Length > 20 ? item.Substring(0, 20) : item;
                    scheduleItemsListBox.Items.Add(listedView);
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
                scheduleItemsListBox.IsEnabled = true;
                eaterTypeComboBox.IsEnabled = true;
                editButton.Content = "Edit";
            }
            if (!onOrOff)
            {
                addButton.IsEnabled = false;
                deleteButton.IsEnabled = false;
                scheduleItemsListBox.IsEnabled = false;
                eaterTypeComboBox.IsEnabled = false;
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
            //If not currently editing:
            if (scheduleItemsListBox.SelectedIndex != -1 && !editing)
            {
                editing = true;
                int index = scheduleItemsListBox.SelectedIndex;
                ToggleControlsUponEdit(false);
                itemEntryRichTextBox.Document.Blocks.Clear();
                string toEdit = currentAnimal.FoodSchedule.GetSpecificInstruction(index);
                itemEntryRichTextBox.Document.Blocks.Add(new Paragraph(new Run(toEdit)));
            }
            //If currently editing:
            else if (scheduleItemsListBox.SelectedIndex != -1 && editing)
            {
                int index = scheduleItemsListBox.SelectedIndex;
                currentAnimal.FoodSchedule.EditInstruction(GetRichTextBoxString(itemEntryRichTextBox), index);
                scheduleItemsListBox.Items.Clear();
                itemEntryRichTextBox.Document.Blocks.Clear();
                UpdateItems();
                editing = false;
                ToggleControlsUponEdit(true);
            }
            else if (scheduleItemsListBox.Items == null)
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
            if (scheduleItemsListBox.SelectedIndex != -1)
            {
                int index = scheduleItemsListBox.SelectedIndex;
                currentAnimal.FoodSchedule.RemoveInstruction(index);
                UpdateItems();
            }
        }
    }
}
