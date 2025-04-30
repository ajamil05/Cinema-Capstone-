using System.ComponentModel.Design;

namespace Capstone.Cinema_features
{
    /// <summary>
    /// This class is responsible for parsing the name of the cinema from a text file.
    /// Static class to provide a method for retrieving the name.
    /// </summary>
    public static class NameParser
    {
        // Path to the text file containing the name data
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Name.txt";

        /// <summary>
        /// Struct representing the name data.
        /// </summary>
        public struct NameData
        {
            public string Name;
        }
        /// <summary>
        /// Method to retrieve the name data from the text file.
        /// </summary>
        /// <returns></returns>
        public static List<NameData> GetName()
        {
            // List to store the name data. type struct
            List<NameData> NameDataList = new List<NameData>();

            // Read all lines from the file and process each line
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Length < line.Trim('[', ']').Length)
                {
                    Exception();
                }
                // Split the line into parts using '%' as a delimiter and trim the brackets
                string parts = line.Trim('[', ']');

                // Create a new instance of NameData for each line
                NameData Name = new NameData();

                // Process each part of the line

                // Split the part into key-value pairs using ':' as a delimiter
                string[] keyValue = parts.Split(':');

                // Check if the key-value pair has exactly two elements
                if (keyValue.Length == 2)
                {
                    // Gets the Name data from the file
                    switch (keyValue[0])
                    {
                        case "Name":
                            Name.Name = keyValue[1];
                            break;
                    }

                }
                else
                {
                    Exception();
                }
                // Add the processed NameData to the list
                NameDataList.Add(Name);
            }
            // Return the list of NameData
            return NameDataList;
        }
        /// <summary>
        /// Method to handle exceptions when the format of the data is invalid.
        /// </summary>
        private static void Exception()
        {
            Console.WriteLine("Invalid Formatt:[Name:{NAME}]");
            Environment.Exit(0);
        }
    }
}
