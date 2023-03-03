using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class School
    {
		private string _name;
		private string _address;
		private string _phoneNo;

		public string PhoneNo
		{
			get { return _phoneNo; }
			set { _phoneNo = value; }
		}


		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}


		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

	}
}
