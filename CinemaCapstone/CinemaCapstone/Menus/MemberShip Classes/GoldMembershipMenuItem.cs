using Capstone.Cinema_features.Parsers;

namespace Capstone.Menus.MemberShip_Classes
{
    /// <summary>
    /// This class represents the Gold Membership menu item. It inherits from ConsoleMenu.
    /// </summary>
    class GoldMembershipMenuItem : LoyalityMemberShipMenuItem
    {
        // path to the file containing membership information
        private static string filepath = $@"{Environment.CurrentDirectory}\Resources\Membership.txt";

        // path to the file containing transaction information
        private string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        /// <summary>
        /// This method creates the menu items for the Gold Membership.
        /// </summary>
        public override void CreateMenuItems()
        {
           
        }
        /// <summary>
        /// This method displays the menu text for the Gold Membership menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Gold Membership";
        }
        /// <summary>
        /// This method handles the process of adding members to the Gold Membership scheme.
        /// </summary>
        public override void PostProcess()
        {
            // Getting an Anuual Membership Date

            int Yearly = DateTime.Now.Month;

            int Yearly2 = DateTime.Now.Day;

            int Yearly3 = DateTime.Now.Year + 1;

            string year = $"{Yearly}/{Yearly2}/{Yearly3}";

            // Getting the current date
            string currentDate = DateTime.Now.ToString("yyyy/MM/dd");

            // Getting data from MembershipParser which gets data from the Membership.txt file
            var gold = MemberShipParser.GetMemberShip();

            foreach(var Gold in gold)
            {
                if (Gold.Member == "Loyality")
                {
                    Console.WriteLine($"{Gold.MemberID} - Firstname:{Gold.Firstname} Lastname:{Gold.Lastname} Email Address:{Gold.Email} Member:{Gold.Member} Visted:{Gold.Visted}");
                }
                if (Gold.Member == "Gold")
                {
                    Console.WriteLine($"{Gold.MemberID} - Firstname:{Gold.Firstname} Lastname:{Gold.Lastname} Email Address:{Gold.Email} Member:{Gold.Member} Visted:{Gold.Visted} MemberShipEndDate:{year}");
                }
            }

            // Selling the user a Gold Membership
            Console.WriteLine("Would You Like To Join Gold Member Its £89 Per Year Yes Or No");
            string SellMembership = Console.ReadLine();

            // Validating the input for Yes or No
            if (SellMembership == "Yes")
            {
                // Opening the Membership.txt file and Converting the loyality member to a gold member
                StreamWriter sw = new StreamWriter(filepath);

                foreach (var i in gold)
                {
                    sw.WriteLine($"[MemberID:{i.MemberID}%FirstName:{i.Firstname}%LastName:{i.Lastname}%Email:{i.Email}%Member:Gold%Visted:{i.Visted}%MemberShipEndDate:{year}]");

                    // Checking if the current date is equal to the membership end date
                    if (currentDate == year)
                    {
                        // Stays a loyality member
                        sw.WriteLine($"[MemberID:{i.MemberID}%FirstName:{i.Firstname}%LastName:{i.Lastname}%Email:{i.Email}%Member:Loyality%Visted:{i.Visted}]");
                    }
                    // Adding the new data to the transaction.txt file if they are a Gold Member
                    var existingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();

                    string newData = $"{i.Firstname} {i.Lastname} (Gold)";

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
                // Closing the file
                sw.Close();
            }
            // if no stay in loyality scheme
            else if (SellMembership == "No")
            {
                Console.WriteLine("You Have Chosen Loyality Scheme");
            }
            else
            {
                // restarts the method if the input is not valid
                PostProcess();
            }
        }
    }
}
