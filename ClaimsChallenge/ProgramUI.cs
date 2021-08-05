using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsChallenge
{
    class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeedClaimList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine($"Please choose an option:\n" +
                    $"1. See all Claims\n" +
                    $"2. Take care of next Claim\n" +
                    $"3. Enter a new Claim\n" +
                    $"4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //See claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        TakeCareNextClaim();
                        break;
                    case "3":
                        //Enter new claim
                        CreateAClaim();
                        break;
                    case "4":
                        Console.WriteLine("Have a good day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter a valid choice!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.GetClaimsQueue();
            foreach(Claims claims in queueOfClaims)
            {
                Console.WriteLine($"Claim ID: {claims.ClaimID}\t" +
                    $"Type of Claim: {claims.TypeOfClaim}\t" +
                    $"Description: {claims.Description}\t" +
                    $"Claim Amount: {claims.ClaimAmount}\t" +
                    $"Date of Incident: {claims.DateOfIncident}\t" +
                    $"Date Of Claim: {claims.DateOfClaim}\t" +
                    $"IsValid: {claims.IsValid}");
            }
        }

        private void TakeCareNextClaim()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.GetClaimsQueue();
            Claims nextInQueue = queueOfClaims.Peek();
            Console.WriteLine($"Claim ID: {nextInQueue.ClaimID}\n" +
                    $"Type of Claim: {nextInQueue.TypeOfClaim}\n" +
                    $"Description: {nextInQueue.Description}\n" +
                    $"Claim Amount: {nextInQueue.ClaimAmount}\n" +
                    $"Date of Incident: {nextInQueue.DateOfIncident}\n" +
                    $"Date Of Claim: {nextInQueue.DateOfClaim}\n" +
                    $"IsValid: {nextInQueue.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now? (Y/N)");
            string input = Console.ReadLine().ToLower();
                if (input.Contains("y"))
                {
                    queueOfClaims.Dequeue();
                    queueOfClaims.Peek();
                    TakeCareNextClaim();
                }
                //else if (input.Contains("n"))
                //{
                //    Console.WriteLine("Press any key to be returned to the menu...");
                //}
            
        }

        private void CreateAClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();
            Console.WriteLine("Enter the ID for the Claim:");
            string input1 = Console.ReadLine();
            newClaim.ClaimID = int.Parse(input1);
            Console.WriteLine("Enter the Claim type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.TypeOfClaim = (ClaimType)typeAsInt;
            Console.WriteLine("Enter the description of the Claim: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Enter the amount of the Claim: ");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(amountAsString);
            Console.WriteLine("Enter the date of the Incident (YYYY/MM/DD): ");
            string dateTimeAsString = Console.ReadLine();
            newClaim.DateOfIncident = Convert.ToDateTime(dateTimeAsString);
            Console.WriteLine("Enter the date of the Claim (YYYY/MM/DD): ");
            string dateTimeAsString2 = Console.ReadLine();
            newClaim.DateOfClaim = Convert.ToDateTime(dateTimeAsString2);
            Console.WriteLine("Was this claim made within 30 days of incident? (Y/N)");
            string input2 = Console.ReadLine().ToLower();
            if (input2.Contains("y"))
            {
                newClaim.IsValid = true;
            }
            else if (input2.Contains("n"))
            {
                newClaim.IsValid = false;
            }
            _claimsRepo.AddClaimToList(newClaim);
        }
        private void SeedClaimList()
        {
            Claims firstClaim = new Claims(1, ClaimType.Car, "Rear-ended", 4000, new DateTime(1999,07,01), new DateTime(1999,07,21), true);
            _claimsRepo.AddClaimToList(firstClaim);
            Claims secondClaim = new Claims(2, ClaimType.Theft, "House robbery", 8000, new DateTime(2000, 09, 05), new DateTime(2000, 09, 25), true);
            _claimsRepo.AddClaimToList(secondClaim);
        }
    }
}
