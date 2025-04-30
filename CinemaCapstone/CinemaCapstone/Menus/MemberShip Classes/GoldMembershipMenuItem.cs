using Capstone.Cinema_features.Parsers;

namespace Capstone.Menus.MemberShip_Classes
{
    /// <summary>
    /// This class represents the Gold Membership menu item. It inherits from ConsoleMenu.
    /// </summary>
    class GoldMembershipMenuItem : ConsoleMenu
    {
        // path to the file containing transaction information
        

        /// <summary>
        /// This method creates the menu items for the Gold Membership.
        /// </summary>
        public override void CreateMenuItems()
        {
            // Choose member here.
            var Membership = MemberShipParser.GetMemberShip();
            foreach(var member in Membership)
            {
                _menuItems.Add(new GoldMemberSelectMenuItem(member)); 
            }
            _menuItems.Add(new ExitMenuItem(this)); 
        }
        /// <summary>
        /// This method displays the menu text for the Gold Membership menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Gold Membership";
        }
    }
}
