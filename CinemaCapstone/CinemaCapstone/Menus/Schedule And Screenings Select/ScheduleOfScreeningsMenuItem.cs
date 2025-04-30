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

        /// <summary>
        /// Creates the menu items for the schedule of screenings.
        /// </summary>
        public override void CreateMenuItems()
        {
            Console.WriteLine("Upcoming Screenings:");
            // Get the list of schedules from the ScheduleOfScreeningsParser
            var Scheduling = ScheduleOfScreeningsParser.GetSchedules();

            
            // Create a StreamWriter for each file path

            // Loop through the schedules. Adding the specific dates towards the specific files
            foreach (var item in Scheduling)
            {
                string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

                string filePath = Path.Combine(folderPath, $"{item.Month}.{item.Day}.{item.Year}.fs");

                var existingData = File.Exists(filePath) ? File.ReadAllLines(filePath) : Array.Empty<string>();

                // Prepare the new data to write
                string newData = $"{item.Month} {item.Day}, {item.Year} at {item.Time} - Screening: {item.Screening}";

                // Check if the data already exists
                if (!existingData.Contains(newData))
                {
                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine(newData);
                    } 
                }
                _menuItems.Add(new ScheduleSelectmenuItem(item));
            }
            _menuItems.Add(new ExitMenuItem(this));
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
