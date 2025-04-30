# Selling Tickets To A Customer Worflow

## Step By Step Guide To Complete The Workflow

The Code Editor Has Made It An Prioity To Put All The Files Inside The Resources Folder Into The bin, debug, net8.0 File. 

![Screenshot 2025-04-18 135236](https://github.com/user-attachments/assets/7fab9af7-ba37-4acc-a46f-89aafadd1348)

Any Staff Member Can Sell You Tickets. Therefore The User Can Select Any Staff. 

![Screenshot 2025-04-18 135415](https://github.com/user-attachments/assets/67e7d765-3a7d-47d1-9af5-7a1a4fa1400d)

A Staff Member Is To Start a Transaction With a Customer. 

![Screenshot 2025-04-18 135529](https://github.com/user-attachments/assets/f7cccfca-2fed-45fc-94c5-d521778a1002)

To Portray The Schedule Of Screenings The User Should Select The 1st Option. 

![image](https://github.com/user-attachments/assets/daaef0d2-e02c-4438-a03f-78f7841af455)

In The Screenshot Above You Can Now Choose Any Schedule of Screening.

![image](https://github.com/user-attachments/assets/39c6aabd-6f48-492b-80ff-0b683722e5e2)

User Can Now Select a Number Of Tickets To Buy. Input The Number 1.

![image](https://github.com/user-attachments/assets/d92fed59-4faa-47d9-be62-f98518cc9e58)

a User Can Select Any Movie To Watch For The Specific Schedule Of Screening That Was Selected Above. 

![image](https://github.com/user-attachments/assets/d5c7f985-5fbd-4648-a45d-35a55d3cbb84)

For The Specific Movie The User Can Now Select a Premium Or Standard Ticket. It Is Recommended That You Select a Standard Then Premium Ticket. 

![image](https://github.com/user-attachments/assets/7fd60bca-2c9c-46f4-b174-a1b600090f19)

The User Can Enter The Number Of Tickets They Would Like To Add Depedning On How Many Seats Are Availble For The Specific Screening. The Cinema application Asks The Age Of The Ticket Holders Dependent On How many Tickets The User Has Booked.   

![image](https://github.com/user-attachments/assets/39c6aabd-6f48-492b-80ff-0b683722e5e2)

Now The User Can Purchase Concessions By Inputting The Number 2.

![image](https://github.com/user-attachments/assets/ac9901df-dd91-4195-90d4-c45d3ed60788)

The Customer Can Now Order Multiple Concessions And Add It To The Cart. Now The User Can Finialise a Transaction. 

![image](https://github.com/user-attachments/assets/bf6b0b89-334a-42b8-88d9-107c86915747)

~~~cs
public void FinaliseTransaction()
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
        FinaliseTransaction();
    }
}
~~~
The User can Input Yes They Would Like To Finialise The Tranaction Or Input No.

![image](https://github.com/user-attachments/assets/41d63c06-cd15-476b-89fb-ea1a5472f9e1)

## Functionality Of Workflow
~~~cs
 private static void Exception()
 {
     Console.WriteLine("Invalid Formatt:[Movie:{MOVIE} Length:{LENGTH} Genre:{GENRE} Rating:{RATING}]");
     Environment.Exit(0);
 }
~~~
Restricts Invalid Data From Loading Into The Console.
```cs
            public List<int> TotalPrice()
            {
                // integers is a list to store the parsed integers from the file
                var integers = new List<int>();

                // Organizing the transaction details
                Console.WriteLine("Transaction Details:");
                Console.WriteLine(" ");

                // Reading all lines from the file and processing each line
                foreach (var line in File.ReadAllLines(path))
                {
                    // Display the transaction detials in the Console
                    Console.WriteLine(line);

                    // Split the line at the colon
                    var parts = line.Split(':');

                    // Check if the line has two parts
                    if (parts.Length == 2)
                    {
                        // Try to parse the second part as an integer
                        if (int.TryParse(parts[1], out int value))
                        {
                            // If successful, add the integer to the list
                            integers.Add(value);
                        }
                    }
                }

                // Calculate the standard and premium price using the parsed data
                int standardprice = integers[0] * 800;

                int premiumprice = integers[1] * 1200;

                // Create a list to store the concession prices
                List<int> ConcessionsTotal = new List<int>();

                // Loop through the integers list starting from index 2 to get the concession prices. Adding the concession prices to the ConcessionsTotal list
                for (int i = 2; i < integers.Count; i++)
                {
                    ConcessionsTotal.Add(integers[i]);
                }

                // Calculate the total concession price
                float totalConcessions = ConcessionsTotal.Sum();

                // Calculate the total price by adding the standard price, premium price, and total concession price
                float totalprice = standardprice + premiumprice + totalConcessions;

                // setting Gold annual Membership price
                int GoldannualMembershipPrice = 89;

                // Reading the membership details from the Membership.txt file Using a Parser
                var Membership = MemberShipParser.GetMemberShip();

                // Loop through the membership details to check for loyalty or gold membership
                foreach (var i in Membership)
                {
                    // Checking if the member is a loyalty member with a visted count of 10
                    if (i.Member == "Loyality" && i.Visted == "10")
                    {
                        // apply the benefits
                        standardprice = 0;
                        totalprice = standardprice + premiumprice + totalConcessions;
                    }
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
                }
                // Outputting data in the Console Making it Look More Professional
                Console.WriteLine(" ");
                Console.WriteLine("Total Transaction Is");
                // Outputting Total Price
                Console.WriteLine(totalprice);
                Console.WriteLine(" ");
                return integers;
            }
        }
```

If Input is Yes Then The Program Would Output Your Transaction Details Calculate Your Total Price Of Transaction With Or Without Benifiets and Allow You To Confirm a Payment.

![image](https://github.com/user-attachments/assets/9b4aa0db-3223-414e-a706-6f1e4aaa58fb)
~~~cs
 // Read existing data from the file
 var screening = ScreeningParser.GetScreens();

 // Initialize standard and premium seat counts
 int standard = 0;

 int premium = 0;

 // Read existing data from the file
 StreamWriter writer = new StreamWriter(filePath);

 // Loop through the screening data to find the matching screening
 foreach (var screen in screening)
 {
     // Check if the screening matches the selected schedule
     if (schedule.Screening == screen.Screen)
     {
         standard = screen.StandardSeat;

         premium = screen.PremiumSeat;
     }
 }
 // Write the seat information to the file
 writer.WriteLine($"[Screen:{schedule.Screening}%NumPremiumSeat:{premium}%NumStandardSeat:{standard}]");

 // Close the file
 writer.Close();
~~~
In The Seats.txt File The Programmer Has Created This File To Allow The Program To Update The Tickets Availble And Save The Updated Information About Screenings.

Additionally The Staff Level Manager Can Set Daily Schedules According To Scheduling Rules Which Is Basiaclly Editing Schedule Of Screenings. The Manager Can Also Add, Edit And Remove Concession Names And Prices According To Scheduling Rules. 




