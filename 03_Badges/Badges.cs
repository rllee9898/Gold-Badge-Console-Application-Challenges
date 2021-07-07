using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badges
    {
        //POCOs *Plain old C# object
        //Properties       
        public int BadgeID { get; set; }
        public List<string> ListOfDoorNamesForAccess { get; set; } = new List<string>();

        //Constructors

        //Empty Construtor
        public Badges() { }

        //Full Constructor
        public Badges(int badgeID, List<string> listOfDoorNamesForAccess)
        {
            BadgeID = badgeID;
            ListOfDoorNamesForAccess = listOfDoorNamesForAccess;
            
        }
    }
}