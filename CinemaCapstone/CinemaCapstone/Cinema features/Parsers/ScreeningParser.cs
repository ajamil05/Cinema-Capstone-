using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Cinema_features.StaffParser;

namespace Capstone.Cinema_features
{
    /// <summary>
    /// This class is responsible for parsing the screening information from a file.
    /// Static class ScreeningParser that contains methods to read and parse screening data.
    /// </summary>
    public static class ScreeningParser
    {
        // Path to the Screening file
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Screening.txt";

        /// <summary>
        /// Struct representing the different data types of a screen.
        /// </summary>
        public struct Screens
        {
            public string Screen;
            public int PremiumSeat;
            public int StandardSeat;
        }
        /// <summary>
        /// This method reads the screening data from a file and parses it into a list of Screens objects.
        /// </summary>
        /// <returns></returns>
        public static List<Screens> GetScreens()
        {
            // List to store the parsed screen data
            List<Screens> ScreenManager = new List<Screens>();

            // Read all lines from the file and iterate through each line
            foreach (string line in File.ReadAllLines(path))
            {
                // Trim the line and remove the brackets, then split by '%'
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new Screens object to store the parsed data
                Screens Screen = new Screens();

                // Iterate through each part of the line and parse the key-value pairs
                foreach (string part in parts)
                {
                    // Split the part by ':' to get the key and value
                    string[] keyValue = part.Split(':');

                    // Check if the keyValue array has exactly 2 elements (key and value)
                    if (keyValue.Length == 2)
                    {
                        // Initialize the Screen objects based on the key
                        switch (keyValue[0])
                        {
                            case "Screen":
                                Screen.Screen = keyValue[1];
                                break;
                            case "NumPremiumSeat":
                                Screen.PremiumSeat = int.Parse(keyValue[1]);
                                break;
                            case "NumStandardSeat":
                                Screen.StandardSeat = int.Parse(keyValue[1]);
                                break;
                        }
                    }
                }
                // Add the parsed Screen object to the list
                ScreenManager.Add(Screen);
            }
            // Return the list of parsed screens
            return ScreenManager;
        }
    }
}
