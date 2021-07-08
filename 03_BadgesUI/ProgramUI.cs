using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesUI
{
    class ProgramUI
    {
        protected readonly BadgesRepo _badgeDirectory = new BadgesRepo();

        public void Run()
        {
            SeedBadgeList();

            DisplayMenu();
        }
        //Program Needs to 
        //create a new badge
        //update doors on an existing badge.
        //delete all doors from an existing badge.
        //show a list with all badge numbers and door access, like this:

        private void DisplayMenu()
        {
            bool isRunning = true; 
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    ("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a Badge \n" +
                    "2. Edit a Badge \n" +
                    "3. List all Badges\n" +
                    "4. Exit \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4!");
                        break;
                }
            }
        }

        //Add a new Badge 
        private void AddBadge()
        {
            Console.Clear();

            Console.Write("What is the number on the badge: ");
            int badgeNum = int.Parse(Console.ReadLine());

            bool addingDoors = true;
            List<string> newDoors = new List<string> { };
            while (addingDoors == true)
            {
                Console.Write("List a door that it needs access to: ");
                string newDoor = Console.ReadLine();
                newDoors.Add(newDoor);

                Console.Write("Any other doors(y/n)? ");
                string continueAdding = Console.ReadLine();

                if (continueAdding == "y")
                {
                    addingDoors = true;
                }
                else if (continueAdding == "n")
                {
                    addingDoors = false;
                }
                else
                {
                    Console.WriteLine("Incorrect Input. Please update if you still would like to add additional doors");
                    addingDoors = false;
                    DisplayHelper();
                } 
            }
            Badge _newBadge = new Badge(badgeNum, newDoors);
            _badgeDirectory.AddBadgeToDictionary(_newBadge);
        }

        private void UpdateBadge()
        {
            Console.Clear();

            Console.Write("What is the badge number to update: ");
            int badgeUpdate = int.Parse(Console.ReadLine());
            List<string> accessibleDoors = _badgeDirectory.GetDoorsByID(badgeUpdate);

            string userMessage = badgeUpdate.ToString() + " has access to doors: ";

            foreach(string door in accessibleDoors)
            {
                userMessage +=  door + " ";
            }
            Console.WriteLine(userMessage);

            Console.WriteLine("What would you like to do? \n" +
                "   1. Remove a Door \n" +
                "   2. Add a Door \n");
            Console.Write(">");
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                Console.Write("Which door would you like to remove? ");
                string doorRemove = Console.ReadLine();
                bool removedDoor = _badgeDirectory.DeleteDoorOnBadge(badgeUpdate, doorRemove);
                if (removedDoor == true)
                {
                    Console.WriteLine("Door Removed.");
                }
                else
                {
                    Console.WriteLine("Door was not removed.");
                }

            }
            if (userInput == 2)
            {
                Console.Write("Which door would you like to add? ");
                string doorAdd = Console.ReadLine();
                bool addDoor = _badgeDirectory.AddDoorToBadge(badgeUpdate, doorAdd);
                if (addDoor == true)
                {
                    Console.WriteLine("Door Added.");
                }
                else
                {
                    Console.WriteLine("Door was not added.");
                }
            }
            string userMessage2 = badgeUpdate.ToString() + " has access to doors: ";
            foreach (string door in accessibleDoors)
            {
                userMessage2 += door + " ";
            }

            Console.WriteLine(userMessage2);
            DisplayHelper();
        }

        private void ListBadges()
        {
            Console.Clear();

            Console.WriteLine("Key");
            Console.WriteLine("Badge #    DoorAccess");

            Dictionary<int, List<string>> badges = _badgeDirectory.GetBadges();

            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                int badgeID = badge.Key;
                string idDisplay = badgeID.ToString();

                string doorDisplay = "";
                foreach (string door in badge.Value)
                {
                    doorDisplay += door + " ";
                }

                Console.WriteLine(idDisplay + "      " + doorDisplay);
            }
            Console.WriteLine(" ");
            DisplayHelper();
        }

        //Helper Functions
        private void DisplayHelper()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedBadgeList()
        {
            Badge badge1 = new Badge(12345, new List<string> { "A5", "A7" });

            _badgeDirectory.AddBadgeToDictionary(badge1);
        }
    }
}
