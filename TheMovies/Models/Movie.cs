using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Director { get; set; }
        public DateTime Premiere { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"{Title},{Duration},{Genre},{Director},{Premiere}";
        }
    }
}
