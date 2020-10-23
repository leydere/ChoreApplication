using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChoreApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChoresApplicationDataHandler ChoresApplicationDataHandler;

        int? ActiveUserID;
        int? SelectedUserID;

        //Hard Code values for temporary measure
        int[] scores = new int[10];

        public MainWindow()
        {
            InitializeComponent();
            UserGrid.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChoresApplicationDataHandler = new ChoresApplicationDataHandler();
            // TODO: Add code here to load data into the table SpecificChores.
            // This code could not be generated, because the database1DataSetSpecificChoresTableAdapter.Fill method is missing, or has unrecognized parameters.
            ChoreApplication.Database1DataSetTableAdapters.SpecificChoresTableAdapter database1DataSetSpecificChoresTableAdapter = new ChoreApplication.Database1DataSetTableAdapters.SpecificChoresTableAdapter();
            System.Windows.Data.CollectionViewSource specificChoresViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("specificChoresViewSource")));
            specificChoresViewSource.View.MoveCurrentToFirst();
        }

        private void Users_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChoresApplicationDataHandler.UpdateUsers();
                ChoresApplicationDataHandler.UpdateAll();
                MessageBox.Show("Database Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChoreUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChoresApplicationDataHandler.UpdateChores();
                ChoresApplicationDataHandler.UpdateAll();
                MessageBox.Show("Database Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUserID != null)
            {
                ActiveUserID = SelectedUserID;
                SelectedUserID = null;
                LoginGrid.Visibility = Visibility.Hidden;
                UserGrid.Visibility = Visibility.Visible;
                RefreshChoreTables();
                RefreshPersonalScores();
            }
        }

        private void RefreshChoreTables()
        {
            ChoresApplicationDataHandler.RefreshSpecificChores((int)ActiveUserID);
            //ChoresApplicationDataHandler.RefreshChores();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginGrid.Visibility = Visibility.Visible;
            UserGrid.Visibility = Visibility.Hidden;
            ActiveUserID = null;
        }

        private void UncommitBtn_Click(object sender, RoutedEventArgs e)
        {
            //If the user is logged in
            if (ActiveUserID != null)
            {
                DataRowView dataRowView = (DataRowView)SpecificUserChoreList.SelectedItem;
                int choreID = (int)dataRowView["ChoreID"];
                ChoresApplicationDataHandler.UnCommitToChore(choreID);

                MessageBox.Show("Chore UnCommited to sucessfully!");
            }
            else
            {
                MessageBox.Show("You need to log in first!");
            }
        }

        private void RefreshPersonalScores()
        {
            if (ActiveUserID != null)
            {
                scoreTextBox.Text = ChoresApplicationDataHandler.GetUserScore((int)ActiveUserID).ToString();
                PrivateScore.Text = ChoresApplicationDataHandler.GetUserScore((int)ActiveUserID).ToString();
            }
        }

        private void RefreshScoreCard()
        {
            ChoresApplicationDataHandler.RefreshScoreCard();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // For entering different tabs
            if (HomeTab.IsSelected)
            {
                LoadHomeTabTables();
                RefreshPersonalScores();
            }
            if (UsersTab.IsSelected)
            {

            }
            if (ChoresTab.IsSelected)
            {

            }
            if (LeaderboardTab.IsSelected)
            {
                RefreshScoreCard();
                RefreshPersonalScores();
            }
            if (RewardsTab.IsSelected)
            {

            }
        }

        private void LoadHomeTabTables()
        {

        }

        private void AddPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ChoreDG.SelectedIndex != -1)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = "Select a Image";
                    // the lengthy directory statement below takes us to the chore application\\chore application\\chore application folder in our project folder -ERL
                    openFileDialog.InitialDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Images\\ChorePics\\";
                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        string thisHerePath = openFileDialog.FileName; //unnecessary path stuff -ERL
                        string filenameWithoutPath = Path.GetFileName(openFileDialog.FileName); //unnecessary path stuff -ERL
                        MessageBox.Show("PATH: " + thisHerePath + "\nFILENAME: " + filenameWithoutPath, "A path way perhaps?", MessageBoxButton.OK, MessageBoxImage.Information); //unnecessary path stuff -ERL

                        byte[] img = File.ReadAllBytes(openFileDialog.FileName); //converts selected file to byte array -ERL

                        DataRowView row = (DataRowView)ChoreDG.SelectedItem; //aligns to selected row for line below -ERL
                        row[3] = img; //puts converted byte array image in column 3 of selected row of datatable -ERL

                    }
                    openFileDialog = null;
                }
                else
                {
                    MessageBox.Show("No Chore Selected", "Selected Index = -1", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CompleteUserChore_Click(object sender, RoutedEventArgs e)
        {
            if (SpecificUserChoreList.SelectedItem == null)
                MessageBox.Show("You have to select a chore to delete.", "Warning", MessageBoxButton.OK);
            else
            {
                int ChoreID = (int)((DataRowView)SpecificUserChoreList.SelectedItem)["ChoreID"];
                ChoresApplicationDataHandler.CompleteChore(ChoreID, (int)ActiveUserID);
                MessageBox.Show("Chore completed");
                RefreshChoreTables();
            }
        }

        private void UserPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            try
            {
                DataRowView dataRowView = (DataRowView)comboBox.SelectedItem;
                SelectedUserID = (int)dataRowView.Row["UserID"];
                selectedUserLabelName.Content = (string)dataRowView.Row["UserName"];
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error reading the selected line.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                selectedUserLabelName.Content = "none";
                SelectedUserID = null;
            }
        }

        private void CommitBtn_Click(object sender, RoutedEventArgs e)
        {
            //If the user is logged in
            if (ActiveUserID != null)
            {
                if ((DataRowView)ChoreDG.SelectedItem != null)
                {
                DataRowView dataRowView = (DataRowView)ChoreDG.SelectedItem;
                int choreID = (int)dataRowView["ChoreID"];
                //Check to see if the chore is already selected by another user

                if (ChoresApplicationDataHandler.TryAddNewResponsibility((int)ActiveUserID, choreID))
                    MessageBox.Show("Chore commited to sucessfully!");
                else
                    MessageBox.Show("There was an error committing to the chore.", "Error", MessageBoxButton.OK);
                }
                else
                    MessageBox.Show("No chore was selected.", "Error", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("You need to log in first!");
        }

        private void CreateChore_Click(object sender, RoutedEventArgs e)
        {
            CreateChore choreControl = new CreateChore(ChoresApplicationDataHandler);
            choreControl.ShowDialog();
        }

        private void DeleteChore_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(choreIDTextBox.Text, out int ChoreID))
                ChoresApplicationDataHandler.RemoveChore(ChoreID);
            else
                MessageBox.Show("Error parsing choreID", "Error", MessageBoxButton.OK);
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser(ChoresApplicationDataHandler);
            createUser.ShowDialog();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(userIDTextBox.Text, out int UserID))
                ChoresApplicationDataHandler.RemoveUser(UserID);
            else
                MessageBox.Show("Error parsing choreID", "Error", MessageBoxButton.OK);
        }
    }
}
