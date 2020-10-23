using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoreApplication
{
    class CreateChore
    {
        private string choreName;
        private string choreDesc;
        private int choreValue;
        private int choreID;


        public CreateChore(string choreName, string choreDesc, int choreValue)
        {
            this.choreName = choreName;
            this.choreDesc = choreDesc;
            choreValue = 0;
        }
        #region getters and setters
        //Get Values
        public string GetUserName()
        {
            return choreName;
        }
        public string GetChoreName()
        {
            return choreName;
        }
        public string GetChoreDesc()
        {
            return choreDesc;
        }
        public int GetChoreValue()
        {
            return choreValue;
        }
        public int GetChoreID()
        {
            return choreID;
        }
        //Set Values
        public void SetChoreName(string choreName)
        {
            this.choreName = choreName;
        }
        public void SetChoreDesc(string choreDesc)
        {
            this.choreDesc = choreDesc;
        }
        public void SetChoreValue(int choreValue)
        {
            this.choreValue = choreValue;
        }
        
        #endregion
        public void EditValue(int adjusted)
        {
            SetChoreValue(adjusted);
        }
    }
}
