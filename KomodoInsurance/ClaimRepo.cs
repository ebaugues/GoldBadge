using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ClaimRepo
    {
        private List<Claim> _claimItemDirectory = new List<Claim>();

        //Claim Create
        public void AddClaimToLists(Claim claim)
        {
            _claimItemDirectory.Add(claim);
        }


        //Claim Read
        public List<Claim> GetClaimItems()
        {
            return _claimItemDirectory;

        }

        //Claim Update
        public bool UpdateExistingClaim(string claimId, Claim NewClaim)
        {
            //Find Content
            Claim OldClaim = GetClaimItemById(claimId);


            //Update Content
            if (OldClaim != null)  //Check content was returned
            {

                OldClaim.ClaimType = NewClaim.ClaimType;
                OldClaim.Description = NewClaim.Description;
                OldClaim.ClaimAmt = NewClaim.ClaimAmt;
                OldClaim.ClaimType = NewClaim.ClaimType;
                OldClaim.DateOfClaim = NewClaim.DateOfClaim;
                OldClaim.DateOfIncident = NewClaim.DateOfIncident;
                OldClaim.IsValid = NewClaim.IsValid;



                return true;
            }
            else
            {
                return false;
            }
        }


        //Claim Delete
        public bool RemoveClaimItemFromLists(string claimid)
        {
            Claim claimItem = GetClaimItemById(claimid);
            if (claimItem == null)
            {
                return false;
            }


            int initialCount = _claimItemDirectory.Count;
            _claimItemDirectory.Remove(claimItem);

            if (initialCount > _claimItemDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Claim Helper (Get Claim by Claim #)
        public Claim GetClaimItemById(string claimid)
        {
            //Iterrate through the list
            foreach (Claim claim in _claimItemDirectory)
            {
                if (claim.ClaimId == claimid)  //What if there are multiple with same id in list?
                {
                    return claim;
                }
            }

            return null;
        }
    }
}

