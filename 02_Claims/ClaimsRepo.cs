using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimsRepo
    {
        protected readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();

        //Create 
        public bool AddClaimToDirectory(Claims newClaim)
        {
            int startingCount = _claimsDirectory.Count();
            _claimsDirectory.Enqueue(newClaim);
            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public Queue<Claims> GetClaims()
        {
            return _claimsDirectory;
        }

        public Claims GetNextClaim()
        {
            return _claimsDirectory.Peek();
        }

        //Delete
        public Claims RemoveExistingClaim()
        {
            return _claimsDirectory.Dequeue();  
        }
    }
}
