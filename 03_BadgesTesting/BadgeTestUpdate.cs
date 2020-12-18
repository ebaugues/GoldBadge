using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_BadgesTesting
{
    [TestClass]
    public class BadgeTestUpdate
    {
        [TestMethod]
        public void TestMethod1()
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

            //Try Update
            var doors2 = new Dictionary<string, int>()
                {
                    { "B1", 1 },
                    { "B2", 1},
                    { "B3", 1 }
                };

            Badge newBadge2 = new Badge(1, doors2);
            newBadgeRepo.UpdateExistingBadge(1, newBadge2);

            Badge newBadge3 = newBadgeRepo.GetBadgeItemById(1);

            var actual = doors2;
            var expected = newBadge3.Doors;

            Assert.AreEqual(expected, actual);  //Update without issue and added to list 
        }
    }
}
