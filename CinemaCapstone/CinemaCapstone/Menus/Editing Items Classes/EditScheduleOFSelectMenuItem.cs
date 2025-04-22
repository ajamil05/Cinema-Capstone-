using Capstone.Cinema_features;
using Capstone.Cinema_features.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Capstone.Menus.Editing_Items_Classes
{
    /// <summary>
    /// Edits the schedule of screenings menu item. Inherits from ConsoleMenu.
    /// </summary>
    class EditScheduleOFSelectMenuItem : ConsoleMenu
    {
        // Path to the file containing schedule information
        private string path = $@"{Environment.CurrentDirectory}/Resources/ScheduleOfScreenings.fs";

        private static string path1 = $@"{Environment.CurrentDirectory}/Resources/Seats.txt";

        // ScheduleOfScreeningsParser.ScheduleOfData object representing the schedule to be edited
        private ScheduleOfScreeningsParser.ScheduleOfData schedule;

        /// <summary>
        /// Constructor for the EditScheduleOFSelectMenuItem class.
        /// Setting the ScheduleOfScreeningsParser.ScheduleOfData object to be edited.
        /// </summary>
        /// <param name="Schedule"></param>
        public EditScheduleOFSelectMenuItem(ScheduleOfScreeningsParser.ScheduleOfData Schedule)
        {
            schedule = Schedule;
        }

        /// <summary>
        /// Displays the menu text for the edit schedule menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"Edit Schedule: {schedule.Month} {schedule.Day}, {schedule.Year} at {schedule.Time} - Screening: {schedule.Screening}";
        }

        /// <summary>
        /// This method creates the menu items for editing the schedule of screenings.
        /// </summary>
        public override void PostProcess()
        {
            // Read existing data from the file
            var screening = ScreeningParser.GetScreens();

            // Initialize standard and premium seat counts
            int standard = 0;

            int premium = 0;

            // Read existing data from the file
            StreamWriter writer = new StreamWriter(path1);

            // Loop through the screening data to find the matching screening
            foreach (var screens in screening)
            {
                // Check if the screening matches the selected schedule
                if (schedule.Screening == screens.Screen)
                {
                    standard = screens.StandardSeat;

                    premium = screens.PremiumSeat;
                }
            }
            // Write the seat information to the file
            writer.WriteLine($"[Screen:{schedule.Screening}%NumPremiumSeat:{premium}%NumStandardSeat:{standard}]");

            // Closing The File
            writer.Close();

            // Prompts the user for Screening Input and Time Input
            Console.WriteLine("Enter a Screen A, B Or C");

            string screen = Console.ReadLine();

            Console.WriteLine("Input Hours e.g(24)");

            int Hours = 0;
            // Try to parse the input for hours
            try
            {
                Hours = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("invalid");

                PostProcess();
            }
            Console.WriteLine("Input Minutes e.g(60)");

            int Minutes = 0;
            // Try to parse the input for minutes
            try
            {
                Minutes = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("invalid");

                PostProcess();
            }
            // Adding Minutes For Trailers
            Minutes = Minutes + 20;

            // Validate the input for screen
            if (screen != "A" && screen != "B" && screen != "C")
            {
                PostProcess();
            }
            // Validate the input for hours and minutes
            if (Hours < 0 || Hours > 24 && Minutes < 0 || Minutes > 60)
            {
                PostProcess();
            }
            // Combinding Hours and Minutes Into a String
            string Time = $"{Hours} {Minutes}";

            // Check if the screen and time match the schedule
            if (screen == schedule.Screening && Time == schedule.Time)
            {
                PostProcess();
            }
            // Getting retirivng data from Seats.txt file using parser. 
            var seats = SeatsParser.GetSeats();
            // Looping through the seats to get the number of standard and premium seats
            foreach (var i in seats)
            {
                // Calculating Total Number of Seats For Specific Screening
                int TotalSeats = i.NumStandardSeats + i.NumPremiumSeats;

                // Checking the TurnAround Times for the different total seats in the theatre
                if (TotalSeats <= 50)
                {
                    Minutes = Minutes + 15;
                }
                else if (TotalSeats >= 51 && TotalSeats <= 100)
                {
                    Minutes = Minutes + 30;
                }
                else if (TotalSeats > 100)
                {
                    Minutes = Minutes + 45;
                }
                // if the minutes are greater than 60, increment the hours and adjust the minutes
                if (Minutes > 60)
                {
                    Hours = Hours + 1;

                    Minutes = Minutes - 60; 
                }
            }
            // Reading all lines from the file converting into a list
            var lines = File.ReadAllLines(path).ToList();

            // ReIdentifying the time so that the hours and minutes would update after the TurnAround Times.
            Time = $"{Hours} {Minutes}";

            // Find the line to replace
            string oldLine = $"[Month:{schedule.Month}%Day:{schedule.Day}%Year:{schedule.Year}%Time:{schedule.Time}%Screening:{schedule.Screening}]";
            string newLine = $"[Month:{schedule.Month}%Day:{schedule.Day}%Year:{schedule.Year}%Time:{Time}%Screening:{screen}]";

            // Find the index of the line to replace
            int index = lines.FindIndex(line => line == oldLine);

            // If the line is found
            if (index != -1)
            {
                // Replace the line
                lines[index] = newLine;

                // Write the updated lines back to the file
                File.WriteAllLines(path, lines);

                Console.WriteLine("Schedule updated successfully.");
            }
        }

        public override void CreateMenuItems()
        {

        }
    }
}





