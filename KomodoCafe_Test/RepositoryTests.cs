using System;
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Test
{
    [TestClass]
    public class RepositoryTests
    {
        private MenuRepository _repo = new MenuRepository();            // We are testing repository, so don't put "Menu" put "MenuRepository

        [TestMethod]
        public void AddToMenuListTest()
        {
            Menu burger = new Menu("Burger", "flat meat", "cow guts", 5.50, 1);
            Menu pizza = new Menu("Pizza", "melted cheese on bread", "cheese, sauce, bread", 8.50, 2);

            _repo.AddToMenuList(burger);
            _repo.AddToMenuList(pizza);

            int expected = 2;
            int actual = _repo.ViewMenuList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ViewMenuTest()
        {
            Menu burger = new Menu("Burger", "flat meat", "cow guts", 5.50, 1);
            _repo.AddToMenuList(burger);

            Menu viewMenu = _repo.ViewMenuListByMealName("Burger");

            Assert.AreEqual(burger, viewMenu);
        }

        [TestMethod]
        public void RemoveFromMenuListTest()
        {
            Menu burger = new Menu("Burger", "flat meat", "cow guts", 5.50, 1);
            Menu pizza = new Menu("Pizza", "melted cheese on bread", "cheese, sauce, bread", 8.50, 2);
            _repo.AddToMenuList(burger);
            _repo.AddToMenuList(pizza);

            _repo.RemoveFromMenuList("Burger");
            int expected = 1;
            int actual = _repo.ViewMenuList().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
