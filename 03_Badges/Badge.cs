using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {


        public int BadgeId { get; set; }

        public Dictionary<string, int> Doors { get; set; }

        public Badge() { }

        public Badge(int badgeid, Dictionary<string, int> doors)
        {
            BadgeId = badgeid;
            Doors = doors;
        }

    }
}