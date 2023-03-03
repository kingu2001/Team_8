using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class TempHour
    {

		Availability date; 
		School school;
		Course name; 
		private DateTime _hour;
		

		public DateTime Hour
		{
			get { return _hour; }
			set { _hour = value; }
		}

		public TempHour(DateTime date, DateTime hour)
		{
			Hour = hour;
			this.date = new Availability(date);
			this.school = new School();
			this.name = new Course();
		}

		public override string ToString()
		{
			return $"{Hour}:{date}:{school}:{name}";
		}



	}
}
