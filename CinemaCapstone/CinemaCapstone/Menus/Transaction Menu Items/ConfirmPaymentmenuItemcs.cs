using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for confirming payment. Inherting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class ConfirmPaymentmenuItemcs : ConsoleMenu
    {
        // File path for the transaction file
        private static string filePath = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        /// <summary>
        /// Ending the program and creating the menu items for confirming payment.
        /// </summary>
        public override void CreateMenuItems()
        {
           
        }
        /// <summary>
        /// Displays the menu text for confirming payment.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Confirm Payment";   
        }

        public override void PostProcess()
        {
            Console.WriteLine("Your Ticket Has Been Booked");
            // Getting the name from a file calling the parser class

            var Name = NameParser.GetName();

            foreach (var i in Name)
            {
                // Displaying the name of the cinema. Thanks for booking with the cinena
                Console.WriteLine($"Thank You For Booking a Movie With {i.Name}");
            }
            // Clears the file after transaction is finished
            File.WriteAllText(filePath, string.Empty);

            // Adds Exit MenuItem
            _menuItems.Add(new ExitMenuItem(this));

            // Exits the program
            Environment.Exit(0);
        }
    }
}
