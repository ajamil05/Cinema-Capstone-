# Loyality Scheme Worflow Documentation

## Step By Step Guide Towards Loyality Workflow

In This Code The Programmer Has Made It a Prority That The User Puts The File, Membership.txt in The Filepath bin, debug, net8.0 File.

![image](https://github.com/user-attachments/assets/26531b6a-3b2c-4e51-b9f8-f9acd1652afb)

In The Image Above a User Can Select Either Manager Or Staff To Go Through The Loyality Scheme Worflow.

![image](https://github.com/user-attachments/assets/ca76cfcb-1fd7-4c1a-87d7-2258ff63abbb)

User Is Recommended To Select To Start a Transaction With a Customer. 

![image](https://github.com/user-attachments/assets/5e417050-4788-46d1-897b-db700443a504)

User Should Select Membership Option. 

![image](https://github.com/user-attachments/assets/54af1a4b-98f9-4662-a4a4-e247bd5c3aa4)

Once a User Has Selected The Membership Option. There Are Presented with Options To Select a Loyality Scheme Or Gold Membership. They Should Select Loyality Scheme.

![image](https://github.com/user-attachments/assets/cad46230-333c-455d-b888-f40715338a71)

The User Can Now Select To Create a Loyality Member Or Exit The Menu. The User Should Select To Create a Loyality Member. Furthermore The Examminer Can See That The Programmer Has Successfully Loaded The Members. 

![image](https://github.com/user-attachments/assets/97abfd9b-7e1c-4585-8d1c-b817dd18e0f4)

## How Workflow Is Being Implemented
~~~cs
 private static void Exception()
 {
     Console.WriteLine("Invalid Formatt:[Movie:{MOVIE} Length:{LENGTH} Genre:{GENRE} Rating:{RATING}]");
     Environment.Exit(0);
 }
~~~
This Doesn't Allow Invalid Data To Load In The Console. 
~~~cs
 Console.WriteLine("Enter Firstname:");

 string firstname = Console.ReadLine();

 Console.WriteLine("Enter Suraname");

 string lastname = Console.ReadLine();

 Console.WriteLine("Enter Email Address");

 string email = Console.ReadLine();
~~~
~~~cs
sw.WriteLine($"[MemberID:{MemberID}%Firstname:{firstname}%Lastname:{lastname}%Email:{email}%Member:Loyality%Visted:{Visted}]");
~~~
The Loyality Scheme Allows Any Rank Of Staff To Add A Loyality Member Towards The Loyality Scheme By Asking The Customer For There Firstname, Lastname and Email Address. Once Entered The Member Is Added Towards A Membership.txt File With There Information. Multiple Members Are Added Towards The File. 

![image](https://github.com/user-attachments/assets/3569d9d0-1e35-4fcc-b5c2-40e15b7f6d7b)

~~~cs
foreach (var loyality in Loyality)
                {
                    if (firstname == loyality.Firstname && lastname == loyality.Lastname)
                    {
                        Console.WriteLine("Member Already Exists");
                        Visted++;
                    }
                }
~~~
~~~cs
 foreach (var i in Membership)
 {
     // Checking if the member is a loyalty member with a visted count of 10
     if (i.Member == "Loyality" && i.Visted == "10")
     {
         // apply the benefits
         standardprice = 0;
         totalprice = standardprice + premiumprice + totalConcessions;
     }
}
~~~

In The Image Above Is The Text File Where Code Editor Is Storing The Loyality Scheme Members. Visted Count Is Presented In The File And Get's Updated By 1 Everytime a Customer Has The Same Firstname and Lastname. Reference Towards The Parser Is Used To Check If The Visted Count Is 10, If It Is Then Your Next Standard Ticket Is Free.
