using Capstone.Cinema_features;
using System.Text;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents an abstract base class for console menu.
    /// </summary>
	abstract class ConsoleMenu : MenuItem
	{
        // boolean That Decides Whether To Exit The Menu Or Not.
        public bool IsActive { get; set; }

        // abstract base method to create menu items
        public abstract void CreateMenuItems();

        /// <summary>
        /// Method That Does The Process Of Selecting The Menu Item.
        /// </summary>
		public override void Select()
		{
            // bool is True if the menu is active.
            IsActive = true;


            do // Loop To Implement The Menu Is Active.
            {
                // Clears MenuItems
                Console.Clear();
                _menuItems.Clear();

                //Create MenuItems
                CreateMenuItems();

                //PreDisplay
                PreDisplay();

                //Displays MenuItems
				Display();

                //PostDisplay
                PostProcess();

		        //Asks For An Input
				InputDisplay();
			} while (IsActive); // Once IsActive is False, The Menu Will Exit.
        }
        /// <summary>
        /// Displays before the menu items are shown.
        /// </summary>
		public virtual void PreDisplay()
		{
			Console.WriteLine(MenuTitleText());
		}
        /// <summary>
        /// Displays the menu items.    
        /// </summary>
		public void Display()
		{
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _menuItems.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {_menuItems[i].MenuTitleText()}");
            }
            Console.WriteLine(sb.ToString());
        }
        /// <summary>
        /// Carrys Out a Specific Process after the menu items are shown.
        /// </summary>
		public virtual void PostProcess()
		{
			
		}
        /// <summary>
        /// Prompts the user for input and selects the corresponding menu item Within a Specified Range.
        /// </summary>
		public void InputDisplay()
		{
            if (_menuItems.Count == 0)
            {
                Console.WriteLine("No menu items available. Returning to the previous menu...");
                IsActive = false; // Exit the current menu
                return;
            }

            Console.Write("Input: ");
            int selection = ConsoleHelpers.GetIntegerInRange(1, _menuItems.Count) - 1;

            if (selection >= 0 && selection < _menuItems.Count)
            {
                _menuItems[selection].Select();
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }
}
