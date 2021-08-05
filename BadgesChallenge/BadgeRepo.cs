using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesChallenge
{
    public class BadgeRepo
    {
        private List<Badge> _listOfBadges = new List<Badge>();
        private Dictionary<int, List<string>> accessList = new Dictionary<int, List<string>>();
        //C R U D

        //Create
        public void AddBadgeToDictionary(Badge badge)
        {
            accessList.Add(badge.BadgeID, badge.Doors);
        }

        //Create
        public void AddBadgeToList(Badge badge)
        {
            _listOfBadges.Add(badge);
        }

        //Read
        public List<Badge> GetBadgeList()
        {
            return _listOfBadges;
        }

        //Read
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return accessList;
        }
    
        //Update
        public bool UpdateExistingBadge(int originalBadgeID, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByID(originalBadgeID);
            if(oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Doors = newBadge.Doors;
                oldBadge.BadgeName = newBadge.BadgeName;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Badge GetBadgeByID(int badgeID)
        {
            foreach(Badge badge in _listOfBadges)
            {
                if(badge.BadgeID == badgeID)
                {
                    return badge;
                }
            }

            return null;
        }

        public int GetBadgeByIDDictionary(int badgeID)
        {
            Dictionary<int, List<string>> listOfBadges = accessList;

            foreach (KeyValuePair<int, List<string>> kvp in listOfBadges)
            {
                if (accessList.ContainsKey(badgeID))
                {
                    return kvp.Key;
                }
            }
            return 0;
        }
    }
}
