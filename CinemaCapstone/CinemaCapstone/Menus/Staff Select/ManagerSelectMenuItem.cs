using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Cinema_features;
using Capstone.Menus.AddClasses;
using Capstone.Menus.Editing_Items_Classes;
using Capstone.Menus.Editing_Items_Classes.Capstone.Menus.Editing_Items_Classes;
using Capstone.Menus.Removeitems;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for selecting a Manager staff member, inheriting from <see cref="StaffSelectMenuItem"/>.
    /// </summary>
    internal class ManagerSelectMenuItem : StaffSelectMenuItem
    {
        /// <summary>
        /// Constructor for the <see cref="ManagerSelectMenuItem"/> class.
        /// Inhertits the staffManager Property from the StaffSelectMenuItem class.
        /// </summary>
        /// <param name="staffManager"></param>
        public ManagerSelectMenuItem(StaffParser.Staff staffManager) : base(staffManager)
        {

        }
        /// <summary>
        /// Creates the menu by adding menu items specific to the Manager role.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new EditScheduleofScreeningsMenuItem());
            _menuItems.Add(new AddStaffMenuItem());
            _menuItems.Add(new RemoveStaffMenuItem());
            _menuItems.Add(new AddconcessionMenuItem());
            _menuItems.Add(new RemoveConcessionsMenuItem());
            _menuItems.Add(new EditConcessionMenuItem());
            base.CreateMenuItems();
        }
    }
}
