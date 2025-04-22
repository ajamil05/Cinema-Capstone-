using Capstone.Cinema_features;
using Capstone.Cinema_features.Total_Price_Of_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// Represents a menu item for selecting concessions. Inherting from <see cref="ConsoleMenu"/>.
    /// </summary>
    class ConcessionSelectMenuItem : ConsoleMenu
    {
        /// The path to the file where transaction data is stored.
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";
        // The ConcessionParser.ConcessionData object that holds the concession data.
        private ConcessionParser.ConcessionData Concessions { get; }

        // Constructor for the ConcessionSelectMenuItem class. Setting the ConcessionParser.ConcessionData.
        public ConcessionSelectMenuItem(ConcessionParser.ConcessionData concession)
        {
            Concessions = concession;
        }
        public override void CreateMenuItems()
        {

        }
        /// <summary>
        /// Displays the menu text for the concession menu item. Allowing You To Select A Concession To Buy
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"{Concessions.Concession}:{Concessions.Price}";
        }
        /// <summary>
        /// Adds the concession data to the file. It checks if the data already exists in the file before appending it.
        /// </summary>
        public override void PostProcess()
        {
            StreamWriter sw = new StreamWriter(path, true);

            sw.WriteLine($"{Concessions.Concession}:{Concessions.Price}");

            sw.Close();
            // Read existing data from the file
            var existingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();
            // Prepare the new data to write
            string newData = $"{Concessions.Concession}:{Concessions.Price}";
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
    }
}
