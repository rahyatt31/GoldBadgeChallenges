using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class Menu
    {                                                   // Enum is not going to be needed for challenge
        public string MealName { get; set; }            // The name of Meal
        public string MealDescription { get; set; }     // The description of the Meal
        public string MealIngredients { get; set; }     // The ingredients of the Meal
        public double MealPrice { get; set; }           // The price of the Meal, needs to be a double not int
        public int MealNumber { get; set; }             // Assign a number to a Meal, should probably use "dictionary"

        public Menu() {}

        public Menu(string mealName, string mealDescription, string mealIngredients, double mealPrice, int mealNumber)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
            MealNumber = mealNumber;
        }
    }
}
