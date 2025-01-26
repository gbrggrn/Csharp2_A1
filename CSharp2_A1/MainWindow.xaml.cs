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

            speciesListBox.SelectionChanged += UpdateGUI;
        }

        internal void LoadCategories()
        {
            List<string> categoryNames = Assembly.GetExecutingAssembly().GetTypes().Where(name => name.Namespace == "Csharp2_A1.Models.AnimalCategories" && name.IsClass).Select(name => name.Name).ToList();

            foreach (var name in categoryNames)
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

                List<string> speciesNames = Assembly.GetExecutingAssembly().GetTypes().Where(name => name.Namespace == $"Csharp2_A1.Models.AnimalSpecies.Species{category}" && name.IsClass).Select(Name => Name.Name).ToList();

                foreach (var name in speciesNames)
                {
                    speciesListBox.Items.Add(name);
                }
            }
        }

        internal void UpdateGUI(Object sender, EventArgs e)
        {

        }
    }
}