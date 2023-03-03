using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Models
{
    public class Course
    {
      List<String> courses;
        
        public Course()
        {
            courses = new List<String>() {
            "Dansk",
            "Engelsk",
            "Fysik",
            "Matematik",
            "tysk"
            };
        }
        
    }
}
