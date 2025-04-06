using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Cinema_features.StaffmanagerParse;

namespace Capstone.Cinema_features
{
    public static class ScreenParse
    {
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Screening.txt";
        public struct Screens
        {
            public string Screen;
        }
        public static List<Screens> GetScreens()
        {
            List<Screens> ScreenManager = new List<Screens>();
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Trim('[', ']').Split('%');
                Screens Screen = new Screens();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0])
                        {
                            case "Screen":
                                Screen.Screen = keyValue[1];
                                break;
                        }
                    }
                }
                ScreenManager.Add(Screen);
            }
            return ScreenManager;
        }
    }
}
