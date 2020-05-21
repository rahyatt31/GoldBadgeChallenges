using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuUI
    {
        private readonly MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Add Meal to the Menu\n" +
                    "2. Delete Meal from the Menu\n" +
                    "3. View Menu\n" +
                    "4. Exit"
                );

                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        AddItemToMenu();
                        break;
                    case "2":
                        RemoveMealFromMenu();
                        break;
                    case "3":
                        ViewMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Have a Great Day!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
                        Console.ReadKey();
                        Console.Clear();
            }
        }

        private void AddItemToMenu()
        {
            Console.Clear();
            
            Console.WriteLine("\nWelcome, when adding a new meal to the menu, we must start with the name!");
            
            Console.WriteLine("\nPlease name your new Meal!");
            string mealName = Console.ReadLine();
            
            Console.WriteLine("Please give a decription for you new Meal!");
            string mealDescription = Console.ReadLine();
            
            Console.WriteLine("Please list the ingredients included in your new Meal!");
            string mealIngredients = Console.ReadLine();
            
            Console.WriteLine("What is the price for your new Meal? (Only a number is necessary)");
            double mealPrice = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Finally, you need to assign a Meal Number to your new Meal! (Only a number is necessary)");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            Menu menu = new Menu(mealName, mealDescription, mealIngredients, mealPrice, mealNumber);

            _repo.AddToMenuList(menu);

            Console.WriteLine("Congratulations, you added a new Meal to your Menu!");
            Console.ReadKey();
        }

        private void ViewMenu()
        {
            Console.Clear();
            List<Menu> menuItemList = _repo.ViewMenuList();

            foreach (Menu order in menuItemList)
            {
                Console.WriteLine($"Name: {order.MealName}\n\nDescription: {order.MealDescription}\n\nIngredients: {order.MealIngredients}\n\nPrice: ${order.MealPrice}\n\nMeal Number: #{order.MealNumber}");
            }
        }

        private bool RemoveMealFromMenu()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Meal you want to remove.");
            string mealName = Console.ReadLine();
            
            foreach (Menu order in _repo.ViewMenuList())
            {
                if (order.MealName == mealName)
                {
                    _repo.RemoveFromMenuList(mealName);
                    Console.WriteLine("Bye Food *Waves in slow motion*");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, there are no meals with that name, maybe you misspelled something");
                    Console.ReadKey();
                    return false;
                }
            }
            Console.ReadKey();
            return false;
        }
    }
}
