using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoreApplication
{
    class UserProfile
    {

        //Might not need all of these variables.  Might be other ones we do need.
        private string username;
        private string firstName;
        private string lastName;
        private int totalPoints;

        public UserProfile(string username, string firstName, string lastName)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            totalPoints = 0;
        }

        #region getters and setters

        public string GetUserName()
        {
            return username;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SettLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public int GetTotalPoints()
        {
            return totalPoints;
        }

        public void SetTotalPoints(int totalPoints)
        {
            this.totalPoints = totalPoints;
        }

        #endregion

        public void AddPoints(int points)
        {
            int current = GetTotalPoints();
            int final = current + points;
            SetTotalPoints(final);
        }
    }
}
