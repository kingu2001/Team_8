using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Models
{
    public class Order
    {
        public Customer c { get; set; }
        public Movie m { get; set; }
        public Location l { get; set; }
        public Playtime p { get; set; }
        public int AmountOfTickets { get; set; }
        public int OrderNumber { get; set; }
    }
}
