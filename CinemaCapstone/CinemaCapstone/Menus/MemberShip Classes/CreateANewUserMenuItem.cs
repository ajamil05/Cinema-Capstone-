using Capstone.Cinema_features.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.MemberShip_Classes
{
    internal class CreateANewUserMenuItem : ConsoleMenu
    {
        private string filepath = $@"{Environment.CurrentDirectory}\Resources\Membership.txt";


        /// <summary>
        /// This method creates the menu items for creating a new user.
        /// </summary>
        public override void CreateMenuItems()
        {
            
        }

        /// <summary>
        /// This method displays the menu text for creating a new user.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"Create a Loyality Member";
        }

        /// <summary>
        /// This method handles the process of creating a new user. It prompts the user for input and validates it.
        /// </summary>
        public override void PostProcess()
        {
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
            var Loyality = MemberShipParser.GetMemberShip();

            int Visted = 1;

            // Checking if member already exists in the file if they do increments the amount of time they have visted by 1. 
            using (StreamWriter sw = new StreamWriter(filepath, true))
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
