using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe
{
    public class MenuRepo
    {
        //FakeDatabase
        protected readonly List<Menu> _ItemDirectory = new List<Menu>();

        //CRUD

        //CREATE
        public bool AddItemToDirectory(Menu newItem)
        {
            int startingCount = _ItemDirectory.Count;
            _ItemDirectory.Add(newItem);
            bool wasAdded = (_ItemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        //READ
        public List<Menu> GetItems()
        {
            return _ItemDirectory;
        }

        public Menu GetItemByName(string mealName)
        {
            //sort through all the items using mealnumber to find a match
            foreach (Menu item in _ItemDirectory)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    //I want to return menu items that match the meals name.
                    return item;
                }
            }
            return null;
        }



        //UPDATE
        public bool UpdateExsitingItem(string originalMealName, Menu newItem)
        {
            Menu oldItem = GetItemByName(originalMealName);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }


        //DELETE
        public bool DeleteExistingItem(Menu existingItem)
        {
            bool deleteResults = _ItemDirectory.Remove(existingItem);
            return deleteResults;
        }
    }
}
