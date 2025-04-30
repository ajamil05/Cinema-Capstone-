using Capstone.Cinema_features.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus.MemberShip_Classes
{
    class GoldMemberSelectMenuItem : ConsoleMenu
    {
        private string filepath = $@"{Environment.CurrentDirectory}\Resources\Membership.txt";

        private string path = $@"{Environment.CurrentDirectory}\Resources\Transaction.txt";

        private MemberShipParser.MembershipData Gold; 
        public GoldMemberSelectMenuItem(MemberShipParser.MembershipData membership)
        {
            Gold = membership;
        }
        public override void CreateMenuItems()
        {
            
        }
        public override string MenuTitleText()
        {
            return $"{Gold.MemberID} - {Gold.Firstname} {Gold.Lastname} {Gold.Email} {Gold.Member} {Gold.Visted}";
        }

        public override void PostProcess()
        {
            // Generating a Membership End Date And Current Date
            var Day = DateTime.Now.Day;

            var Month = DateTime.Now.Month;

            var Year = DateTime.Now.Year + 1;

            string MembershipEndDate = $"{Day}.{Month}.{Year}";

            string currentDate = DateTime.Now.ToString("yyyy/MM/dd");

            // Read existing data from the file
            var existingData = File.Exists(filepath) ? File.ReadAllLines(filepath) : Array.Empty<string>();

            var ExistingData = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();

            // Prepare the new data to write
            string newdata = $"[MemberID:{Gold.MemberID}%Firstname:{Gold.Firstname}%Lastname:{Gold.Lastname}%Email:{Gold.Email}%Member:Gold%MemberShipEndDate:{MembershipEndDate}%Visted:{Gold.Visted}]";

            string NewData = $"{Gold.Firstname} {Gold.Lastname} ({Gold.Member})"; 

            // Check if the data already exists
            if (!existingData.Contains(newdata))
            {
                // Append the new data only if it doesn't already exist
                using (StreamWriter streamWriter = new StreamWriter(filepath, true))
                {
                    streamWriter.WriteLine(newdata);

                    if (MembershipEndDate == currentDate)
                    {
                        streamWriter.WriteLine($"[MemberID:{Gold.MemberID}%Firstname:{Gold.Firstname}%Lastname:{Gold.Lastname}%Email:{Gold.Email}%Member:Loyality%Visted:{Gold.Visted}]");
                    }
                }
            }
            // Check if the data already exists
            if (!ExistingData.Contains(NewData))
            {
                // Append the new data only if it doesn't already exist
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.WriteLine(NewData);
                }
            }
        }
    }
}
