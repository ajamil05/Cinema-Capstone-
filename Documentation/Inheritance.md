# Inheritance for Code Reuse (10%)

## Code Showing Inheritance
~~~cs
/// <summary>
/// Represents a menu item for selecting a General staff member, inheriting from <see cref="ConsoleMenu"/>.
/// </summary>
class StaffSelectMenuItem : ConsoleMenu 
{
    // Initializes the Staffmanager Property as a Staff Parser Object.
    public StaffParser.Staff StaffManager { get; }

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
~~~

```cs
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
```
## Explain On How Inheritance Is Applied
The Code Above Shows That The ManagerSelectMenuItem Is Being Inherited From The Parent Class StaffSelectMenuItem. This Is Displayed Because Inside The ManagerSelectMenuItem There Is The Key Word "base" Which access Member's From The StaffSelectMenuItem. The Programmer Has Also Shown Reusing Code Since a Manager Can Do Everything a General Staff Can. Thus The Menu Syestem That The StaffSelectMenuItem Accomplishes Is Implemented In ManagerSelectMenuItem Class By Using "base.CreateMenuItems". Another Example Of Resuing Code In This Program Is Referencing The StaffParser Class In The StaffSelectMenuItem Class To Output The Data Of The Staff Members In The Set File. Another Point That This Code Portrays Inheritance Is The : Between The Child Class ManagerSelectMenuItem and Parent Class StaffSelectMenuItem. 

# Class Diagram
![Inheritance Class Diagram](https://github.com/user-attachments/assets/9272cc71-4c63-47e7-977b-e4db561a0028)
