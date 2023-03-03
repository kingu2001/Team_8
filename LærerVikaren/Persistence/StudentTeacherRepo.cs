using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LærerVikaren.Models;
namespace LærerVikaren.Persistence
{
    internal class StudentTeacherRepo
    {
        private Dictionary<int,StudentTeacher> studentTeachers = new Dictionary<int, StudentTeacher>();

        string connectionString = "Server=10.56.8.36; database=DB_2023_37; user id=STUDENT_37; password=OPENDB_37;";
        public StudentTeacherRepo()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LS", con);// WHERE Name = '@Name'", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        StudentTeacher studentTeacher = new StudentTeacher();
                        studentTeacher.Name = (dr["Name"].ToString());
                        studentTeacher.PhoneNo = (dr["PhoneNo"].ToString());
                        studentTeacher.SSNo = (dr["SSNo"].ToString());
                        studentTeacher.Certificate = (dr["Certificate"].ToString());


                        studentTeachers.Add(int.Parse(dr["ID"].ToString()), studentTeacher);
                    }

                }

            }

            // Load all owner data from database via SQL statements and populate owner repository

            // IMPLEMENT THIS!
        }

        public int Add(StudentTeacher studentTeacher)
        {
            // Add new owner to database and to repository
            // Return the database id of the owner
            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO LS (ID, Name, PhoneNo, SSNo, Certificate) VALUES (@ID, @Name, @PhoneNo, @SSNo, @Certificate)", con);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = studentTeacher.ID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = studentTeacher.Name;
                cmd.Parameters.Add("@OwnerLastName", SqlDbType.NVarChar).Value = studentTeacher.PhoneNo;
                cmd.Parameters.Add("@OwnerPhone", SqlDbType.NVarChar).Value = studentTeacher.SSNo;
                cmd.Parameters.Add("@OwnerEmail", SqlDbType.NVarChar).Value = studentTeacher.Certificate;
                result = int.Parse(cmd.ExecuteScalar().ToString());
            }


            // IMPLEMENT THIS!

            return result;
        }
        public List<StudentTeacher> GetAll()
        {
            // Retrieve all owners from database

            List<StudentTeacher> result = studentTeachers;

            // IMPLEMENT THIS!

            return result;
        }
        public StudentTeacher GetById(int id)
        {
            // Get owner by id from database
            StudentTeacher studentTeacher = studentTeachers.Find(studentTeacher => studentTeacher.ID == id);



            // IMPLEMENT THIS!

            return studentTeacher;
        }
        public void Update(StudentTeacher studentTeacher)
        {
            // Update existing owner on database

            // IMPLEMENT THIS!
            StudentTeacher newstudentTeacher = studentTeachers.Find(newNewStudentTeacher => newNewStudentTeacher.ID == studentTeacher.ID);
            studentTeachers.Remove(newstudentTeacher);
            studentTeachers.Add(studentTeacher);
        }
        public void Remove(StudentTeacher studentTeacher)
        {
            // Delete existing owner in database

            // IMPLEMENT THIS!
            studentTeachers.Remove(studentTeacher);
        }
    }
}
