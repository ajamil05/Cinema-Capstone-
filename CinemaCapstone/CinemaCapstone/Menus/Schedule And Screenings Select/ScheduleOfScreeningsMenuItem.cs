using Capstone.Cinema_features;
using Capstone.Cinema_features.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Cinema_features.Parsers.ScheduleOfScreeningsParser;
using static Capstone.Menus.ScheduleOfScreeningsMenuItem;
using static Capstone.Menus.ScheduleSelectmenuItem;

namespace Capstone.Menus
{
    /// <summary>
    /// This class represents the menu item for displaying the schedule of screenings.
    /// </summary>
    class ScheduleOfScreeningsMenuItem : ConsoleMenu
    {
        // file path for each different date of the schedule of screeenings
        private static string filePath2 = $@"{Environment.CurrentDirectory}\Resources\April,11,2025.fs";

        private static string filePath3 = $@"{Environment.CurrentDirectory}\Resources\April,10,2025.fs";

        private static string filePath4 = $@"{Environment.CurrentDirectory}\Resources\April,12,2025.fs";

        /// <summary>
        /// Creates the menu items for the schedule of screenings.
        /// </summary>
        public override void CreateMenuItems()
        {
            Console.WriteLine("Upcoming Screenings:");
            // Get the list of schedules from the ScheduleOfScreeningsParser
            var Scheduling = ScheduleOfScreeningsParser.GetSchedules();
            // Create a StreamWriter for each file path
            StreamWriter streamWriter1 = new StreamWriter(filePath4);

            StreamWriter streamWriter2 = new StreamWriter(filePath3);

            StreamWriter streamWriter3 = new StreamWriter(filePath2);
            // Loop through the schedules and add them to the menu. Adding the specific dates towards the specific files
            foreach (var item in Scheduling)
            {
                if (item.Day == "10")
                {
                    streamWriter2.WriteLine($"{item.Month} {item.Day}, {item.Year} at {item.Time} - Screening: {item.Screening}");
                }
                if (item.Day == "11")
                {
                    streamWriter3.WriteLine($"{item.Month} {item.Day}, {item.Year} at {item.Time} - Screening: {item.Screening}");
                }
                if (item.Day == "12")
                {
                    streamWriter1.WriteLine($"{item.Month} {item.Day}, {item.Year} at {item.Time} - Screening: {item.Screening}");
                }
                _menuItems.Add(new ScheduleSelectmenuItem(item));
            }
            _menuItems.Add(new ExitMenuItem(this));
            // Closing the files
            streamWriter1.Close();

            streamWriter2.Close();

            streamWriter3.Close();
        }
        /// <summary>
        /// Displays the menu text for the schedule of screenings.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Schedule Of Screenings";
        }
    }
}
