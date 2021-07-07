using _01_KCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_KCafeTests
{
    [TestClass]
    public class CafeTest
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            Menu newItem = new Menu();
            MenuRepo repository = new MenuRepo();
            //Act
            bool addResult = repository.AddItemToDirectory(newItem);
            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            Menu testItem = new Menu("Baconator", 1, "yummy", "IDK",7);
            MenuRepo repo = new MenuRepo();
            repo.AddItemToDirectory(testItem);
            //Act
            List<Menu> Items = repo.GetItems();
            bool directoryHasItem = Items.Contains(testItem);
            //Assert
            Assert.IsTrue(directoryHasItem);
        }

        private Menu _Item;
        private MenuRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _Item = new Menu("Baconator", 1, "yummy", "IDK", 7);
            _repo = new MenuRepo();
            _repo.AddItemToDirectory(_Item);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            //Handled in Test Initialize
            //Act
            Menu searchResult = _repo.GetItemByName("Baconator");
            //Assert
            Assert.AreEqual(_Item, searchResult);

        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange 
            Menu updatedInfo = new Menu("Baconator", 1, "yummy", "IDK", 7);
            //Act
            bool updateResult = _repo.UpdateExsitingItem("Baconator", updatedInfo);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange!
            Menu foundItem = _repo.GetItemByName("Mr.Right");
            //Act!
            bool removeResult = _repo.DeleteExistingItem(foundItem);
            //Assert!
            Assert.IsTrue(removeResult);
        }
    }
}