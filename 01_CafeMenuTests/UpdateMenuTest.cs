using _01_CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_CafeMenuTests
{
    [TestClass]
    public class UpdateMenuTest
    {
        [TestMethod]
        public void TestMethod1()
        {


            List<string> newIngredients = new List<String> { "Hamburger Meat", "Bacon", "Swiss Cheese", "Lettuce", "Tomato", "Pickle", "Ketchup", "Mayo" };
            Menu hamburger = new Menu(1, "Bacon Cheeseburger", "Hamburger with swiss cheese and bacon.", newIngredients, 10.99);

            MenuRepo newMenuRepo = new MenuRepo();

            newMenuRepo.AddMenuToLists(hamburger);  //added

            //Add Grey Pupon Mustard
            List<string> newIngredients2 = new List<String> { "Grey Poupon Mustard", "Hamburger Meat", "Bacon", "Swiss Cheese", "Lettuce", "Tomato", "Pickle", "Ketchup", "Mayo" };
            Menu hamburger2 = new Menu(1, "Bacon Cheeseburger", "Hamburger with swiss cheese and bacon.", newIngredients2, 10.99);

            newMenuRepo.UpdateExistingMenu(1, hamburger2);

            Menu hamburger3 = newMenuRepo.GetMenuItemById(1);

            bool actual = hamburger3.Ingredents.Contains("Grey Poupon Mustard");
            bool expected = true;


            Assert.AreEqual(expected, actual);  //Created without issue and added to list  
        }
    }
}
