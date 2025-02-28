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

namespace Csharp2_A1
{
    /// <summary>
    /// Interaction logic for FoodScheduleWindow.xaml
    /// </summary>
    public partial class FoodScheduleWindow : Window
    {
        private Animal currentAnimal;
        private bool editing;

        internal FoodScheduleWindow(Animal currentAnimalIn)
        {
            InitializeComponent();
            currentAnimal = currentAnimalIn;
            LoadItems();
            UpdateItems();
            editing = false;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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

        private void AddButton_Click(Object sender, EventArgs e)
        {
            string itemContent = GetRichTextBoxString(itemEntryRichTextBox);

            if (itemContent != null && itemContent.Length > 0)
            {
                currentAnimal.FoodSchedule.FoodList.Add(GetRichTextBoxString(itemEntryRichTextBox));
                UpdateItems();
            }
        }

        private string GetRichTextBoxString(RichTextBox textBox)
        {
            TextRange textRange = new(textBox.Document.ContentStart, textBox.Document.ContentEnd);

            return textRange.Text;
        }

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

        private void ToggleControlsUponEdit(bool onOrOff)
        {
            if (onOrOff)
            {
                addButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
                scheduleItemsListBox.IsEnabled = true;
                editButton.Content = "Save";
            }
            if (!onOrOff)
            {
                addButton.IsEnabled = false;
                deleteButton.IsEnabled = false;
                scheduleItemsListBox.IsEnabled = false;
                editButton.Content = "Edit";
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (scheduleItemsListBox.SelectedIndex != -1 && !editing)
            {
                editing = true;
                ToggleControlsUponEdit(false);
                itemEntryRichTextBox.Document.Blocks.Clear();
                string toEdit = currentAnimal.FoodSchedule.FoodList[scheduleItemsListBox.SelectedIndex];
                itemEntryRichTextBox.Document.Blocks.Add(new Paragraph(new Run(toEdit)));
            }
            if (scheduleItemsListBox.SelectedIndex != -1 && editing)
            {
                currentAnimal.FoodSchedule.FoodList.Add(GetRichTextBoxString(itemEntryRichTextBox));
                UpdateItems();
                editing = false;
                ToggleControlsUponEdit(true);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
