using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeChallenge
{
    class ProgramUI
    {
        private MenuRepo _mealRepo = new MenuRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select an option:\n" +
                    "1. Create a new Meal\n" +
                    "2. View all Meals\n" +
                    "3. View all Meals by Number\n" +
                    "4. Delete exisiting Meal\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Create new meal
                        CreateNewMeal();
                        break;
                    case "2":
                        //View all meals
                        DisplayAllMeals();
                        break;
                    case "3":
                        //View all meals by number
                        DisplayMealsByNumber();
                        break;
                    case "4":
                        //Delete a meal
                        DeleteAMeal();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Have a good day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a valid choice!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewMeal()
        {
            Console.Clear();
            Menu newMeal = new Menu();

            Console.WriteLine("Enter the number for the meal:");
            string numberAsString = Console.ReadLine();
            newMeal.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the name of the meal:");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description of the meal:");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the meal:");
            newMeal.MealIngredients = Console.ReadLine();

            Console.WriteLine("Enter the price of the meal:");
            string priceAsString = Console.ReadLine();
            newMeal.MealPrice = double.Parse(priceAsString);

            _mealRepo.AddMealsToList(newMeal);
        }

        private void DisplayAllMeals()
        {
            Console.Clear();
            List<Menu> listOfMenu = _mealRepo.GetMealList();
            foreach(Menu meal in listOfMenu)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n");
            }
        }

        private void DisplayMealsByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you wish to see:");
            string numberAsString = Console.ReadLine();
            int mealNumber = int.Parse(numberAsString);
            Menu meal = _mealRepo.GetMealByNumber(mealNumber);

            if(meal != null)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Meal Description: {meal.MealDescription}\n" +
                    $"Meal Ingredients: {meal.MealIngredients}\n" +
                    $"Meal Price: ${meal.MealPrice}");
            }
            else
            {
                Console.WriteLine("No meal by that number!");
            }
        }

        private void DeleteAMeal()
        {
            DisplayAllMeals();
            Console.WriteLine("Enter the number of the meal you wish to remove:");
            string numAsString = Console.ReadLine();
            int mealNumber = int.Parse(numAsString);
            bool wasDeleted = _mealRepo.RemoveMealFromList(mealNumber);
            if (wasDeleted)
            {
                Console.WriteLine("The meal was removed successfully!");
            }
            else
            {
                Console.WriteLine("The meal could not be removed!");
            }
        }
    }
}
