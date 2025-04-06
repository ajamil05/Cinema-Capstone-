using Capstone.Menus;
using Capstone;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.Menus
{
    class AddConcessionsMenuItem : MenuItem
    {
        private ExampleSumObject _totalSum;

        public int Min { get; set; }

        public int Max { get; set; }

        public AddConcessionsMenuItem(ref ExampleSumObject total, int min, int max)
        {
            _totalSum = total;
            Min = min;
            Max = max;
        }
        public override string MenuText()
        {
            return "Add Concession";
        }
        public override void Select()
        {
            _menuItems.Clear();
            _menuItems.Add(new ExitMenuItem(_ParentMenu));
            for (int i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuItems[i].MenuText()}");
            }
            int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose a Concession");
            _totalSum.AddToSum(valueToAdd);
        }
    }
}
