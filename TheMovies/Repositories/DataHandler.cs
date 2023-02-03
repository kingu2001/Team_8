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


        //public void Save(Order order)
        //{
        //    using (StreamWriter sw = new(OrderFilename))
        //    {
                
        //    }
        //}

        //public void Save(Customer customer)
        //{

        //}

        public void Load(Order order)
        {
            using(StreamReader sr = new StreamReader(OrderFilename))
            {

            }
        }
        public void Load(Customer customer)
        {
            using(StreamReader sr = new StreamReader(CustomerFilename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!line.StartsWith("Biograf"))
                    {
                        string[] data = line.Split(',');
                    }
                }
            }
        }
    }
}
