using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Menus.MovieParse;

namespace Capstone.Cinema_features
{
    public static class NameParsecs
    {
        private static string path = $@"{Environment.CurrentDirectory}\Resources/Name.txt";

        public struct NameData
        {
            public string Name;
        }
        public static List<NameData> GetName()
        {
            List<NameData> NameDataList = new List<NameData>();
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Trim('[', ']').Split('%');
                NameData Name = new NameData();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0])
                        {
                            case "Name":
                                Name.Name = keyValue[1];
                                break;
                        }
                    }
                }
                NameDataList.Add(Name);
            }
            return NameDataList;
        }
    }
}
