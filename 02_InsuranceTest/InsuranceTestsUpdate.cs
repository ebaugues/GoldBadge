using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02_KomodoInsurance;

namespace _02_InsuranceTest
{
    [TestClass]
    public class InsuranceTestsUpdate
    {
        [TestMethod]
       
            public void UpdateTest()
            {
                //Set test
                Claim newClaim = new Claim();
                newClaim.ClaimId = "1";
                newClaim.ClaimType = ClaimType.Car;
                newClaim.Description = "Accident on I-69";
                newClaim.DateOfIncident = new DateTime(2020, 1, 18);
                newClaim.DateOfClaim = new DateTime(2020, 1, 30);
                ClaimRepo newClaimRepo = new ClaimRepo();

                //Can you add it ok
                newClaimRepo.AddClaimToLists(newClaim);

                //Update test
                newClaim.Description = "Accident on I-70";
                newClaimRepo.UpdateExistingClaim("1", newClaim);

                //Does description update
                string expected2 = "Accident on I-70";
                string actual2 = newClaim.Description;

                Assert.AreEqual(expected2, actual2);  //Updated without issue 

            
        }
    }
}
