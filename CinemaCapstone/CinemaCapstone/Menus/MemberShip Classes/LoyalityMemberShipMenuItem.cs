using Capstone.Cinema_features;
using Capstone.Cinema_features.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.Menus
{
    /// <summary>
    /// This class represents the loyalty membership menu item. It inherits from ConsoleMenu.
    /// </summary>
    class LoyalityMemberShipMenuItem : ConsoleMenu
    {
        // path to the file containing membership information
        private string filepath = $@"{Environment.CurrentDirectory}\Resources\Membership.txt";

        // path to the file containing transaction information
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        /// <summary>
        /// Writing the loyalty membership data to a file. It checks if the data already exists before writing.
        /// </summary>
        public override void CreateMenuItems()
        {
            
        }
        /// <summary>
        /// This method displays the menu text for the loyalty membership menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Loyality Scheme";
        }

        /// <summary>
        /// This method creates the menu items for the loyalty membership. It handles the process of adding members to the loyalty scheme.
        /// </summary>
        public override void PostProcess()
        {
            // Check if the file exists and read existing data
            var existingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();

            // Prepare the new data to write
            var Loyality = MemberShipParser.GetMemberShip();
            foreach (var i in Loyality)
            {
                // Loading the member information for loyality members
                Console.WriteLine($"{i.MemberID} - FirstName:{i.Firstname} LastName:{i.Lastname} Email:{i.Email} Member:{i.Member} Visted:{i.Visted}");

                // Adding the new data to the transaction.txt file 
                string newData = $"{i.Firstname} {i.Lastname} ({i.Member})";

                // Check if the data already exists
                if (!existingData.Contains(newData))
                {
                    // Append the new data only if it doesn't already exist
                    using (StreamWriter streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine(newData);
                    }
                }
            }
            // Unique Member ID
            Random random = new Random();

            int MemberID = random.Next(0, 100);

            // Prompting the user for input Firstname , Lastname, and Email Address
            Console.WriteLine("Enter Firstname:");

            string firstname = Console.ReadLine();

            Console.WriteLine("Enter Suraname");

            string lastname = Console.ReadLine();

            Console.WriteLine("Enter Email Address");

            string email = Console.ReadLine();

            // Validating the input for Firstname, Lastname and Email Address. If not valid input restarts the method
            bool Num = int.TryParse(firstname, out int i1);

            bool Num2 = int.TryParse(lastname, out int i2);

            bool First = char.IsUpper(firstname[0]);

            bool Last = char.IsUpper(lastname[0]);

            if (Num || Num2 || !First || !Last)
            {
                Console.WriteLine("Invalid Names");

                PostProcess();
            }
            if (email[0] == '@' || email.Length == '@' || email[0] == '.' || email.Length == '.' || email.Contains("@@"))
            {
                Console.WriteLine("Invalid Email Address");

                PostProcess();
            }

            // Retriving data from the Membership Parser
            Loyality = MemberShipParser.GetMemberShip();

            int Visted = 1;

            // Checking if member already exists in the file if they do increments the amount of time they have visted by 1. 
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (var loyality in Loyality)
                {
                    if (firstname == loyality.Firstname && lastname == loyality.Lastname)
                    {
                        Console.WriteLine("Member Already Exists");
                        Visted++;
                    }
                }
                // Writing Updated data towards the file
                sw.WriteLine($"[MemberID:{MemberID}%Firstname:{firstname}%Lastname:{lastname}%Email:{email}%Member:Loyality%Visted:{Visted}]");
            }
        }
    }
}
