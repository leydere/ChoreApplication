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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        ChoresApplicationDataHandler ChoresApplicationDataHandler;
        public CreateUser(ChoresApplicationDataHandler choresApplicationDataHandler)
        {
            ChoresApplicationDataHandler = choresApplicationDataHandler;
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // If Picture has been set
            if (profilePicture.Source != null)
            {
                // TODO: Add user with picture
                //
            }
            else
            {
                ChoresApplicationDataHandler.AddNewUser_WithoutPicture(UserName.Text);
                Close();
            }
        }

        private void AddProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented", "Error", MessageBoxButton.OK);
        }
    }
}
