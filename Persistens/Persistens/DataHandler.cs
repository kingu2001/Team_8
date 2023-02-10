using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistens
{
    public class DataHandler
    {
        private string connectionString = "Server=10.56.8.36;Database=DB_2023_27;User Id=STUDENT_27;Password=OPENDB_27;";

        private string name;
        private DateTime birthdate;
        private double height;
        private bool isMarried;
        private int noOfChildren;

        public Person LoadPerson()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Name, Birthdate, Height, IsMarried, NoOfChildren FROM Persons", con);// WHERE Name = '@Name'", con);
                //cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                Person person = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        person = new Person();
                        person.Name = dr["Name"].ToString();
                        person.BirthDate = DateTime.Parse(dr["Birthdate"].ToString());
                        person.Height = double.Parse(dr["Height"].ToString());
                        person.IsMarried = bool.Parse(dr["IsMarried"].ToString());
                        person.NoOfChildren = int.Parse(dr["NoOfChildren"].ToString());

                    }
                }
                return person;
            }
        }


        public void SavePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Persons (Name, Birthdate, Height, IsMarried, NoOfChildren) VALUES (@Name, @Birthdate, @Height, @IsMarried, @NoOfChildren)", con);

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = person.Name;
                cmd.Parameters.Add("@Birthdate", SqlDbType.DateTime2).Value = person.BirthDate;
                cmd.Parameters.Add("@Height", SqlDbType.Float).Value = person.Height;
                cmd.Parameters.Add("@IsMarried", SqlDbType.Bit).Value = person.IsMarried;
                cmd.Parameters.Add("@NoOfChildren", SqlDbType.Int).Value = person.NoOfChildren;


                cmd.ExecuteScalar();


            }
        }


        public void CreateTable()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("CREATE TABLE Persons (Name NvarChar(50), Birthdate DateTime2, Height float, IsMarried bit, NoOfChildren Int)", con);

                cmd.ExecuteScalar();
            }
        }






        //public Person LoadPerson()
        //{
        //    using (StreamReader sr = new StreamReader(DataFileName))
        //    {
        //        string line = sr.ReadLine();
        //        string[] data = line.Split(";");
        //        Person person = new Person(data[0], DateTime.Parse(data[1]), double.Parse(data[2]), bool.Parse(data[3]), int.Parse(data[4]));
        //        return person;
        //    }
            

        //}

        
        //public void SavePersons(Person[] persons)
        //{
        //    using (StreamWriter sw = new StreamWriter(DataFileName))
        //    {

        //        for (int i = 0; i < persons.Length; i++)
        //        {

        //            sw.WriteLine(persons[i].MakeTitle());
        //        }

        //    }

        //}

        //public Person[] LoadPersons()
        //{
        //    using (StreamReader sr = new StreamReader(DataFileName))
        //    {
        //        string text;
        //        Person[] persons = new Person[10];
        //        int count = 0;

        //        while ((text = sr.ReadLine()) != null)
        //        {
        //            string[] data = text.Split(";", StringSplitOptions.RemoveEmptyEntries);
        //            persons[count] = new Person(data[0], DateTime.Parse(data[1]), double.Parse(data[2]), bool.Parse(data[3]), int.Parse(data[4]));
        //            count++;
        //        }
        //        return persons;
             
        //    }
            
           

        //}
    }
}
