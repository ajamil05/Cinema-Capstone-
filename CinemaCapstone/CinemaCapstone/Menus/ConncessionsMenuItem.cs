﻿using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class ConncessionsMenuItem : MenuItem
    {
        private ExampleSumObject _totalSum;

        private List<ConcessionParse.ConcessionData> Concessions;
        public int Min { get; set; }

        public int Max { get; set; }
        public ConncessionsMenuItem(ref ExampleSumObject totalsum, int min, int max)
        {
            TotalTransaction = new List<int>();
            _totalSum = totalsum;
            Min = min;
            Max = max;
            Concessions = ConcessionParse.GetConcession();
        }
        public override string MenuText()
        {
            return "Concession";
        }
        public override void Select()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                stringBuilder.AppendLine($"{i + 1}. Concession:{Concessions[i].Concession} Price:{Concessions[i].Price}");
            }
            _menuItems.Clear();
            _menuItems.Add(new ExitMenuItem(_ParentMenu));
            for (int i = 0; i < _menuItems.Count; i++)
            {
                stringBuilder.AppendLine($"{1 + 1}. {_menuItems[i].MenuText()}");
            }
            Console.WriteLine(stringBuilder.ToString());
            int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose a Concession");
            if (valueToAdd == 1)
            {
                TransactionMenuItem transactionitem = new TransactionMenuItem(ref _totalSum, 1, 2);
                transactionitem.Select();
                Transaction transaction = new Transaction();
                transaction.AddConcessions();
            }
            _totalSum.AddToSum(valueToAdd);
        }
    }
}
