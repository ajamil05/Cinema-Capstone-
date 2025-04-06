using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class MemberShipMenuItem : MenuItem
    {
        private ExampleSumObject _totalSum;

        public int Min { get; set; }

        public int Max { get; set; }

        public MemberShipMenuItem(ref ExampleSumObject totalsum, int min, int max)
        {
            _totalSum = totalsum;
            Min = min;
            Max = max;
        }
        public override string MenuText()
        {
            return "Membership";
        }

        public override void Select()
        {
            _menuItems.Clear();
            Console.WriteLine("1. Loyality Scheme");
            Console.WriteLine("2. Gold MemberShip");
            _menuItems.Add(new ExitMenuItem(_ParentMenu));
            for (int i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuItems[i].MenuText()}");
            }
            int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose a Membership");
            if (valueToAdd == 1)
            {
                ConsoleHelpers.GetStringInRange("FirstName:", "LastName:", "Email Address:");
            }
            _totalSum.AddToSum(valueToAdd);
        }
    }
}
