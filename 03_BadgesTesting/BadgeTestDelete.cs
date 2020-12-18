using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_BadgesTesting
{
    [TestClass]
    public class BadgeTestDelete
    {
        [TestMethod]
        public void TestDelete()
        {
            //Set test
            var doors = new Dictionary<string, int>()
                {
                    { "A1", 1 },
                    { "A2", 1},
                    { "A3", 1 }
                };

            Badge newBadge = new Badge(1, doors);

            BadgeRepo newBadgeRepo = new BadgeRepo();
            newBadgeRepo.AddBadgeToLists(newBadge);

            //Try Delete
            newBadgeRepo.RemoveBadgeItemFromLists(1);
            Badge newBadge2 = newBadgeRepo.GetBadgeItemById(1);
            Assert.IsNull(newBadge2);
            
        }
    }
}
