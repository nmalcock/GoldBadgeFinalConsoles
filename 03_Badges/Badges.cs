using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        //Properties
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }

        //Empty Constructor
        public Badge() { }

        //Full Constructor
        public Badge(int badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }
    }
}
