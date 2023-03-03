using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class Availability
    {
		private DateTime _date;
	
		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public Availability(DateTime date)
		{
			date = Date;
		}

		public override string ToString()
		{
			return $"{Date}";
		}

	}
}
