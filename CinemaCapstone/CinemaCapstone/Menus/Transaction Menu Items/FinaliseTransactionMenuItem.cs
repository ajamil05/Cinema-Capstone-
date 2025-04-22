using Capstone.Cinema_features.Total_Price_Of_Transaction;
using Capstone.Cinema_features.Total_Price_Of_Transaction.Capstone.Cinema_features.Total_Price_Of_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for finalising a transaction. Inherting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class FinaliseTransactionMenuItem : ConsoleMenu
    {
        /// <summary>
        /// Creating Menu Items for the Finalise Transaction Menu.
        /// </summary>
        public override void CreateMenuItems()
        {
            _menuItems.Add(new ConfirmPaymentmenuItemcs());
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// Displays the menu text for finalising a transaction.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Finalise Transaction";
        }
        /// <summary>
        /// Asks the user if they would like to finalise their transaction.
        /// </summary>
        public override void PostProcess()
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
                PostProcess();
            }
        }
    }
}
