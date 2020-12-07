using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }

        public List<string> Ingredents { get; set; }

        public double MealPrice { get; set; }


        public Menu() { }

        public Menu(int mealNumber, string mealName, string description, List<string> ingredents, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredents = ingredents;
            MealPrice = mealPrice;
        }

    }
}
