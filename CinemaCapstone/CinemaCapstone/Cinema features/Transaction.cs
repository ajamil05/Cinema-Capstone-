using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features
{
    class Transaction
    {
        private List<ConcessionParse.ConcessionData> Concessions;
        private int ConcessionPrice;
        public Transaction()
        {
            Concessions = ConcessionParse.GetConcession();
        }
        public int AddConcessions()
        {
            for (int i = 0; i < Concessions.Count; i++)
            {
                int price = Concessions[i].Price;
                ConcessionPrice = price;
                break;
            }
            return ConcessionPrice;
        }
    }
}
