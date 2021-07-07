using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsTest
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            Claims newClaim = new Claims();
            ClaimsRepo repository = new ClaimsRepo();

            bool addResult = repository.AddClaimToDirectory(newClaim);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            Claims testClaim = new Claims(1, ClaimType.Car, "Car Accident on 465.", 400.00m, new DateTime(2018,04,25), new DateTime(2018,04,27));

            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToDirectory(testClaim);

            Queue<Claims> claims = repo.GetClaims();
            bool directoryHasClaim = claims.Contains(testClaim);

            Assert.IsTrue(directoryHasClaim);
        }

        private Claims _claim1;
        private Claims _claim2;
        private ClaimsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo(); ;
            _claim1 = new Claims(1, ClaimType.Car, "Car Accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _claim2 = new Claims(2, ClaimType.Home, "House fire in Kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));

            _repo.AddClaimToDirectory(_claim1);
            _repo.AddClaimToDirectory(_claim2);
        }

        [TestMethod]
        public void GetNextClaim_ShouldReturnCorrectClaim()
        {
            Claims seachResult = _repo.GetNextClaim();

            Assert.AreEqual(_claim1, seachResult);
        }

        [TestMethod]
        public void RemoveNext_ShouldReturnTrueWithNextClaim()
        {
            _repo.RemoveExistingClaim();

            Claims nextClaim = _repo.GetNextClaim();
            Assert.AreEqual(_claim2, nextClaim);
        }     
    }
}
