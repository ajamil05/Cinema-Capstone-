using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.Editing_Items_Classes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using global::Capstone.Cinema_features;
    using global::Capstone.Cinema_features.Parsers;

    namespace Capstone.Menus.Editing_Items_Classes
    {
        /// <summary>
        /// This class represents the EditScheduleofScreeningsMenuItem. It inherits from ConsoleMenu.
        /// </summary>
        class EditScheduleofScreeningsMenuItem : ConsoleMenu
        {
            /// <summary>
            /// Creates the menu items for editing the schedule of screenings.
            /// </summary>
            public override void CreateMenuItems()
            {
                var Scheduling = ScheduleOfScreeningsParser.GetSchedules();
                foreach (var schedule in Scheduling)
                {
                    _menuItems.Add(new EditScheduleOFSelectMenuItem(schedule));
                }
                _menuItems.Add(new ExitMenuItem(this));
            }
            /// <summary>
            /// Displays the menu text for editing the schedule of screenings.
            /// </summary>
            /// <returns></returns>
            public override string MenuTitleText()
            {
                return "Edit Schedule of Screenings";
            }
        }
          
    }

}
