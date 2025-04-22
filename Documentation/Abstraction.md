# Abstraction (10%)

# Code Snippet For Abstraction
~~~cs
internal abstract class MenuItem
{
    public List<MenuItem> _menuItems = new List<MenuItem>();

    /// <summary>
    /// Executes the action associated with selecting the menu item.
    /// </summary>
    public abstract void Select();

    /// <summary>
    /// Gets the text to be displayed for the menu item.
    /// </summary>
    /// <returns>A string representing the menu text.</returns>
    public abstract string MenuTitleText();
}
~~~
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
            PostDisplay();

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
	public virtual void PostDisplay()
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
In This Code Snippet The Abstract Console Menu Class Is Inheriting From The Abstract Class MenuItem. Inside The Abstract MenuItem Class There Are Two Abstract Methods MenuTitleText Method And The Select Method. As Presented Both Methods From The Abstract MenuItem Class Are Being Updated/ Overrided In The Abstract Console Menu Class. Abstraction Is Shown By Implementing Essential Features And Removing Uneccssary Data To Create a Fully Functional User Interaction Menu Syestem Inside The Abstract Console Menu Class.

# Abstraction Class Digram
![Abstraction Class Digram (1)](https://github.com/user-attachments/assets/9059fc7b-076b-4210-bf82-c59fb5a84685)

