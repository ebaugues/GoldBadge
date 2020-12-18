using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo;

namespace _01_MenuUI
{
    class ProgramUI
    {
        //private StreamingContentRepository _contentRepo = new StreamingContentRepository();
        private MenuRepo _menuItemDirectory = new MenuRepo();

        //Method that runs/starts the appliaction
        public void Run()
        {
            seedContentList();
            Menu();
        }

        //Menu method for menu
        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {

                //Display the options
                Console.WriteLine("Select a menu option:\n" +
                    "1 - Add New Menu Item\n" +
                    "2 - View All Menu Items\n" +
                    "3 - View Menu Item by Number\n" +
                    "4 - Update Existing Menu Item\n" +
                    "5 - Delete Existing Menu Item\n" +
                    "6 - Exit");

                // Get users input
                string input = Console.ReadLine();


                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new menu item
                        CreateNewMenuItem();
                        break;

                    case "2":
                        //View all Meu items
                        DisplayAllMenuItems();
                        break;

                    case "3":
                        //View Menu Item by ID
                        DisplayMenuItemById();
                        break;

                    case "4":
                        //Update Existing developer
                        UpdateMenuItem();
                        break;

                    case "5":
                        //Delete Existing developer
                        DeleteExistingMenuIdem();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;


                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }



        }


        //Creating new Menu Item
        private void CreateNewMenuItem()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            //Menu Item Id
            Console.WriteLine("Enter a unique Number for the new Menu Item:");
            string mealNum = Console.ReadLine();
            newMenu.MealNumber = Convert.ToInt16(mealNum);

            //Menu Item Name
            Console.WriteLine("Enter the name for the new Menu Item:");
            newMenu.MealName = Console.ReadLine();

            //Menu Item Description
            Console.WriteLine("Enter the description for the new Menu Item:");
            newMenu.Description = Console.ReadLine();

            //Menu Item Ingredients
            Console.WriteLine("Enter the Ingredients for the new Menu Item");
            List<string> ingredients = new List<string>();

