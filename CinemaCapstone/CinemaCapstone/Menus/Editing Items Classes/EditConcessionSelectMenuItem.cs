using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.Editing_Items_Classes
{
    /// <summary>
    /// This class represents the EditConcessionSelectMenuItem. It inherits from ConsoleMenu.
    /// </summary>
    class EditConcessionSelectMenuItem : ConsoleMenu
    {
        // Path to the file containing concession information
        public string path = $@"{Environment.CurrentDirectory}/Resources/Concessions.txt";

        // ConcessionParser.ConcessionData object representing the concession to be edited
        private ConcessionParser.ConcessionData concessionData;

        /// <summary>
        /// Constructor for the EditConcessionSelectMenuItem class.
        /// Setting the ConcessionParser.ConcessionData object to be edited.
        /// </summary>
        /// <param name="concession"></param>
        public EditConcessionSelectMenuItem(ConcessionParser.ConcessionData concession)
        {
            concessionData = concession;
        }

        /// <summary>
        /// This method creates the menu items for editing the concession.
        /// </summary>
        public override void PostProcess()
        {
            // Prompts the user for Concession Name and Price
            Console.WriteLine("Concession Name:");

            string concessionName = Console.ReadLine();

            Console.WriteLine("Concession Price:");

            int concessionPrice = 0;
            // Try to parse the input for price
            try
            {
                concessionPrice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                PostProcess();
            }
            // Check if the concession name is a number
            bool Num = int.TryParse(concessionName, out int i1);

            // If the concession name is a number Restart the method
            if (Num)
            {
                PostProcess();
            }
            // Reading all lines in the Concessions.txt converting it to a list
            var lines = File.ReadAllLines(path).ToList();

            // Find the line to be replaced
            string oldLine = $"[Concession:{concessionData.Concession}%Price:{concessionData.Price}]";

            string newLine = $"[Concession:{concessionName}%Price:{concessionPrice}]";

            // Find the index of the line to be replaced
            int index = lines.FindIndex(line => line == oldLine);

            // If the index of the line is found
            if (index != -1)
            {
                // Replace the line
                lines[index] = newLine;

                // Write the updated lines back to the file
                File.WriteAllLines(path, lines);

                Console.WriteLine("Schedule updated successfully.");
            }
        }
        /// <summary>
        /// This method displays the menu text for the edit concession menu item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return $"Edit Concession: {concessionData.Concession} - Price: {concessionData.Price}";
        }

        public override void CreateMenuItems()
        {
            
        }
    }
}
