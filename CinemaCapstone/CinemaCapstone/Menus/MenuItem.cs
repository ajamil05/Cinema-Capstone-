namespace Capstone.Menus
{
	/// <summary>
	/// Represents an abstract base class for a menu item.
	/// </summary>
	internal abstract class MenuItem
	{
        public List<int> TotalTransaction;

        public List<MenuItem> _menuItems = new List<MenuItem>();

		public ConsoleMenu _ParentMenu;

		public string[] screeningData;

		public string[] GeneralManager;

		public string[] Ticket;
      
        /// <summary>
        /// Executes the action associated with selecting the menu item.
        /// </summary>
        public abstract void Select();

		/// <summary>
		/// Gets the text to be displayed for the menu item.
		/// </summary>
		/// <returns>A string representing the menu text.</returns>
		public abstract string MenuText();
	}
}
