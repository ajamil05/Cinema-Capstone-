using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Capstone.Cinema_features;

namespace Capstone.Menus.Removeitems
{
    class RemoveSelectConcessionsMenuItem : ConsoleMenu
    {
        /// Path to the file containing concession information
        private string path = $@"{Environment.CurrentDirectory}\Resources/Concessions.txt";

        /// ConcessionParser.ConcessionData object representing the concession to be removed
        private ConcessionParser.ConcessionData Concessions { get; }

        /// <summary>
        /// Constructor for the RemoveSelectConcessionsMenuItem class.
        /// Setting The ConessionParser.ConcessionData object to be removed.
        /// </summary>
        /// <param name="concessionData"></param>
        public RemoveSelectConcessionsMenuItem(ConcessionParser.ConcessionData concessionData)
        {
            Concessions = concessionData;
        }
        /// <summary>
        /// This method creates the menu items for removing concessions. Removing concessions.
        /// </summary>
        public override void CreateMenuItems()
        {
            
        }

        public override void PostProcess()
        {
            // Temporary storage for updated content
            List<string> updatedLines = new List<string>();

            // Read the file line by line
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Check if the line matches the selected concession
                    if (!line.Contains(Concessions.Concession) || !line.Contains(Concessions.Price))
                    {
                        updatedLines.Add(line); // Keep lines that don't match
                    }
                }
            }

            // Write the updated content back to the file
            using (StreamWriter sw = new StreamWriter(path, false)) // Overwrite the file
            {
                foreach (string updatedLine in updatedLines)
                {
                    sw.WriteLine(updatedLine);
                }
            }
        }
        /// <summary>
        /// Displays the menu text for the concession menu item. To Choose a Concession to remove
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"{Concessions.Concession}:{Concessions.Price}";
        }
    }
}
