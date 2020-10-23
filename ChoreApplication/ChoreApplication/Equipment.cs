using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoreApplication
{
    public class Equipment
    {
        private string name;
        private int strengthModifier;

        public int StrengthModifier
        {
            get { return strengthModifier; }
            set { strengthModifier = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
