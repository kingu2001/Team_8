using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Models
{
    public class Playtime
    {
        public DateTime Time { get; set; }

        public Playtime(DateTime time)
        {
            Time = time;
        }

        public override string ToString()
        {
            return Time.ToString();
         
        }
    }
}
