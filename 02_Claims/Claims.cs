using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public enum ClaimType
    {
        Car = 1, Home, Theft
    }

    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                TimeSpan diff = DateOfClaim - DateOfIncident;
                if (diff.Days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Empty Constructor
        public Claims() { }

        // Full Constructor
        public Claims(int claimID, ClaimType claimType, string desc, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            Description = desc;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
