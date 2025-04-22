using Capstone.Cinema_features;
using Capstone.Cinema_features.Total_Price_Of_Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.Menus
{
    class TicketSelectMenuItem : ConsoleMenu
    {
        // Getting the ticket data from the TicketParser
        private TicketParser.TicketData Tickets { get; }

        // Getting the screening data from the ScreeningParser
        private ScreeningParser.Screens Screen;

        // Getting the seats data from the SeatsParser
        private SeatsParser.SeatsInformation Seats;

        // Varaible stroing the rating as a string
        private string Rating;

        // Path to the Transaction file
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        // Property to store the Tickets Input
        private int ValueToAdd { get; set; }

        // Constructor for the TicketSelectMenuItem class Setting the TicketData, SeatsInformation and Rating
        public TicketSelectMenuItem(TicketParser.TicketData tickeT, SeatsParser.SeatsInformation seats, string rating)
        {
            Tickets = tickeT;
            Seats = seats;
            Rating = rating;
        }
        // Calling The UpdateSeatsAndInputAge method to update the seats and input age Inside the CreateMenuItems method
        public override void CreateMenuItems()
        {
            
        }
        /// <summary>
        /// Method to display the menu text to select a ticket type
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"{Tickets.Tickettype}:{Tickets.Price}";
        }
        /// <summary>
        /// Taking Input For The Number Of Seats In the specific screening and age of the customer
        /// </summary>
        public override void PostProcess()
        {
            // Idetifying the path to the Transaction file
            StreamWriter streamWriter1 = new StreamWriter(path, true);

            //Getting the seats data from the SeatsParser
            var seats = SeatsParser.GetSeats();

            // Looping through the seats to get the number of standard and premium seats
            foreach (var seat in seats)
            {
                // Checking what type of ticket it is then asking how many tickets you want depedning on the screening selected
                if (Tickets.Tickettype == "Standard")
                {  
                    ValueToAdd = ConsoleHelpers.GetIntegerInRange(0, seat.NumStandardSeats);
                }
                if (Tickets.Tickettype == "Premium")
                {
                    ValueToAdd = ConsoleHelpers.GetIntegerInRange(0, seat.NumPremiumSeats);
                }
            }
            // Input for Age depending on the rating of the movie
            ConsoleHelpers.AgeInput(ValueToAdd, Rating);

            // Writing the ticket type and the number of tickets to the Transaction file
            streamWriter1.WriteLine($"{Tickets.Tickettype}:{ValueToAdd}");

            streamWriter1.Close();

            //Checking If Data Already Exits In the file
            var existingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();

            // Prepare the new data to write
            string newData = $"{Tickets.Tickettype}:{ValueToAdd}";

            // Check if the data already exists
            if (!existingData.Contains(newData))
            {
                // Append the new data only if it doesn't already exist
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.WriteLine(newData);
                }
            }
            
        }
    }
}
