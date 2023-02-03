using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Models;

namespace TheMovies.Repositories
{
    public class DataHandler
    {
        public string OrderFilename { get; } = "orderdata.csv";
        public string CustomerFilename { get; } = "customerdata.csv";


        public void Save(Order order)
        {
            using (StreamWriter sw = new(OrderFilename))
            {
                
            }
        }

        public void Save(Customer customer)
        {

        }
    }
}
