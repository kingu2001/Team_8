using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Models
{
    public class Customer
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Email},{PhoneNumber}";
        }
    }
}
