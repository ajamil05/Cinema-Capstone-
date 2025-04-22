using Capstone.Cinema_features;
using System.Diagnostics;

namespace Capstone.Menus
{
    namespace Capstone.Menus
    {
        /// <summary>
        /// Represents an menu manager that inherits from <see cref="ConsoleMenu"/>.
        /// </summary>
        internal class CinemaManagerMenu : ConsoleMenu
        {
            /// <summary>
            /// Contructor for the <see cref="CinemaManagerMenu"/> class.
            /// Inheriting From The ConsoleMenu Class by Using The Key Word base
            /// </summary>
            public CinemaManagerMenu(): base()
            {
                
            }

            /// <summary>
            /// Creates the menu by adding menu items
            /// </summary>
            public override void CreateMenuItems()
            {
                /// Get the list of staff members from the Parser
                var staffMembers = StaffParser.GetStaff();

                /// Loop through the staff members and add them to the menu
                foreach (var staff in staffMembers)
                {
                    /// Check if the staff member is general and add to the appropriate menu item
                    if (staff.Level == "General")
                    {
                        _menuItems.Add(new StaffSelectMenuItem(staff));
                    }
                    /// Check if the staff member is a manager and add the appropriate menu item
                    else if (staff.Level == "Manager")
                    {
                        _menuItems.Add(new ManagerSelectMenuItem(staff));
                    }
                }
                /// Add the exit menu item
                _menuItems.Add(new ExitMenuItem(this));
            }

            /// <summary>
            /// Displays the menu text and welcome message. For The Specific Cinema
            /// </summary>
            public override void PreDisplay()
            {
                var cinemaData = NameParser.GetName().First();

                Console.WriteLine($"Welcome to {cinemaData.Name}");
            }

            /// <summary>
            /// Displays the menu text
            /// </summary>
            /// <returns></returns>
            public override string MenuTitleText()
                => "";


        }
    }
}