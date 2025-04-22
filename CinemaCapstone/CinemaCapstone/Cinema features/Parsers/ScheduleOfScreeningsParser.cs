using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features.Parsers
{
    /// <summary>
    /// This class is responsible for parsing the schedule of screenings from a file.
    /// </summary>
    public static class ScheduleOfScreeningsParser
    {
        // Path to the file containing schedule information
        private static string path = $@"{Environment.CurrentDirectory}/Resources/ScheduleOfScreenings.fs";

        /// <summary>
        /// This struct represents the schedule of data for screenings.
        /// </summary>
        public struct ScheduleOfData
        {
            public string Month;
            public string Day;
            public string Year;
            public string Time;
            public string Screening;
        }

        /// <summary>
        /// This method retrieves the schedules of screenings from the file and parses them into a list of ScheduleOfData objects.
        /// </summary>
        /// <returns></returns>
        public static List<ScheduleOfData> GetSchedules()
        {
            // Read all lines from the file and parse them into ScheduleOfData objects
            List<ScheduleOfData> ScheduleDataList = new List<ScheduleOfData>();

            // Read all lines from the file
            foreach (string line in File.ReadAllLines(path))
            {
                // Split the line into parts based on the '%' character and remove brackets
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new ScheduleOfData object and populate its properties based on the parsed parts
                ScheduleOfData Schedules = new ScheduleOfData();

                // Loop through each part and split it into key-value pairs
                foreach (string part in parts)
                {
                    // Split the part into key and value based on the ':' character
                    string[] keyValue = part.Split(':');

                    // Check if the key-value pair has exactly two elements
                    if (keyValue.Length == 2)
                    {
                        // Getting the Different Values from the file and storing it in the struct
                        switch (keyValue[0])
                        {
                            case "Month":
                                Schedules.Month = keyValue[1];
                                break;
                            case "Day":
                                Schedules.Day = keyValue[1];
                                break;
                            case "Year":
                                Schedules.Year = keyValue[1];
                                break;
                            case "Time":
                                Schedules.Time = keyValue[1];
                                break;
                            case "Screening":
                                Schedules.Screening = keyValue[1];
                                break;
                        }
                    }
                }
                // Adding the Data To the List
                ScheduleDataList.Add(Schedules);
            }
            // Returning the list of schedules
            return ScheduleDataList;
        }
    }
}
