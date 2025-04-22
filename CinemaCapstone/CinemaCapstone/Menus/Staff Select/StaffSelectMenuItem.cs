using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Cinema_features.StaffParser;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for selecting a General staff member, inheriting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class StaffSelectMenuItem : ConsoleMenu 
    {
        // Initializes the Staffmanager Property as a Staff Parser Object.
        private StaffParser.Staff StaffManager { get; }

        /// <summary>
        /// Constructor for the <see cref="StaffSelectMenuItem"/> class.
        /// Setting The StaffManager Property as a Staff Parser Object.
        /// </summary>
        /// <param name="staffManager"></param>
        public StaffSelectMenuItem(StaffParser.Staff staffManager)
        {
            StaffManager = staffManager;
        }

        /// <summary>
        /// Creates the menu by adding menu items.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new TransactionMenuItem(StaffManager));
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text for the General staff member.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"{StaffManager.StaffID} {StaffManager.Level} {StaffManager.FirstName} {StaffManager.LastName}";
        }
    }
}
