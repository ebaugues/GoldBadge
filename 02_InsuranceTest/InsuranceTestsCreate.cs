using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02_KomodoInsurance;

namespace _02_InsuranceTest
{
    [TestClass]
    public class InsuranceTestsCreate
    {
        [TestMethod]
        public void SetTest()
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
            Claim newclaim2 = newClaimRepo.GetClaimItemById("1");

            string expected = "Accident on I-69";
            string actual = newclaim2.Description;

            Assert.AreEqual(expected, actual);  //Created without issue and added to list            

        }

        

    

    }  
}
