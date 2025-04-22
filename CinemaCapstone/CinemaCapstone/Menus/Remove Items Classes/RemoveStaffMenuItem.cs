using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.Removeitems
{
    /// <summary>
    /// This class represents the menu item for removing staff members. Inhertits from ConsoleMenu.
    /// </summary>
    class RemoveStaffMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Creates the menu items for removing staff.
        /// </summary>
        public override void CreateMenuItems()
        {
            var Staffs = StaffParser.GetStaff();
            foreach (var staff in Staffs)
            {
                _menuItems.Add(new RemoveSelectStaffMenuItem(staff));
            }
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text for removing staff members.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Remove Staff";
        }
    }
}
