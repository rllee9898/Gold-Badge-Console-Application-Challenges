using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimsRepo
    {
        //FakeDatabase
        protected readonly Queue<Claims> _ItemDirectory = new Queue<Claims>();

        //CRUD

        //CREATE
        public bool AddItemToDirectory(Claims newItem)
        {
            int startingCount = _ItemDirectory.Count;
            _ItemDirectory.Enqueue(newItem);
            bool wasAdded = (_ItemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        //READ
        public Queue<Claims> GetItems()
        {
            return _ItemDirectory;
        }

        public Claims NextItemInQueue()
        {
            return _ItemDirectory.Peek();
        }

        public Claims GetItemByType(string claimType)
        {
            //get the directory
            //sort through all the items using title to find a match
            foreach (Claims Item in _ItemDirectory)
            {

                if (Item.ClaimType.ToLower() == claimType.ToLower())
                {
                    //I want to return streaming content that matches the title
                    return Item;
                }
            }
            return null;

            //UPDATE
            //public bool UpdateExsitingItem(int originalClaimId, Claims newItem)
            //           {
            // Claims oldItem = NextItemInQueue(originalClaimId);
            // if (oldItem != null)
            //                {
            //                    oldItem.ClaimID = newItem.ClaimID;
            //       oldItem.ClaimType = newItem.ClaimType;
            //                    oldItem.Description = newItem.Description;
            //      oldItem.ClaimAmount = newItem.ClaimAmount;
            //                    oldItem.DateOfIncident = newItem.DateOfIncident;
            //                    return true;
            //    }
            //              else
            //     {
            //                   return false;
            //               }
            //            }
        }

        public void Remove()
        {
             _ItemDirectory.Dequeue();
        }
    }
}