using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class MovieMenuItem : ConsoleMenu 
    {
        private MovieParser.MovieData Movies { get; }

        SeatsParser.SeatsInformation seat;

        private TicketParser.TicketData ticket;

        private static string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";
        public MovieMenuItem(MovieParser.MovieData Movie, SeatsParser.SeatsInformation seats)
        {
            Movies = Movie;
            seat= seats;
        }
        /// <summary>
        /// Creates the menu items for the movie menu.
        /// </summary>
        public override void CreateMenuItems()
        {
            var Ticket = TicketParser.GetTickets();

            foreach (var ticket in Ticket)
            {
                _menuItems.Add(new TicketSelectMenuItem(ticket, seat, Movies.Rating));
            }
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text for the movie menu item. Allowing You To Select A Movie To Watch
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"{Movies.Movie}:{Movies.Length} {Movies.Genre} {Movies.Rating}";
        }

        public override void PostProcess()
        {
            // Read existing data from the file
            var existingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();
            // Prepare the new data to write
            string newData = $"{Movies.Movie} Length {Movies.Length} {Movies.Genre} {Movies.Rating}++";
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
