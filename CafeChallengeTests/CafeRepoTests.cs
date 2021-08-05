using CafeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace CafeChallengeTests
{
    [TestClass]
    public class CafeRepoTests
    {
        private MenuRepo _repo;
        private Menu _meal;

        [TestMethod]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _meal = new Menu(1, "Hot Dog with Fries", "A hot dog with fries", "Hot dog, bun, fried potatoes", 4.99);
            _repo.AddMealsToList(_meal);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Menu meal = new Menu();
            meal.MealNumber = 1;
            MenuRepo repository = new MenuRepo();

            repository.AddMealsToList(meal);
            Menu mealFromDirectory = repository.GetMealByNumber(1);

            Assert.IsNotNull(mealFromDirectory);
        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            Arrange();
            bool deleteResult = _repo.RemoveMealFromList(_meal.MealNumber);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void CheckList_ShouldGetTrue()
        {
            Arrange();
            List<Menu> allMeals = _repo.GetMealList();
            Assert.IsTrue(allMeals.Contains(_meal));
        }
    }
}
