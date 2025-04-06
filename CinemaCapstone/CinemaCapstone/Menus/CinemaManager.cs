using Capstone.Cinema_features;

namespace Capstone.Menus
{
	/// <summary>
	/// Represents an example console menu that inherits from <see cref="ConsoleMenu"/>.
	/// This menu allows users to add numbers to a running total stored in an instance of the ExampleSumObject business class.
	/// </summary>
	internal class CinemaManager : ConsoleMenu
	{
        private List<NameParsecs.NameData> names;
        private ExampleSumObject _totalSum;
        public CinemaManager(ref ExampleSumObject total)
		{
			_totalSum = total;
            names = NameParsecs.GetName();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CinemaManager"/> class with a specified <see cref="ExampleSumObject"/>.
        /// </summary>
        /// <param name="sum">An instance of <see cref="ExampleSumObject"/> that maintains the running total.</param>

        /// <summary>
        /// Creates the menu by adding menu items.
        /// </summary>
        public override void CreateMenu()
		{
            _menuItems.Clear();
            _menuItems.Add(new ManagerMenuItem(ref _totalSum, 1, 3));
			_menuItems.Add(new StaffMenuItem(ref _totalSum, 1, 3));
					if (_totalSum.Total >= 1)
					{
						_menuItems.Clear();
                        _menuItems.Add(new ScreeningMenuItem(ref _totalSum, 1, 4));
                        _menuItems.Add(new TicketMenuItem(ref _totalSum, 1, 6));
                        _menuItems.Add(new ConncessionsMenuItem(ref _totalSum, 1, 2));
                        _menuItems.Add(new MemberShipMenuItem(ref _totalSum, 1, 3));
                    }
					if (_totalSum.Total >= 2)
					{
                        _menuItems.Clear();
                        _menuItems.Add(new ScreeningMenuItem(ref _totalSum, 1, 4));
                        _menuItems.Add(new TicketMenuItem(ref _totalSum, 1, 6));
                        _menuItems.Add(new ConncessionsMenuItem(ref _totalSum, 1, 3));
                        _menuItems.Add(new MemberShipMenuItem(ref _totalSum, 1, 3));
						//_menuItems.Add(new TransactionMenuItem(ref _totalSum, 1, 3));
                    }
			_menuItems.Add(new ExitMenuItem(this));
        }

		/// <summary>
		/// Gets the text to be displayed for the console menu.
		/// </summary>
		/// <returns>A string representing the menu text and the current total sum.</returns>
		public override string MenuText()
		{
			for (int i = 0; i < names.Count; i++)
			{
                return $"{names[i].Name} Total: {_totalSum.Total}";
            }
			return "";
        }
	}
}
