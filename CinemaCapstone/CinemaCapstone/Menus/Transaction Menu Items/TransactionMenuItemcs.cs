using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for starting a transaction Inherting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class TransactionMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Constructor for the <see cref="TransactionMenuItem"/> class.
        /// Setting The Staff Property as a Staff Parser Object.
        /// </summary>
        /// <param name="staff"></param>
        public TransactionMenuItem(StaffParser.Staff staff)
        {
            Staff = staff;
        }

        public StaffParser.Staff Staff { get; }

        /// <summary>
        /// Creates the menu by adding menu items.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new ScheduleOfScreeningsMenuItem());
            _menuItems.Add(new MemberShipMenuItem());
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text To Start a Transaction.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"Start a Transaction";
        }

    }
}
