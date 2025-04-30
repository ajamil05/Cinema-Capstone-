# Polymorphism (10%)

## Code Snippet For Polymorphism
```cs
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
        /// Displays after the menu items are shown.
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
```
~~~cs
/// <summary>
/// Represents a menu item for finalising a transaction. Inherting from <see cref="ConsoleMenu"/>.
/// </summary>
class FinaliseTransactionMenuItem : ConsoleMenu
{
    /// <summary>
    /// Creating Menu Items for the Finalise Transaction Menu.
    /// </summary>
    public override void CreateMenuItems()
    {
        _menuItems.Add(new ConfirmPaymentmenuItemcs());
        _menuItems.Add(new ExitMenuItem(this));
    }
    /// <summary>
    /// Displays the menu text for finalising a transaction.
    /// </summary>
    /// <returns></returns>
    public override string MenuTitleText()
    {
        return "Finalise Transaction";
    }
    /// <summary>
    /// Asks the user if they would like to finalise their transaction.
    /// </summary>
    public override void PostProcess()
    {
        Console.WriteLine("Would You Like To Finalise Your Transaction Yes Or No");

        string input = Console.ReadLine();
        // Check if the input is "Yes" or "No"

        if (input == "Yes")
        {
            // Creating an instance of the Transactional class and calling the TotalPrice method
            Transactional transactional = new Transactional();

            transactional.TotalPrice();
        }
        else if (input == "No")
        {
            Console.WriteLine("Transaction Not Finalised");
        }
        else
        {
            // If the input is not "Yes" or "No", restart the method
            PostProcess();
        }
    }
~~~

## Explain On How Polymorphism Is Implemented
In The Code Above Polymorphism Is Applied Since There Are Two Virtual Methods PreDisplay And PostProcess. Virtual Means That The Method Is Now a Base Method. In All Of My MenuItem Classes They Inherit From The ConsoleMenu Class, This Allows The Developer To Override The Virtual Methods In The MenuItem Classes. Override Means To Update The Specific Method. As The Sofrtware Engineer Has Shown Inside The FinaliseTransactionMenuItem The PostProcess Method Is Being Overrided Therefore Allowing PostProcess Method To Have Mutliple Implementations For a Particular Functionality.

## Class Diagram
![Polymorphism Class Diagram (2)](https://github.com/user-attachments/assets/f5c3fd6b-a532-4c01-a850-93719b131826)
