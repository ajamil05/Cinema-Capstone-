using Capstone.Cinema_features;
using Capstone.Cinema_features.Parsers;
using static Capstone.Menus.ScheduleOfScreeningsMenuItem;

namespace Capstone.Menus
{
    /// <summary>
    /// This class represents a menu item for selecting a schedule of screenings. It inherits from ConsoleMenu.
    /// </summary>
    class ScheduleSelectmenuItem : ConsoleMenu
    {
        // File paths for the seats and transaction files
        private static string filePath = $@"{Environment.CurrentDirectory}\Resources\Seats.txt";

        // File path for the transaction file
        private static string filePath1 = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        // Property to store the Seats Information
        private SeatsParser.SeatsInformation seatsInformation;

        // Property to store the schedule of screenings information
        private ScheduleOfScreeningsParser.ScheduleOfData schedule;

        /// <summary>
        /// Constructor for the ScheduleSelectmenuItem class.
        /// Setting the ScheduleOfScreeningsParser.ScheduleOfData object.
        /// </summary>
        /// <param name="scheduleOfData"></param>
        public ScheduleSelectmenuItem(ScheduleOfScreeningsParser.ScheduleOfData scheduleOfData)
        {
            schedule = scheduleOfData;
        }

        /// <summary>
        /// Displays the menu text for the schedule of screenings menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"{schedule.Month} {schedule.Day}, {schedule.Year} at {schedule.Time} - Screening {schedule.Screening}";
        }

        /// <summary>
        /// This method creates the menu items for selecting a schedule of screenings.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new TicketMenuItem(seatsInformation));
            _menuItems.Add(new ConncessionsMenuItem());
            _menuItems.Add(new ExitMenuItem(this));
        }

        /// <summary>
        /// This method retrieves the number of seats and adds them to the file.
        /// </summary>
        public override void PostProcess()
        {
            // Read existing data from the file
            var screening = ScreeningParser.GetScreens();

            // Initialize standard and premium seat counts
            int standard = 0;

            int premium = 0;

            // Read existing data from the file
            StreamWriter writer = new StreamWriter(filePath);

            // Loop through the screening data to find the matching screening
            foreach (var screen in screening)
            {
                // Check if the screening matches the selected schedule
                if (schedule.Screening == screen.Screen)
                {
                    standard = screen.StandardSeat;

                    premium = screen.PremiumSeat;
                }
            }
            // Write the seat information to the file
            writer.WriteLine($"[Screen:{schedule.Screening}%NumPremiumSeat:{premium}%NumStandardSeat:{standard}]");

            // Close the file
            writer.Close();

            // Read the Transaction.txt file
            var existingData = File.Exists(filePath1) ? File.ReadAllLines(filePath1) : Array.Empty<string>();

            // Prepare the new data to write
            string newData = $"{schedule.Month} {schedule.Day},{schedule.Year} {schedule.Time} - Screening {schedule.Screening}";

            // Check if the data already exists
            if (!existingData.Contains(newData))
            {
                // Append the new data only if it doesn't already exist
                using (StreamWriter streamWriter = new StreamWriter(filePath1, true))
                {
                    streamWriter.WriteLine(newData);
                }
            }
        }
    }
}
