using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02_KomodoInsurance;

namespace _02_InsuranceTest
{
    [TestClass]
    public class InsuranceTestsGet
    {
        [TestMethod]
      
            public void GetTest()
            {

                //Set test
                Claim newClaim = new Claim();
                newClaim.ClaimId = "1";
                newClaim.ClaimType = ClaimType.Car;
                newClaim.Description = "Accident on I-69";
                newClaim.DateOfIncident = new DateTime(2020, 1, 18);
                newClaim.DateOfClaim = new DateTime(2020, 1, 30);
                ClaimRepo newClaimRepo = new ClaimRepo();


                newClaimRepo.AddClaimToLists(newClaim);

                //Get test
                Claim newClaim4 = newClaimRepo.GetClaimItemById("1");
                Assert.IsNotNull(newClaim4);  //Picked up a claim, pass

            
        }
    }
}
