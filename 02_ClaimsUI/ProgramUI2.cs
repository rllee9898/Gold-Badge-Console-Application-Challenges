using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    public class ProgramUI
    {
        protected readonly ClaimsRepo _claimsRepo = new ClaimsRepo();

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
                    "Choose a menu item:: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");

                //Reading user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllItems();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        CreateNewItem();
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


        //Add new Items
        private void CreateNewItem()
        {
            Console.Clear();

            //int claim ID
            Console.Write("Enter the claim id: ");
            int claimID = int.Parse(Console.ReadLine());

            //string description
            Console.Write("Enter the claim type: ");
            string claimType = Console.ReadLine();

            //int starRating
            Console.Write("Enter a claim description: ");
            string description = (Console.ReadLine());

            //string Genre
            Console.Write("Amount of Damage: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());

            //MaturityRating
            Console.WriteLine("Date Of Accident: ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date of Claim:");
            DateTime dateofClaim = DateTime.Parse(Console.ReadLine());


            //Console.WriteLine(isValid);

            Claims Item = new Claims(claimID, claimType, description, claimAmount, dateOfIncident, dateofClaim, true);

            //Add to repository
            _claimsRepo.AddItemToDirectory(Item);
        }

        //Display All Items
        private void ShowAllItems()
        {
            Console.Clear();

            //Get Content
            Queue<Claims> listOfItems = _claimsRepo.GetItems();

            //Loop through Contents
            foreach (Claims content in listOfItems)
            {
                //Console Write (Display Content)
                DisplayItems(content);
            }

            //if invald input
            PressKeyToCountinue();
        }


        

         //Update
         private void NextClaim()
        {
            Console.Clear();
            //Original Title
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Claims NextClaim = _claimsRepo.NextItemInQueue();
            Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
            bool Y = true;
            if (Y)
            {
                 _claimsRepo.NextItemInQueue();
            }
            else
            {
                 DisplayMenu();
            }
        }



        //Helper Methods



        private void DisplayItems(Claims content)
        {
            Console.WriteLine($"Claim ID : {content.ClaimID }\n" +
                    $"Claim Type : {content.ClaimType }\n" +
                    $"Description: {content.Description }\n" +
                    $"Amount : {content.ClaimAmount }\n" +
                    $"Date Of Incident : {content.DateOfIncident }\n" +
                    $"Date Of Claim : {content.DateOfClaim  }\n" +
                    $"IsValid  : {content.IsValid  }\n");
        }

        private void PressKeyToCountinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        //Seed Method
        private void SeedContentList()
        {
            Claims Baconator = new Claims(1, "Car", "nice car", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);
            Claims McDouble = new Claims(2, "Home", "nice house", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);
            Claims Whooper = new Claims(3, "Theft", "Oh no", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);

            _claimsRepo.AddItemToDirectory(Baconator);
            _claimsRepo.AddItemToDirectory(McDouble);
            _claimsRepo.AddItemToDirectory(Whooper);
        }
    }
}