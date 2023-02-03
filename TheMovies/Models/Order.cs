using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TheMovies.Models
{
    public class Order
    {
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public Location Location { get; set; }
        public Playtime Playtime { get; set; }
        public int AmountOfTickets { get; set; }
        public int OrderNumber { get; set; }
        private static int count=0;
        public Order(Customer c, Movie m, Location l, Playtime p, int tickets)
        {
            Customer = c;
            Movie = m;
            Location = l;
            Playtime = p;
            AmountOfTickets = tickets;
            OrderNumber= ++count;
        }

        public override string ToString()
        {
            return $"{Location},{Playtime},{Movie},{Customer},{AmountOfTickets},{OrderNumber}";
        }
    }
}
