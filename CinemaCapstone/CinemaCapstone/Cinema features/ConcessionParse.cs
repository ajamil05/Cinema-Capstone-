using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features
{
    public static class ConcessionParse
    {
            private static string path = $@"{Environment.CurrentDirectory}\Resources/Concessions.txt";

            public struct ConcessionData
            {
                public string Concession;
                public int Price;
            }
            public static List<ConcessionData> GetConcession()
            {
                List<ConcessionData> ConcessionDataList = new List<ConcessionData>();
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] parts = line.Trim('[', ']').Split('%');
                    ConcessionData Concessions = new ConcessionData();
                    foreach (string part in parts)
                    {
                        string[] keyValue = part.Split(':');
                        if (keyValue.Length == 2)
                        {
                            switch (keyValue[0])
                            {
                                case "Concession":
                                    Concessions.Concession = keyValue[1];
                                    break;
                                case "Price":
                                    Concessions.Price = int.Parse(keyValue[1]);
                                    break;
                            }
                        }
                    }
                    ConcessionDataList.Add(Concessions);
                }
                return ConcessionDataList;
            }
    }
}
