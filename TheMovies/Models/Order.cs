using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override string ToString()
        {
            return $"{Customer}:{Movie}:{Location}:{Playtime}:{AmountOfTickets}:{OrderNumber}";
        }
    }
}
