using BadgesChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgeChallengeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgeRepo _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge(1234, new List<string> { "A1, B1"});

            _repo.AddBadgeToList(_badge);
            _repo.AddBadgeToDictionary(_badge);
        }
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Badge badge = new Badge();
            badge.BadgeID = 1;
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToList(badge);
            Badge badgeFromDirectory = repo.GetBadgeByID(1);
            Assert.IsNotNull(badgeFromDirectory);
        }
        [TestMethod]
        public void AddToDictionary_ShouldGetNotZero()
        {
            Badge badge = new Badge();
            badge.BadgeID = 1;
            badge.Doors = new List<string> { "A1", "B1" };
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToDictionary(badge);
            int badgeFromDirectory = repo.GetBadgeByIDDictionary(1);
            Assert.IsNotNull(badgeFromDirectory);
        }
        [TestMethod]
        public void GetDictionary_ShouldNotGetNull()
        {
            Badge badge = new Badge();
            badge.BadgeID = 1;
            badge.Doors = new List<string> { "A1", "B1" };
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToDictionary(badge);
            Assert.IsNotNull(repo.GetBadgeDictionary());
        }
        [TestMethod]
        public void GetList_ShouldNotGetNull()
        {
            Badge badge = new Badge();
            badge.BadgeID = 1;
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToList(badge);
            Assert.IsNotNull(repo.GetBadgeList());
        }
        [TestMethod]
        public void UpdateExistingBadge_ShouldGetTrue()
        {
            Badge newBadge = new Badge(0987, new List<string> {"A1", "C1" });
            bool updateResult = _repo.UpdateExistingBadge(1234, newBadge);
            Assert.IsTrue(updateResult);
        }
    }
}
