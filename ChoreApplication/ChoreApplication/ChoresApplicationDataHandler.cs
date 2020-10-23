using System;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace ChoreApplication
{
    public class ChoresApplicationDataHandler
    {
        //TODO: Make class a static class
        public Database1DataSetTableAdapters.UsersTableAdapter UsersTableAdapter;
        public Database1DataSetTableAdapters.ChoresTableAdapter ChoresTableAdapter;
        public Database1DataSetTableAdapters.CompletedChoresTableAdapter CompletedChoresTableAdapter;
        public Database1DataSetTableAdapters.ResponsibilitiesTableAdapter ResponsibilitiesTableAdapter;
        public Database1DataSetTableAdapters.SpecificChoresTableAdapter SpecificChoresTableAdapter;
        public Database1DataSetTableAdapters.ScoreCardTableAdapter ScoreCardTableAdapter;

        public Database1DataSetTableAdapters.TableAdapterManager TableAdapterManager;
        public Database1DataSet DataSet;

        public ChoresApplicationDataHandler()
        {
            DataSet = (Database1DataSet)System.Windows.Application.Current.FindResource("database1DataSet");

            UsersTableAdapter = new Database1DataSetTableAdapters.UsersTableAdapter();
            ChoresTableAdapter = new Database1DataSetTableAdapters.ChoresTableAdapter();
            ScoreCardTableAdapter = new Database1DataSetTableAdapters.ScoreCardTableAdapter();
            SpecificChoresTableAdapter = new Database1DataSetTableAdapters.SpecificChoresTableAdapter();
            CompletedChoresTableAdapter = new Database1DataSetTableAdapters.CompletedChoresTableAdapter();
            ResponsibilitiesTableAdapter = new Database1DataSetTableAdapters.ResponsibilitiesTableAdapter();

            UsersTableAdapter.Fill(DataSet.Users);
            ChoresTableAdapter.Fill(DataSet.Chores);
            ScoreCardTableAdapter.Fill(DataSet.ScoreCard);             // Not needed
            CompletedChoresTableAdapter.Fill(DataSet.CompletedChores);
            // Cannot use the Fill method without a specific user. This is set upon a user loggin in.
            //SpecificChoresTableAdapter.Fill(DataSet.SpecificChores);
            ResponsibilitiesTableAdapter.Fill(DataSet.Responsibilities);

            TableAdapterManager = new Database1DataSetTableAdapters.TableAdapterManager
            {
                UsersTableAdapter = UsersTableAdapter,
                ChoresTableAdapter = ChoresTableAdapter,
                CompletedChoresTableAdapter = CompletedChoresTableAdapter,
                ResponsibilitiesTableAdapter = ResponsibilitiesTableAdapter
            };
        }

        public void AddNewChore(string ChoreName, int Value, byte[] ChorePicture, string Description)
        {
            DataSet.Chores.AddChoresRow(ChoreName, Value, ChorePicture, Description, true);
            //UpdateChores();
            UpdateAll();
        }

        public void AddNewChore_WithoutPicture(string ChoreName, int Value, string Description)
        {
            DataSet.Chores.AddChoresRow(ChoreName, Value, null, Description, true);
            //UpdateChores();
            UpdateAll();
        }

        public void AddNewUser(string UserName, byte[] ProfilePicture)
        {
            DataSet.Users.AddUsersRow(UserName, ProfilePicture, true);
            //UpdateUsers();
            UpdateAll();
        }

        public void AddNewUser_WithoutPicture(string UserName)
        {
            DataSet.Users.AddUsersRow(UserName, null, true);
            //UpdateUsers();
            UpdateAll();
        }

        public bool TryAddNewResponsibility(int UserID, int ChoreID)
        {
            Database1DataSet.UsersRow User = UsersTableAdapter.GetDataByID(UserID)[0];
            Database1DataSet.ChoresRow Chore = ChoresTableAdapter.GetDataByID(ChoreID)[0];
            try
            {
                DataSet.Responsibilities.AddResponsibilitiesRow(User, Chore);
                //UpdateResponsibilities();
                UpdateAll();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddNewCompletedChore(Database1DataSet.UsersRow User, Database1DataSet.ChoresRow Chore)
        {
            DataSet.CompletedChores.AddCompletedChoresRow(User, Chore, 1, true);
            //UpdateCompletedChores();
            UpdateAll();
        }

        public void IncrementCompletedChore(int UserID,int ChoreID)
        {
            System.Data.DataRow CompletedChore = DataSet.CompletedChores.Rows.Find(new object[2] { UserID, ChoreID });
            CompletedChore.BeginEdit();
            CompletedChore["Occurances"] = (int)CompletedChore["Occurances"] + 1;
            CompletedChore.EndEdit();
            //UpdateCompletedChores();
            UpdateAll();
        }

        public void UpdateUsers()
        {
            UsersTableAdapter.Update(DataSet.Users);
        }

        public void UpdateChores()
        {
            ChoresTableAdapter.Update(DataSet.Chores);
        }

        public void UpdateResponsibilities()
        {
            ResponsibilitiesTableAdapter.Update(DataSet.Responsibilities);
        }

        public void UpdateCompletedChores()
        {
            CompletedChoresTableAdapter.Update(DataSet.CompletedChores);
        }

        public void UpdateAll()
        {
            TableAdapterManager.UpdateAll(DataSet);
        }

        public void RefreshSpecificChores(int ActiveUserID)
        {
            SpecificChoresTableAdapter.FillBy(DataSet.SpecificChores, ActiveUserID);
        }

        public void RefreshChores()
        {
            ChoresTableAdapter.Fill(DataSet.Chores);
        }

        public void RefreshScoreCard()
        {
            ScoreCardTableAdapter.Fill(DataSet.ScoreCard);
        }

        public void UnCommitToChore(int ChoreID)
        {
            DataSet.SpecificChores.RemoveSpecificChoresRow((Database1DataSet.SpecificChoresRow)DataSet.SpecificChores.Rows.Find(ChoreID));
            DataSet.Responsibilities.RemoveResponsibilitiesRow((Database1DataSet.ResponsibilitiesRow)DataSet.Responsibilities.Rows.Find(ChoreID));
            UpdateAll();
        }

        public int GetUserScore(int ActiveUserID)
        {
            Database1DataSet.ScoreCardDataTable scoreCardRows = ScoreCardTableAdapter.GetDataByUserID(ActiveUserID);
            if (scoreCardRows.Count != 0)
            {
                return scoreCardRows[0].Score;
            }
            else return 0;
        }

        public void CompleteChore(int ChoreID, int UserID)
        {
            // Set local User and Chore
            Database1DataSet.UsersRow User = UsersTableAdapter.GetDataByID(UserID)[0];
            Database1DataSet.ChoresRow Chore = ChoresTableAdapter.GetDataByID(ChoreID)[0];

            // Get specific responsibility
            Database1DataSet.ResponsibilitiesRow Responsibility = ResponsibilitiesTableAdapter.GetDataByChoreIDANDUserID(UserID, ChoreID)[0];

            // Make sure responsibility exists
            if (DataSet.Responsibilities.Rows.Contains(new object[2] { UserID, ChoreID }))
            {
                // Get All completed chores for a specific user
                Database1DataSet.CompletedChoresDataTable completedChoresRows = CompletedChoresTableAdapter.GetDataByID(UserID);
                bool CompletedPrior = false;
                foreach (Database1DataSet.CompletedChoresRow row in completedChoresRows)
                {
                    // Check if the chore has been completed by the user before
                    if (row.ChoreID == ChoreID)
                    {
                        // If it has, increment the completed chore
                        IncrementCompletedChore(UserID, ChoreID);
                        CompletedPrior = true;
                    }
                }

                // If this is first time the chore is being done
                if (CompletedPrior == false)
                {
                    // Create new completed chores
                    AddNewCompletedChore(User, Chore);
                }

                // Remove the responsibility now that the chore has been completed
                RemoveResponsibility(UserID, ChoreID);
            }
            else
            {
                // There is no responsibility for userID to choreID
                throw new Exception("There is no responsibility for user " + User.UserName + " to chore " + Chore.ChoreName);
            }
        }

        public void RemoveResponsibility(int UserID, int ChoreID)
        {
            //DataSet.Responsibilities.RemoveResponsibilitiesRow(Responsibility);
            System.Data.DataRow Responsibility = DataSet.Responsibilities.Rows.Find(new object[2] { UserID, ChoreID });
            Responsibility.Delete();
            UpdateAll();
        }

        public void RemoveChore(int ChoreID)
        {
            DataSet.Chores.FindByChoreID(ChoreID).isActive = false;
            ChoresTableAdapter.Update(DataSet.Chores);
        }

        public void RemoveUser(int UserID)
        {
            DataSet.Users.FindByUserID(UserID).isActive = false;
            UsersTableAdapter.Update(DataSet.Users);
        }
    }
}
