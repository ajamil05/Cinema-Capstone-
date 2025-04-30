using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features.Parsers
{
    /// <summary>
    /// This class is responsible for parsing membership data from a text file.
    /// Static class to provide a method for retrieving membership data.
    /// </summary>
    public static class MemberShipParser
    {
        /// Path to the membership data file
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Membership.txt";

        /// <summary>
        /// Struct to hold membership data.
        /// </summary>
        public struct MembershipData
        {
            public string MembershipEndDate;
            public string MemberID; 
            public string Firstname;
            public string Lastname;
            public string Email;
            public string Member;
            public string Visted;
        }

        /// <summary>
        /// Method to retrieve membership data from the file.
        /// </summary>
        /// <returns></returns>
        public static List<MembershipData> GetMemberShip()
        {
            // List to hold membership data
            List<MembershipData> MemberShipDataList = new List<MembershipData>();

            // Read all lines from the file and parse each line
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Length < line.Trim('[', ']').Length)
                {
                    Exception();
                }
                // Split the line into parts based on the delimiter '%' and remove brackets
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new MembershipData object
                MembershipData MemberShip = new MembershipData();

                // Parse each part
                foreach (string part in parts)
                {
                    // Split each part into key-value pairs based on the delimiter ':'
                    string[] keyValue = part.Split(':');

                    // Check if the keyValue array has exactly 2 elements
                    if (keyValue.Length == 2)
                    {
                        // Assign values to the MembershipData object based on the key
                        switch (keyValue[0])
                        {
                            case "MemberID":
                                MemberShip.MemberID = keyValue[1];
                                break;
                            case "Firstname":
                                MemberShip.Firstname = keyValue[1];
                                break;
                            case "Lastname":
                                MemberShip.Lastname = keyValue[1];
                                break;
                            case "Email":
                                MemberShip.Email = keyValue[1];
                                break;
                            case "Member":
                                MemberShip.Member = keyValue[1];
                                break;
                            case "Visted":
                                MemberShip.Visted = keyValue[1];
                                break;
                            case "MemberShipEndDate":
                                MemberShip.MembershipEndDate = keyValue[1];
                                break;
                        }
                    }
                    else
                    {
                        Exception();
                    }
                }
                // Add the parsed MembershipData object to the list
                MemberShipDataList.Add(MemberShip);
            }
            // Return the list of membership data
            return MemberShipDataList;
        }
        /// <summary>
        /// Method to handle exceptions when parsing the membership data.
        /// </summary>
        private static void Exception()
        {
            Console.WriteLine("Invalid Formatt:[MemberID:{MEMBERID} Firstname:{FIRSTNAME} Lastname:{LASTNAME} Email:{EMAIL ADDRESS} Member:{MEMBER} Visted:{VISTED}]");
            Environment.Exit(0);
        }
    }
}
