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

        internal FoodScheduleWindow(Animal currentAnimalIn)
        {
            InitializeComponent();
            currentAnimal = currentAnimalIn;
            LoadItems();
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
            }
        }

        private string GetRichTextBoxString(RichTextBox textBox)
        {
            TextRange textRange = new(textBox.Document.ContentStart, textBox.Document.ContentEnd);

            return textRange.Text;
        }

        private void UpdateItems()
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
