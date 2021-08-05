using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeChallenge
{
    public class MenuRepo
    {
        private List<Menu> _listOfMenu = new List<Menu>();

        //Create
        public void AddMealsToList(Menu meal)
        {
            _listOfMenu.Add(meal);
        }

        //Read
        public List<Menu> GetMealList()
        {
            return _listOfMenu;
        }

        //Delete
        public bool RemoveMealFromList(int mealNumber)
        {
            Menu meal = GetMealByNumber(mealNumber);

            if(meal == null)
            {
                return false;
            }

            int initialCount = _listOfMenu.Count;
            _listOfMenu.Remove(meal);

            if(initialCount > _listOfMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Menu GetMealByNumber(int mealNumber)
        {
            foreach(Menu meal in _listOfMenu)
            {
                if(meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
