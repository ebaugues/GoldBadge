using Komodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoNameSpace
{
    public class MenuRepo
    {
        private List<Menu> _menuItemDirectory = new List<Menu>();

        //Menu Create
        public void AddMenuToLists(Menu menu)
        {
            _menuItemDirectory.Add(menu);
        }


        //Menu Read
        public List<Menu> GetMenuItems()
        {
            return _menuItemDirectory;

        }

        //Menu Update
        public bool UpdateExistingMenu(int  menuNumber, Menu NewMenu)
        {
            //Find Content
            Menu OldMenu = GetMenuItemById(menuNumber);


            //Update Content
            if (OldMenu != null)  //Check content was returned
            {
                OldMenu.MealName = NewMenu.MealName; 
                OldMenu.MealPrice = NewMenu.MealPrice;
                OldMenu.Description = NewMenu.Description;
                OldMenu.Ingredents = NewMenu.Ingredents;

                return true;
            }
            else
            {
                return false;
            }
        }


        //Menu Delete
        public bool RemoveMenuItemFromLists(int menuItemid)
        {
            Menu menuItem = GetMenuItemById(menuItemid);
            if (menuItem == null)
            {
                return false;
            }


            int initialCount = _menuItemDirectory.Count;
            _menuItemDirectory.Remove(menuItem);

            if (initialCount > _menuItemDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Menu Helper (Get Menu by Meal #)
        public Menu GetMenuItemById(int mealNumber)
        {
            //Iterrate through the list
            foreach (Menu menu in _menuItemDirectory)
            {
                if (menu.MealNumber == mealNumber)  //What if there are multiple with same title in list?
                {
                    return menu;
                }
            }

            return null;
        }
    }
}
