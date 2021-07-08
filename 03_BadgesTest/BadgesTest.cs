using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_BadgesTest
{
    [TestClass]
    public class BadgesTest
    {
        [TestMethod]
        public void AddBadgeToDirectory_ShouldReturnTrue()
        {
            Badge newBadge = new Badge();
            BadgesRepo repository = new BadgesRepo();

            bool addResult = repository.AddBadgeToDictionary(newBadge);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            List<string> testList = new List<string> { "A5", "A7" };
            Badge newBadge = new Badge(12345, testList);
            BadgesRepo repository = new BadgesRepo();
            repository.AddBadgeToDictionary(newBadge);

            Dictionary<int, List<string>> badges = repository.GetBadges();
            bool dictionaryHasBadge = badges.ContainsKey(newBadge.BadgeID) && badges.ContainsValue(testList);
            Assert.IsTrue(dictionaryHasBadge);
        }

        private Badge _badge;
        private Badge _badge2;
        private BadgesRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepo();
            _badge = new Badge(12345, new List<string> { "A5", "A7" });
            _badge2 = new Badge(12345, new List<string> { "A9"});
            _repo.AddBadgeToDictionary(_badge);
        }

        [TestMethod]
        public void GetByBadgeID_ShouldReturnCorrectDoors()
        {
            string testString1 = "A5";
            string testString2 = "A7";
            List<string> searchResult = _repo.GetDoorsByID(12345);
            bool correctDoors = searchResult.Contains(testString1) && searchResult.Contains(testString2);

            Assert.IsTrue(correctDoors);
        }

        [TestMethod]
        public void AddNewDoorToBadge_ShouldReturnTrue()
        {
            bool addedDoor = _repo.AddDoorToBadge(12345, "A9");

            Assert.IsTrue(addedDoor);
        }

        [TestMethod]
        public void RemoveDoorFromBadge_ShouldReturnTrue()
        {
            bool deletedDoor = _repo.DeleteDoorOnBadge(12345, "A7");

            Assert.IsTrue(deletedDoor);
        }
    }
}
