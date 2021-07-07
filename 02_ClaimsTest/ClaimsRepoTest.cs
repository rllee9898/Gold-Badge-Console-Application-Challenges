using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsRepoTest
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            Claims newContent = new Claims();
            ClaimsRepo repository = new ClaimsRepo();
            //Act
            bool addResult = repository.AddItemToDirectory(newContent);
            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            Claims testContent = new Claims(1, "Car", "nice car", 854, new DateTime (2018,03,24), new DateTime(2018, 04, 26), false);
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddItemToDirectory(testContent);
            //Act
            Queue<Claims> contents = repo.GetItems();
            bool directoryHasContent = contents.Contains(testContent);
            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        private Claims _content;
        private ClaimsRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _content = new Claims(1, "Car", "nice car", 854, new DateTime(2018, 03, 24), new DateTime(2018, 04, 26), false);
            _repo = new ClaimsRepo();
            _repo.AddItemToDirectory(_content);
        }
    }
}