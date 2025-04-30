# Gold MemberShip Workflow 

## Step By Step Guide To Work Through The Workflow

In This Program The Programmer Has Made It a Prority That The User Puts The File, Membership.txt in The Filepath bin, debug, net8.0 File.

![Screenshot 2025-04-18 135236](https://github.com/user-attachments/assets/a560db82-fc13-4800-b98a-6424ae0440bc)

The User Should Pick a Staff Member. Both Staff Levels Can Complete The Gold Membership Worflow. 

![Screenshot 2025-04-18 135415](https://github.com/user-attachments/assets/a6844e75-924b-4281-8c23-ce4da57e9493)

The User Should Then Select To Start a Transaction With a Customer. 

![Screenshot 2025-04-18 135529](https://github.com/user-attachments/assets/2332a2a3-3ccb-467b-ad15-14a7c282416a)

In The Image Above The Membership Option Should be Selected To Procced To Loyality and Gold. 

![Screenshot 2025-04-18 135751](https://github.com/user-attachments/assets/6501a29b-2585-4a2b-afde-326950ea82e3)

The Reviewer Of My Program Should Select Gold Membership. 

![image](https://github.com/user-attachments/assets/9a4c7733-0449-42dd-af91-3c3bd12a64db)

The User Can Now Select Any Loyality Member To Convert Towards a Gold Member. Therefore In The Image Above The Coder Is Also Loading The Members. 

## Functionality Applied Towards Workflow
~~~cs
 private static void Exception()
 {
     Console.WriteLine("Invalid Formatt:[Movie:{MOVIE} Length:{LENGTH} Genre:{GENRE} Rating:{RATING}]");
     Environment.Exit(0);
 }
~~~
Forbids Invalid Data From Loading Into The Console. 
~~~cs
 var Day = DateTime.Now.Day;

 var Month = DateTime.Now.Month;

 var Year = DateTime.Now.Year + 1;

 string MembershipEndDate = $"{Day}.{Month}.{Year}";

 string currentDate = DateTime.Now.ToString("yyyy/MM/dd");
~~~
In The Code Snippet Above The Software Developer Has Created a MemberShip End Date And The Current Date.

~~~cs
// Read existing data from the file
var existingData = File.Exists(filepath) ? File.ReadAllLines(filepath) : Array.Empty<string>();

var ExistingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();

// Prepare the new data to write
string newdata = $"[MemberID:{Gold.MemberID}%Firstname:{Gold.Firstname}%Lastname:{Gold.Lastname}%Email:{Gold.Email}%Member:Gold%MemberShipEndDate:{MembershipEndDate}%Visted:{Gold.Visted}]";

 if (!existingData.Contains(newdata))
 {
     // Append the new data only if it doesn't already exist
     using (StreamWriter streamWriter = new StreamWriter(filepath, true))
     {
         streamWriter.WriteLine(newdata);

         if (MembershipEndDate == currentDate)
         {
             streamWriter.WriteLine($"[MemberID:{Gold.MemberID}%Firstname:{Gold.Firstname}%Lastname:{Gold.Lastname}%Email:{Gold.Email}%Member:Loyality%Visted:{Gold.Visted}]");
         }
     }
 }
~~~

![image](https://github.com/user-attachments/assets/42325808-ef7f-4a3a-b714-8837b748ec60)

Once a Member Is Selected To Convert From a Loyality Member To a Gold Member. It Appends The Data Of The User Selected as a Gold Member, But If That Member Already Exists as a Gold Member It Doesn't. If The Membership End Date Is Equal To The Current Date Then The Member That Was Selected Would Remain a Loyality Member. 

~~~cs
 // Checking if the member is Gold and has a visted count of 10
 else if (i.Member == "Gold" && i.Visted == "10")
 {
     // apply the benefits
     standardprice = 0;
     totalConcessions = totalConcessions * 0.25f;
     totalprice = standardprice + premiumprice + totalConcessions + GoldannualMembershipPrice;

 }
 // Checking if the member is a Gold member
 else if(i.Member == "Gold")
 {
     // apply the benefits
     totalConcessions = totalConcessions * 0.25f;
     totalprice = standardprice + premiumprice + totalConcessions + GoldannualMembershipPrice;
 }
~~~
Applying The Benefits For a Gold Member In The Transaction. Implementing Functionality For 25% Discount On All Concessions And Loyality Scheme Benefits Too. 





