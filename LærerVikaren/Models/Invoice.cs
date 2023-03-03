using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class Invoice
    {
		private int _number;
		private DateTime _invoiceDate;
		private int _fk_tempHour;

		public int Fk_TempHour
		{
			get { return _fk_tempHour; }
			set { _fk_tempHour = value; }
		}


		public DateTime InvoiceDate
		{
			get { return _invoiceDate; }
			set { _invoiceDate = value; }
		}


		public int Number
		{
			get { return _number; }
			set { _number = value; }
		}

		public override string ToString()
		{
			return $"{Number}:{InvoiceDate}";
		}

	}
}
