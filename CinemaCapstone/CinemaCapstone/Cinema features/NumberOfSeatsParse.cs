using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Cinema_features
{
    public static class NumberOfSeatsParse
    {
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Screening.txt";
        public struct Seats
        {
            public int PremiumSeat;
            public int StandardSeat;
        }
        public static List<Seats> GetSeats()
        {
            List<Seats> StaffManagerList = new List<Seats>();
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Trim('[', ']').Split('%');
                Seats Screen = new Seats();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0])
                        {
                            case "NumPremiumSeat":
                                Screen.PremiumSeat = int.Parse(keyValue[1]);
                                break;
                            case "NumStandardSeat":
                                Screen.StandardSeat = int.Parse(keyValue[1]);
                                break;
                        }
                    }
                }
                StaffManagerList.Add(Screen);
            }
            return StaffManagerList;
        }
    }
}
