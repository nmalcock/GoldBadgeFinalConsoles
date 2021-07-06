using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CafeTests
{
    [TestClass]
    public class CafeTest
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            Menu newItem = new Menu();
            MenuRepo repository = new MenuRepo();

            bool addResult = repository.AddMenuToDirectory(newItem);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            Menu newItem = new Menu(1, "Cheese Burger", "Quarter Pound Beef Patty with American Cheese on Brioche bun", new Ingredient{ "1/4 lb. beef patty", "Brioche bun", "American Cheese", "Pickle", "Onion" }, 4.99m);

            MenuRepo repository = new MenuRepo();
            repository.AddMenuToDirectory(newItem);

            List<Menu> content = repository.GetMenu();
            bool directoryHasContent = content.Contains(newItem);

            Assert.IsTrue(directoryHasContent);
        }

        private Menu _menuItem;
        private Menu _menuItem2;
        private MenuRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _menuItem = new Menu(1, "Cheese Burger", "Quarter Pound Beef Patty with American Cheese on Brioche bun", new Ingredient { "1/4 lb. beef patty", "Brioche bun", "American Cheese", "Pickle", "Onion" }, 4.99m);
            _menuItem2 = new Menu(2, "French Fries", "Golden Brown Fries", new Ingredient { "Potato", "Salt" }, 0.99m);
            _repo.AddMenuToDirectory(_menuItem);
            _repo.AddMenuToDirectory(_menuItem2);
        }

        [TestMethod]
        public void GetByMealNumber_ShouldReturnCorrectMeal()
        {
            Menu searchResult = _repo.GetMenuByID(1);

            Assert.AreEqual(_menuItem, searchResult);
        }

        [TestMethod]
        public void DeleteExistingMenu_ShouldReturnTrue()
        {
            Menu foundContent = _repo.GetMenuByID(1);

            bool removeResult = _repo.DeleteCurrentMenu(foundContent);

            Assert.IsTrue(removeResult);
        }
    }
}
