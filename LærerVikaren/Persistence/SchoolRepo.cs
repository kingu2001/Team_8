using LærerVikaren.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Persistence
{
    internal class SchoolRepo
    {
        private List<School> SchoolRepos = new List<School>();

        string connectionString = "Server=10.56.8.36; database=DB_2023_37; user id=STUDENT_37; password=OPENDB_37;";
        public SchoolRepo()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SCHOOL", con);// WHERE Name = '@Name'", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        School school = new School();
                        school.Name = (dr["Name"].ToString());
                        school.Address = (dr["Address"].ToString());
                        school.PhoneNo = (dr["PhoneNo"].ToString());


                        SchoolRepos.Add(school);
                    }

                }

            }

            // Load all owner data from database via SQL statements and populate owner repository

            // IMPLEMENT THIS!
        }

        public int Add(School school)
        {
            // Add new owner to database and to repository
            // Return the database id of the owner
            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO School (Name, Address, PhoneNo) VALUES (@ID, @Address, @PhoneNo)", con);
                cmd.Parameters.Add("@Name", SqlDbType.Int).Value = school.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = school.Name;
                cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar).Value = school.PhoneNo;
                result = int.Parse(cmd.ExecuteScalar().ToString());
            }


            // IMPLEMENT THIS!

            return result;
        }
        public List<School> GetAll()
        {
            // Retrieve all schools from database

            List<School> result = SchoolRepos;

            // IMPLEMENT THIS!

            return result;
        }
        public School GetById(string Name)
        {
            // Get school by name from database
            School School = SchoolRepos.Find(School => School.Name == Name);



            // IMPLEMENT THIS!

            return School;
        }
        public void Update(School School)
        {
            // Update existing school name on database

            // IMPLEMENT THIS!
            School newSchool = SchoolRepos.Find(newNewSchool => newNewSchool.Name == School.Name);
            SchoolRepos.Remove(newSchool);
            SchoolRepos.Add(School);
        }
        public void Remove(School school)
        {
            // Delete existing school in database

            // IMPLEMENT THIS!
            SchoolRepos.Remove(school);
        }
    }
}
