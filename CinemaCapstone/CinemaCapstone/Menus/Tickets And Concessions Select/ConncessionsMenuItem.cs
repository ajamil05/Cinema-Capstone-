using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for selecting concessions. Inherting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class ConncessionsMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Displays the menu text for the concessions menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Concession";
        }
        /// <summary>
        /// Creates the menu items for the concessions menu.
        /// </summary>
        /// <returns></returns>
        public override void CreateMenuItems()
        {
            // Gets the list of concessions from the ConcessionParser
            var Concessions = ConcessionParser.GetConcession();

            // Loop through the concessions and add them to the menu
            foreach (var concession in Concessions)
            {
                _menuItems.Add(new ConcessionSelectMenuItem(concession));
            }
            // Adding Finalise Transaction Menu Item
            _menuItems.Add(new FinaliseTransactionMenuItem());

            // Adding The Exit Menu Item
            _menuItems.Add(new ExitMenuItem(this));
        }
    }
}
