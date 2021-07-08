using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgesRepo
    {

        //Methods Needed
        //1. Create a dictionary of badges.
        //2. The key for the dictionary will be the BadgeID.
        //3. The value for the dictionary will be the List of Door Names.


        protected readonly Dictionary<int,List<string>> _badgeDirectory = new Dictionary<int,List<string>>();

        //Creates a Dictionary of Badges

        public bool AddBadgeToDictionary(Badge newBadge)
        {
            int startingCount = _badgeDirectory.Count();
            _badgeDirectory.Add(newBadge.BadgeID, newBadge.Doors);
            bool wasAdded = (_badgeDirectory.Count() > startingCount) ? true : false;
            return wasAdded;
        }

        //Read Directory Of Badges
        public Dictionary<int,List<string>> GetBadges()
        {
            return _badgeDirectory;
        }

        //Get Doors by BadgeID 
        public List<string> GetDoorsByID(int badgeID)
        {
            foreach (KeyValuePair <int, List<string>> badge in _badgeDirectory)
            {
                if (badgeID == badge.Key)
                {
                    return badge.Value;
                }
            }
            return null;
        }


        //Update New Doors 
        public bool AddDoorToBadge(int badgeID, string newDoor)
        {
            List<string> doors = GetDoorsByID(badgeID);
            int startingCount = doors.Count();
            doors.Add(newDoor);
            bool wasAdded = (doors.Count() > startingCount) ? true : false;
            return wasAdded;
        }


        //Delete Doors off Badge
        public bool DeleteDoorOnBadge(int badgeID, string doorToRemove)
        {
            List<string> doors = GetDoorsByID(badgeID);
            foreach (string door in doors)
            {
                if(doorToRemove == door)
                {
                    doors.Remove(door);
                    return true;
                }
            }
            return false;
        }
    }
}
