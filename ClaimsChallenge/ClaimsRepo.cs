using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsChallenge
{
    public class ClaimsRepo
    {
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();
        
        public void AddClaimToList(Claims claims)
        {
            _queueOfClaims.Enqueue(claims);
        }

        public Queue<Claims> GetClaimsQueue()
        {
            return _queueOfClaims;
        }

        //DO NOT NEED
        //public bool UpdateExisitingClaim(int originalClaimID, Claims newClaim)
        //{
        //    Claims oldClaim = GetClaimsByID(originalClaimID);

        //    if(oldClaim != null)
        //    {
        //        oldClaim.ClaimID = newClaim.ClaimID;
        //        oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
        //        oldClaim.Description = newClaim.Description;
        //        oldClaim.ClaimAmount = newClaim.ClaimAmount;
        //        oldClaim.DateOfIncident = newClaim.DateOfIncident;
        //        oldClaim.DateOfClaim = newClaim.DateOfClaim;
        //        oldClaim.IsValid = newClaim.IsValid;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool RemoveClaimFromQueue(int claimID)
        {
            Claims claim = GetClaimsByID(claimID);
            if(claim == null)
            {
                return false;
            }
            int initialCount = _queueOfClaims.Count;
            _queueOfClaims.Dequeue();
            if(initialCount > _queueOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Claims GetClaimsByID(int claimID)
        {
            foreach(Claims claims in _queueOfClaims)
            {
                if(claims.ClaimID == claimID)
                {
                    return claims;
                }
            }
            return null;
        }
    }
}
