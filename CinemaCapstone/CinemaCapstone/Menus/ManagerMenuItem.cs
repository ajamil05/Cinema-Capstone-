using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class ManagerMenuItem : MenuItem
    {
        /// <summary>
        /// Gets the minimum value (inclusive) for the range.
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// Gets the maximum value (inclusive) for the range.
        /// </summary>
        public int Max { get; private set; }

        private ExampleSumObject _totalSum;

        private List<StaffmanagerParse.StaffManager> _staffManagers;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleMenuItem"/> class.
        /// </summary>
        /// <param name="total">A reference to the <see cref="ExampleSumObject"/> that maintains the running total.</param>
        /// <param name="min">The minimum value (inclusive) for the range.</param>
        /// <param name="max">The maximum value (inclusive) for the range.</param>
        /// <exception cref="Exception">Thrown when the minimum value is greater than the maximum value.</exception>
        public ManagerMenuItem(ref ExampleSumObject total, int min, int max)
        {
            if (min > max) { throw new Exception($"minimum value {min} cannot be greater than maximum value {max}."); }
            _staffManagers = StaffmanagerParse.GetStaffManager();
            Min = min;
            Max = max;
            _totalSum = total; 
        }

        /// <summary>
        /// Gets the text to be displayed for the menu item.
        /// </summary>
        /// <returns>A string representing the menu text.</returns>
        public override string MenuText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var staff in _staffManagers)
            {
                if (staff.FirstName == "Simon" && staff.LastName == "Grey")
                {
                    sb.AppendLine($"StaffID:{staff.StaffID} Level:{staff.Level} Name:{staff.FirstName} LastName:{staff.LastName}");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Prompts the user to enter a number within the specified range and adds it to the running total.
        /// </summary>
        public override void Select()
        {
            for (int j = 0; j < _menuItems.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {_menuItems[j].MenuText()}");
            }
            _totalSum.AddToSum(1);
        }
    }
}
