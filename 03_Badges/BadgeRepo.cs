using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03_Badges
{
    public class BadgeRepo
    {
        private List<Badge> _badgeItemDirectory = new List<Badge>();

        //Badge Create
        public void AddBadgeToLists(Badge badge)
        {
            _badgeItemDirectory.Add(badge);
        }


        //Badge Read
        public List<Badge> GetBadgeItems()
        {
            return _badgeItemDirectory;

        }

        //Badge Update
        public bool UpdateExistingBadge(int badgeId, Badge Newbadge)
        {
            //Find Content
            Badge OldBadge = GetBadgeItemById(badgeId);


            //Update Content
            if (OldBadge != null)  //Check content was returned
            {

                OldBadge.Doors = Newbadge.Doors;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Badge Delete
        public bool RemoveBadgeItemFromLists(int badgeid)
        {
            Badge badgeitem = GetBadgeItemById(badgeid);
            if (badgeitem == null)
            {
                return false;
            }


            int initialCount = _badgeItemDirectory.Count;
            _badgeItemDirectory.Remove(badgeitem);

            if (initialCount > _badgeItemDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Badge Helper (Get Badge by Badge #)
        public Badge GetBadgeItemById(int badgeid)
        {
            //Iterrate through the list
            foreach (Badge badge in _badgeItemDirectory)
            {
                if (badge.BadgeId == badgeid)  //What if there are multiple with same id in list?
                {
                    return badge;
                }
            }

            return null;
        }
    }
}
