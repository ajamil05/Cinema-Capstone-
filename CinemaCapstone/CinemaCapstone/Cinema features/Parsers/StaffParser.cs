using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Menus.MenuItem;

namespace Capstone.Cinema_features
{
    /// <summary>
    /// This class is responsible for parsing the staff information from a text file.
    /// It's Static and contains a method to retrieve a list of staff members.
    /// </summary>
    public static class StaffParser
    {
        /// <summary>
        /// This struct represents a staff member with properties for StaffID, Level, FirstName, and LastName.
        /// </summary>
        public struct Staff
        {
            public string StaffID;
            public string Level;
            public string FirstName;
            public string LastName;
        }
        // Path to the file containing staff information
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Staff.txt";
        /// <summary>
        /// This method reads the staff information from the file and returns a list of Staff objects.
        /// </summary>
        /// <returns></returns>
        public static List<Staff> GetStaff()
        {
            // Read all lines from the file and parse them into a list of Staff objects
            List<Staff> StaffManagerList = new List<Staff>();

            // Read all lines from the file
            foreach (string line in File.ReadAllLines(path))
            {
                // Split the line into parts using '%' as a delimiter and trim the brackets
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new Staff object and populate its properties based on the parsed parts
                Staff Staff = new Staff();

                // Loop through each part and split it into key-value pairs
                foreach (string part in parts)
                {
                    // Split the part into key and value using ':' as a delimiter
                    string[] keyValue = part.Split(':');

                    // Check if the keyValue array has exactly 2 elements
                    if (keyValue.Length == 2)
                    {
                        // Retriving the StaffID, Level, FirstName, and LastName from the keyValue array
                        switch (keyValue[0])
                        {
                            case "Staff":
                                Staff.StaffID = keyValue[1];
                                break;
                            case "Level":
                                Staff.Level = keyValue[1];
                                break;
                            case "FirstName":
                                Staff.FirstName = keyValue[1];
                                break;
                            case "LastName":
                                Staff.LastName = keyValue[1];
                                break;
                        }
                    }
                }
                // Add the populated Staff object to the list
                StaffManagerList.Add(Staff);
            }
            // Return the list of Staff objects
            return StaffManagerList;
        }
    }
}
