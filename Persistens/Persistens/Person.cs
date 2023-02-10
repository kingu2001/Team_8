using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Persistens
{
    public class Person
    {
        private string name;
        private DateTime birthdate;
        private double height;
        private bool isMarried;
        private int noOfChildren; 

        public string Name
        {
            get { 
                return name; 
            }
            set {
                name = value;
                if (name == "")
                {
                    throw new Exception("Hej søde ven, du har lavet en fejl:)");
                }
            }
        }
        public DateTime BirthDate
        {
            get { 
                return birthdate;
            }
            set { 
                birthdate = value;
                DateTime dt = new DateTime(1900, 1, 1);
                dt.ToShortDateString();
                if (birthdate <= dt)
                {
                   throw new Exception("Hej søde ven, du har lavet en fejl:)");
                }
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                if(height <= 0)
                {
                    throw new Exception("Hej søde ven, du har lavet en fejl:)");
                }
            }
        }

        public bool IsMarried
        {
            get { return isMarried; }
            set
            {
                isMarried = value;
            }
        }

        public int NoOfChildren
        {
            get { return noOfChildren; }
            set
            {
                noOfChildren = value;
                if(noOfChildren < 0)
                {
                    throw new Exception("Hej søde ven, du har lavet en fejl:)");
                }
            }
        }
        
       


        public Person(string name, DateTime birthDate, double height, bool isMarried, int noOfChildren)
        {
            Name = name;
            BirthDate = birthDate;
            Height = height;
            IsMarried = isMarried;
            NoOfChildren = noOfChildren;


        }

        public Person(string name, DateTime birthDate, double height, bool isMarried)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Height = height;
            this.IsMarried = isMarried;
            noOfChildren = 0; 
        }
        

        public string MakeTitle()
        {
            string title = ($"{Name};{BirthDate.ToString(("dd-MM-yyyy HH':'mm':'ss"))};{Height};{IsMarried};{NoOfChildren}");
            return title; 
           
        }

        public Person()
        {

        }
    }
}
