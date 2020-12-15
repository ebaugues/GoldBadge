using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{

    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public string ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }

        public double ClaimAmt { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(string claimId, string claimType, string description, double claimAmt, DateTime dateofIncident, DateTime dateofClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmt = claimAmt;
            DateOfIncident = dateofIncident;
            DateOfClaim = dateofClaim;
            IsValid = isValid;
        }

    }
}
