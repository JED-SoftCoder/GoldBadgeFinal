using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsuranceChallenge
{
    class ProgramUI
    {
        private DataRepo _dataRepo = new DataRepo();
        public void Run()
        {
            SeedDataList();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Create a policy\n" +
                    "2. View all policies\n" +
                    "3. Update a policy\n" +
                    "4. Delete a policy\n" +
                    "5. Calculate a premium\n" +
                    "6. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreatePolicy();
                        break;
                    case "2":
                        ViewAllPolicies();
                        break;
                    case "3":
                        UpdateAPolicy();
                        break;
                    case "4":
                        DeleteAPolicy();
                        break;
                    case "5":
                        CalculateAPremium();
                        break;
                    case "6":
                        Console.WriteLine("Have a good day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void CreatePolicy()
        {
            Console.Clear();
            Data newData = new Data();
            Console.WriteLine("Please enter the policy number for the new policy:");
            string policyAsString = Console.ReadLine();
            newData.PolicyNumber = int.Parse(policyAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver speed?");
            string speedAsString = Console.ReadLine();
            newData.AverageSpeeding = int.Parse(speedAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver swerve lanes?");
            string swerveAsString = Console.ReadLine();
            newData.LaneSwerve = int.Parse(swerveAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver roll through stop signs?");
            string stopsAsString = Console.ReadLine();
            newData.StopSigns = int.Parse(stopsAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver follow other drivers too closely?");
            string followsAsString = Console.ReadLine();
            newData.CloseFollow = int.Parse(followsAsString);
            _dataRepo.AddDataToList(newData);
        }

        public void ViewAllPolicies()
        {
            Console.Clear();
            List<Data> listOfData = _dataRepo.GetDataList();
            foreach (Data data in listOfData)
            {
                Console.WriteLine($"Policy Number: {data.PolicyNumber}\t" +
                    $"Speeding Average: {data.AverageSpeeding}\t" +
                    $"Swerving Average: {data.LaneSwerve}\t" +
                    $"Stopping Average: {data.StopSigns}\t" +
                    $"Following Average: {data.CloseFollow}");
            }
        }

        public void UpdateAPolicy()
        {
            ViewAllPolicies();
            Console.WriteLine("Enter the policy number of the policy you would like to update...");
            string policyNumberAsString = Console.ReadLine();
            int oldPolicyNumber = int.Parse(policyNumberAsString);
            Data newData = new Data();
            Console.WriteLine("Please enter the policy number for the new policy:");
            string policyAsString = Console.ReadLine();
            newData.PolicyNumber = int.Parse(policyAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver speed?");
            string speedAsString = Console.ReadLine();
            newData.AverageSpeeding = int.Parse(speedAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver swerve lanes?");
            string swerveAsString = Console.ReadLine();
            newData.LaneSwerve = int.Parse(swerveAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver roll through stop signs?");
            string stopsAsString = Console.ReadLine();
            newData.StopSigns = int.Parse(stopsAsString);
            Console.WriteLine("On a scale of 1 to 10, 1 being not at all, and 10 being constantly, how often does the driver follow other drivers too closely?");
            string followsAsString = Console.ReadLine();
            newData.CloseFollow = int.Parse(followsAsString);
            bool wasUpdated = _dataRepo.UpdateExistingData(oldPolicyNumber, newData);
            if (wasUpdated)
            {
                Console.WriteLine("Policy was updated successfully!");
            }
            else
            {
                Console.WriteLine("Could not update policy.");
            }
        }

        public void DeleteAPolicy()
        {
            ViewAllPolicies();
            Console.WriteLine("Enter the policy number of the policy you would like to remove:");
            string input = Console.ReadLine();
            int policyNumber = int.Parse(input);
            bool wasDeleted = _dataRepo.DeleteDataFromList(policyNumber);
            if (wasDeleted)
            {
                Console.WriteLine("The policy was removed successfully!");
            }
            else
            {
                Console.WriteLine("The policy could not be removed!");
            }
        }

        public void CalculateAPremium()
        {
            Console.Clear();
            ViewAllPolicies();
            Console.WriteLine("Enter the policy number of the policy you wish to calculate a premium for: ");
            string input = Console.ReadLine();
            int policyNumber = int.Parse(input);
            Data data = _dataRepo.GetDataByPolicyNumber(policyNumber);
            int premium = data.AverageSpeeding + data.LaneSwerve + data.StopSigns + data.CloseFollow;
            if (premium <= 10)
            {
                Console.WriteLine("The base premium cost is $50. Your monthly premium is $100!");
            }
            else if (premium <= 20)
            {
                Console.WriteLine("The base premium cost is $50. Your premium is $125!");
            }
            else if (premium <= 30)
            {
                Console.WriteLine("The base premium cost is $50. Your premium is $150!");
            }
            else if (premium <= 40)
            {
                Console.WriteLine("The base premium cost is $50. Your premium is $175!");
            }
        }

        public void SeedDataList()
        {
            Data first = new Data(1234, 10, 10, 10, 10);
            Data second = new Data(5678, 1, 1, 1, 1);
            Data third = new Data(9999, 5, 5, 5, 5);
            _dataRepo.AddDataToList(first);
            _dataRepo.AddDataToList(second);
            _dataRepo.AddDataToList(third);
        }
    }
}
