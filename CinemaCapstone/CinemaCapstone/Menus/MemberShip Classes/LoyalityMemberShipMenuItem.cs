using Capstone.Cinema_features;
using Capstone.Cinema_features.Parsers;
using Capstone.Menus.MemberShip_Classes;
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
        

        // path to the file containing transaction information
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        /// <summary>
        /// Writing the loyalty membership data to a file. It checks if the data already exists before writing.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new CreateANewUserMenuItem());
            _menuItems.Add(new ExitMenuItem(this));
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

        }
    }
}
