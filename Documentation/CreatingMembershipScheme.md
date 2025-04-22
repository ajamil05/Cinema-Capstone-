# Gold MemberShip Workflow 

![Screenshot 2025-04-18 135236](https://github.com/user-attachments/assets/a560db82-fc13-4800-b98a-6424ae0440bc)

The User Should Pick a Staff. Both Staff Levels Can Complete The Gold Membership Worflow. 

![Screenshot 2025-04-18 135415](https://github.com/user-attachments/assets/a6844e75-924b-4281-8c23-ce4da57e9493)

The User Should Then Select To Start a Transaction With a Customer. 

![Screenshot 2025-04-18 135529](https://github.com/user-attachments/assets/2332a2a3-3ccb-467b-ad15-14a7c282416a)

In The Image Above The Membership Option Should be Selected To Procced To Loyality and Gold. 

![Screenshot 2025-04-18 135751](https://github.com/user-attachments/assets/6501a29b-2585-4a2b-afde-326950ea82e3)

The Reviewer Of My Program Should Select Gold Membership. 

~~~cs
 foreach(var Gold in gold)
 {
     if (Gold.Member == "Loyality")
     {
         Console.WriteLine($"{Gold.MemberID} - Firstname:{Gold.Firstname} Lastname:{Gold.Lastname} Email Address:{Gold.Email} Member:{Gold.Member} Visted:{Gold.Visted}");
     }
     if (Gold.Member == "Gold")
     {
         Console.WriteLine($"{Gold.MemberID} - Firstname:{Gold.Firstname} Lastname:{Gold.Lastname} Email Address:{Gold.Email} Member:{Gold.Member} Visted:{Gold.Visted} MemberShipEndDate:{year}");
     }
 }
~~~

Loads The Information of Gold Members and Loyality Members.

![image](https://github.com/user-attachments/assets/a6d302a2-1fce-43d0-ac76-1cf360102e6c)

![image](https://github.com/user-attachments/assets/8f545066-0d8e-4979-aa40-a73f4cb4d383)
~~~cs
            Console.WriteLine("Would You Like To Join Gold Member Its £89 Per Year Yes Or No");
            string SellMembership = Console.ReadLine();
~~~

Inputting From The User If They would Like To Join The Gold Membership From a Loyality Scheme.
~~~cs
 if (SellMembership == "Yes")
 {
     // Opening the Membership.txt file and Converting the loyality member to a gold member
     StreamWriter sw = new StreamWriter(filepath);

     foreach (var i in gold)
     {
         sw.WriteLine($"[MemberID:{i.MemberID}%FirstName:{i.Firstname}%LastName:{i.Lastname}%Email:{i.Email}%Member:Gold%Visted:{i.Visted}%MemberShipEndDate:{year}]");

         // Checking if the current date is equal to the membership end date
         if (currentDate == year)
         {
             // Stays a loyality member
             sw.WriteLine($"[MemberID:{i.MemberID}%FirstName:{i.Firstname}%LastName:{i.Lastname}%Email:{i.Email}%Member:Loyality%Visted:{i.Visted}]");
         }
         // Adding the new data to the transaction.txt file if they are a Gold Member
         var existingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();

         string newData = $"{i.Firstname} {i.Lastname} (Gold)";

         // Check if the data already exists
         if (!existingData.Contains(newData))
         {
             // Append the new data only if it doesn't already exist
             using (StreamWriter streamWriter = new StreamWriter(path, true))
             {
                 streamWriter.WriteLine(newData);
             }
         }
     }
     // Closing the file
     sw.Close();
 }
~~~

If Input Is Yes Then It Would Add That Member As a Gold Member. 
~~~cs
 else if (SellMembership == "No")
 {
     Console.WriteLine("You Have Chosen Loyality Scheme");
 }
 else
 {
     // restarts the method if the input is not valid
     Gold();
 }
~~~
If Input Is No The Loyality Scheme Member will Stay a Loyality Scheme Member. If Its None Of The Inputs "Yes" Or "No" It Restarts The Method. This Term Is Called Recusrsion. Reursion Is a Function That Is Calling Itself. 













