using Csharp2_A1.Control;
using Csharp2_A1.Models;
using Csharp2_A1.Models.AnimalCategories;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp2_A1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, List<String>> categoriesAndSpecies;

        public MainWindow()
        {
            InitializeComponent();
            categoriesAndSpecies = GetCategoriesAndSpecies();
            LoadCategories();
            categoryListBox.SelectionChanged += LoadSpecies;
            speciesListBox.SelectionChanged += UpdateInputControls;
            listAllCheckBox.Checked += LoadAllSpecies;
            listAllCheckBox.Unchecked += EnableCategories;
        }

        internal void LoadCategories()
        {
            categoryListBox.ItemsSource = categoriesAndSpecies.Keys;
        }

        internal void LoadSpecies(Object sender, EventArgs e)
        {
            if (categoryListBox.SelectedIndex != -1)
            {
                string category = categoryListBox.SelectedItem.ToString()!;

                if (categoriesAndSpecies.ContainsKey(category))
                {
                    speciesListBox.ItemsSource = categoriesAndSpecies[category];
                }
            }
        }

        internal void LoadAllSpecies(Object sender, EventArgs e)
        {
            speciesListBox.Items.Clear();
            categoryListBox.IsEnabled = false;

            List<string> categories = categoriesAndSpecies.Keys.ToList();

            foreach (var listOfSpecies in categoriesAndSpecies.Values)
            {
                foreach (string species in listOfSpecies)
                {
                    speciesListBox.Items.Add(species);
                }
            }
        }

        internal void EnableCategories(Object sender, EventArgs e)
        {
            speciesListBox.Items.Clear();
            categoryListBox.IsEnabled = true;
        }

        internal void UpdateInputControls(Object sender, EventArgs e)
        {
            if (speciesListBox.SelectedIndex != -1)
            {
                string selectedCategory = categoryListBox.SelectedItem.ToString()!.Trim();
                string selectedSpecies = speciesListBox.SelectedItem.ToString()!.Trim();
                Animal currentAnimal;

                try
                {
                    currentAnimal = AnimalFactory.CreateAnimal(selectedCategory, selectedSpecies);
                } catch (ArgumentException ax)
                {
                    DisplayErrorBox(ax.ToString());
                    return;
                }
                
                List<string> questions = currentAnimal.GetQuestions();

                categoryQuestionLabel.Content = questions[0];
                speciesQuestionLabel.Content = questions[1];

                firstQTextBox.Visibility = Visibility.Visible;
                secondQTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                categoryQuestionLabel.Content = string.Empty;
                speciesQuestionLabel.Content = string.Empty;

                firstQTextBox.Visibility = Visibility.Hidden;
                secondQTextBox.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Retrieves all types in the assembly, then iterates over them to filter out categories and species.
        /// Adds the categories as keys and the species in a list as values to the dictionary.
        /// </summary>
        /// <returns>the complete dictionary of categories and corresponding species</returns>
        internal Dictionary<string, List<string>> GetCategoriesAndSpecies()
        {
            Dictionary<string, List<string>> categoriesAndSpecies = new();
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type category in allTypes)
            {
                if (category.IsClass && category.Namespace == "Csharp2_A1.Models.AnimalCategories")
                {
                    List<string> speciesList = new List<string>();

                    foreach (var species in allTypes)
                    {
                        if (species.IsClass && species.Namespace == $"Csharp2_A1.Models.AnimalSpecies.Species{category.Name}")
                        {
                            speciesList.Add(species.Name);
                        }
                    }
                    categoriesAndSpecies.Add(category.Name, speciesList);
                }
            }
            return categoriesAndSpecies;
        }

        internal void DisplayErrorBox(string message)
        {
            MessageBox.Show(message,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}