            //loop until user hits exit
            bool keepRunning2 = true;
            while (keepRunning2)
            {

                //Display the options
                Console.WriteLine("Select a menu option:\n" +
                    "1 - Add New Ingredient\n" +
                    "All other key - No additional ingedients");
                // Get users input
                string input = Console.ReadLine();
                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add new Ingredient
                        Console.WriteLine("Add Ingrident:\n");
                        string ingredient = Console.ReadLine();
                        ingredients.Add(ingredient);
                        break;

                    default:
                        keepRunning2 = false;
                        break;
                }
            }

            if (ingredients.Count > 0)
            {
                newMenu.Ingredents = ingredients;
            }


            //Menu Item Price
            Console.WriteLine("Please insert menu item price:");
            string menupriceinit = Console.ReadLine();
            newMenu.MealPrice = Convert.ToDouble(menupriceinit);


            _menuItemDirectory.AddMenuToLists(newMenu);

        }

        //View All Current Menu Items
        private void DisplayAllMenuItems()
        {
            Console.Clear();

            //show everything on content list
            List<Menu> listofMenuItems = _menuItemDirectory.GetMenuItems();

            foreach (Menu menu in listofMenuItems)
            {
                Console.WriteLine($"Menu ID: {menu.MealNumber}\n" +
                    $"Name: {menu.MealName}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Price: {menu.MealPrice}");

                if (menu.Ingredents != null)
                {
                    int counter = 1;
                    //write out ingredents.
                    foreach (string ingredient in menu.Ingredents)
                    {
                        Console.WriteLine($"Ingredient [{counter}]: {ingredient}");
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine("No ingredient entered.");

                }

            }

        }

        //View menu Item by ID
        private void DisplayMenuItemById()
        {
            Console.Clear();
            //Prompt user to give menu item id
            Console.WriteLine("Enter the id of the menu item you'd like to see:");

            //get the user's input
            string menuItemPre = Console.ReadLine();
            int menuItem = Convert.ToInt32(menuItemPre);

            //Find the developer by id
            Menu menu = _menuItemDirectory.GetMenuItemById(menuItem);


            //Display Menu Item if it isn't null
            if (menu != null)
            {

                Console.WriteLine($"Menu ID: {menu.MealNumber}\n" +
                   $"Name: {menu.MealName}\n" +
                   $"Description: {menu.Description}\n" +
                   $"Price: {menu.MealPrice}");

                if (menu.Ingredents != null)
                {
                    int counter = 1;
                    //write out ingredents.
                    foreach (string ingredient in menu.Ingredents)
                    {
                        Console.WriteLine($"Ingredient [{counter}]: {ingredient}");
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine("No ingredient entered.");

                }


            }
            else
            {
                Console.WriteLine($"Menu Item [{menuItem}] not found.");
            }

        }


        //Update Menu Item Content
        private void UpdateMenuItem()
        {

            //Display all content
            ViewAllMenuItems();

            // Ask for the title to update
            Console.WriteLine("Enter the Menu ID of the menu item you'd like to update:");

            //Get that title
            string menuid_init = Console.ReadLine();
            int menuid = Convert.ToInt32(menuid_init);

            //We will build new object
            Console.Clear();
            Menu newMenu = new Menu();

            //Menu Item Name
            Console.WriteLine("Enter the name for the new Menu Item:");
            newMenu.MealName = Console.ReadLine();

            //Menu Item Description
            Console.WriteLine("Enter the description for the new Menu Item:");
            newMenu.Description = Console.ReadLine();

            //Menu Item Ingredients
            Console.WriteLine("Enter the Ingredients for the new Menu Item");
            List<string> ingredients = new List<string>();

            //loop until user hits exit
            bool keepRunning2 = true;
            while (keepRunning2)
            {

                //Display the options
                Console.WriteLine("Select a menu option:\n" +
                    "1 - Add New Ingredient\n" +
                    "All other key - No additional ingedients");
                // Get users input
                string input = Console.ReadLine();
                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add new Ingredient
                        Console.WriteLine("Add Ingrident:\n");
                        string ingredient = Console.ReadLine();
                        ingredients.Add(ingredient);
                        break;

                    default:
                        keepRunning2 = false;
                        break;
                }
            }

            if (ingredients.Count > 0)
            {
                newMenu.Ingredents = ingredients;
            }


            //Menu Item Price
            Console.WriteLine("Please insert menu item price:");
            string menupriceinit = Console.ReadLine();
            newMenu.MealPrice = Convert.ToDouble(menupriceinit);

            bool wasUpdated = _menuItemDirectory.UpdateExistingMenu(menuid, newMenu);

            if (wasUpdated)
            {
                Console.WriteLine("Meal Item was updated successfully.");
            }
            else
            {
                Console.WriteLine("Could not update Meal Item.");
            }
        }

        //Delete Existing Employee
        private void DeleteExistingMenuIdem()
        {
            Console.Clear();
            ViewAllMenuItems();

            //Get the title they want to remove
            Console.WriteLine("\nEnter the menu item # you'd like to remove:");
            string input_init = Console.ReadLine();
            int input = Convert.ToInt32(input_init);

            //Call the delete method
            bool wasDeleted = _menuItemDirectory.RemoveMenuItemFromLists(input);

            //If the content was deleted, say so
            //Otherwise state if could not be deleted/found
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");

            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }

        }



        //View All Menu Items 
        private void ViewAllMenuItems()
        {
            Console.Clear();

            //show everything on content list
            List<Menu> listofMenuItems = _menuItemDirectory.GetMenuItems();

            Console.WriteLine("List of Menu Items:\n");
            foreach (Menu menu in listofMenuItems)
            {

                Console.WriteLine($"Menu ID: {menu.MealNumber}\n" +
                  $"Name: {menu.MealName}\n" +
                  $"Description: {menu.Description}\n" +
                  $"Price: {menu.MealPrice}");

                if (menu.Ingredents.Count > 0)
                {
                    int counter = 1;
                    //write out ingredients.
                    foreach (string ingredient in menu.Ingredents)
                    {
                        Console.WriteLine($"Ingredient [{counter}]: {ingredient}");
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine("No ingredient entered.");

                }


            }

        }






        //See method
        private void seedContentList()
        {

            List<string> newIngredients = new List<String> { "Hamburger Meat", "Bacon", "Swiss Cheese", "Lettuce", "Tomato", "Pickle", "Ketchup", "Mayo" };
            Menu hamburger = new Menu(1, "Bacon Cheeseburger", "Hamburger with swiss cheese and bacon.", newIngredients, 10.99);

            List<string> newIngredients2 = new List<String> { "Chicken", "Gravy", "Onions", "Carrots", "Chives" };
            Menu potpie = new Menu(2, "Chicken Pot Pie", "Classic chicken pot pie.", newIngredients2, 8.99);

            List<string> newIngredients3 = new List<String> { "Breaded Tenderlion", "Lettuce", "Tomato", "Pickle", "Onion", "Mayo" };
            Menu tenderlion = new Menu(3, "Breaded Tenderlion", "Breaded Tenderlion with trimmings.", newIngredients3, 10.99);

            _menuItemDirectory.AddMenuToLists(hamburger);
            _menuItemDirectory.AddMenuToLists(potpie);
            _menuItemDirectory.AddMenuToLists(tenderlion);

        }


    }
}