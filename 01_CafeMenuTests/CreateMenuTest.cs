﻿using _01_CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_CafeMenuTests
{
    [TestClass]
    public class CreateMenuTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            List<string> newIngredients = new List<String> { "Hamburger Meat", "Bacon", "Swiss Cheese", "Lettuce", "Tomato", "Pickle", "Ketchup", "Mayo" };
            Menu hamburger = new Menu(1, "Bacon Cheeseburger", "Hamburger with swiss cheese and bacon.", newIngredients, 10.99);

            MenuRepo newMenuRepo = new MenuRepo();

            newMenuRepo.AddMenuToLists(hamburger);


            Menu newMenu2 = newMenuRepo.GetMenuItemById(1);

            Assert.IsNotNull(newMenu2);  //Should pass if created and added by repo
        }
    }
}
