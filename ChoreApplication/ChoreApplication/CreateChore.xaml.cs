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

namespace ChoreApplication
{
    /// <summary>
    /// Interaction logic for CreateChore.xaml
    /// </summary>
    public partial class CreateChore : Window
    {
        ChoresApplicationDataHandler ChoresApplicationDataHandler;
        public CreateChore(ChoresApplicationDataHandler choresApplicationDataHandler)
        {
            ChoresApplicationDataHandler = choresApplicationDataHandler;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // If Picture has been set
            if (chorePictureImage.Source != null)
            {
                // TODO: Add chore with picture
                //ChoresApplicationDataHandler.AddNewChore(choreNameTextBox.Text, Int32.Parse(valueTextBox.Text), (byte[])chorePictureImage.SomeField descriptionTextBox.Text);
            }
            else
            {
                if (Int32.TryParse(valueTextBox.Text, out int Value))
                {
                    ChoresApplicationDataHandler.AddNewChore_WithoutPicture(choreNameTextBox.Text, Int32.Parse(valueTextBox.Text), descriptionTextBox.Text);
                    Close();
                }
            }
        }

        private void AddChorePicture_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented", "Error", MessageBoxButton.OK);
        }
    }
}
