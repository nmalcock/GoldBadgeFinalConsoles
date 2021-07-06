using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepo
    {
        // Psuedo Database of Menu at KCafe
        protected readonly List<Menu> _menuDirectory = new List<Menu>();


        //Create
        public bool AddMenuToDirectory(Menu newMenu)
        {
            int startingCount = _menuDirectory.Count();
            bool uniqueID = IsMenuIDUnique(newMenu);

            if (uniqueID == true)
            {
                _menuDirectory.Add(newMenu);
            }
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool IsMenuIDUnique(Menu newMenu)
        {
            int checkID = newMenu.MealNumber;

            foreach (Menu menu in _menuDirectory)
            {
                if (menu.MealNumber == checkID)
                {
                    return false;
                }
            }
            return true;
        }

        //Read
        public List<Menu> GetMenu()
        {
            return _menuDirectory;
        }

        public Menu GetMenuByID(int idNumber)
        {
            foreach(Menu menuItem in _menuDirectory)
            {
                if (menuItem.MealNumber == idNumber)
                {
                    return menuItem;
                }
            }
            return null; 
        }

        //Update - Dont Need to Update Menu Items Now

        //Delete
        public bool DeleteCurrentMenu(Menu existingMenu)
        {
            bool deleteResult = _menuDirectory.Remove(existingMenu);
            return deleteResult;
        }

    }
}
