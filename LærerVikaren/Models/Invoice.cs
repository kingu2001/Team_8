using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class Invoice
    {
		private string _number;
		private DateTime _invoiceDate;

		public DateTime InvoiceDate
		{
			get { return _invoiceDate; }
			set { _invoiceDate = value; }
		}


		public string Number
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
