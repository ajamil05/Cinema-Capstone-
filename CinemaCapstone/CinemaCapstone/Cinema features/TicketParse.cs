using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Capstone.Menus.MenuItem;

namespace Capstone.Menus
{
    public static class TicketParse
    {
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Ticket.txt";
        public struct TicketData
        {
            public string Tickettype;
            public int Price;
        }
        public static List<TicketData> GetTickets()
        {
            
            List<TicketData> ticketDataList = new List<TicketData>();

            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Trim('[', ']').Split('%');
                TicketData ticketData = new TicketData();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0])
                        {
                            case "Ticket":
                                ticketData.Tickettype = keyValue[1];
                                break;
                            case "Price":
                                ticketData.Price = int.Parse(keyValue[1]);
                                break;
                        }
                    }
                }
                ticketDataList.Add(ticketData);
            }
            return ticketDataList;
        }
    }
}
        
