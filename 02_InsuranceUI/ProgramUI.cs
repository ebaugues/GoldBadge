using _02_KomodoInsurance;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_InsuranceUI
{
    class ProgramUI
    {
        //private StreamingContentRepository _contentRepo = new StreamingContentRepository();
        private ClaimRepo _claimItemDirectory = new ClaimRepo();

        //Method that runs/starts the appliaction
        public void Run()
        {
            seedContentList();
            ClaimMenu();
        }

        //Menu method for claim
        private void ClaimMenu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                //Display the options
                Console.WriteLine("Select a menu option:\n" +
                    "1.  See all claims\n" +
                    "2.  Take care of next claim\n" +
                    "3.  Enter a new claim\n" +
                    "4.  Exit");

                // Get users input
                string input = Console.ReadLine();


                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //See All Claims 
                        DisplayAllClaimItems();
                        break;

                    case "2":
                        //Take care of next claim
                        WorkNextClaim();
                        break;

                    case "3":
                        //Create new claim item
                        CreateNewClaimItem();
                        break;

                    case "4":
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


        //Creating new Claim Item
        private void CreateNewClaimItem()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //Claim Item Id
            Console.WriteLine("Enter the claim id:");
            newClaim.ClaimId = Console.ReadLine();



            bool keepRunningType = true;
            while (keepRunningType)
            {
                //Claim Type
                Console.WriteLine("Enter the claim type (Car,Home,Theft):");
                //might need to verify correct value
                string claimtype = Console.ReadLine();

                if (claimtype.ToUpper() == "CAR")
                {
                    newClaim.ClaimType = ClaimType.Car;
                    keepRunningType = false;
                }
                else if (claimtype.ToUpper() == "HOME")
                {
                    newClaim.ClaimType = ClaimType.Home;
                    keepRunningType = false;
                }
                else if (claimtype.ToUpper() == "THEFT")
                {
                    newClaim.ClaimType = ClaimType.Theft;
                    keepRunningType = false;
                }
                else
                {
                    Console.WriteLine("Claim Type is invalid. Try again, press any key to continue....");
                    Console.ReadLine();
                }


            }

            //Claim Description
            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();
            

            //Claim Amount
            Console.WriteLine("Amount of Damage:");
            string claimAmt = Console.ReadLine();
            newClaim.ClaimAmt = Convert.ToDouble(claimAmt);

            //Claim DateOfIncident
            bool keepRunningDate = true;
            while (keepRunningDate)
            {

                Console.WriteLine("Date Of Accident (MM/DD/YYYY):");
                string datestring = Console.ReadLine();
                bool ValidClaimDate = DateValid(datestring);

               if (ValidClaimDate)
                    {
                    newClaim.DateOfIncident = ParseMyFormatDateTime(datestring);
                    keepRunningDate = false;
                    }
               else
                {
                    Console.WriteLine("Date is not valid, try again, press any key to continue...");
                    Console.ReadLine();
                }


                //DateTime dateofincident = DateTime.ParseExact(datestring, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //newClaim.DateOfIncident = dateofincident;

            }



            //Claim DateOfIncident
            bool keepRunningDate2 = true;
            while (keepRunningDate2)
            {
                //Claim DateOfClaim
                Console.WriteLine("Date of Claim (MM/DD/YYYY):");
                string datestring2 = Console.ReadLine();
                bool ValidClaimDate = DateValid(datestring2);


                if (ValidClaimDate)
                {
                    DateTime dateofclaim = DateTime.ParseExact(datestring2, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    newClaim.DateOfClaim = dateofclaim;
                    keepRunningDate2 = false;
                }
                else
                {
                    Console.WriteLine("Date is not valid, try again, press any key to continue...");
                    Console.ReadLine();
                }


            }

            //Claim IsValid
            //Did not check future dates, could be an enhancement.
            if (((newClaim.DateOfClaim.AddDays(-30)) <= (newClaim.DateOfIncident)) & (newClaim.DateOfIncident < newClaim.DateOfClaim))
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            if (newClaim.IsValid)
            {
                Console.WriteLine("The claim is valid.");
                _claimItemDirectory.AddClaimToLists(newClaim);
            }
            else
            {
                Console.WriteLine("The claim is not valid. System will not add invalid claim.");
            }


        }





        //View All Current Claim Items
        private void DisplayAllClaimItems()
        {
            Console.Clear();

            //show everything on content list
            List<Claim> listofClaimItems = _claimItemDirectory.GetClaimItems();
            Console.WriteLine("{0,-10} {1,5} {2,20} {3,10} {4,15} {5,15} {6,10}\n", "ClaimID", "Type", "Description", "Amount", "DateofAccident", "DateofClaim", "IsVlaid");
            //Console.WriteLine("ClaimID  Type        Description         Amount          DateofAccident          DateofClaim                 IsVlaid\n");
            foreach (Claim claim in listofClaimItems)
            {
                Console.WriteLine($" {claim.ClaimId,-10} {claim.ClaimType,5} {claim.Description,20} {claim.ClaimAmt,10} {claim.DateOfIncident.Date.ToShortDateString(),15} {claim.DateOfClaim.Date.ToShortDateString(),15} {claim.IsValid,10}\n");
              //  Console.WriteLine($"{0,-10} {1,5} {2,20} {3,10} {4,15} {5,15} {6,10}\n", {claim.ClaimId},         {claim.ClaimType},           {claim.Description}         {claim.ClaimAmt}            {claim.DateOfIncident}          {claim.DateOfClaim}         {claim.IsValid}\n");
            }

        }


        //View All Menu Items 
        private void WorkNextClaim()
        {
            Console.Clear();

            //show everything on content list
            List<Claim> listofClaims = _claimItemDirectory.GetClaimItems();
            bool AcceptableResponse = false;
            int counter = 0;


            while (AcceptableResponse == false)
            {
                Console.Clear();
                Claim currentClaim = listofClaims[counter];
                Console.WriteLine($"ClaimID: {currentClaim.ClaimId}\n");
                Console.WriteLine($"Type: {currentClaim.ClaimType}\n");
                Console.WriteLine($"Description: {currentClaim.Description}\n");
                Console.WriteLine($"Amount: {currentClaim.ClaimAmt}\n");
                Console.WriteLine($"DateofAccident: {currentClaim.DateOfIncident}\n");
                Console.WriteLine($"DateofClaim: {currentClaim.DateOfClaim}\n");
                Console.WriteLine($"IsValid: {currentClaim.IsValid}\n");


                Console.WriteLine("Do you want to deal with this claim now(y/n)? Are (x) to Exit:");
                string response = Console.ReadLine().ToUpper();

                if (response == "Y")
                {
                    AcceptableResponse = true;
                    _claimItemDirectory.RemoveClaimItemFromLists(currentClaim.ClaimId);
                }
                else if (response == "N")
                {

                    Console.WriteLine("Moving to next claim. Press enter to continue.");
                    counter++;
                    Console.ReadLine();

                }
                else if (response == "X")  //Exit
                {
                    AcceptableResponse = true;
                    ClaimMenu();
                }
                else
                {
                    Console.WriteLine("Response not acceptable. Press any key to continue.");
                    Console.ReadLine();

                }

            }



        }


        private static DateTime ParseMyFormatDateTime(string s)
        {
            var culture = CultureInfo.CurrentCulture;
            return DateTime.ParseExact(s, "MM/dd/yyyy", culture);
        }

        private static bool DateValid(string dateValue)
        {
            DateTime dt;
            string[] formats = { "MM/dd/yyyy" };
            if (!DateTime.TryParseExact(dateValue, formats,
                            System.Globalization.CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
            {
                //your condition fail code goes here
                return false;
            }
            else
            {
                return true;
            }

        }


        //See method
        private void seedContentList()
        {


            Claim claim1 = new Claim("1", ClaimType.Car, "Accident on I-69", 5000.00, ParseMyFormatDateTime("01/01/2020"), ParseMyFormatDateTime("01/25/2020"), true);
            Claim claim2 = new Claim("2", ClaimType.Home, "House burned down", 15000.00, ParseMyFormatDateTime("12/01/2020"), ParseMyFormatDateTime("12/08/2020"), true);
            Claim claim3 = new Claim("3", ClaimType.Theft, "House robbed", 3000.00, ParseMyFormatDateTime("12/01/2020"), ParseMyFormatDateTime("12/08/2020"), true);

            _claimItemDirectory.AddClaimToLists(claim1);
            _claimItemDirectory.AddClaimToLists(claim2);
            _claimItemDirectory.AddClaimToLists(claim3);

        }
    }
}
