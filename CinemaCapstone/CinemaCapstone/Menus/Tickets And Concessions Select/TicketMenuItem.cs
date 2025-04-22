using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// This class represents the ticket menu item in the console menu.
    /// </summary>
    class TicketMenuItem : ConsoleMenu
    {
        // The SeatsParser.SeatsInformation object that holds the seat information.
        private SeatsParser.SeatsInformation Seats;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketMenuItem"/> class with the specified seat information.
        /// </summary>
        /// <param name="seats"></param>
        public TicketMenuItem(SeatsParser.SeatsInformation seats)
        {
            Seats = seats;
        }
        /// <summary>
        /// Displays the menu text for the ticket menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Ticket";
        }
        /// <summary>
        /// Creates the menu items for the ticket menu.
        /// </summary>
        public override void CreateMenuItems()
        {
            // Get the list of movies from the MovieParser
            var Movies = MovieParser.GetMovies();

            // Loop through the movies and add them to the menu
            foreach (var movie in Movies)
            {
                _menuItems.Add(new MovieMenuItem(movie, Seats));
            }
            // Adding The Exit Menu Item
            _menuItems.Add(new ExitMenuItem(this));
        }
    }
}

