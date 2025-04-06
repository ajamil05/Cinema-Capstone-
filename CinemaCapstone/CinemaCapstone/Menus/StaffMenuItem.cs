using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class StaffMenuItem : MenuItem
    {
        private List<StaffmanagerParse.StaffManager> _staffManagers;
        public int Min { get; private set; }
        public int Max { get; private set; }
        private ExampleSumObject _totalSum;
        //private ConsoleMenu _ParentMenu;

        public StaffMenuItem(ref ExampleSumObject totalSum, int min, int max)
        {
            if (min > max) { throw new Exception($"minimum value {min} cannot be greater than maximum value {max}."); }
            _staffManagers = StaffmanagerParse.GetStaffManager();
            Min = min;
            Max = max;
            _totalSum = totalSum;
        }
        public override string MenuText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var staff in _staffManagers)
            {
                if (staff.FirstName == "David" && staff.LastName == "Parker")
                {
                    sb.AppendLine($"StaffID:{staff.StaffID} Level:{staff.Level} Name:{staff.FirstName} LastName:{staff.LastName}");
                }
            }
            return sb.ToString();
        }
        public override void Select()
        {
            _menuItems.Clear();
            _menuItems.Add(new TransactionMenuItem(ref _totalSum, 1, 2));
            _menuItems.Add(new ExitMenuItem(_ParentMenu));
            for (int j = 0; j < _menuItems.Count; j++)
            {
                    Console.WriteLine($"{j + 1}. {_menuItems[j].MenuText()}");
            }
            int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose To Start An Transaction");
            _totalSum.AddToSum(valueToAdd);
        }
    }
}
