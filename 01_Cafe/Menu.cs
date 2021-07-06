using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class Menu
    {
        //Properties
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        //Empty Constructor
        public Menu() { }

        //Full Constructor
        public Menu (int mealNumber, string name, string desc, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = name;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }

    }
}
