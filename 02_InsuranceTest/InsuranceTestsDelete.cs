using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02_KomodoInsurance;

namespace _02_InsuranceTest
{
    [TestClass]
    public class InsuranceTestsDelete
    {
        [TestMethod]
        
            public void DeleteTest()
            {

                Claim newClaim = new Claim();
                newClaim.ClaimId = "1";
                newClaim.ClaimType = ClaimType.Car;
                newClaim.Description = "Accident on I-69";
                newClaim.DateOfIncident = new DateTime(2020, 1, 18);
                newClaim.DateOfClaim = new DateTime(2020, 1, 30);
                ClaimRepo newClaimRepo = new ClaimRepo();

                //Add
                newClaimRepo.AddClaimToLists(newClaim);


                //Does it remove ok
                newClaimRepo.RemoveClaimItemFromLists("1");
                Claim newClaim3 = newClaimRepo.GetClaimItemById("1");
                Assert.IsNull(newClaim3);

            
        }
    }
}
