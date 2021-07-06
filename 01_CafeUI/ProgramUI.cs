using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    class ProgramUI
    {
        protected readonly MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine(
                    "Enter the number of the option that you would like to select: \n" +
                    "1. Show the Full Menu \n" +
                    "2. Add new meal to Menu \n" +
                    "3. Delete meal from Menu \n" +
                    "4. Exit \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllMeals();
                        break;
                    case "2":
                        AddMeal();
                        break;
                    case "3":
                        DeleteMeal();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4!");
                        break;
                }
            }
        }

        //Show All Meals
        private void ShowAllMeals()
        {
            Console.Clear();

            List<Menu> listOfMeals = _menuRepo.GetMenu();

            foreach (Menu meal in listOfMeals)
            {
                DisplayMeal(meal);
            }
            displayHelper();
        }

        //Add Meal
        private void AddMeal()
        {
            Console.Clear();
            Console.Write("Please enter the Meal Number: (Must be a new meal number) ");
            int mealNum = int.Parse(Console.ReadLine());

            Console.Write("Please enter the Meal Name: ");
            string name = Console.ReadLine();

            Console.Write("Please enter the Meal Description: ");
            string desc = Console.ReadLine();

            bool addIngredient = true;
            List<string> listOfIngredients = new List<string>();

            Console.WriteLine("\nPlease enter an Ingredient or 1 if done adding Ingredients");

            while (addIngredient == true)
            {
                Console.Write("Please enter an Ingredient in the meal: ");
                string ingredient = Console.ReadLine();
                if (ingredient == "1")
                {
                    addIngredient = false;
                }
                else
                {
                    listOfIngredients.Add(ingredient);
                }
            }

            Console.Write("Please enter a decimal for the price of the meal: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Menu newItem = new Menu(mealNum, name, desc, listOfIngredients, price);

            _menuRepo.AddMenuToDirectory(newItem);
            Console.WriteLine("\nPlease check to see if your meal was added. If not check to see if you used a unique meal number.");
            displayHelper();
        }

        //Delete a Meal with the Meal Number
        private void DeleteMeal()
        {
            Console.Clear();

            Console.WriteLine("What meal name would you like to delete?");

            int count = 0;

            List<Menu> menuList = _menuRepo.GetMenu();
            foreach(Menu meal in menuList)
            {
                count++;
                Console.WriteLine($"{count}. {meal.MealName}");
            }
            Console.WriteLine("Select the number of the meal that you want to delete.");

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex <= menuList.Count())
            {
                //Delete the Content
                //Selecting Objects to be deleted
                Menu targetContent = menuList[targetIndex];

                //Chcek if deleted
                if (_menuRepo.DeleteCurrentMenu(targetContent))
                {
                    Console.WriteLine($" {targetContent.MealName} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            displayHelper();
        }


        //Helper Functions

        //Displays Meal Object
        private void DisplayMeal(Menu meal)
        {
            Console.WriteLine("Meal Number: " + meal.MealNumber + "\n" +
                "Meal Name: " + meal.MealName + "\n" +
                "Description: " + meal.Description + "\n" +
                "Price: " + meal.Price.ToString() + "\n" +
                "Ingredients: ");
            foreach (string ingredient in meal.Ingredients)
            {
                Console.WriteLine("   " + ingredient);
            }
            Console.WriteLine("\n");
        }

        // Helps display Readkey
        private void displayHelper()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Seed Menu List
        private void SeedMenuList()
        {
            Menu cheeseburger = new Menu(1, "Cheeseburger w/ Fries", "QuarterPounder with Golden Fries on the Side", new List<string>{ "Beef Patty", "Brioche Bun", "Ketchup", "Mustard", "Onion", "Pickle", "French Fries" }, 7.99m);
            Menu nuggets = new Menu(2, "Chicken Nuggets w/ Fries", "10 Chicken Nuggets with Golden Fries on the Side and BBQ Sauce", new List<string> { "Chicken Nuggets", "French Fries", "BBQ Sauce" }, 6.99m);

            _menuRepo.AddMenuToDirectory(cheeseburger);
            _menuRepo.AddMenuToDirectory(nuggets);
        }
    }
}
