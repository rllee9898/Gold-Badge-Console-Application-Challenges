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

        //Add New Badge
        private void CreateNewItem()
        {
            Console.Clear();

            //int claim number
            Console.Write("What is the number on the badge:  ");
            int badgeID = int.Parse(Console.ReadLine());

            //string door
            Console.Write("List a door that it needs access to:  ");
            string listOfDoorNamesForAccess = Console.ReadLine();

            //ask for additional doors
            Console.Write("Any other doors(y/n)? ");
            char userInput;
            bool parseResult = char.TryParse(Console.ReadLine(), out userInput);
            while (userInput == 'Y' || userInput == 'y')
            {
           //     Console.Write("List a door that it needs access to:  ");
           // string ListOfDoorNamesForAccess = Console.ReadLine();
           //  }
                else
                {
                    DisplayMenu();
                }

                Badges Item = new Badges(badgeID, listOfDoorNamesForAccess);

                //Add to repository
                _badgesRepo.AddItemToDirectory(Item);
            }
        }



        //Display All Items
        void ShowAllItems()
        {
            Console.Clear();

            //Get Content
            Dictionary<BadgeID, ListOfDoorNamesForAccess> listOfItems = _badgesRepo.GetItems();

            //Loop through Contents
            Console.WriteLine("{0,15} {1,15}", "Key Badge #", "Door Access");
            foreach (Badges content in listOfItems)
            {
                //Console Write (Display Content)
                DisplayItemsTwo(content);
            }

            //if invald input
            PressKeyToCountinue();
        }

        //Update
        void UpdateBadge()
        {
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
                    DisplayDoors(Item);
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
                        DisplayDoors(Item);
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
                        DisplayDoors(Item);
                    }
                    else
                    {
                        Console.WriteLine("Failed to find door");
                    }
                    PressKeyToCountinue();
                }
                else
                {
                    Console.WriteLine("Failed to find title");
                }
                PressKeyToCountinue();




                Badges updatedItem = new Badges();

                Console.Write("What is the new meal number?");
                updatedItem.BadgeID = int.Parse(Console.ReadLine());

                Console.Write("What is the new name?");
                updatedItem.ListOfDoorNamesForAccess = Console.ReadLine();


                _badgesRepo.UpdateExsitingItem(userInput, updatedItem);
                //Does this update
                //Did they gove me a title
                //Feedback message iser
                PressKeyToCountinue();


            }
        }

        //Helper Methods

        private void DisplayItems(Badges content)
        {
            Console.WriteLine($"Claim ID : {content.ClaimID }\n" +
                    $"Claim Type : {content.ClaimType }\n" +
                    $"Description: {content.Description }\n" +
                    $"Amount : {content.ClaimAmount }\n" +
                    $"Date Of Incident : {content.DateOfIncident }\n" +
                    $"Date Of Claim : {content.DateOfClaim  }\n" +
                    $"IsValid  : {content.IsValid  }\n");
        }

        private void DisplayItemsTwo(Badges badges)
        {
            Console.WriteLine("{0,15} {1,15}", badges.BadgeID, badges.ListOfDoorNamesForAccess);
        }

        private void DisplayDoors(List<string> Doors)
        {
            foreach (string door in Doors)
            {
                Console.WriteLine(door);
            }
        }

        private void PressKeyToCountinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        //Seed Method
        private void SeedContentList()
        {
            Badges Baconator = new Badges(1, "Car", "nice car", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);
            Badges McDouble = new Badges(2, "Home", "nice house", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);
            Badges Whooper = new Badges(3, "Theft", "Oh no", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);

            _claimsRepo.AddItemToDirectory(Baconator);
            _claimsRepo.AddItemToDirectory(McDouble);
            _claimsRepo.AddItemToDirectory(Whooper);
        }
    }
}
}
}