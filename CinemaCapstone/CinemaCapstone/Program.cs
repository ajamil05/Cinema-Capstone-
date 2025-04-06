// See https://aka.ms/new-console-template for more information
using Capstone;
using Capstone.Cinema_features;
using Capstone.Menus;

Console.WriteLine("Hello, Capstone!");

/*
 * This program is provided as a starting point to the capstone project.
 * It shows an example of how you can create business objects (in this case an instance of ExampleSumObject and
 * interact with them using the ConsoleMenu and MenuItem objects.
 * 
 * You do not have to use this menuing system for the capstone project if you don't want to, but if you do this 
 * might provide a good starting point.
 * 
 */

Console.WriteLine("Hello, Capstone!");

// Read data from File1.txt
string path = $@"{Environment.CurrentDirectory}\Resources\Movies.txt";
string path1 = $@"{Environment.CurrentDirectory}\Resources\Screening.txt";
string path2 = $@"{Environment.CurrentDirectory}\Resources\StaffManager.txt";
string path3 = $@"{Environment.CurrentDirectory}\Resources\Ticket.txt";
ExampleSumObject exampleSumObject = new ExampleSumObject(0); 
// Create and display the CinemaManager menu
CinemaManager myMenu = new CinemaManager(exampleSumObject);
myMenu.Select();
// to do - Dynamically Create TicketTypes Menu Items