using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Menus.MenuItem;

namespace Capstone.Cinema_features
{
    public static class StaffmanagerParse
    {
        public struct StaffManager
        {
            public string StaffID;
            public string Level;
            public string FirstName;
            public string LastName;
        }
        private static string path = $@"{Environment.CurrentDirectory}\Resources\StaffManager.txt";

        public static List<StaffManager> GetStaffManager()
        {
            List<StaffManager> StaffManagerList = new List<StaffManager>();
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Trim('[', ']').Split('%');
                StaffManager Staff = new StaffManager();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0])
                        {
                            case "Staff":
                                Staff.StaffID = keyValue[1];
                                break;
                            case "Level":
                                Staff.Level = keyValue[1];
                                break;
                            case "FirstName":
                                Staff.FirstName = keyValue[1];
                                break;
                            case "LastName":
                                Staff.LastName = keyValue[1];
                                break;
                        }
                    }
                }
                StaffManagerList.Add(Staff);
            }
            return StaffManagerList;
        }
    }
}
