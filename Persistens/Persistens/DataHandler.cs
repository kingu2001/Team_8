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

        public Person LoadPerson(string name)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"SELECT Name, Birthdate, Height, IsMarried, NoOfChildren FROM Persons WHERE Name = {name}", con);// WHERE Name = '@Name'", con);
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
    }
}
