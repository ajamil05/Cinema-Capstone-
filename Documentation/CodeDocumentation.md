# Self commenting code and explicit comments (5%)

## Naming Conventions
~~~cs
public abstract void CreateMenuItems();

public override void Select();

public virtual void PreDisplay();

public void Display();

public virtual void PostProcess();

public void InputDisplay();
~~~
~~~cs
 public List<MenuItem> _menuItems = new List<MenuItem>();
~~~
The Programmer has Used Camel Case And Pascal Case. Pascal Case Is Where Every Word Starts With a Captial Letter, The Coder Has Used This For Class Names And Methods. Camel Case Is Where The First Letter Of The Word Is Lower Case And Second Letter Is UpperCase. The Program Writer Has Used This For Member Varaibles and Varaibles. The Software Developer Named Classes, Methods And Member Varaibles Depedning On Accurate Logic Of Code And Of Course Specific Towards The Classes And Methods For The Cinema Application. 

## Comments
~~~cs
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
~~~
Summary Comments Have Been Used By The Developer Espically Before Methods And Classes. To Provide a Short Conclusion Describing The Functionality Of Methods And Classes. Explicit/ General Comments Are Used Within The Main Infrastrcutre/ Logic Of The Program. To Explain Step By Step What Each Line Of The Particular Code Is Completing. Comments Allow Other Programmers / Users To Understand What The Source Code Is Executing. 
