using _01_KCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafeTest
{
    public class ProgramUI
    {
        protected readonly MenuRepo _menuRepo = new MenuRepo();

        //This is the method that runs our User Interface
        public void Run()
        {
            //Putting in seed data to have some starting data
            SeedContentList();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show all menu items \n" +
                    "2. Find menu items by Name \n" +
                    "3. Add new menu Items\n" +
                    "4. Update menu item \n" +
                    "5. Remove menu Item \n" +
                    "6. Exit\n");

                //Reading user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllItems();
                        break;
                    case "2":
                        GetItemByName();
                        break;
                    case "3":
                        CreateNewItem();
                        break;
                    case "4":
                        UpdateItem();
                        break;
                    case "5":
                        DeleteItem();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 6 \n" +
                            "PressKeyToCountinue();");
                        Console.ReadKey();
                        break;
                } 
            }
        }


        //Add new Items
        private void CreateNewItem()
        {
            Console.Clear();

            //string Name
            Console.Write("Please enter a meal name: ");
            string mealName = Console.ReadLine();

            //int starRating
            Console.Write("Please enter a meal number: ");
            int mealNumber = int.Parse(Console.ReadLine());

            //string description
            Console.Write("Please enter a meal description: ");
            string mealDescrption = Console.ReadLine();

            //string Genre
            Console.Write("Please enter the ingredients: ");
            string ingredients = Console.ReadLine();

            //MaturityRating
            Console.WriteLine("Please enter the price of the item: ");
            int price = int.Parse(Console.ReadLine());

            Menu Item = new Menu(mealName, mealNumber, mealDescrption, ingredients, price);

            //Add to repository
            _menuRepo.AddItemToDirectory(Item);
        }

        //Display All Items
        private void ShowAllItems()
        {
            Console.Clear();

            //Get Content
            List<Menu> listOfItems = _menuRepo.GetItems();

            //Loop through Contents
            foreach (Menu content in listOfItems)
            {
                //Console Write (Display Content)
                DisplayItems(content);
            }

            //if invald input
            PressKeyToCountinue();
        }

        //Display Content By Title
        private void GetItemByName()  //Search Functionality
        {
            //What title do we want
            Console.WriteLine("What Item are you looking for?");
            //Getting user input
            string MealName = Console.ReadLine();

            //Get Content
            Menu content = _menuRepo.GetItemByName(MealName);

            //If we have it
            if (content != null)
            {
                //Display content
                DisplayItems(content);
            }
            else
            {
                Console.WriteLine("Failed to find title");
            }
            PressKeyToCountinue();


            //Display Content

        }

        //Delete Content
        private void DeleteItem()
        {
            Console.Clear();
            //select the content to delete
            //get content by title
            Console.WriteLine("What title would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //display all content
            List<Menu> ItemList = _menuRepo.GetItems();
            foreach (Menu Item in ItemList)
            {
                count++;
                Console.WriteLine($"{count}. {Item.MealName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex < ItemList.Count())
            {
                //delete the content
                //Selecting object to be deleted
                Menu targetItem = ItemList[targetIndex];
                //Check to see of deleted
                if (_menuRepo.DeleteExistingItem(targetItem))
                {
                    //success message
                    Console.WriteLine($"{targetItem.MealName} removed from repo");
                }
                else
                {
                    //Fail message
                    Console.WriteLine("Sorry something went wrong");
                }


            }
            //if invald input
            else
            {
                Console.WriteLine("Invalid selection");
            }
            PressKeyToCountinue();
        }

        //Update
        private void UpdateItem()
        {
            Console.Clear();
            //Original Title
            //Ask the user what to update
            Console.WriteLine("What meal name would you like to update?");
            string userInput = Console.ReadLine();
            //New Content (Updated content)
            Menu updatedItem = new Menu();

            Console.Write("What is the new name?");
            updatedItem.MealName = Console.ReadLine();

            Console.Write("What is the new meal number?" );
            updatedItem.MealNumber = int.Parse(Console.ReadLine());

            Console.Write("What is the new description?");
            updatedItem.MealDescription = Console.ReadLine();

            Console.Write("What are the new ingredients?");
            updatedItem.Ingredients = Console.ReadLine();

            Console.Write("What is the new price?");
            updatedItem.Price = int.Parse(Console.ReadLine());

            _menuRepo.UpdateExsitingItem(userInput, updatedItem);
            //Does this update
            //Did they gove me a title
            //Feedback message iser
            PressKeyToCountinue();


        }



        //Helper Methods



        private void DisplayItems(Menu content)
        {
            Console.WriteLine($"Name: {content.MealName}\n" +
                    $"Meal Number: {content.MealNumber}\n" +
                    $"Description: {content.MealDescription}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Rating: {content.Price}\n");
        }

        private void PressKeyToCountinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        //Seed Method
        private void SeedContentList()
        {
            Menu Baconator = new Menu("Baconator", 2, "Yummy burger", "effef", 12);
            Menu McDouble = new Menu("McDouble", 2, "Yummy burger", "effef", 15);
            Menu Whooper = new Menu("Whooper", 2, "Yummy burger", "effef", 16);

            _menuRepo.AddItemToDirectory(Baconator);
            _menuRepo.AddItemToDirectory(McDouble);
            _menuRepo.AddItemToDirectory(Whooper);
        }
    }
}