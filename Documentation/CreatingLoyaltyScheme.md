# Loyality Scheme Worflow Documentation

![image](https://github.com/user-attachments/assets/26531b6a-3b2c-4e51-b9f8-f9acd1652afb)

In The Image Above a User Can Select Either Manager Or Staff To Go Through The Loyality Scheme Worflow.

![image](https://github.com/user-attachments/assets/ca76cfcb-1fd7-4c1a-87d7-2258ff63abbb)

User Is Recommended To Select To Start a Transaction With a Customer. 

![image](https://github.com/user-attachments/assets/5e417050-4788-46d1-897b-db700443a504)

User Should Select Membership Option. 

![image](https://github.com/user-attachments/assets/54af1a4b-98f9-4662-a4a4-e247bd5c3aa4)

Once a User Has Selected The Membership Option. There Are Presented with Options To Select a Loyality Scheme Or Gold Membership. They Should Select Loyality Scheme.

![image](https://github.com/user-attachments/assets/9c3e0aee-72b6-4ce7-8f64-abcab6db396d)

Screenshot Is Portaying The Information Of A Loyality Scheme Member Loaded Into The Console.

![image](https://github.com/user-attachments/assets/242e4253-180b-4464-ae0a-0c6ac19766ce)

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

The Loyality Scheme Allows Any Rank Of Staff To Add A Loyality Member Towards The Loyality Scheme By Asking The Customer For There Firstname, Lastname and Email Address. Once Entered The Member Is Added Towards A Membership.txt File With There Information.

![image](https://github.com/user-attachments/assets/2c5be15f-d078-4dde-b609-37a7cc0b69cb)

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

In The Image Above Is The Text File Where I Am Storing The Loyality Scheme Members. Visted Count Is Presented In The File And Get's Updated By 1 Everytime a Customer Has The Same Firstname and Lastname. Refernce Towards The Parser Is Used To Check If The Visted Count Is 10, In The Membership.txt File And If It Is Then Your Next Standard Ticket Is Free.

When The Manager Is Selected, It Does Same Process as Staff But With Different Input Numbers. For Manager To Start a Transaction, The Input Is 7.










