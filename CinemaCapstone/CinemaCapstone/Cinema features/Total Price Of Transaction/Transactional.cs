using Capstone.Cinema_features.Parsers;
using Capstone.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features.Total_Price_Of_Transaction
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.Collections.Generic;

    namespace Capstone.Cinema_features.Total_Price_Of_Transaction
    {
        /// <summary>
        /// This class is responsible for calculating the total price of transactions.
        /// </summary>
        public class Transactional
        {
            // Path to the Transaction file
            private static string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

            /// <summary>
            /// Reads the transaction details from the file and calculates the total price.
            /// </summary>
            /// <returns></returns>
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
                int standardprice = 0; // Initialize standardprice to 0
                try
                {
                    standardprice = integers[0] * 800;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("invalid");
                }
                int premiumprice = 0; // Initialize standardprice to 0
                try
                {
                    premiumprice = integers[1] * 1200;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("invalid");
                }
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
    }

}
