using Capstone.Cinema_features;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    class TicketMenuItem : MenuItem
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        private ExampleSumObject _totalSum;
        private List<MovieParse.MovieData> Movies;
        private List<TicketParse.TicketData> Tickets;
        public TicketMenuItem(ref ExampleSumObject total, int min, int max)
        {
            if (min > max) { throw new Exception($"minimum value {min} cannot be greater than maximum value {max}."); }
            Movies = MovieParse.GetMovies();
            Tickets = TicketParse.GetTickets();
            Min = min;
            Max = max;
            _totalSum = total;
        }
        public override string MenuText()
        {
            return "Ticket";
        }
        public override void Select()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            _menuItems.Add(new ExitMenuItem(_ParentMenu));
            for (int i = 0; i < Movies.Count; i++)
            {
                stringBuilder.AppendLine($"{i + 1}. Movie:{Movies[i].Movie} Length:{Movies[i].Length} Genre:{Movies[i].Genre} Rating:{Movies[i].Rating}");
            }
            for (int j = 0; j < _menuItems.Count; j++)
            {
                stringBuilder.AppendLine($"{5 + 1}. {_menuItems[j].MenuText()}");
            }
            Console.WriteLine(stringBuilder.ToString());
            int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose a Movie To Watch");
            _totalSum.AddToSum(valueToAdd);
            for (int i = 0; i < Tickets.Count; i++)
            {
                sb.AppendLine($"{i + 1}. Ticket:{Tickets[i].Tickettype} Price:{Tickets[i].Price}");
            }
            for (int i = 0; i < _menuItems.Count; i++)
            {
                sb.AppendLine($"{3}. {_menuItems[i].MenuText()}");
            }
            Console.WriteLine(sb.ToString());
            valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Choose a Ticket Type");
            _totalSum.AddToSum(valueToAdd);
        }
    }
}

