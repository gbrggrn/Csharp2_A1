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

        /// <summary>
        /// Sets the itemsource of the categoryListBox to Keys of the categoriesAndSpecies Dictionary.
        /// </summary>
        internal void LoadCategories()
        {
            categoryListBox.ItemsSource = categoriesAndSpecies.Keys;
        }

        /// <summary>
        /// Loads the species associated with a specific category to speciesListBox upon selection of category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Lists all species in speciesListBox upon checking of listAllCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Called upon unchecking of listAllCheckBox.
        /// Clears the speciesListBox of all species, and re-enables the categoryListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void EnableCategories(Object sender, EventArgs e)
        {
            speciesListBox.Items.Clear();
            categoryListBox.IsEnabled = true;
        }

        /// <summary>
        /// Called upon a change of index in speciesListBox to manipulate the input fields.
        /// Retrieves interfaces for the currently chosen animal and accesses the relevant properties
        /// to display the category-, and species specific question.
        /// If nothing is selected: hides the fields again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Adds the categories as keys and the corresponding species as a list as values to the dictionary.
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

        /// <summary>
        /// Displays a messagebox with a prompt:question that the user can answer yes or no to.
        /// </summary>
        /// <param name="question">The question posed to the user</param>
        /// <param name="title">The title of the messagebox</param>
        /// <returns>True if yes, false if no</returns>
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

                if (errors.Count > 1)
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

        /// <summary>
        /// Provides access to the ObservableCollection. This method is called upon the event that the collection is
        /// modified in AnimalRegistry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ObserveRegistry(Object sender, EventArgs e)
        {
            DisplayAnimals(animalRegistry.Animals);
        }

        /// <summary>
        /// Displays a shortlist of all animals that have been registered so far.
        /// Retrieves the interfaces for the specific animal in the collection.
        /// Through the interfaces, retrieves the name, name of the class (type->string)
        /// and age.
        /// </summary>
        /// <param name="animals">the observablecollection animals from animalRegistry</param>
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

        /// <summary>
        /// Displays a specific animal, chosen in the displayAllListBox, to displayAnimalListBox.
        /// Retrieves the specific animal from the observablecollection in animalRegistry.
        /// Retrieves the interfaces for that animal, and accesses the properties through those.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Resets all input fiels.
        /// </summary>
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