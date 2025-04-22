using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Cinema_features;

namespace Capstone.Menus.Removeitems
{
    /// <summary>
    /// This class represents the menu item for removing concessions. Inherits from ConsoleMenu.
    /// </summary>
    class RemoveConcessionsMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Creates the menu items for removing concessions.
        /// </summary>
        public override void CreateMenuItems()
        {
            var Concessions = ConcessionParser.GetConcession();
            foreach (var concession in Concessions)
            {
                _menuItems.Add(new RemoveSelectConcessionsMenuItem(concession));
            }
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text for removing concessions.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Remove Concessions";
        }
    }
}
