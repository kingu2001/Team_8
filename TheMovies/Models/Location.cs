using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Models
{
    public class Location
    {
        public string City { get; set; }

        public Location(string city)
        {
            City = city;
        }


        public override string ToString()
        {
            return City;
        }
    }
}
