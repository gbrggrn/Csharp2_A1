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

namespace Csharp2_A1
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            TextBlockContent();
        }

        /// <summary>
        /// Sets the Text-property of the textblock.
        /// </summary>
        private void TextBlockContent()
        {
            string aboutText = "Welcome to Animal Specifications!\n" +
                "Keep a registry of animals!\n" +
                "This is version 1.0 of this program\n" +
                "Developed by: Gustaf Berggren Sörlin";

            aboutTextBlock.Text = aboutText;
        }

        /// <summary>
        /// Closes the window upon click of the ok-button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}