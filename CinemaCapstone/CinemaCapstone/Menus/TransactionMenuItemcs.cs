using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class TransactionMenuItem : MenuItem
    {
        ///<summary>
		/// Gets the minimum value (inclusive) for the range.
		/// </summary>
		public int Min { get; private set; }

        /// <summary>
        /// Gets the maximum value (inclusive) for the range.
        /// </summary>
        public int Max { get; private set; }

        private ExampleSumObject _totalSum;

        private List<ConcessionParse.ConcessionData> Concessions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleMenuItem"/> class.
        /// </summary>
        /// <param name="total">A reference to the <see cref="ExampleSumObject"/> that maintains the running total.</param>
        /// <param name="min">The minimum value (inclusive) for the range.</param>
        /// <param name="max">The maximum value (inclusive) for the range.</param>
        /// <exception cref="Exception">Thrown when the minimum value is greater than the maximum value.</exception>
        public TransactionMenuItem(ref ExampleSumObject total, int min, int max)
        {
            if (min > max) { throw new Exception($"minimum value {min} cannot be greater than maximum value {max}."); }
            TotalTransaction = new List<int>();
            Min = min;
            Max = max;
            _totalSum = total;
            Concessions = ConcessionParse.GetConcession();
        }

        /// <summary>
        /// Gets the text to be displayed for the menu item.
        /// </summary>
        /// <returns>A string representing the menu text.</returns>
        public override string MenuText()
        {
            return $"Start a Transaction";
        }

        /// <summary>
        /// Prompts the user to enter a number within the specified range and adds it to the running total.
        /// </summary>
        public override void Select()
        {
                _menuItems.Clear();
                _menuItems.Add(new AddConcessionsMenuItem(ref _totalSum, 1, 2));
                _menuItems.Add(new ExitMenuItem(_ParentMenu));
                for (int i = 0; i < _menuItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_menuItems[i].MenuText()}");
                }
                int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose a Item To Add Towards The Transaction");
                if (valueToAdd == 1)
                {
                    Transaction transaction = new Transaction();
                    for (int i = 0; i < Concessions.Count; i++)
                    {
                        Console.WriteLine($"{Concessions[i].Concession} Price is {transaction.AddConcessions()}");
                        break;
                    }
                }
                _totalSum.AddToSum(valueToAdd);
        }
    }
}
