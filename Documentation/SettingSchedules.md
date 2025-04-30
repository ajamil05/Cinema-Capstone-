# Schedule Of Screenings Worflow

## Step By Step Guide Towards The Specific Workflow

The Sotfware Developer Has Made This a Priority To Put All The .fs Extension Files Into The bin, debug, net8.0 File. 

![Screenshot 2025-04-18 135236](https://github.com/user-attachments/assets/9b1193d7-5341-48f4-aa09-6652fb609716)

The Programmer Shows That Manager And General Level Staff Are Loaded Into The Console. The User Should Select a Manager. 

![image](https://github.com/user-attachments/assets/46e57287-9de6-4a95-ae36-ea1a7e0c6b16)

In The Image Above The User Can See That The Programmer Has Impemented Different Atrributes Towarda a Manager. a Manager Can Edit, Add And Remove Concession Names And Prices, Add and Remove Staff and Lastly Edit The Schedule of Screenings. The User Should Procced To Select Edit Schedule of Screenings. 

![image](https://github.com/user-attachments/assets/b42890db-bc19-4c1e-8894-7cf50e5e1414)

In The Portait Above The User Can Choose a Any Schedule Of Screening To Edit. 

## Functionality Of Workflow
~~~cs
 private static void Exception()
 {
     Console.WriteLine("Invalid Formatt:[Movie:{MOVIE} Length:{LENGTH} Genre:{GENRE} Rating:{RATING}]");
     Environment.Exit(0);
 }
~~~
Prevents Invalid Data From Loading Into The Console.
![image](https://github.com/user-attachments/assets/56ce3797-0dcc-4abd-b8ba-17ba423cccdd)
~~~cs
 Console.WriteLine("Enter a Screen A, B Or C");

 string screen = Console.ReadLine();

 Console.WriteLine("Input Hours e.g(24)");

 int Hours = 0;
 // Try to parse the input for hours
 try
 {
     Hours = int.Parse(Console.ReadLine());
 }
 catch (FormatException)
 {
     Console.WriteLine("invalid");

     CreateMenuItems();
 }
 Console.WriteLine("Input Minutes e.g(60)");

 int Minutes = 0;
 // Try to parse the input for minutes
 try
 {
     Minutes = int.Parse(Console.ReadLine());
 }
 catch (FormatException)
 {
     Console.WriteLine("invalid");

     CreateMenuItems();
 }
// Adding Minutes For Trailers
Minutes = Minutes + 20;

// Validate the input for screen
if (screen != "A" && screen != "B" && screen != "C")
{
    CreateMenuItems();
}
// Validate the input for hours and minutes
if (Hours < 0 || Hours > 24 && Minutes < 0 || Minutes > 60)
{
    CreateMenuItems();
}
// Combinding Hours and Minutes Into a String
string Time = $"{Hours} {Minutes}";
~~~
The User Should Enter The Specific Screen , The Time As Serprate Inputs as Hours And Minutes. So Let Say You Want To Watch a Movie At 1pm, The User Should Enter It As The Screenshot Above. The Programmer Has Added Validation Checks To Make Sure The Program Doesn't Take Invalid Inputs.
~~~cs
 if (screen == schedule.Screening && Time == schedule.Time)
 {
     CreateMenuItems();
 }
~~~
Builder Of This Program Has Done a Check Which Makes Sure That The Selected Screening That You wanted To Edit Isn't The Same As The Inputted Screen And Time.

![Screenshot 2025-04-19 150830](https://github.com/user-attachments/assets/791ce15a-3ab2-4f5f-a8f2-7f438700f2ed)
~~~cs
var seats = SeatsParser.GetSeats();
// Looping through the seats to get the number of standard and premium seats
foreach (var i in seats)
{
    // Calculating Total Number of Seats For Specific Screening
    int TotalSeats = i.NumStandardSeats + i.NumPremiumSeats;

    // Checking the TurnAround Times for the different total seats in the theatre
    if (TotalSeats <= 50)
    {
        Minutes = Minutes + 15;
    }
    else if (TotalSeats >= 51 && TotalSeats <= 100)
    {
        Minutes = Minutes + 30;
    }
    else if (TotalSeats > 100)
    {
        Minutes = Minutes + 45;
    }
    // if the minutes are greater than 60, increment the hours and adjust the minutes
    if (Minutes > 60)
    {
        Hours = Hours + 1;

        Minutes = Minutes - 60; 
    }
}
~~~
Once The User Had Already Selcted The Specific Schedule Of Screening To Edit The Seats Would Update, This Is Where We Are Calculating The Turn Around Time Depending On The Number of Seats. 

![image](https://github.com/user-attachments/assets/4240e5c5-37d2-456e-a2f9-dbe6008aac15)

The Constructor of This Code Has Created a File That Stores All The Schedule Of Screenings In a .fs extension File. This allows any Staff Member To Load The Schedule Of Screenings Into The Console. By Accessing The Specific File Shown Above. 

![image](https://github.com/user-attachments/assets/c4d7aeb7-9afd-462b-b0b7-c6b9d3a3c237)

![image](https://github.com/user-attachments/assets/2d850277-adb0-4eb5-b519-2635ec1375dd)

![image](https://github.com/user-attachments/assets/a9cc0a11-de4d-4769-b655-887633e635e2)

The Coder Has Created Files Based On The Specific Dates Indicated In The Filename. Storing The Specific Timings And Screenings For The Specific Dates In The File. 
