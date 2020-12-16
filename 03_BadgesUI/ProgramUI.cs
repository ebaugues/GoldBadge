using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_BadgesUI;
using _03_Badges;

namespace _03_BadgesUI
{
    class ProgramUI
    {

        //private StreamingContentRepository _contentRepo = new StreamingContentRepository();
        private BadgeRepo _badgeItemDirectory = new BadgeRepo();

        //Method that runs/starts the appliaction
        public void Run()
        {
            seedContentList();
            BadgeMenu();
        }

        //Menu method for claim
        private void BadgeMenu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                //Display the options
                Console.WriteLine("Select a menu option:\n" +
                    "1.  Add a badge\n" +
                    "2.  Edit a badge.\n" +
                    "3.  Delete Doors for an existing badge\n" +
                    "4.  List all Badges\n" +
                    "5.  Exit");

                // Get users input
                string input = Console.ReadLine();


                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //See All Claims 
                        CreateNewBadgeItem();
                        //DisplayAllClaimItems();
                        break;

                    case "2":
                        //Update doors on an existing badge
                        UpdateBadgeItem();
                        break;

                    case "3":
                        //Delete All Doors from an existing badge
                        DeleteDoorsforBadgeItem();
                        break;

                    case "4":
                        //Display All Badge Items
                        DisplayAllBadgeItems();
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;


                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }


        //Creating new Badge Item
        private void CreateNewBadgeItem()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            //Claim Item Id
            Console.WriteLine("What is the number on the badge:");
            newBadge.BadgeId = Convert.ToInt16(Console.ReadLine());

            Dictionary<string, int> doorlist = new Dictionary<string, int>();
            bool keepRunningType = true;
            while (keepRunningType)
            {
                //Claim Type
                Console.WriteLine("List a door that it needs access to:");
                //might need to verify correct value
                string doorid = Console.ReadLine();
                //Check to see if value already exist.
                if (doorlist.ContainsKey(doorid))
                {
                    Console.WriteLine("Door ID already exists in dictionary for user. Try a different door.");

                }
                else
                {
                    doorlist.Add(doorid, newBadge.BadgeId);
                }

                Console.WriteLine("Any other doors(y/n) ?");
                string response = Console.ReadLine().ToUpper();
                if (response.Contains("Y"))
                {
                    //'Keep Going'
                }
                else
                {
                    keepRunningType = false;
                }

            }
            newBadge.Doors = doorlist;
            _badgeItemDirectory.AddBadgeToLists(newBadge);
        }

        //Updating  Badge Item
        private void UpdateBadgeItem()
        {
            Console.Clear();

            //Claim Item Id
            Console.WriteLine("What is the badge number to update:");
            int badgeid = Convert.ToInt32(Console.ReadLine());

            //Find  developer by id
            Badge badge = _badgeItemDirectory.GetBadgeItemById(badgeid);

            //Display Menu Item if it isn't null
            if (badge == null)
            {
                Console.WriteLine("Badge id does not exist.");
            }
            else
            {
                //Show badge doors
                string FullListDoors2 = null;

                //Loop through and  doors
                foreach (KeyValuePair<string, int> entry in badge.Doors)
                {
                    if (FullListDoors2 is null)
                    {
                        FullListDoors2 = entry.Key;

                    }
                    else
                    {
                        FullListDoors2 = FullListDoors2 + " & " + entry.Key;
                    }
                }

                Console.WriteLine($" {badge.BadgeId,-10} has access to doors {FullListDoors2,40}.\n");

                Badge newBadge = new Badge();
                newBadge.BadgeId = badge.BadgeId;
                Dictionary<string, int> doorlist = badge.Doors;
                bool keepRunningType = true;
                while (keepRunningType)
                {

                    Console.WriteLine("What would you like to do?\n" +
                  "1.  Remove a door\n" +
                  "2.  Add a door\n" +
                  "3.  Exit (Any key other than 1 or 2)\n");

                    int resp = Convert.ToInt32(Console.ReadLine());

                    switch (resp)
                        {
                        case 1:
                            //Remove Door
                            Console.WriteLine("Which door do you want to remove:");
                            string doorid = Console.ReadLine();
                            
                                //Check to see if value already exist.
                                if (doorlist.ContainsKey(doorid))
                                {
                                    Console.WriteLine("Door ID already exists for user. Add a different door.");
                                    doorlist.Remove(doorid);  //, badge.BadgeId);   //(doorid, badge.BadgeId);

                                 }
                                else
                                {
                                   
                                }
                            break;

                        case 2:
                            //Add Door
                             Console.WriteLine("Which door do you want to add:");
                             string doorid2 = Console.ReadLine();
                                        //Check to see if value already exist.
                                        if (doorlist.ContainsKey(doorid2))
                                        {
                                            Console.WriteLine("Door ID already exists for user. Add a different door.");

                                        }
                                        else
                                        {
                                            doorlist.Add(doorid2, badge.BadgeId);
                                        }                                   
                            break;

                        default:
                            keepRunningType = false;
                            break;
                }
                newBadge.Doors = doorlist;
                //Update Badge
                _badgeItemDirectory.UpdateExistingBadge(badge.BadgeId, newBadge);

            }
        }
    }

        private void DeleteDoorsforBadgeItem()
        {
            Console.Clear();
            //Claim Item Id
            Console.WriteLine("Enter the Badge id to remove all doors:");
            int badgeid = Convert.ToInt16(Console.ReadLine());

            //Find  developer by id
            Badge badge = _badgeItemDirectory.GetBadgeItemById(badgeid);

            //Display Menu Item if it isn't null
            if (badge == null)
            {
                Console.WriteLine("Badge id does not exist.");
            }
            else
            {

                //Loop through and delete doors
                while (badge.Doors.Count > 0)
                {
                    var obj = badge.Doors.Last();
                    badge.Doors.Remove(obj.Key);
                }
            }

        }


        //View All Current Claim Items
        private void DisplayAllBadgeItems()
        {
            Console.Clear();
             string FullListDoors = null;
            //show everything on content list
            List<Badge> listofBadgeItems = _badgeItemDirectory.GetBadgeItems();
            Console.WriteLine("{0,-10} {1,40} \n", "BadgeID", "Door Access");
            //Console.WriteLine("ClaimID  Type        Description         Amount          DateofAccident          DateofClaim                 IsVlaid\n");
            foreach (Badge badge in listofBadgeItems)
            {
                FullListDoors = null;
                //Loop through and delete doors
               
                foreach (KeyValuePair<string, int> entry in badge.Doors)
                {

                    if (FullListDoors is null)
                    {
                        FullListDoors = entry.Key;

                    }
                    else
                    {
                        FullListDoors = FullListDoors + " & " + entry.Key;
                    }

                    
                }

                Console.WriteLine($" {badge.BadgeId,-10} {FullListDoors,40}\n");
            }

        }

        //See method
        private void seedContentList()
        {

            var doors = new Dictionary<string, int>()
                {
                    { "A1", 1 },
                    { "A2", 1},
                    { "A3", 1 }
                };

            Badge badge1 = new Badge(1, doors);


            var doors2 = new Dictionary<string, int>()
                {
                    { "B1", 2 },
                    { "B2", 2 },
                    { "B3", 2 }
                };

            Badge badge2 = new Badge(2, doors2);


            _badgeItemDirectory.AddBadgeToLists(badge1);
            _badgeItemDirectory.AddBadgeToLists(badge2);

        }


    }


    }