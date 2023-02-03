using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Models
{
    public class Order
    {
        public Customer customer { get; set; }
        public Movie movie { get; set; }
        public Location location { get; set; }
        public Playtime playtime { get; set; }
        public int AmountOfTickets { get; set; }
        public int OrderNumber { get; set; }

        public override string ToString()
        {
            return $"{customer}:{movie}:{location}:{playtime}:{AmountOfTickets}:{OrderNumber}";
        }
    }
}
