using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.Editing_Items_Classes
{
    /// <summary>
    /// This class represents the EditConcessionMenuItem. It inherits from ConsoleMenu.
    /// </summary>
    class EditConcessionMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Create the menu items for editing concessions.
        /// </summary>
        public override void CreateMenuItems()
        {
            var Concessions = ConcessionParser.GetConcession();
            foreach (var concession in Concessions)
            {
                _menuItems.Add(new EditConcessionSelectMenuItem(concession));
            }
            _menuItems.Add(new ExitMenuItem(this));
        }

        /// <summary>
        /// Displays the menu text for editing concessions.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Edit Concessions";
        }
    }
}
