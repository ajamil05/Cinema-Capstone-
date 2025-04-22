using Capstone.Cinema_features;
using Capstone.Cinema_features.Parsers;
using Capstone.Menus.MemberShip_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// This class represents the membership menu item. It inherits from ConsoleMenu.
    /// </summary>
    class MemberShipMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Creates the menu items for the membership menu.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new LoyalityMemberShipMenuItem());
            _menuItems.Add(new GoldMembershipMenuItem());
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text for the membership menu.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Membership";
        }

       
    }
}
