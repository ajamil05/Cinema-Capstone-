using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Menus.MenuItem;

namespace Capstone.Menus
{
    /// <summary>
    /// This class is responsible for parsing ticket data from a file.
    /// Its Static and contains a method to retrieve ticket information.
    /// </summary>
    public static class TicketParser
    {
        // Path to the Ticket file
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Ticket.txt";

        // a struct to hold ticket data
        public struct TicketData
        {
            public string Tickettype;
            public int Price;
        }
        /// <summary>
        /// a Method to get the ticket data from the Ticket file
        /// </summary>
        /// <returns></returns>
        public static List<TicketData> GetTickets()
        {
            // Varaible for the ticket data
            List<TicketData> ticketDataList = new List<TicketData>();

            // Read all lines from the Ticket file
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Length < line.Trim('[', ']').Length)
                {
                    Exception();
                }
                // Split the line into parts using the '%' character and remove the brackets
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new TicketData object and populate it with the parsed data
                TicketData ticketData = new TicketData();

                // Loop through each part and split it into key-value pairs
                foreach (string part in parts)
                {
                    // Split the part into key-value pairs using the ':' character
                    string[] keyValue = part.Split(':');

                    // Check if the key-value pair has exactly two elements
                    if (keyValue.Length == 2)
                    {
                        // Assign the values to the TicketData object based on the key
                        switch (keyValue[0])
                        {
                            case "Ticket":
                                ticketData.Tickettype = keyValue[1];
                                break;
                            case "Price":
                                ticketData.Price = int.Parse(keyValue[1]);
                                break;
                        }
                    }
                    else
                    {
                        Exception();
                    }
                }
                // Add the populated TicketData object to the list
                ticketDataList.Add(ticketData);
            }
            // Return the list of ticket data
            return ticketDataList;
        }
        private static void Exception()
        {
            Console.WriteLine("Invalid Formatt:[Ticket:{TICKETTYPE} Price:{PRICE}]");
            Environment.Exit(0);
        }
    }
}
        
