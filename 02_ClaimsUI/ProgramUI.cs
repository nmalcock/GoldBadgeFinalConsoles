using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    class ProgramUI
    {
        protected readonly ClaimsRepo _claimRepo = new ClaimsRepo();

        public void Run()
        {
            SeedClaimsQueue();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine(
                    "Choose a menu item: \n" +
                    "1. See All Claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4!");
                        break;
                }
            }
        }

        private void DisplayAllClaims()
        {
            Console.Clear();

            Queue<Claims> queueOfClaims = _claimRepo.GetClaims();
            Console.WriteLine("ClaimID   Type        Description         Amount   DateOfAccident   DateOfClaim   IsValid");
            foreach (Claims claim in queueOfClaims)
            {
                string claimType = claim.TypeOfClaim.ToString();
                string claimAmount = claim.ClaimAmount.ToString();
                string dateIncident = claim.DateOfIncident.ToString("d");
                string dateClaim = claim.DateOfClaim.ToString("d");
                string isValid = claim.IsValid.ToString();
                Console.WriteLine($"{claim.ClaimID}   {claimType,10}   {claim.Description,-10}  {claimAmount,10}     {dateIncident,-5}      {dateClaim,10}  {isValid,10}");
            }

            displayHelper();
        }


        private void NextClaim()
        {
            Console.Clear();

            Claims nextClaim = _claimRepo.GetNextClaim();
            Console.WriteLine("ClaimID: " + nextClaim.ClaimID.ToString() + "\n" +
                "Type: " + nextClaim.TypeOfClaim.ToString() + "\n" +
                "Description: " + nextClaim.Description + "\n" +
                "Amount: " + nextClaim.ClaimAmount.ToString() + "\n" +
                "DateOfAccident: " + nextClaim.DateOfIncident.ToString("d") + "\n" +
                "DateOfClaim: " + nextClaim.DateOfClaim.ToString("d") + "\n" +
                "IsValid: " + nextClaim.IsValid.ToString() + "\n");

            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Write("Do you want to deal with this claim now(y/n)? ");
                string dealWithClaim = Console.ReadLine();
                if (dealWithClaim == "y")
                {
                    _claimRepo.RemoveExistingClaim();
                    isRunning = false;
                    displayHelper();

                }
                else if (dealWithClaim == "n")
                {
                    isRunning = false;
                    DisplayMenu();
                }
                else
                {
                    Console.WriteLine("Please enter either y or n");
                    displayHelper();
                }
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Console.Write("Enter the claim id: ");
            int claimID = int.Parse(Console.ReadLine());

            
            bool getType = true;
            ClaimType newType = new ClaimType();
            while (getType == true)
            {
                Console.Write("Enter the claim type: ");
                string type = Console.ReadLine();
                if (type.ToLower() == "car") 
                {
                    newType = ClaimType.Car;
                    getType = false;
                }
                else if (type.ToLower() == "home")
                {
                    newType = ClaimType.Home;
                    getType = false;
                }
                else if (type.ToLower() == "theft")
                {
                    newType = ClaimType.Theft;
                    getType = false;
                }
                else
                {
                    Console.WriteLine("Please enter Car, Home, or Theft");
                    displayHelper();
                }
            }

            Console.Write("Enter a claim description: ");
            string desc = Console.ReadLine();

            Console.Write("Amount of Damage: $");
            decimal damageAmount = decimal.Parse(Console.ReadLine());

           
            Console.Write("Date Of Accident: ");
            string acciDate = Console.ReadLine();
            DateTime accidentDate = DateTime.Parse(acciDate);

            Console.Write("Date of Claim: ");
            string claimDatestr = Console.ReadLine();
            DateTime claimDate = DateTime.Parse(claimDatestr);
         
            Claims newClaim = new Claims(claimID, newType, desc, damageAmount, accidentDate, claimDate);

            _claimRepo.AddClaimToDirectory(newClaim);

            if(newClaim.IsValid == true)
            {
                Console.WriteLine("This Claim is Valid");
            }
            else
            {
                Console.WriteLine("This claim is not valid");
            }

            displayHelper();
        }

        //Helper Functions
        private void displayHelper()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedClaimsQueue()
        {
            Claims claim1 = new Claims(1, ClaimType.Car, "Car Accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in Kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

            _claimRepo.AddClaimToDirectory(claim1);
            _claimRepo.AddClaimToDirectory(claim2);
            _claimRepo.AddClaimToDirectory(claim3);
        }


    }
}
