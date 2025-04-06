using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Cinema_features.ScreenParse;

namespace Capstone.Menus
{
    class ScreeningMenuItem : MenuItem
    {
        private ExampleSumObject _totalSum;
        public int Min { get; private set; }
        public int Max { get; private set; }

        public List<ScreenParse.Screens> MyScreens;

        private List<NumberOfSeatsParse.Seats> _seats;
        public ScreeningMenuItem(ref ExampleSumObject totalsum, int min, int max)
        {
            MyScreens = ScreenParse.GetScreens();
            _seats = NumberOfSeatsParse.GetSeats();
            _totalSum = totalsum;
            Min = min;
            Max = max;
        }

        public override string MenuText()
        {
            return "Screening";
        }

        public override void Select()
        {
            _menuItems.Add(new ExitMenuItem(_ParentMenu));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <  MyScreens.Count; i++)
            {
                sb.AppendLine($"{i + 1}. Screen:{MyScreens[i].Screen}");
            }
            for (int i = 0; i < _menuItems.Count; i++)
            {
                sb.AppendLine($"{3 + 1}. {_menuItems[i].MenuText()}");
            }
            Console.WriteLine(sb.ToString());
            int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose A Screen");
            if (valueToAdd == 1)
            {
                for (int i = 0; i < 1; i++)
                {

                }
            }
            else if (valueToAdd == 2)
            {
                Console.WriteLine("You have selected Screen A");
            }
            else if (valueToAdd == 3)
            {
                Console.WriteLine("You have selected Screen B");
            }
                _totalSum.AddToSum(valueToAdd);
        }
    }
}
