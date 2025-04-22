namespace Capstone.Menus.AddClasses
{
    /// <summary>
    /// This class represents a menu item for adding a concession item to the system.
    /// </summary>
    class AddconcessionMenuItem : ConsoleMenu
    {
        // Path to the concessions file
        private string path = $@"{Environment.CurrentDirectory}\Resources/Concessions.txt";

        public override void CreateMenuItems()
        {
            
        }

        /// <summary>
        /// Displays the menu text for adding a concession item.
        /// </summary>
        /// <returns></returns>
        public override string MenuTitleText()
        {
            return "Add Concession";
        }

        /// <summary>
        /// Creates the menu items for adding a concession item.
        /// </summary>
        public override void PostProcess()
        {
            // Check if the file exists
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                // Unique Price
                Random random = new Random();
                int Price = 0;
                // Generate a random price between 0 and 250
                Price = random.Next(0, 250);

                // Prompt the user for the concession name
                Console.WriteLine("input Concession Name");
                string ConcessionName = Console.ReadLine();

                // Check if the concession name is a number
                bool Num = int.TryParse(ConcessionName, out int i1);

                // If the concession name is a number, restart the method
                if (Num == true)
                {
                    CreateMenuItems();
                }

                // Check if the concession name contains both uppercase and lowercase letters
                for (int j = 0; j < ConcessionName.Length; j++)
                {
                    bool First = char.IsUpper(ConcessionName[j]);
                    bool Last = char.IsLower(ConcessionName[j]);

                    // If the concession name does not contain both uppercase and lowercase letters, restart the method
                    if (First == true && Last == true)
                    {
                        CreateMenuItems();
                    }
                }

                // Writing Data To the file to add conceesions
                sw.WriteLine($"[Concession:{ConcessionName}%Price:{Price}]");

            }
        }
    }
}
