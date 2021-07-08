using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesUI
{
    public class ProgramUI
    {
        private readonly BadgesRepo _badgesRepo = new BadgesRepo();

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
                    "Hello Security Admin, What would you like to do?: \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all Badges\n" +
                    "4. Exit\n");

                //Reading user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewItem();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowAllItems();
                        break;
                    case "4":
                        // Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "PressKeyToCountinue();");
                        Console.ReadKey();
                        break;
                }
            }
        }

        
        private void CreateNewItem()
        {
            Console.Clear();

            //int claim number
            Console.Write("What is the number on the badge:  ");
            int badgeID = int.Parse(Console.ReadLine());
            List<string> DoorList = new List<string>();
            //string door
            Console.Write("List a door that it needs access to:  ");
            string listOfDoorNamesForAccess = Console.ReadLine();
            DoorList.Add(listOfDoorNamesForAccess);
            //ask for additional doors
            bool KeepRuning = true;
            while (KeepRuning)
            {
                Console.Write("Any other doors(y/n)? ");
                string userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    Console.Write("List a door that it needs access to: ");
                    string NeededDoor = Console.ReadLine();
                    DoorList.Add(NeededDoor);
                }
                if (userInput == "N" || userInput == "n")
                {
                    KeepRuning = false;
                }
            }

            //Add to repository
            _badgesRepo.AddItemToDirectory(badgeID, DoorList);
        }

        
        private void ShowAllItems()
        {
            Console.Clear();

            //Get Content
            Dictionary<int, List<string>> listOfItems = _badgesRepo.GetItems();

            //Loop through Contents
            Console.WriteLine("{0,15} {1,15}", "Key Badge #", "Door Access");
            {
                foreach (KeyValuePair<int, List<string>> content in listOfItems)
                {
                    //Console Write (Display Content)
                    DisplayDoors(content.Key, content.Value);
                }
                PressKeyToCountinue();
            }
        }

        private void UpdateBadge()
        {
            Console.Clear();
            //Original Title
            //Ask the user what to update
            Console.WriteLine("What is the badge number to update?");
            //Getting user input
            int badgeID = int.Parse(Console.ReadLine());
            //Get Content
            List<string> Item = _badgesRepo.GetDoorNameByBadgeId(badgeID);

            //If we have it
            if (Item != null)
            {
                //Display content
                DisplayDoors(badgeID, Item);
            }
            else
            {
                Console.WriteLine("Failed to find title");
            }
            Console.WriteLine(
                "What would you like to do? \n" +
                "1. Remove door \n" +
                "2. Add a door \n");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine("Which door would you like to remove?");
                string DoorToRemove = Console.ReadLine();
                if (DoorToRemove != null)
                {
                    _badgesRepo.RemoveDoor(badgeID, DoorToRemove);
                    Console.WriteLine("Door removed.");
                    DisplayDoors(badgeID, Item);
                }
                else
                {
                    Console.WriteLine("Failed to find door");
                }
                PressKeyToCountinue();
            }
            if (userInput == "2")
            {
                Console.WriteLine("Which door would you like to Add?");
                string DoorToAdd = Console.ReadLine();
                if (DoorToAdd != null)
                {
                    _badgesRepo.AddDoor(badgeID, DoorToAdd);
                    Console.WriteLine("Door added.");
                    DisplayDoors(badgeID, Item);
                }
                else
                {
                    Console.WriteLine("Failed to find door");
                }
                PressKeyToCountinue();
            }
        }

        private void DisplayItemsTwo(Badges badges)
        {
            Console.WriteLine("{0,15} {1,15}", badges.BadgeID, badges.ListOfDoorNamesForAccess);
        }

        private void DisplayDoors(int badgeNumber, List<string> Doors)
        {
            string doorsList = string.Join(" ", Doors);
            //foreach (string door in Doors)
            //{
            //   Console.WriteLine(door);
            // }
            Console.WriteLine(badgeNumber + " has access to: " + doorsList);
        }

        private void PressKeyToCountinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        //Seed Method
        private void SeedContentList()
        {
            Badges Micheal = new Badges(12345, new List<string>() { "A7" });
            Badges Jen = new Badges(22345, new List<string>() { "A1", "A4", "B1", "B2" });
            Badges Thomas = new Badges(32345, new List<string>() { "A4", "A5" });


            _badgesRepo.AddItemToDirectory(Micheal.BadgeID, Micheal.ListOfDoorNamesForAccess);
            _badgesRepo.AddItemToDirectory(Jen.BadgeID, Jen.ListOfDoorNamesForAccess);
            _badgesRepo.AddItemToDirectory(Thomas.BadgeID, Thomas.ListOfDoorNamesForAccess);
        }
    }
}