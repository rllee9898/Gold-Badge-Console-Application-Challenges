using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe
{
    public class Menu
        //POCOs *Plain old C# object
    {
        static void Main(string[] args)
        {
        }
        //Properties
        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }


        //Constructors
        
        //Empty Construtor
        public Menu() { }
        
        //Full Constructor
        public Menu(string mealName, int mealNumber, string mealDescription, string ingredients, int price)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;

        }


    }
}