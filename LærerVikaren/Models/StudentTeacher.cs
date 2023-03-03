using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class StudentTeacher
    {
		private string _name;
		private string _phoneNo;
		private string _ssNo;
		private string _certificate;

		public string Certificate
		{
			get { return _certificate; }
			set { _certificate = value; }
		}


		public string SSNo
		{
			get { return _ssNo; }
			set { _ssNo = value; }
		}


		public string PhoneNo
		{
			get { return _phoneNo; }
			set { _phoneNo = value; }
		}


		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public StudentTeacher(string name, string phoneNo, string ssNo, string certificate)
		{
			name = Name;
			phoneNo = PhoneNo;
			ssNo = SSNo;
			certificate = Certificate; 
		}


	}
}
