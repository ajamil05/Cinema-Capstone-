﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features
{
    /// <summary>
    /// This class is responsible for parsing concession data from a text file.
    /// </summary>
    public static class ConcessionParser
    {
        // Path to the file containing concession information
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Concessions.txt";

        /// <summary>
        /// This struct represents the concession data. It contains two properties: Concession and Price.
        /// </summary>
        public struct ConcessionData
        {
            public string Concession;
            public string Price;
        }

        /// <summary>
        /// This method reads the concession data from the file and returns a list of ConcessionData objects.
        /// </summary>
        /// <returns></returns>
        public static List<ConcessionData> GetConcession()
        {
            // List to hold the concession data
            List<ConcessionData> ConcessionDataList = new List<ConcessionData>();

            // Read all lines from the file
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Length < line.Trim('[', ']').Length)
                {
                    Exception();
                }
                // Split the line into parts based on the '%' character and trim the brackets
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new ConcessionData object and populate it with the parsed data
                ConcessionData Concessions = new ConcessionData();

                // Loop through each part and split it into key-value pairs
                foreach (string part in parts)
                {
                    // Split the part into key and value based on the ':' character
                    string[] keyValue = part.Split(':');

                    // Check if the keyValue array has exactly two elements
                    if (keyValue.Length == 2)
                    {
                        if (keyValue[0] == "Concession")
                        {
                            Concessions.Concession = keyValue[1];
                        }
                        else if (keyValue[0] == "Price")
                        {
                            Concessions.Price = keyValue[1];
                        }
                        else
                        {
                            Exception();
                        }
                    }
                    else
                    {
                        Exception();
                    }
                }
                // Add the populated ConcessionData object to the list
                ConcessionDataList.Add(Concessions);
            }
            // Return the list of ConcessionData objects
            return ConcessionDataList;
        }
        /// <summary>
        /// This method handles the exception when the format of the concession data is invalid.
        /// </summary>
        private static void Exception()
        {
            Console.WriteLine("Invalid Formatt:[Concession:CONCESSION%Price:PRICE]");
            Environment.Exit(0);
        }
    }
}
