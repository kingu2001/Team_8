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
		private int _A_ID;
		private int _FK_LS;

		public int FK_LS
		{
			get { return _FK_LS; }
			set { _FK_LS = value; }
		}


		public int A_ID
		{
			get { return _A_ID; }
			set { _A_ID = value; }
		}


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
