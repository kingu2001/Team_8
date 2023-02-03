using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using TheMovies.Models;

namespace TheMovies.Repositories
{
    public class DataHandler
    {
        public string OrderFilename { get; } = "orderdata.csv";
        public string CustomerFilename { get; } = "customerdata.csv";
        private int indexBookingMail,indexPhoneNumber,indexBio, indexBy, indexPremiere, indexForestillingstidspunkt, indexTitle, indexFilmVarihed, indexFilmInstruktor, indexGenre;
        private string[] data;
        private char start = Convert.ToChar("0");
        //public void Save(Order order)
        //{
        //    using (StreamWriter sw = new(OrderFilename))
        //    {

        //    }
        //}

        //public void Save(Customer customer)
        //{

        //}

        public void findIndex()
        {
            using (StreamReader sr = new StreamReader(CustomerFilename))
            {
               
                    string line = sr.ReadLine();
                    if (line.StartsWith("Biograf"))
                    {
                        data = line.Split(';');
                    }
                for (int i = 0; i < data.Length; i++)
                {
                    switch (data[i])
                    {
                        case "Bookingmail":
                            indexBookingMail = i; break;
                        case "Biograf":
                            indexBio = i; break;
                        case "Forestillingstidspunkt":
                            indexForestillingstidspunkt = i; break;
                        case "Bookingtelefonnummer":
                            indexPhoneNumber = i; break;
                        case "Premieredato":
                            indexPremiere = i; break;
                        case "By":
                            indexBy = i; break;
                        case "Filmvarighed":
                            indexFilmVarihed = i; break;
                        case "Filmgenre":
                            indexGenre = i; break;
                        case "Filminstruktør":
                            indexFilmInstruktor = i; break;
                        case "Filmtitel":
                            indexTitle = i; break;
                    }
                }
                    
        } 

        }

        public void Load(Order order)
        {
            using(StreamReader sr = new StreamReader(OrderFilename))
            {

            }
        }
        public List<Order> Load()
        {
            List<Order> list = new List<Order>();
            findIndex();
            using(StreamReader sr = new StreamReader(CustomerFilename))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!line.StartsWith("Biograf"))
                    {
                        string[] data = line.Split(';');
                        Customer c = new Customer (data[indexBookingMail], data[indexPhoneNumber] );
                        Movie m = new Movie(data[indexTitle], TimeSpan.Parse(data[indexFilmVarihed].TrimStart(start)), data[indexFilmInstruktor], DateTime.Parse(data[indexPremiere]), data[indexGenre]);
                        Playtime p = new Playtime(DateTime.Parse(data[indexForestillingstidspunkt]));
                        Location l = new Location(data[indexBy]);
                        Order o = new Order(c,m, l,p,1);
                        list.Add(o);
                        }
                  
                }
            }
            return list;
        }
    }
}
