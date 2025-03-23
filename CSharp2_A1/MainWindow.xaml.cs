using Csharp2_A1;
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
        private readonly FoodManager foodManager;
        private readonly IdGenerator idGenerator;

        private bool editingFlag;

        /// <summary>
        /// Constructor instantiates classes and initiates basic configuration of the GUI.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            idGenerator = new();
            animalRegistry = new(idGenerator);
            foodManager = new();
            categoriesAndSpecies = GetCategoriesAndSpecies();
            LoadCategories();
            LoadGenderComboBox();
            SetSubscriptions();
            editingFlag = false;
            animalRegistry.Collection.CollectionChanged += DisplayAnimals!;
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
            displayAllListView.SelectionChanged += DisplayAnimal;
            sortNameCheckBox.Checked += SortAction;
            sortSpeciesCheckBox.Checked += SortAction;
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

                //A bit of an inefficient lookup, but the dictionary is small.
                //Could be changed to TryGetValue if application was bigger but this feels more readable.
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
        /// Sorting calls depending on user choice via checkboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortAction(Object sender, EventArgs e)
        {
            //Call sorting of animal-list by name
            if (sortNameCheckBox.IsChecked == true)
            {
                animalRegistry.SortCollection(Enums.SortBy.Name);
            }
            //Call sorting of animal-list by species
            else if (sortSpeciesCheckBox.IsChecked == true)
            {
                animalRegistry.SortCollection(Enums.SortBy.Species);
            }
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

                //If editing, retrieve interface of currently selected animal
                if (displayAllListView.SelectedIndex != -1 && editingFlag)
                {
                    int index = displayAllListView.SelectedIndex;
                    animalInterface = new InterfaceService(animalRegistry.GetAt(index));
                }

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
        private static Dictionary<string, List<string>> GetCategoriesAndSpecies()
        {
            Dictionary<string, List<string>> categoriesAndSpecies = [];
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            //Iterates over all types to retrieve a category and find its' corresponding species
            foreach (Type category in allTypes)
            {
                if (category.IsClass && category.Namespace == "Csharp2_A1.Models.AnimalCategories")
                {
                    //Initialize list to store species for retrieved category
                    List<string> speciesList = [];

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
            if (MessageBoxes.DisplayQuestion("Do you want to quit?\nUnsaved changes will be lost", "Quit?"))
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
                MessageBoxes.DisplayErrorBox(ax.ToString());
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

                //If editing, retrieve interface of currently selected animal
                if (editingFlag)
                {
                    int index = displayAllListView.SelectedIndex;
                    animalInterface = new InterfaceService(animalRegistry.GetAt(index));
                }

                if (animalInterface != null)
                {
                    List<string> errors = ValidateInput(animalInterface);

                    if (errors.Count > 0)
                    {
                        MessageBoxes.DisplayErrorBox($"Faulty input!\nErrorMessages:\n{string.Join("\n", errors)}");
                        return;
                    }
                    else
                    {
                        //Creates a Dictionary where the key represents an action (in this case a setter)
                        //and the value represents a string from a textbox in the UI.
                        Dictionary<Action<string>, string> settersAndValues = new()
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

                        //Adds the current animal to the AnimalRegistry
                        if (editingFlag)
                        {
                            int index = displayAllListView.SelectedIndex;
                            animalRegistry.ChangeAt(animalInterface.Animal.ThisAnimal, index);
                            ResetInputFields();
                            return;
                        }
                        else
                        {
                            try
                            {
                                animalRegistry.AddAnimal(animalInterface.Animal.ThisAnimal);
                                animalInterface.Animal.Id = idGenerator.GenerateId();
                            }
                            catch (Exception ex)
                            {
                                MessageBoxes.DisplayErrorBox($"Something went wrong:\n{ex.Message}");
                                return;
                            }
                            ResetInputFields();
                        }
                    }
                }
                else
                {
                    MessageBoxes.DisplayErrorBox("Could not create an animal");
                    return;
                }
            }
            else
            {
                MessageBoxes.DisplayErrorBox("No animaltype selected!");
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
            List<string> errors = [];

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
        /// Displays a shortlist of all animals that have been registered so far.
        /// Retrieves the interface for the specific animal in the collection.
        /// Through the interface, retrieves the name, name of the class (type->string)
        /// and age.
        /// </summary>
        /// <param name="animals">The observablecollection animals from animalRegistry</param>
        private void DisplayAnimals(Object sender, EventArgs e)
        {
            displayAllListView.Items.Clear();

            foreach (Animal animal in animalRegistry.Collection)
            {
                InterfaceService interfaces = new(animal);
                displayAllListView.Items.Add(
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
            if (displayAllListView.SelectedIndex != -1)
            {
                int indexToDisplay = displayAllListView.SelectedIndex;
                Animal animal = animalRegistry.GetAt(indexToDisplay);
                InterfaceService currentInterface = new(animal);

                displayAnimalListBox.Items.Clear();
                displayAnimalListBox.Items.Add(
                    $"ID:{currentInterface.Animal.Id,-15}\n" +
                    $"Age: {currentInterface.Animal.Age,-15}\n" +
                    $"Name: {currentInterface.Animal.Name,-15}\n" +
                    $"Gender: {currentInterface.Animal.Gender,-15}\n" +
                    $"Domesticated: {currentInterface.Animal.IsDomesticated,-10}\n" +
                    $"{currentInterface.Animal.CategoryQuestion}: {currentInterface.Animal.CategoryTrait}\n" +
                    $"{currentInterface.Animal.SpeciesQuestion}: {currentInterface.Animal.SpeciesTrait}\n" 
                    );

                //Update food connections display
                displayConnectionsListBox.Items.Clear();
                if (foodManager.Connections.Count > 0)
                {
                    if (foodManager.Connections.TryGetValue(animal, out List<FoodItem>? foodItems))
                    {
                        foreach (FoodItem item in foodItems)
                        {
                            displayConnectionsListBox.Items.Add(item.Name);
                        }
                    }
                }
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
            if (displayAllListView.SelectedIndex != -1)
            {
                int indexToDelete = displayAllListView.SelectedIndex;
                Animal animal = animalRegistry.GetAt(indexToDelete);
                string animalType = animal.GetType().Name;
                string name = animal.Name;

                if (MessageBoxes.DisplayQuestion($"Do you wish to remove the {animalType} {name} from the registry?",
                    $"Remove {animalType}?"))
                {
                    if (animalRegistry.DeleteAt(animal))
                    {
                        displayAnimalListBox.Items.Clear();
                        MessageBoxes.DisplayInfoBox($"The {animalType} {name} was removed from the registry",
                            $"Successful removal of {animalType}");
                    }
                    else
                    {
                        MessageBoxes.DisplayErrorBox("Animal could not be found!");
                    }
                }
            }
            else
            {
                MessageBoxes.DisplayErrorBox("No animal selected!");
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
            if (displayAllListView.SelectedIndex != -1)
            {
                OpenFileDialog openFile = new()
                {
                    Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg",
                    Multiselect = false
                };

                if (openFile.ShowDialog() == true)
                {
                    try
                    {
                        BitmapImage img = new();
                        img.BeginInit();
                        img.UriSource = new Uri(openFile.FileName);
                        img.EndInit();

                        imgControl.Source = img;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxes.DisplayErrorBox($"Something went wrong:\n{ex.Message}");
                        return;
                    }
                }
            }
            else
            {
                if (displayAllListView.Items.Count < 1)
                {
                    MessageBoxes.DisplayErrorBox("No animals added yet!");
                    return;
                }

                MessageBoxes.DisplayErrorBox("No animal selected!");
            }
        }

        /// <summary>
        /// Displays a new FoodScheduleWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageFoodItemsButton_Click(object sender, RoutedEventArgs e)
        {
            FoodScheduleWindow foodScheduleWindow = new(foodManager);

            foodScheduleWindow.ShowDialog();
        }

        /// <summary>
        /// Launches the about-window upon click of the about-button in MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new();

            aboutWindow.ShowDialog();
        }

        /// <summary>
        /// Toggles controls on/off when editing/not editing.
        /// </summary>
        /// <param name="onOrOff">Boolean false if On : true if Off</param>
        private void ToggleControlsUponEditing(bool onOrOff)
        {
            if (onOrOff)
            {
                deleteButton.IsEnabled = false;
                categoryListBox.IsEnabled = false;
                speciesListBox.IsEnabled = false;
                listAllCheckBox.IsEnabled = false;
                displayAllListView.IsEnabled = false;
                editButton.IsEnabled = false;
                manageFoodItemsButton.IsEnabled = false;

                //Rearrange subscriptions
                addButton.Content = "Save";
                addButton.Click -= AddButton_Click;
                addButton.Click += EditButton_Click;
            }
            if (!onOrOff)
            {
                deleteButton.IsEnabled = true;
                categoryListBox.IsEnabled = true;
                speciesListBox.IsEnabled = true;
                listAllCheckBox.IsEnabled = true;
                displayAllListView.IsEnabled = true;
                editButton.IsEnabled = true;
                manageFoodItemsButton.IsEnabled = true;

                //Rearrange subcriptions
                addButton.Content = "+ Add";
                addButton.Click -= EditButton_Click;
                addButton.Click += AddButton_Click;
            }
        }

        /// <summary>
        /// Provides the logic for when the "Edit general info"-button i clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (displayAllListView.SelectedIndex != -1)
            {
                //If not currently editing:
                if (!editingFlag)
                {
                    editingFlag = true;
                    UpdateInputControls(sender, e);
                    ToggleControlsUponEditing(editingFlag);
                    int index = displayAllListView.SelectedIndex;
                    InterfaceService currentInterface = new(animalRegistry.GetAt(index));
                    LoadAnimalToEdit(currentInterface);
                }
                //If currently editing:
                else if (editingFlag)
                {
                    AddButton_Click(sender, e);
                    editingFlag = false;
                    ToggleControlsUponEditing(editingFlag);
                }
            }
        }

        /// <summary>
        /// Loads the info from the currently selected animal to the GUI controls for editing.
        /// </summary>
        /// <param name="currentAnimalInterfaceIn">The interface of the currently selected animal</param>
        private void LoadAnimalToEdit(InterfaceService currentAnimalInterfaceIn)
        {
            nameTextBox.Text = currentAnimalInterfaceIn.Animal.Name;
            ageTextBox.Text = currentAnimalInterfaceIn.Animal.Age;
            genderComboBox.SelectedItem = currentAnimalInterfaceIn.Animal.Gender;
            domesticatedCheckBox.IsChecked = currentAnimalInterfaceIn.Animal.IsDomesticated;
            firstQTextBox.Text = currentAnimalInterfaceIn.Animal.CategoryTrait;
            secondQTextBox.Text = currentAnimalInterfaceIn.Animal.SpeciesTrait;
        }

        /// <summary>
        /// Displays a new Connections Window.
        /// Updates GUI upon return.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionsButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectionsWindow connectionsWindow = new(animalRegistry, foodManager);

            connectionsWindow.ShowDialog();

            DisplayAnimal(sender, e);
        }
    }
}