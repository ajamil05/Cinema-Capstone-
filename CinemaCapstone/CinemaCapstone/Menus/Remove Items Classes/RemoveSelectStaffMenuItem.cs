using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.Removeitems
{
    /// <summary>
    /// This class represents the menu item for removing staff members. Inherits from ConsoleMenu.
    /// </summary>
    class RemoveSelectStaffMenuItem : ConsoleMenu
    {
        /// Path to the file containing staff information
        private string path = $@"{Environment.CurrentDirectory}\Resources\Staff.txt";

        /// StaffParser.Staff object representing the staff member to be removed
        private StaffParser.Staff Staff { get; }

        /// <summary>
        /// Constructor for the RemoveSelectStaffMenuItem class.
        /// Setting the staff member to be removed.
        /// </summary>
        /// <param name="staff"></param>
        public RemoveSelectStaffMenuItem(StaffParser.Staff staff)
        {
            Staff = staff;
        }
        /// <summary>
        /// This method creates the menu items for removing staff members. Removing staff members.
        /// </summary>
        public override void PostProcess()
        {
            // Temporary storage for updated content
            List<string> updatedLines = new List<string>();

            // Read the file line by line
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Check if the line matches the selected staff
                    if (!line.Contains(Staff.FirstName) || !line.Contains(Staff.StaffID.ToString()))
                    {
                        updatedLines.Add(line); // Keep lines that don't match
                    }
                }
            }

            // Write the updated content back to the file
            using (StreamWriter sw = new StreamWriter(path, false)) // Overwrite the file
            {
                foreach (string updatedLine in updatedLines)
                {
                    sw.WriteLine(updatedLine);
                }
            }
            // Display a message indicating the staff has been removed
            Console.WriteLine($"Staff {Staff.FirstName} has been removed.");
        }
        /// <summary>
        /// Displays the menu text for removing staff members.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"Remove Staff: {Staff.FirstName}";
        }

        public override void CreateMenuItems()
        {
            
        }
    }
}
