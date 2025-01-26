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
        public MainWindow()
        {
            InitializeComponent();
            LoadCategories();
            categoryListBox.SelectionChanged += LoadSpecies;
            speciesListBox.SelectionChanged += UpdateInputControls;
            listAllCheckBox.Checked += LoadAllSpecies;
            listAllCheckBox.Unchecked += EnableCategories;
        }

        internal void LoadCategories()
        {
            List<string> categories = GetCategories();
            foreach (var name in categories)
            {
                categoryListBox.Items.Add(name);
            }
        }

        internal void LoadSpecies(Object sender, EventArgs e)
        {
            if (categoryListBox.SelectedIndex != -1)
            {
                speciesListBox.Items.Clear();
                string category = categoryListBox.SelectedItem.ToString()!.Trim();

                List<string> species = GetSpecies(category);
                foreach (var name in species)
                {
                    speciesListBox.Items.Add(name);
                }
            }
        }

        internal void LoadAllSpecies(Object sender, EventArgs e)
        {
            speciesListBox.Items.Clear();
            categoryListBox.IsEnabled = false;
            List<string> categories = [];
            
            foreach (var item in categoryListBox.Items)
            {
                categories.Add(item.ToString()!.Trim());
            }

            List<string> species = GetSpecies(categories);
            foreach (var name in species)
            {
                speciesListBox.Items.Add(name);
                Console.WriteLine(name);
            }
        }

        internal void EnableCategories(Object sender, EventArgs e)
        {
            categoryListBox.IsEnabled = true;
        }

        internal void UpdateInputControls(Object sender, EventArgs e)
        {


        }

        internal List<string> GetCategories()
        {
            List<string> categoryNames = [];
            return categoryNames = Assembly.GetExecutingAssembly().GetTypes().Where(name => name.Namespace == "Csharp2_A1.Models.AnimalCategories" && name.IsClass).Select(name => name.Name).ToList();
        }

        internal List<string> GetSpecies(List<string> categories)
        {
            List<string> speciesFromAllCategories = [];

            foreach (var category in categories)
            {
                List<string> speciesFromACategory = Assembly.GetExecutingAssembly().GetTypes().Where(name => name.Namespace == $"Csharp2_A1.Models.AnimalSpecies.Species{category}" && name.IsClass).Select(Name => Name.Name).ToList();
                speciesFromAllCategories.AddRange(speciesFromACategory);
            }

            return speciesFromAllCategories;
        }

        internal List<string> GetSpecies(string category)
        {
            List<string> speciesFromOneCategory = [];

            speciesFromOneCategory = Assembly.GetExecutingAssembly().GetTypes().Where(name => name.Namespace == $"Csharp2_A1.Models.AnimalSpecies.Species{category}" && name.IsClass).Select(Name => Name.Name).ToList();
            
            return speciesFromOneCategory;
        }
    }
}