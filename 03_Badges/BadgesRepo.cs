using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgesRepo
    {
        //FakeDatabase
        protected readonly Dictionary<int, List<string>> _ItemDirectory = new Dictionary<int, List<string>>();

        //CRUD

        ////CREATE
        public bool AddItemToDirectory(int BadgeID, List<string> DoorNames)
        {
            int startingCount = _ItemDirectory.Count;
            _ItemDirectory.Add(BadgeID, DoorNames);
            bool wasAdded = (_ItemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Add Door from Dictionary
        public void AddDoor(int badgeID, string DoorToAdd)
        {
            List<string> DoorList = GetDoorNameByBadgeId(badgeID);
            DoorList.Add(DoorToAdd);
        }

        ////READ
        public Dictionary<int, List<string>> GetItems()
        {
            return _ItemDirectory;
        }

        public List<string> GetDoorNameByBadgeId(int badgeID)
        {
            return _ItemDirectory[badgeID];
        }

        //UPDATE

        //// DELETE
        /// </summary>
        /// <param name="badgeID"></param>
        /// <param name="DoorToRemove"></param>
        //public bool DeleteExistingContent(Badges existingContent)
        //{
        //    bool deleteResult = _ItemDirectory.Remove(existingContent);
        //    return deleteResult;
        //}

        //Remove item from Dictionary
        public void RemoveDoor(int badgeID, string DoorToRemove)
        {
            List<string> DoorList = GetDoorNameByBadgeId(badgeID);
            DoorList.Remove(DoorToRemove);
        }

    }
}