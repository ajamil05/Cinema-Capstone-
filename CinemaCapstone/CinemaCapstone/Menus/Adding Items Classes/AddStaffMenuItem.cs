using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.AddClasses
{
    /// <summary>
    /// Represents a menu item for adding staff, inheriting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class AddStaffMenuItem : ConsoleMenu
    {
        // File path for the staff file
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Staff.txt";

        /// Create the menu items for adding staff.
        public override void CreateMenuItems()
        {

        }
        /// <summary>
        /// Displays the menu text for adding staff.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Add Staff";
        }
        /// <summary>
        /// Prompts the user to input staff information and writes it to a file.
        /// </summary>
        public override void PostProcess()
        {
            // Unqiue Staff ID
            Random random = new Random();

            int value = random.Next(0, 1000000);

            // List of staff levels
            List<string> StaffLevel = new List<string>() {"Manager", "General"};

            // Open the file for appending
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                // Prompt for staff information Firstname and Lastname.
                Console.WriteLine("Enter Firstname:");

                string firstname = Console.ReadLine();

                Console.WriteLine("Enter Suraname");

                string lastname = Console.ReadLine();

                // Choose a Staff Level
                for (int j = 0; j < StaffLevel.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {StaffLevel[j]}");
                }

                // Using the ConsoleHelpers to get a valid input for Staff Level
                int valueToAdd = ConsoleHelpers.GetIntegerInRange(1, StaffLevel.Count);

                string Stafflevel = string.Empty;

                // Depdending on the valueToAdd the staff level is set to either Manager or General
                if (valueToAdd == 1)
                {
                    Stafflevel = StaffLevel[0];
                }
                else if (valueToAdd == 2)
                {
                    Stafflevel = StaffLevel[1];
                }
                // Validating the input for Firstname and Lastname. If not valid input restarts the method
                bool Num = int.TryParse(firstname, out int i1);

                bool Num2 = int.TryParse(lastname, out int i2);

                if (Num == true && Num2 == true)
                {
                    PostProcess();
                }
                // Write the staff information to the file
                sw.WriteLine($"[Staff:{value}%Level:{Stafflevel}%FirstName:{firstname}%LastName:{lastname}]");
            }
        }
    }
}
