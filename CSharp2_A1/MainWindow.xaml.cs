﻿using Csharp2_A1;
using Csharp2_A1.Control;
using Csharp2_A1.Control.Interfaces;
using Csharp2_A1.Models;
using Csharp2_A1.Models.AnimalCategories;
using Csharp2_A1.Models.Enums;
using Microsoft.VisualBasic;
using Microsoft.Win32;
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
        private readonly AnimalRegistry animalRegistry;
        private readonly IdGenerator idGenerator;

        private const int registrySize = 100;

        /// <summary>
        /// Constructor instantiates classes and initiates basic configuration of the GUI.
        /// </summary>
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

        /// <summary>
        /// Helper method to reduce calls in the constructor. Sets subscriptions for crucial events.
        /// </summary>
        private void SetSubscriptions()
        {
            categoryListBox.SelectionChanged += LoadSpecies;
            speciesListBox.SelectionChanged += UpdateInputControls;
            listAllCheckBox.Checked += LoadAllSpecies;
            listAllCheckBox.Unchecked += EnableCategories;
            displayAllListBox.SelectionChanged += DisplayAnimal;
        }

        /// <summary>
        /// Sets the ItemsSource for genderComboBox to the Enum "Gender".
        /// </summary>
        private void LoadGenderComboBox()
        {
            genderComboBox.ItemsSource = Enum.GetValues(typeof(Enums.Gender)).Cast<Enums.Gender>();
            genderComboBox.SelectedIndex = 2;
        }

        /// <summary>
        /// Sets the itemsource of the categoryListBox to Keys of the categoriesAndSpecies Dictionary.
        /// </summary>
        private void LoadCategories()
        {
            categoryListBox.ItemsSource = categoriesAndSpecies.Keys;
        }

        /// <summary>
        /// Loads the species associated with a specific category to speciesListBox upon selection of category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSpecies(Object sender, EventArgs e)
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
        private void LoadAllSpecies(Object sender, EventArgs e)
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
        private void EnableCategories(Object sender, EventArgs e)
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
        private void UpdateInputControls(Object sender, EventArgs e)
        {
            if (speciesListBox.SelectedIndex != -1)
            {
                InterfaceService animalInterface = TryCreateAnimal();

                if (animalInterface != null)
                {
                    categoryQuestionLabel.Content = animalInterface.Animal.CategoryQuestion;
                    speciesQuestionLabel.Content = animalInterface.Animal.SpeciesQuestion;

                    firstQTextBox.Visibility = Visibility.Visible;
                    secondQTextBox.Visibility = Visibility.Visible;

                    //If categories are disabled to highlight the category based on species selection
                    if (listAllCheckBox.IsChecked == true)
                    {
                        string category = GetCorrespondingCategory(animalInterface.Animal.GetType().Name); //Get corresponding category
                        categoryListBox.SelectionChanged -= LoadSpecies; //Remove subscription to prevent exception
                        categoryListBox.SelectedItem = category; //Highlight the category
                        categoryListBox.SelectionChanged += LoadSpecies; //Re-assign subscription
                    }
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
        private string GetCorrespondingCategory(string species)
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
        /// Adds the categories as keys and the corresponding species as a list as values to a dictionary.
        /// It seems to me this method might be inefficient at scale since it is iterating multiple times over the
        /// entire assembly. I still think this is a fun approach to dynamically retrieve the class-names but
        /// a future small side-project should be to make this more efficient...
        /// </summary>
        /// <returns>The complete dictionary of categories and corresponding species</returns>
        private Dictionary<string, List<string>> GetCategoriesAndSpecies()
        {
            Dictionary<string, List<string>> categoriesAndSpecies = new();
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            //Iterates over all types to retrieve a category and find its' corresponding species
            foreach (Type category in allTypes)
            {
                if (category.IsClass && category.Namespace == "Csharp2_A1.Models.AnimalCategories")
                {
                    //Initialize list to store species for retrieved category
                    List<string> speciesList = new List<string>();

                    //Iterates over all types to retrieve the species connected to the retrieved category
                    foreach (Type species in allTypes)
                    {
                        if (species.IsClass && species.Namespace == $"Csharp2_A1.Models.AnimalSpecies.Species{category.Name}")
                        {
                            //Add retreieved specie to the list of this category
                            speciesList.Add(species.Name);
                        }
                    }
                    //Add the category and its' species to the dictionary
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
        /// Dependant on the selected species: retrieves the interfaces through InterfaceService.
        /// </summary>
        /// <returns>An instance of the InterfaceService class with access to the interface-property</returns>
        private InterfaceService TryCreateAnimal()
        {
            string selectedSpecies = speciesListBox.SelectedItem.ToString()!.Trim();
            string selectedCategory = GetCorrespondingCategory(selectedSpecies);
            InterfaceService animalInterface;

            try
            {
                animalInterface = AnimalFactory.CreateAnimal(selectedCategory, selectedSpecies);
            }
            catch (ArgumentException ax)
            {
                DisplayErrorBox(ax.ToString());
                animalInterface = null!;
                return animalInterface!;
            }

            return animalInterface;
        }

        /// <summary>
        /// Upon a click of the add-button, this method calls validation on the inputs, and
        /// either saves them to the correct properties and adds the animal to the animal registry,
        /// or displays a summary of the validation-errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (speciesListBox.SelectedIndex != -1)
            {
                InterfaceService animalInterface = TryCreateAnimal();

                if (animalInterface != null)
                {
                    List<string> errors = ValidateInput(animalInterface);

                    if (errors.Count > 0)
                    {
                        DisplayErrorBox($"Faulty input!\nErrorMessages:\n{string.Join("\n", errors)}");
                        return;
                    }
                    else
                    {
                        //Creates a Dictionary where the key represents an action (in this case a setter)
                        //and the value represents a string from a textbox in the UI.
                        Dictionary<Action<string>, string> settersAndValues = new Dictionary<Action<string>, string>
                        {
                            [value => animalInterface.Animal.Age = value] = ageTextBox.Text,
                            [value => animalInterface.Animal.Name = value] = nameTextBox.Text,
                            [value => animalInterface.Animal.CategoryTrait = value] = firstQTextBox.Text,
                            [value => animalInterface.Animal.SpeciesTrait = value] = secondQTextBox.Text
                        };

                        //Execute each action (key) with the value (value) as an argument
                        foreach (var pair in settersAndValues)
                        {
                            pair.Key(pair.Value);
                        }

                        //Sets the rest of the animal-attributes that are not strings.
                        animalInterface.Animal.IsDomesticated = domesticatedCheckBox.IsChecked!.Value;
                        animalInterface.Animal.Gender = (Enums.Gender)genderComboBox.SelectedItem;
                        animalInterface.Animal.Id = idGenerator.GenerateId();

                        //Adds the current animal to the AnimalRegistry so long as the registry is not full
                        try
                        {
                            animalRegistry.AddAnimal(animalInterface.Animal.ThisAnimal);
                        }
                        catch (Exception ex)
                        {
                            DisplayErrorBox($"Something went wrong:\n{ex.Message}");
                            return;
                        }

                        ResetInputFields();
                    }
                }
                else
                {
                    DisplayErrorBox("Could not create an animal");
                    return;
                }
            }
            else
            {
                DisplayErrorBox("No animaltype selected!");
            }
        }

        /// <summary>
        /// Calls validation methods on the input from the GUI.
        /// Returns a list of errors.
        /// </summary>
        /// <param name="currentInterface"></param>
        /// <returns></returns>
        private List<string> ValidateInput(InterfaceService currentInterface)
        {
            List<string> errors = new List<string>();

            if (!currentInterface.Animal.ValidateAnimalTraits(ageTextBox.Text, nameTextBox.Text, out string errorMessages))
            {
                errors.Add(errorMessages);
            }

            if (!currentInterface.Animal.ValidateCategoryTrait(firstQTextBox.Text, out string errorMessageC))
            {
                errors.Add(errorMessageC);
            }

            if (!currentInterface.Animal.ValidateSpeciesTrait(secondQTextBox.Text, out string errorMessageS))
            {
                errors.Add(errorMessageS);
            }

            return errors;
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
        /// Retrieves the interface for the specific animal in the collection.
        /// Through the interface, retrieves the name, name of the class (type->string)
        /// and age.
        /// </summary>
        /// <param name="animals">The observablecollection animals from animalRegistry</param>
        private void DisplayAnimals(ObservableCollection<Animal> animals)
        {
            displayAllListBox.Items.Clear();

            foreach (Animal animal in animals)
            {
                InterfaceService interfaces = new(animal);
                displayAllListBox.Items.Add(
                    $"{interfaces.Animal.Name,-15}" +
                    $"{interfaces.Animal.GetType().Name,-15}" +
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
                Animal animal = animalRegistry.Animals[indexToDisplay];
                InterfaceService currentInterfaces = new(animal);

                displayAnimalListBox.Items.Clear();
                displayAnimalListBox.Items.Add(
                    $"ID:{currentInterfaces.Animal.Id,-15}\n" +
                    $"Age: {currentInterfaces.Animal.Age,-15}\n" +
                    $"Name: {currentInterfaces.Animal.Name,-15}\n" +
                    $"Gender: {currentInterfaces.Animal.Gender,-15}\n" +
                    $"Domesticated: {currentInterfaces.Animal.IsDomesticated,-10}\n" +
                    $"{currentInterfaces.Animal.CategoryQuestion}: {currentInterfaces.Animal.CategoryTrait}\n" +
                    $"{currentInterfaces.Animal.SpeciesQuestion}: {currentInterfaces.Animal.SpeciesTrait}\n"
                    );
            }
        }

        /// <summary>
        /// Resets all input fiels.
        /// </summary>
        private void ResetInputFields()
        {
            nameTextBox.Text = string.Empty;
            ageTextBox.Text = string.Empty;
            genderComboBox.SelectedIndex = 2;
            domesticatedCheckBox.IsChecked = false;
            firstQTextBox.Text = string.Empty;
            secondQTextBox.Text = string.Empty;
            imgControl.Source = null;
        }

        /// <summary>
        /// If a selection is made, prompts the user for deletion.
        /// Upon "yes" - deletes the selected animal from the registry,
        /// else: does nothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (displayAllListBox.SelectedIndex != -1)
            {
                int indexToDelete = displayAllListBox.SelectedIndex;
                Animal animal = animalRegistry.Animals[indexToDelete];
                string animalType = animal.GetType().Name;
                string name = animal.Name;

                if (DisplayQuestion($"Do you wish to remove the {animalType} {name} from the registry?",
                    $"Remove {animalType}?"))
                {
                    if (animalRegistry.RemoveAnimal(animalRegistry.Animals[indexToDelete]))
                    {
                        displayAnimalListBox.Items.Clear();
                        DisplayInfoBox($"The {animalType} {name} was removed from the registry",
                            $"Successful removal of {animalType}");
                    }
                    else
                    {
                        DisplayErrorBox("Animal could not be found!");
                    }
                }
            }
            else
            {
                DisplayErrorBox("No animal selected!");
            }
        }

        /// <summary>
        /// Displays an openfiledialog and lets the user select an img-file to display for
        /// the chosen animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImgButton_Click(object sender, RoutedEventArgs e)
        {
            if (displayAllListBox.SelectedIndex != -1)
            {
                OpenFileDialog openFile = new();
                openFile.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
                openFile.Multiselect = false;

                if (openFile.ShowDialog() == true)
                {
                    try
                    {
                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(openFile.FileName);
                        img.EndInit();

                        imgControl.Source = img;
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorBox($"Something went wrong:\n{ex.Message}");
                        return;
                    }
                }
            }
            else
            {
                if (displayAllListBox.Items.Count < 1)
                {
                    DisplayErrorBox("No animals added yet!");
                    return;
                }

                DisplayErrorBox("No animal selected!");
            }
        }

        /// <summary>
        /// Launches the about-window upon click of the about-button in MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();

            aboutWindow.ShowDialog();
        }

        /// <summary>
        /// Displays a messageBox containing information.
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="title">The title of the messagebox</param>
        private void DisplayInfoBox(string message, string title)
        {
            MessageBox.Show($"{message}",
                $"{title}",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        /// <summary>
        /// Displays a messagebox with an error-message.
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        private void DisplayErrorBox(string message)
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
        private bool DisplayQuestion(string question, string title)
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
    }
}