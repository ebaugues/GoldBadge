using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _03_Badges;
using System.Collections.Generic;

namespace _03_BadgesTesting
{
    [TestClass]
    public class BadgeTestCreate
    {
        [TestMethod]
        public void CreateBadge()
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

            Badge newBadge2 = newBadgeRepo.GetBadgeItemById(1);

            Assert.IsNotNull(newBadge2);  //Should pass if created and added by repo
   
        }
    }
}
