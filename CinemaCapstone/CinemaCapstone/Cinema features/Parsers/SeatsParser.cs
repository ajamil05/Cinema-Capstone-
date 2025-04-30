using static Capstone.Cinema_features.ScreeningParser;

namespace Capstone.Cinema_features
{
    /// <summary>
    /// This class is responsible for parsing and managing seat information for movie screenings.
    /// Static class SeatsParser that provides methods to read, write, and update seat information in a file.
    /// </summary>
    public static class SeatsParser
    {
        // Path to the Seats file
        private static string filePath = $@"{Environment.CurrentDirectory}\Resources\Seats.txt";

        /// <summary>
        /// Structure to hold information about seats for a specific screening.
        /// </summary>
        public struct SeatsInformation
        {
            public string Screening; 
            public int NumPremiumSeats;
            public int NumStandardSeats;
        }
        /// <summary>
        /// Updates the seat information for a specific screening.
        /// </summary>
        /// <param name="Screen"></param>
        /// <param name="NumberOfPremium"></param>
        /// <param name="NumberOfStandard"></param>
        public static void UpdateSeats(string Screen, int NumberOfPremium, int NumberOfStandard)
        {
            // Read existing data from the file
            var seats = SeatsParser.GetSeats(); 

            // Initaitng a flag
            bool ScreenHasUpdated = false; 

            // Running through the seats data
            foreach ( var seat in seats)
            {
                // Checking if the screen is already in the file
                if (Screen == seat.Screening)
                {
                    // Updating the number of seats
                    NumberOfPremium = seat.NumPremiumSeats;
                    NumberOfStandard = seat.NumStandardSeats;
                    ScreenHasUpdated = true;
                }
            }
            // If the screen has not been updated, add a new entry
            if (ScreenHasUpdated == false)
            {
                var newScreen = new SeatsInformation { 
                    Screening = Screen,
                    NumPremiumSeats = NumberOfPremium,
                    NumStandardSeats = NumberOfStandard
                };
                // Adding the new screen to the list
                seats.Add(newScreen);
            }
            // Write the updated data back to the file
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine($"[Screen:{Screen}%NumPremiumSeat:{NumberOfPremium}%NumStandardSeat:{NumberOfStandard}]");
            writer.Close();
        }

        /// <summary>
        /// Retrieves seat information for a specific screening.
        /// </summary>
        /// <param name="Screen"></param>
        /// <returns></returns>
        public static SeatsInformation GetSeat(string Screen)
        {
            return GetSeats().Where(x => x.Screening == Screen).FirstOrDefault();
        }
        /// <summary>
        /// Retrieves a list of all seat information from the file.
        /// </summary>
        /// <returns></returns>
        public static List<SeatsInformation> GetSeats()
        {
            // Varaible List to store the seat information
            List<SeatsInformation> seats = new List<SeatsInformation>();

            // Reading all lines from the file
            foreach (string line in File.ReadAllLines(filePath))
            {
                if (line.Length < line.Trim('[', ']').Length)
                {
                    Exception();
                }
                // Splitting the line by '%' and removing the brackets
                string[] parts = line.Trim('[', ']').Split('%');

                // Creating a new SeatsInformation object
                SeatsInformation Seats = new SeatsInformation();

                // Looping through the parts to extract seat information
                foreach (string part in parts)
                {
                    // Splitting each part by ':'
                    string[] keyValue = part.Split(':');

                    // Checking if the keyValue array has two elements
                    if (keyValue.Length == 2)
                    {
                        // Assigning values to the SeatsInformation object based on the key
                        switch (keyValue[0])
                        {
                            case "Screen":
                                Seats.Screening = keyValue[1];
                                break;
                            case "NumPremiumSeat":
                                Seats.NumPremiumSeats = int.Parse(keyValue[1]);
                                break;
                            case "NumStandardSeat":
                                Seats.NumStandardSeats = int.Parse(keyValue[1]);
                                break;
                        }
                    }
                }
                // Adding the SeatsInformation object to the list
                seats.Add(Seats);
            }
            // Returning the list of seats
            return seats;
        }
        /// <summary>
        /// This method is called when the file format is invalid.
        /// </summary>
        private static void Exception()
        {
            Console.WriteLine("Invalid Formatt:[Screen:{SCREEN} NumPremiumSeat:{NUMBEROFPREMIUMSEATS} NumStandardSeat:{NUMBEROFSTANDARDSEATS}]");
            Environment.Exit(0);
        }
    }
}
