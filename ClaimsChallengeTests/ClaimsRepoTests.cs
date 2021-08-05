using ClaimsChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsChallengeTests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimsRepo _repo;
        private Claims _claim;
        [TestMethod]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claim = new Claims(1, ClaimType.Car, "Rear-ended", 4000, new DateTime(1999, 07, 01), new DateTime(1999, 07, 21), true);
            _repo.AddClaimToList(_claim);
        }

        [TestMethod]
        public void AddToQueue_ShouldNotGetNull()
        {
            Claims claim = new Claims();
            claim.ClaimID = 1;
            ClaimsRepo repository = new ClaimsRepo();

            repository.AddClaimToList(claim);
            Claims claimFromDirectory = repository.GetClaimsByID(1);
            Assert.IsNotNull(claimFromDirectory);
        }

        [TestMethod]
        public void RemoveClaimFromQueue_ShouldReturnTrue()
        {
            Arrange();
            bool deleteResult = _repo.RemoveClaimFromQueue(_claim.ClaimID);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void GetClaimsQueue_ShouldReturnNotNull()
        {
            Arrange();
            Assert.IsNotNull(_repo.GetClaimsQueue());
        }
    }
}
