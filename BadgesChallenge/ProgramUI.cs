using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesChallenge
{
    public class ProgramUI
    {
        public BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedBadgeFiller();
            Menu();
        }

        public void SeedBadgeFiller()
        {
            Badge lisa = new Badge(5555, new List<string> { "A1", "B1" });
            Badge john = new Badge(1234, new List<string> { "A1", "A2" });
            _badgeRepo.AddBadgeToDictionary(lisa);
            _badgeRepo.AddBadgeToList(lisa);
            _badgeRepo.AddBadgeToList(john);
            _badgeRepo.AddBadgeToDictionary(john);
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select an option:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        Console.WriteLine("Have a good day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter a correct option!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            Console.WriteLine("Enter the name of the badge :");
            newBadge.BadgeName = Console.ReadLine();
            Console.WriteLine("Enter the badge ID:");
            string input = Console.ReadLine();
            newBadge.BadgeID = int.Parse(input);

            bool keepOn = true;
            List<string> doorAccess = new List<string>();
            Console.WriteLine("Enter a door this badge has access to:");
            string input2 = Console.ReadLine().ToUpper();
            doorAccess.Add(input2);
            while (keepOn)
            {
                Console.WriteLine("Add another door this badge has access to? (Y/N)");
                string input3 = Console.ReadLine().ToLower();
                if (input3.Contains("y"))
                {
                    Console.WriteLine("List a door this badge has access to:");
                    string input4 = Console.ReadLine().ToUpper();
                    doorAccess.Add(input4);
                }
                else if (input3.Contains("n"))
                {
                    keepOn = false;
                }
            }
            newBadge.Doors = doorAccess;
            _badgeRepo.AddBadgeToDictionary(newBadge);
            _badgeRepo.AddBadgeToList(newBadge);
        }

        //EditBadges
        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the badge you would like to update:");
            string input = Console.ReadLine();
            int originalBadgeID = int.Parse(input);
            Badge oldBadge = _badgeRepo.GetBadgeByID(originalBadgeID);
            if (oldBadge != null)
            {
               
                bool keepRunning = true;
                while (keepRunning)
                {
                    Console.Clear();
                    Badge newBadge = new Badge();
                    Console.Write($"{oldBadge.BadgeID} has access to doors ");
                    foreach (string door in oldBadge.Doors)
                    {
                        Console.Write($" {door} ");
                    }
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove a door\n" +
                        "2. Add a door\n" +
                        "3. Return to main menu");
                    string option = Console.ReadLine();
                    if (option.Contains("1"))
                    {
                        Console.WriteLine("Which door would you like to remove?");
                        string doorToRemove = Console.ReadLine().ToUpper();
                        if (oldBadge.Doors.Contains(doorToRemove))
                        {
                            oldBadge.Doors.Remove(doorToRemove);
                            Console.WriteLine("Door removed successfully! Press any key to continue!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No door by that name could be found!");

                        }
                    }
                    else if (option.Contains("2"))
                    {
                        Console.WriteLine("What is the door you would like to add?");
                        string doorToAdd = Console.ReadLine().ToUpper();
                        if (oldBadge.Doors.Contains(doorToAdd))
                        {
                            Console.WriteLine("The badge already has access to that door!");
                        }
                        else
                        {
                            oldBadge.Doors.Add(doorToAdd);
                            Console.WriteLine("Door added successfully!");
                        }
                    }
                    else if (option.Contains("3"))
                    {
                        keepRunning = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("No badge by that number could be found! Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        private void ListBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = _badgeRepo.GetBadgeDictionary();
            
            foreach(KeyValuePair<int, List<string>> kvp in listOfBadges)
            {
                Console.Write($"ID: {kvp.Key}\t" +
                    $"Door Access: ");
                foreach(string door in kvp.Value)
                {
                    Console.Write($" {door}");
                }
               
                Console.WriteLine();
            }
        }
    }
}
