using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using Csharp2_A1.Models.AnimalCategories;
using Csharp2_A1.Models.Enums;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
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
        private AnimalRegistry animalRegistry;
        private IdGenerator idGenerator;

        private const int registrySize = 100;

        public MainWindow()
        {
            InitializeComponent();
            idGenerator = new(registrySize);
            animalRegistry = new(this, registrySize, idGenerator);
            categoriesAndSpecies = GetCategoriesAndSpecies();
            LoadCategories();
            LoadGenderComboBox();
            SetSubscriptions();
        }

        internal void SetSubscriptions()
        {
            categoryListBox.SelectionChanged += LoadSpecies;
            speciesListBox.SelectionChanged += UpdateInputControls;
            listAllCheckBox.Checked += LoadAllSpecies;
            listAllCheckBox.Unchecked += EnableCategories;
            displayAllListBox.SelectionChanged += DisplayAnimal;
        }

        internal void LoadGenderComboBox()
        {
            genderComboBox.ItemsSource = Enum.GetValues(typeof(Enums.Gender)).Cast<Enums.Gender>();
            genderComboBox.SelectedIndex = 2;
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
            categoryListBox.IsEnabled = false;
            speciesListBox.ItemsSource = null;

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
                InterfaceService currentInterfaces = GetCurrentInterfaces();

                if (currentInterfaces != null)
                {
                    categoryQuestionLabel.Content = currentInterfaces.Category!.CategoryQuestion;
                    speciesQuestionLabel.Content = currentInterfaces.Species!.SpeciesQuestion;

                    firstQTextBox.Visibility = Visibility.Visible;
                    secondQTextBox.Visibility = Visibility.Visible;
                }
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
        /// Returns the name of the category corresponding to the chosen species.
        /// </summary>
        /// <param name="species">The chosen species</param>
        /// <returns>The corresponding category</returns>
        internal string GetCorrespondingCategory(string species)
        {
            foreach (var category in categoriesAndSpecies)
            {
                if (category.Value.Contains(species))
                {
                    return category.Key;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Retrieves all types in the assembly, then iterates over them to filter out classnames of categories and species.
        /// Adds the categories as keys and the species in a list as values to the dictionary.
        /// </summary>
        /// <returns>The complete dictionary of categories and corresponding species</returns>
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

        /// <summary>
        /// Executes if exit-button is clicked. Prompts user to quit or stay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayQuestion("Do you want to quit?\nUnsaved changes will be lost", "Quit?"))
            {
                this.Close();
            }
        }

        /// <summary>
        /// Displays a messagebox with an error-message.
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        internal void DisplayErrorBox(string message)
        {
            MessageBox.Show(message,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        internal bool DisplayQuestion(string question, string title)
        {
            MessageBoxResult answer = MessageBox.Show(question,
                title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private InterfaceService GetCurrentInterfaces()
        {
            string selectedSpecies = speciesListBox.SelectedItem.ToString()!.Trim();
            string selectedCategory = GetCorrespondingCategory(selectedSpecies);
            InterfaceService currentInterfaces;

            try
            {
                currentInterfaces = AnimalFactory.CreateAnimal(selectedCategory, selectedSpecies);
            }
            catch (ArgumentException ax)
            {
                DisplayErrorBox(ax.ToString());
                currentInterfaces = null!;
                return currentInterfaces!;
            }

            return currentInterfaces;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (speciesListBox.SelectedIndex != -1)
            {
                InterfaceService currentInterfaces = GetCurrentInterfaces();
                List<string> errors = new List<string>();

                if (!currentInterfaces.Animal.ValidateAnimalTraits(ageTextBox.Text, nameTextBox.Text, out string errorMessages))
                {
                    errors.Add(errorMessages);
                }

                if (!currentInterfaces.Category!.ValidateCategoryTrait(firstQTextBox.Text, out string errorMessageC))
                {
                    errors.Add(errorMessageC);
                }

                if (!currentInterfaces.Species!.ValidateSpeciesTrait(secondQTextBox.Text, out string errorMessageS))
                {
                    errors.Add(errorMessageS);
                }

                if (errors.Count > 0)
                {
                    DisplayErrorBox($"Faulty input!\nErrorMessages:\n{string.Join("\n", errors)}");
                    return;
                }
                else
                {
                    Action<string>[] setters = [
                    value => currentInterfaces.Animal.Age = value,
                    value => currentInterfaces.Animal.Name = value,
                    value => currentInterfaces.Category!.CategoryTrait = value,
                    value => currentInterfaces.Species!.SpeciesTrait = value
                    ];

                    string[] input = [
                        ageTextBox.Text,
                        nameTextBox.Text,
                        firstQTextBox.Text,
                        secondQTextBox.Text,
                        ];

                    for (int i = 0; i < setters.Length; i++)
                    {
                        setters[i](input[i]);
                    }

                    currentInterfaces.Animal.IsDomesticated = domesticatedCheckBox.IsChecked!.Value;
                    currentInterfaces.Animal.Gender = (Enums.Gender)genderComboBox.SelectedItem;
                    currentInterfaces.Animal.Id = idGenerator.GenerateId();

                    animalRegistry.AddAnimal(currentInterfaces.Animal);

                    ResetAllInputFields();
                }
            }
        }

        internal void ObserveRegistry(Object sender, EventArgs e)
        {
            DisplayAnimals(animalRegistry.Animals);
        }

        private void DisplayAnimals(ObservableCollection<IAnimal> animals)
        {
            displayAllListBox.Items.Clear();

            foreach (Animal animal in animals)
            {
                InterfaceService interfaces = new(animal);
                displayAllListBox.Items.Add(
                    $"{interfaces.Animal.Name,-15}" +
                    $"{interfaces.Species!.GetType().Name,-15}" +
                    $"{interfaces.Animal.Age, -5}");
            }
        }

        private void DisplayAnimal(Object sender, EventArgs e)
        {
            if (displayAllListBox.SelectedIndex != -1)
            {
                int indexToDisplay = displayAllListBox.SelectedIndex;
                IAnimal animal = animalRegistry.Animals[indexToDisplay];
                InterfaceService currentInterfaces = new(animal);

                displayAnimalListBox.Items.Clear();
                displayAnimalListBox.Items.Add(
                    $"ID:{currentInterfaces.Animal.Id,-15}\n" +
                    $"Age: {currentInterfaces.Animal.Age,-15}\n" +
                    $"Name: {currentInterfaces.Animal.Name,-15}\n" +
                    $"Gender: {currentInterfaces.Animal.Gender,-15}\n" +
                    $"Domesticated: {currentInterfaces.Animal.IsDomesticated,-10}\n" +
                    $"{currentInterfaces.Category!.CategoryQuestion}: {currentInterfaces.Category.CategoryTrait}\n" +
                    $"{currentInterfaces.Species!.SpeciesQuestion}: {currentInterfaces.Species.SpeciesTrait}\n"
                    );
            }
        }

        internal void ResetAllInputFields()
        {
            nameTextBox.Text = string.Empty;
            ageTextBox.Text = string.Empty;
            genderComboBox.SelectedIndex = 2;
            domesticatedCheckBox.IsChecked = false;
            firstQTextBox.Text = string.Empty;
            secondQTextBox.Text = string.Empty;
        }
    }
}